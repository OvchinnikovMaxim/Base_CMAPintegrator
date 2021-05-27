using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace CMAPIntegrator
{
    /// <summary>
    /// Запросы для работы с базой данных MAP
    /// </summary>
    public class MAPquerys
    {
		/// <summary>
		/// Создание объекта класса текстов запросов
		/// </summary>
		Querys_text qT = new Querys_text();

		/// <summary>
		/// создание объекта класса запросов в КИС
		/// </summary>
		KISquerys KISq = new KISquerys();

		/// <summary>
		/// создание объекта класса для логирования
		/// </summary>
		Logging l = new Logging();

        #region для остатков
        /// <summary>
        /// Очистка таблицы с имеющимися остатками
        /// </summary>
        /// <param name="con">подключение к МАП</param>
        public void delRES(FbConnection con, RichTextBox richText)
        {
            l.LOG("Загрузка остатков в МАР: " + DateTime.Now.ToString() + '\n' + "-------------------------", richText);

            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //создание транзакции
            FbTransaction trans = con.BeginTransaction();
            FbCommand DEL_CURRENT_RES = new FbCommand("DELETE FROM MT_CURRENT_RES_DISTR", con, trans);
            DEL_CURRENT_RES.ExecuteNonQuery();
            trans.Commit();
        }

        /// <summary>
        /// Выгрузка остатков в МАР
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="con">подключение к МАП</param>
        /// <param name="KIScon">подключение к КИС</param>
        /// <param name="richText">Поле для логирования</param>
        public void loadRES(string query, FbConnection con, FbConnection KIScon, RichTextBox richText, CheckBox check, ProgressBar progress)
        {
            //создание транзакции
            FbTransaction trans = con.BeginTransaction();

            //запрос таблицы с остатками из КИС
            FbDataReader reader = KISq.getRES(query, KIScon);

            //вызов процедуры базы СМАР с транзакцией
            FbCommand exec_MT_SET_CURRENT_RES2 = new FbCommand("MT_SET_CURRENT_RES2", con, trans);

            //указываем что используем процедуру
            exec_MT_SET_CURRENT_RES2.CommandType = CommandType.StoredProcedure;

            //входные параметры процедуры
            exec_MT_SET_CURRENT_RES2.Parameters.Add("rdistrobj", FbDbType.VarChar); //код товара в КИС
            exec_MT_SET_CURRENT_RES2.Parameters.Add("vamount", FbDbType.Integer); //количество товара на остатках, шт
            exec_MT_SET_CURRENT_RES2.Parameters.Add("rscl", FbDbType.Integer); //код склада (0 – основной склад)

            //выходной параметр процедуры
            exec_MT_SET_CURRENT_RES2.Parameters.Add("result", FbDbType.Integer).Direction = ParameterDirection.Output;

            int ins = 0; //количество новых строк
            int res = 0; //количество не добавленных строк

            int countOst = KISq.countOstKIS(qT.countOST, KIScon);

            progress.Invoke(new ProgressCountDelegate(ProgressCount), progress, countOst);

            progress.Invoke(new ProgressValueDelegate(ProgressValue), progress);

            //чтение полученных данных
            while (reader.Read())
            {
                //заполнение параметров процедуры
                exec_MT_SET_CURRENT_RES2.Parameters["rdistrobj"].Value = reader["robj"].ToString();
                exec_MT_SET_CURRENT_RES2.Parameters["vamount"].Value = reader["vcnt"];
                exec_MT_SET_CURRENT_RES2.Parameters["rscl"].Value = reader["rscl"];
                exec_MT_SET_CURRENT_RES2.ExecuteNonQuery(); // выполнение процедуры

                if (exec_MT_SET_CURRENT_RES2.Parameters["result"].Value.ToString() == "-1" ||
                    exec_MT_SET_CURRENT_RES2.Parameters["result"].Value.ToString() == "1")
                {
                    ins++;
                    if (check.Checked)
                        l.LOG("Остаток по позиции номенклатуры " + reader["robj"].ToString() + " - выгружен", richText);
                }
                else
                {
                    res++;
                    if (check.Checked)
                        l.LOG("На строке с идентификатором " + reader["kid"].ToString() + " отсутствует кодпродукции. Остатки по этой позиции не выгружены", richText);
                }

                progress.Invoke(new ProgressStepDelegate(ProgressStep), progress);

            }
            trans.Commit();

            l.LOG("Выгружено - " + ins.ToString() + ". Не удалось выгрузить - " + res.ToString() + '\n' + DateTime.Now.ToString(), richText);

            l.LOG("=========================" + '\n', richText);
        } 
        #endregion

        /// <summary>
        /// Загрузка заказов из МАП в КИС
        /// </summary>
        /// <param name="bdate">Начало периода</param>
        /// <param name="edate">Конец периода</param>
        /// <param name="con">подключение к МАП</param>
        /// <param name="KIScon">подключение к КИС</param>
        /// <param name="richText">Поле для логирования</param>
        public void MT_GET_ORDERS(DateTime bdate, DateTime edate, FbConnection con, FbConnection KIScon, RichTextBox richText, ProgressBar progress)
        {
			l.LOG("Загрузка заказов в КИС: " + DateTime.Now.ToString() + '\n' + "-------------------------", richText);

            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //создание транзакции
            FbTransaction trans = con.BeginTransaction();

			//вызов процедуры базы СМАР с транзакцией для выбора заказов для загрузки
			FbCommand exec_MT_GET_ORDERS = new FbCommand("MT_GET_ORDERS", con, trans);

			//указываем что используем процедуру
			exec_MT_GET_ORDERS.CommandType = CommandType.StoredProcedure;

			//входные параметры процедуры
			exec_MT_GET_ORDERS.Parameters.Add("bdate", FbDbType.Date);
			exec_MT_GET_ORDERS.Parameters.Add("edate", FbDbType.Date);

			//заполнение параметров процедуры
			exec_MT_GET_ORDERS.Parameters["bdate"].Value = bdate.ToShortDateString();
			exec_MT_GET_ORDERS.Parameters["edate"].Value = edate.ToShortDateString();

			#region выходные параметры процедуры
			exec_MT_GET_ORDERS.Parameters.Add("master_kid", FbDbType.Integer).Direction = ParameterDirection.Output;//внутренний код заявки в map
            exec_MT_GET_ORDERS.Parameters.Add("vdate", FbDbType.Date).Direction = ParameterDirection.Output;//дата заявки
            exec_MT_GET_ORDERS.Parameters.Add("vshipping_date", FbDbType.Date).Direction = ParameterDirection.Output;//дата доставки
            exec_MT_GET_ORDERS.Parameters.Add("vdiscont", FbDbType.Numeric).Direction = ParameterDirection.Output;//скидка, %
            exec_MT_GET_ORDERS.Parameters.Add("nid", FbDbType.VarChar).Direction = ParameterDirection.Output;//внутренний код клиента в map
            exec_MT_GET_ORDERS.Parameters.Add("vnum", FbDbType.VarChar).Direction = ParameterDirection.Output; //код клиента в КИС
            exec_MT_GET_ORDERS.Parameters.Add("vrem", FbDbType.VarChar).Direction = ParameterDirection.Output; //комментарии к заказу
            exec_MT_GET_ORDERS.Parameters.Add("robj", FbDbType.Char).Direction = ParameterDirection.Output; //внутренний код продукции в MAP
            exec_MT_GET_ORDERS.Parameters.Add("vdistr_obj", FbDbType.VarChar).Direction = ParameterDirection.Output; //код продукции в КИС
            exec_MT_GET_ORDERS.Parameters.Add("vamount", FbDbType.Integer).Direction = ParameterDirection.Output; //количество
            exec_MT_GET_ORDERS.Parameters.Add("vcost_rub", FbDbType.Numeric).Direction = ParameterDirection.Output; //цена в рублях
            exec_MT_GET_ORDERS.Parameters.Add("vsum_rub", FbDbType.Numeric).Direction = ParameterDirection.Output; //сумма в рублях со скидкой
            exec_MT_GET_ORDERS.Parameters.Add("ftype", FbDbType.Numeric).Direction = ParameterDirection.Output; //тип позиции (1– бонус, 0 – не бонус)   
            #endregion

			// таблица с данными по заказам
            FbDataReader reader = exec_MT_GET_ORDERS.ExecuteReader();

			int countOrders = Convert.ToInt32(new FbCommand("SELECT COUNT(master_kid) FROM mt_docs WHERE rstate=2 AND rdoc_type=1 AND vdate BETWEEN '" + bdate.ToShortDateString() + "' AND '" + edate.ToShortDateString() + "'", con, trans).ExecuteScalar());

			progress.Invoke(new ProgressCountDelegate(ProgressCount), progress, countOrders);

			progress.Invoke(new ProgressValueDelegate(ProgressValue), progress);

			//массив с количеством загруженных шапок, количеством обновленных шапок, количеством загруженных деталей, количеством обновленных деталей
			int[] res = { 0, 0, 0, 0 };

			//чтение полученных данных
			while (reader.Read())
            {
				#region присвоение локальным переменным значений выходных параметров процедур
				int master_kid = Convert.ToInt32(reader["master_kid"]);
                string vdate = reader["vdate"].ToString();
                string vshipping_date = reader["vshipping_date"].ToString();

                int vdiscont = String.IsNullOrWhiteSpace(reader["vdiscont"].ToString()) ? 0 : Convert.ToInt32(reader["vdiscont"]);

                string vnum = reader["vnum"].ToString();
                string vrem = reader["vrem"].ToString();
                string vdistr_obj = reader["vdistr_obj"].ToString();
                int vamount = Convert.ToInt32(reader["vamount"]);
                double vcost_rub = Convert.ToDouble(reader["vcost_rub"].ToString());
                double vsum_rub = Convert.ToDouble(reader["vsum_rub"].ToString());
                int ftype = Convert.ToInt32(reader["ftype"]);
				#endregion

				string[] r = KISq.loadZakaz(KIScon, bdate, edate,
					master_kid, vdate, vshipping_date, vdiscont, vnum, vrem,
					vdistr_obj, vamount, vcost_rub, vsum_rub, ftype);

				res[0] += Convert.ToInt32(r[0]);
				res[1] += Convert.ToInt32(r[1]);
				res[2] += Convert.ToInt32(r[2]); //Добавлены позиций в заказы 
				res[3] += Convert.ToInt32(r[3]); //Обновлено позиций в заказах

				// изменение статуса на "отправлен в КИС" и присвиение внутреннего ID из КИС
				FbCommand did_map = new FbCommand("UPDATE mt_docs SET rstate = 5,  did='" + r[4] + "' WHERE master_kid=" + master_kid, con, trans);
				did_map.ExecuteNonQuery();

				progress.Invoke(new ProgressStepDelegate(ProgressStep), progress);
			}
			
			trans.Commit();

			l.LOG(/*"Загружено заказов - "+ res[0].ToString()+". Обновлено заказов - "+ res[1].ToString()+'\n' + "----------------------------"+'\n'+*/ "Добавлены позиций в заказы - " + res[2].ToString() + ". Обновлено позиций в заказах - " + res[3].ToString() + '\n' + DateTime.Now.ToString(), richText);

			l.LOG("=========================" + '\n', richText);
		}

        #region для накладных
        /// <summary>
        /// для пометки всех накладных за период как неподтвержденные 
        /// </summary>
        /// <param name="bdate">начало периода</param>
        /// <param name="edate">конец периода</param>
        /// <param name="con">подключение к МАП</param>
        public void MT_DROP_DOC_ACTUAL(DateTime bdate, DateTime edate, FbConnection con, RichTextBox richText)
        {
            l.LOG("Загрузка накладных в МАР: " + DateTime.Now.ToString() + '\n' + "-------------------------", richText);

            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //создание транзакции
            FbTransaction trans = con.BeginTransaction();

            //вызов процедуры базы СМАР с транзакцией
            FbCommand exec_MT_DROP_DOC_ACTUAL = new FbCommand("MT_DROP_DOC_ACTUAL", con, trans);

            //указываем что используем процедуру
            exec_MT_DROP_DOC_ACTUAL.CommandType = CommandType.StoredProcedure;

            //входные параметры процедуры
            exec_MT_DROP_DOC_ACTUAL.Parameters.Add("bdate", FbDbType.Date);
            exec_MT_DROP_DOC_ACTUAL.Parameters.Add("edate", FbDbType.Date);

            //заполнение параметров процедуры
            exec_MT_DROP_DOC_ACTUAL.Parameters["bdate"].Value = bdate.ToShortDateString();
            exec_MT_DROP_DOC_ACTUAL.Parameters["edate"].Value = edate.ToShortDateString();
            exec_MT_DROP_DOC_ACTUAL.ExecuteNonQuery();
            trans.Commit();
        }

        /// <summary>
        /// для пометки как удаленные накладных за период, оставшихся неподтвержденными
        /// </summary>
        /// <param name="bdate">начало периода</param>
        /// <param name="edate">конец периода</param>
        /// <param name="con">подключение к МАП</param>
        public void MT_SET_DOC_DEL2(DateTime bdate, DateTime edate, FbConnection con, RichTextBox richTex)
        {
            //создание транзакции
            FbTransaction trans = con.BeginTransaction();

            //вызов процедуры базы СМАР с транзакцией
            FbCommand exec_MT_SET_DOC_DEL2 = new FbCommand("MT_SET_DOC_DEL2", con, trans);

            //указываем что используем процедуру
            exec_MT_SET_DOC_DEL2.CommandType = CommandType.StoredProcedure;

            //входные параметры процедуры
            exec_MT_SET_DOC_DEL2.Parameters.Add("bdate", FbDbType.Date);
            exec_MT_SET_DOC_DEL2.Parameters.Add("edate", FbDbType.Date);

            //заполнение параметров процедуры
            exec_MT_SET_DOC_DEL2.Parameters["bdate"].Value = bdate.ToShortDateString();
            exec_MT_SET_DOC_DEL2.Parameters["edate"].Value = edate.ToShortDateString();
            exec_MT_SET_DOC_DEL2.ExecuteNonQuery();
            trans.Commit();

            l.LOG("=========================" + '\n', richTex);
        }

        /// <summary>
        /// Выгрузки шапок накладных 
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="bdate">начало периода</param> //возможно не нужно
        /// <param name="edate">конец периода</param> //возможно не нужно
        /// <param name="con">подключение к МАП</param>
        /// <param name="KIScon">подключение к КИС</param>
        /// <param name="richText">Поле для логирования</param>
        public void MT_SET_DOC2(string query, DateTime bdate, DateTime edate, FbConnection con, FbConnection KIScon, RichTextBox richText, CheckBox check, ProgressBar progress)
        {
            //Количество загружаемых накладных 
            int countDOCS = KISq.countDocsKIS(qT.countDocs + " AND vdate BETWEEN '" + bdate.ToShortDateString() + "' AND '" + edate.ToShortDateString() + "'", KIScon);

            progress.Invoke(new ProgressCountDelegate(ProgressCount), progress, countDOCS);

            progress.Invoke(new ProgressValueDelegate(ProgressValue), progress);

            //создание транзакции
            FbTransaction trans = con.BeginTransaction();

            //запрос таблицы с шапками накладных из КИС
            FbDataReader reader = KISq.getDOCS(query, KIScon);

            //вызов процедуры базы СМАР с транзакцией
            FbCommand exec_MT_SET_DOC2 = new FbCommand("MT_SET_DOC2", con, trans);

            //указываем что используем процедуру
            exec_MT_SET_DOC2.CommandType = CommandType.StoredProcedure;
            //exec_MT_SET_DOC2.CommandTimeout = 3600;
            #region входные параметры процедуры
            exec_MT_SET_DOC2.Parameters.Add("guid", FbDbType.VarChar); // (не заполняется)
            exec_MT_SET_DOC2.Parameters.Add("rdoc_type", FbDbType.VarChar); // тип документа (2 - накладная)
            exec_MT_SET_DOC2.Parameters.Add("vdate", FbDbType.VarChar); // дата документа (формат dd.mm.yyyy)
            exec_MT_SET_DOC2.Parameters.Add("vdatecreate", FbDbType.VarChar); // дата создания
            exec_MT_SET_DOC2.Parameters.Add("rscl", FbDbType.VarChar); // код склада (по умолчанию указать 0)
            exec_MT_SET_DOC2.Parameters.Add("vshipping_date", FbDbType.VarChar); // дата доставки
            exec_MT_SET_DOC2.Parameters.Add("vdiscont", FbDbType.VarChar); // скидка в накладной в % (0-100)
            exec_MT_SET_DOC2.Parameters.Add("vrem", FbDbType.VarChar); // примечания
            exec_MT_SET_DOC2.Parameters.Add("nid", FbDbType.VarChar); // (не заполняется)
            exec_MT_SET_DOC2.Parameters.Add("rtp", FbDbType.VarChar); // (не заполняется)
            exec_MT_SET_DOC2.Parameters.Add("vdist_doc_number", FbDbType.VarChar); // номер накладной КИС (ТТН)
            exec_MT_SET_DOC2.Parameters.Add("did", FbDbType.VarChar); // уникальный номер документа в КИС
            exec_MT_SET_DOC2.Parameters.Add("vdist_client_id", FbDbType.VarChar); // код точки в КИС
            exec_MT_SET_DOC2.Parameters.Add("vdistr_payer", FbDbType.VarChar); // код плательщика в КИС
            exec_MT_SET_DOC2.Parameters.Add("rdid", FbDbType.VarChar); // код документа основания в КИС
            exec_MT_SET_DOC2.Parameters.Add("fdel", FbDbType.VarChar); // флаг (1 – документ, помеченный на удаление, 0 - обычный
            exec_MT_SET_DOC2.Parameters.Add("rdoc", FbDbType.Integer); // код заказа MAP, на основании которого создан данный документ (если не на основе заказа из map null) 
            #endregion

            //выходной параметр процедуры
            exec_MT_SET_DOC2.Parameters.Add("result", FbDbType.Integer).Direction = ParameterDirection.Output;

            int upd = 0; //количество обновленных накладных
            int ins = 0; //количество новых накладных
            int res = 0; //количество не добавленных накладных

            //чтение полученных данных
            while (reader.Read())
            {
                #region заполнение параметров процедуры
                //exec_MT_SET_DOC2.Parameters["guid"].Value = "";
                exec_MT_SET_DOC2.Parameters["rdoc_type"].Value = "2";
                exec_MT_SET_DOC2.Parameters["vdate"].Value = reader["vdate"].ToString().Substring(0, 10); //
                exec_MT_SET_DOC2.Parameters["vdatecreate"].Value = reader["vdatecreate"].ToString();
                exec_MT_SET_DOC2.Parameters["rscl"].Value = reader["rscl"].ToString();
                exec_MT_SET_DOC2.Parameters["vshipping_date"].Value = reader["vshipping_date"].ToString().Substring(0, 10); //
                exec_MT_SET_DOC2.Parameters["vdiscont"].Value = reader["vdiscont"].ToString();// или "0"
                exec_MT_SET_DOC2.Parameters["vrem"].Value = reader["vrem"].ToString();
                //exec_MT_SET_DOC2.Parameters["nid"].Value = "";
                //exec_MT_SET_DOC2.Parameters["rtp"].Value = "";
                exec_MT_SET_DOC2.Parameters["vdist_doc_number"].Value = reader["vdist_doc_number"].ToString();
                exec_MT_SET_DOC2.Parameters["did"].Value = reader["did"].ToString();
                exec_MT_SET_DOC2.Parameters["vdist_client_id"].Value = reader["vdist_client_id"].ToString();
                exec_MT_SET_DOC2.Parameters["vdistr_payer"].Value = reader["vdistr_payer"].ToString();
                //vdist_client_id  код точки в КИС и vdistr_payer – код плательщика в КИС – должны совпадать

                exec_MT_SET_DOC2.Parameters["rdid"].Value = reader["did"].ToString();
                exec_MT_SET_DOC2.Parameters["fdel"].Value = "0";
                exec_MT_SET_DOC2.Parameters["rdoc"].Value = 0;//reader["rdoc"]; 
                #endregion

                exec_MT_SET_DOC2.ExecuteNonQuery();

                switch (exec_MT_SET_DOC2.Parameters["result"].Value.ToString())
                {
                    case "1":
                        upd++;
                        if (check.Checked)
                            l.LOG("Документ - " + reader["vdist_doc_number"].ToString() + " - перезаписан", richText);
                        break;
                    case "2":
                        ins++;
                        if (check.Checked)
                            l.LOG("Документ - " + reader["vdist_doc_number"].ToString() + " - добавлен", richText);
                        break;
                    case "-1":
                        res++;
                        if (check.Checked)
                            l.LOG("Документ - " + reader["vdist_doc_number"].ToString() + " - не обработан и не попал в МАР", richText);
                        break;
                }

                progress.Invoke(new ProgressStepDelegate(ProgressStep), progress);
            }

            trans.Commit();

            l.LOG("Обновлено - " + upd.ToString() +
                            ". Добавлено - " + ins.ToString() +
                            ". Не удалось добавить - " + res.ToString() + '\n' + DateTime.Now.ToString(), richText);

            l.LOG("=========================" + '\n', richText);
        }

        /// <summary>
        /// Выгрузка табличной части накладных
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="con">подключение к МАП</param>
        /// <param name="KIScon">подключение к КИС</param>
        /// <param name="richText">Поле для логирования</param>
        public void MT_SET_DETAILS2(string query, DateTime bdate, DateTime edate, FbConnection con, FbConnection KIScon, RichTextBox richText, CheckBox check, ProgressBar progress)
        {
            l.LOG("Выгрузка табличной части накладных в МАП: " + DateTime.Now.ToString() + '\n' + "-------------------------", richText);

            //Количество загружаемых деталей в накладных
            int countDETS = KISq.countDetsKIS(qT.countDetails + " AND vdate BETWEEN '" + bdate.ToShortDateString() + "' AND '" + edate.ToShortDateString() + "')", KIScon);

            progress.Invoke(new ProgressCountDelegate(ProgressCount), progress, countDETS);

            progress.Invoke(new ProgressValueDelegate(ProgressValue), progress);

            //создание транзакции
            FbTransaction trans = con.BeginTransaction();

            //запрос таблицы с шапками накладных из КИС
            FbDataReader reader = KISq.getDETAILS(query, KIScon);

            //вызов процедуры базы СМАР с транзакцией
            FbCommand exec_MT_SET_DETAILS2 = new FbCommand("MT_SET_DETAILS2", con, trans);

            //указываем что используем процедуру
            exec_MT_SET_DETAILS2.CommandType = CommandType.StoredProcedure;
            //exec_MT_SET_DETAILS2.CommandTimeout = 3600;
            #region входные параметры процедуры
            exec_MT_SET_DETAILS2.Parameters.Add("pdid", FbDbType.VarChar); //ссылка на уникальный код шапки документа КИС
            exec_MT_SET_DETAILS2.Parameters.Add("prdobj", FbDbType.VarChar); // код продукции КИС
            exec_MT_SET_DETAILS2.Parameters.Add("pamount", FbDbType.VarChar); // количество, шт.
            exec_MT_SET_DETAILS2.Parameters.Add("pcost", FbDbType.VarChar); // цена за единицу продукции в валюте (не обязательно)
            exec_MT_SET_DETAILS2.Parameters.Add("pcost_rub", FbDbType.VarChar); // цена за единицу продукции в рублях
            exec_MT_SET_DETAILS2.Parameters.Add("psum", FbDbType.VarChar); // сумма в валюте с учетом скидки (не обязательно)
            exec_MT_SET_DETAILS2.Parameters.Add("psum_rub", FbDbType.VarChar); // сумма в рублях с учетом скидки
            exec_MT_SET_DETAILS2.Parameters.Add("ftype", FbDbType.VarChar); // тип позиции (0 – обычная, 1 бонусная) 
            #endregion

            //выходной параметр процедуры
            exec_MT_SET_DETAILS2.Parameters.Add("result", FbDbType.Integer).Direction = ParameterDirection.Output;

            int upd = 0; //количество обновленных строк
            int ins = 0; //количество новых строк
            int res = 0; //количество не добавленных строк

            //чтение полученных данных
            while (reader.Read())
            {
                #region заполнение параметров процедуры
                exec_MT_SET_DETAILS2.Parameters["pdid"].Value = reader["did"].ToString();
                exec_MT_SET_DETAILS2.Parameters["prdobj"].Value = reader["vdistr_obj"].ToString();
                exec_MT_SET_DETAILS2.Parameters["pamount"].Value = reader["vamount"].ToString();
                exec_MT_SET_DETAILS2.Parameters["pcost"].Value = reader["vcost"].ToString().Replace(',', '.');
                exec_MT_SET_DETAILS2.Parameters["pcost_rub"].Value = reader["VCOST_RUB"].ToString().Replace(',', '.');
                exec_MT_SET_DETAILS2.Parameters["psum"].Value = reader["vsum"].ToString().Replace(',', '.');
                exec_MT_SET_DETAILS2.Parameters["psum_rub"].Value = reader["vsum_rub"].ToString().Replace(',', '.');
                exec_MT_SET_DETAILS2.Parameters["ftype"].Value = reader["ftype"].ToString();
                #endregion

                exec_MT_SET_DETAILS2.ExecuteNonQuery();

                switch (exec_MT_SET_DETAILS2.Parameters["result"].Value.ToString())
                {
                    case "2":
                        upd++;
                        if (check.Checked)
                            l.LOG("Товарная позиция с кодом " + reader["vdistr_obj"].ToString() + ", документа " + reader["vdist_doc_number"].ToString() + " - перезаписана", richText);
                        break;
                    case "1":
                        ins++;
                        if (check.Checked)
                            l.LOG("Товарная позиция с кодом " + reader["vdistr_obj"].ToString() + ", документа " + reader["vdist_doc_number"].ToString() + " - добавлена", richText);
                        break;
                    case "-1":
                        res++;
                        if (check.Checked)
                            l.LOG("Товарная позиция с кодом " + reader["vdistr_obj"].ToString() + ", документа " + reader["vdist_doc_number"].ToString() + " - не обработана и не попала в МАР", richText);
                        break;
                }

                progress.Invoke(new ProgressStepDelegate(ProgressStep), progress);
            }
            trans.Commit();

            l.LOG("Обновлено - " + upd.ToString() +
                            ". Добавлено - " + ins.ToString() +
                            ". Не удалось добавить - " + res.ToString() + '\n' + DateTime.Now.ToString(), richText);
        }
        #endregion

        #region для справочников
        /// <summary>
        /// Выгрузка контрагентов
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="con">подключение к МАП</param>
        /// <param name="KIScon">подключение к КИС</param>
        /// <param name="richText">Поле для логирования</param>
        public void MT_SET_CLN(string query, FbConnection con, FbConnection KIScon, RichTextBox richText, CheckBox check, ProgressBar progress)
        {
            l.LOG("Выгрузка контрагентов в МАР: " + DateTime.Now.ToString() + '\n' + "=========================", richText);

            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //создание транзакции
            FbTransaction trans = con.BeginTransaction();

            //запрос таблицы с контрагентами из КИС
            FbDataReader reader = KISq.getCLN(query, KIScon);

            //вызов процедуры базы СМАР с транзакцией
            FbCommand exec_MT_SET_CLN = new FbCommand("MT_SET_CLN", con, trans);

            //указываем что используем процедуру
            exec_MT_SET_CLN.CommandType = CommandType.StoredProcedure;


            #region входные параметры процедуры
            exec_MT_SET_CLN.Parameters.Add("adress", FbDbType.VarChar); // адрес клиента
            exec_MT_SET_CLN.Parameters.Add("vinn", FbDbType.VarChar); // ИНН клиента
            exec_MT_SET_CLN.Parameters.Add("ftype", FbDbType.Integer); // тип точки (1 – контрагент (плательщик), 2 – торговая точка)
            exec_MT_SET_CLN.Parameters.Add("vkod", FbDbType.VarChar); // уникальный код клиента в КИС   
            exec_MT_SET_CLN.Parameters.Add("vname", FbDbType.VarChar); // наименование клиента
            exec_MT_SET_CLN.Parameters.Add("rvkod", FbDbType.VarChar); // если ftype=2 – торговая точка, то привязка к контрагенту (уникальный код клиента в КИС)
            #endregion

            //выходной параметр процедуры
            exec_MT_SET_CLN.Parameters.Add("result", FbDbType.Integer).Direction = ParameterDirection.Output;

            int upd = 0; //количество обновленных строк
            int ins = 0; //количество новых строк
            int res = 0; //количество не добавленных строк

            int countCLN = KISq.countClnKIS(qT.countCLN, KIScon);

            progress.Invoke(new ProgressCountDelegate(ProgressCount), progress, countCLN);

            progress.Invoke(new ProgressValueDelegate(ProgressValue), progress);

            // чтение полученных данных
            while (reader.Read())
            {
                #region заполнение параметров процедуры
                exec_MT_SET_CLN.Parameters["adress"].Value = reader["vadres"].ToString();
                exec_MT_SET_CLN.Parameters["vinn"].Value = reader["vinn"].ToString();
                exec_MT_SET_CLN.Parameters["ftype"].Value = 1;
                exec_MT_SET_CLN.Parameters["vkod"].Value = reader["nid"].ToString();
                exec_MT_SET_CLN.Parameters["vname"].Value = reader["vname"].ToString();
                exec_MT_SET_CLN.Parameters["rvkod"].Value = "NULL";
                #endregion
                //exec_MT_SET_CLN.CommandTimeout = 3600;
                exec_MT_SET_CLN.ExecuteNonQuery();

                switch (exec_MT_SET_CLN.Parameters["result"].Value.ToString())
                {
                    case "2":
                        upd++;
                        if (check.Checked)
                            l.LOG("Клиент - " + reader["vname"].ToString() + ", с кодом - " + reader["nid"].ToString() + " - обновлен", richText);
                        break;
                    case "1":
                        ins++;
                        if (check.Checked)
                            l.LOG("Клиент - " + reader["vname"].ToString() + ", с кодом - " + reader["nid"].ToString() + " - добавлен", richText);
                        break;
                    case "-1":
                        res++;
                        if (check.Checked)
                            l.LOG("Клиент - " + reader["vname"].ToString() + ", с кодом - " + reader["nid"].ToString() + " - не загружен", richText);
                        break;
                }

                progress.Invoke(new ProgressStepDelegate(ProgressStep), progress);
            }
            trans.Commit();

            l.LOG("Обновлено - " + upd.ToString() +
                            ". Добавлено - " + ins.ToString() +
                            ". Не удалось добавить - " + res.ToString() +
                            ": Нет кода или имени клиента" + '\n' + DateTime.Now.ToString(), richText);

            l.LOG("=========================" + '\n', richText);
        }

        /// <summary>
        /// выгрузка номенклатуры
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="con">подключение к МАП</param>
        /// <param name="KIScon">подключение к КИС</param>
        /// <param name="richText">Поле для логирования</param>
        public void MT_SET_OBJ(string query, FbConnection con, FbConnection KIScon, RichTextBox richText, CheckBox check, ProgressBar progress)
        {
            l.LOG("Выгрузка номенклатуры в МАР: " + DateTime.Now.ToString() + '\n' + "=========================", richText);

            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //создание транзакции
            FbTransaction trans = con.BeginTransaction();

            //запрос таблицы с контрагентами из КИС
            FbDataReader reader = KISq.getPROD(query, KIScon);

            //вызов процедуры базы СМАР с транзакцией
            FbCommand exec_MT_SET_OBJ = new FbCommand("MT_SET_OBJ", con, trans);

            //указываем что используем процедуру
            exec_MT_SET_OBJ.CommandType = CommandType.StoredProcedure;

            //входные параметры процедуры
            exec_MT_SET_OBJ.Parameters.Add("vkod", FbDbType.VarChar); // код продукции в КИС
            exec_MT_SET_OBJ.Parameters.Add("vname", FbDbType.VarChar); // наименование продукции
            exec_MT_SET_OBJ.Parameters.Add("vtg_name", FbDbType.VarChar); // наименование товарной группы в КИС

            //выходной параметр процедуры
            exec_MT_SET_OBJ.Parameters.Add("result", FbDbType.Integer).Direction = ParameterDirection.Output;

            int upd = 0; //количество обновленных строк
            int ins = 0; //количество новых строк
            int res = 0; //количество не добавленных строк

            int countProd = KISq.countProdKIS(qT.countProd, KIScon);

            progress.Invoke(new ProgressCountDelegate(ProgressCount), progress, countProd);

            progress.Invoke(new ProgressValueDelegate(ProgressValue), progress);

            // чтение полученных данных
            while (reader.Read())
            {
                //заполнение параметров процедуры
                exec_MT_SET_OBJ.Parameters["vkod"].Value = reader["kid"].ToString();
                exec_MT_SET_OBJ.Parameters["vname"].Value = reader["vname"].ToString();
                exec_MT_SET_OBJ.Parameters["vtg_name"].Value = reader["vname"].ToString();
                exec_MT_SET_OBJ.ExecuteNonQuery();
                //exec_MT_SET_OBJ.CommandTimeout = 3600;

                switch (exec_MT_SET_OBJ.Parameters["result"].Value.ToString())
                {
                    case "2":
                        upd++;
                        if (check.Checked)
                            l.LOG("Товар - " + reader["vname"].ToString() + ", с кодом - " + reader["kid"].ToString() + " - обновлен", richText);
                        break;
                    case "1":
                        ins++;
                        if (check.Checked)
                            l.LOG("Товар - " + reader["vname"].ToString() + ", с кодом - " + reader["kid"].ToString() + " - добавлен", richText);
                        break;
                    case "-1":
                        res++;
                        if (check.Checked)
                            l.LOG("Товар - " + reader["vname"].ToString() + ", с кодом - " + reader["kid"].ToString() + " - не загружен", richText);
                        break;
                }

                progress.Invoke(new ProgressStepDelegate(ProgressStep), progress);
            }
            trans.Commit();

            l.LOG("Обновлено - " + upd.ToString() +
                            ". Добавлено - " + ins.ToString() +
                            ". Не удалось добавить - " + res.ToString() +
                            ": Нет кода или наименования нимоенклатуры" + '\n' + DateTime.Now.ToString(), richText);

            l.LOG("=========================" + '\n', richText);
        } 
        #endregion

        #region Делегаты - для работы в основном потоке
        /// <summary>
        /// Делегат для увеличения прогресса на шаг
        /// </summary>
        /// <param name="progress">Полоса прогресса (ProgressBar)</param>
        private delegate void ProgressStepDelegate(ProgressBar progress);

		/// <summary>
		/// Делегат для присвоения максимального значения полосе прогресса
		/// </summary>
		/// <param name="progress">Полоса прогресса (ProgressBar)</param>
		/// <param name="count">Количество</param>
		private delegate void ProgressCountDelegate(ProgressBar progress, int count);

		/// <summary>
		/// Делегат для присвоения значения полосе прогресса при её повторном вызове
		/// </summary>
		/// <param name="progress">Полоса прогресса (ProgressBar)</param>
		private delegate void ProgressValueDelegate(ProgressBar progress);

		/// <summary>
		/// Метод увеличения прогресса на шаг
		/// </summary>
		/// <param name="progress">Полоса прогресса (ProgressBar)</param>
		private void ProgressStep(ProgressBar progress)
        {
            progress.PerformStep();
        }

		/// <summary>
		/// Метод для присвоения максимального значения полосе прогресса
		/// </summary>
		/// <param name="progress">Полоса прогресса (ProgressBar)</param>
		/// <param name="count">Количество</param>
		private void ProgressCount(ProgressBar progress, int count)
        {
            progress.Maximum = count;
        }

		/// <summary>
		/// Метод для присвоения значения полосе прогресса при её повторном вызове
		/// </summary>
		/// <param name="progress">Полоса прогресса (ProgressBar)</param>
		private void ProgressValue(ProgressBar progress)
        {
            progress.Value = 0;
        } 
        #endregion

    }
}
