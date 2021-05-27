using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace CMAPIntegrator
{
    /// <summary>
    /// Запросы для работы с базой КИС дистрибьютора
    /// </summary>
    class KISquerys
    {
        /// <summary>
        /// Создание объекта класса текстов запросов
        /// </summary>
        Querys_text qT = new Querys_text();

        /// <summary>
        /// получение остатков из КИС
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="con">подключение к КИС</param>
        /// <returns>таблица с остатками</returns>
        public FbDataReader getRES(string query, FbConnection con)
        {
            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //формирование команды на получение остатков из КИС
            FbCommand Res_kis = new FbCommand(query, con);

            //для запросов, которые возвращают результат в виде набора данных
            return Res_kis.ExecuteReader();
        }

        /// <summary>
        /// запись заказов в КИС
        /// </summary>
        /// <param name="con">подключение к КИС</param>
        /// <param name="bdate">Начало периода</param>
        /// <param name="edate">Конец периода</param>
        /// <param name="master_kid">внутренний код заявки в MAP</param>
        /// <param name="vdate">дата заявки</param>
        /// <param name="vshipping_date">дата доставки</param>
        /// <param name="vdiscont">скидка, %</param>
        /// <param name="vnum">код клиента в КИС</param>
        /// <param name="vrem">комментарии к заказу</param>
        /// <param name="vdistr_obj">код продукции в КИС</param>
        /// <param name="vamount">количество</param>
        /// <param name="vcost_rub">цена</param>
        /// <param name="vsum_rub">сумма</param>
        /// <param name="ftype">тип позиции (1– бонус, 0 – не бонус )</param>
        /// <returns>массив с внутреннним ID документа дистра, количеством загруженных и обновленных строк</returns>
        public string[] loadZakaz(FbConnection con, DateTime bdate, DateTime edate, int master_kid, string vdate, string vshipping_date, int vdiscont, string vnum, string vrem, string vdistr_obj, int vamount, double vcost_rub, double vsum_rub, int ftype)
        {
            //количество новых шапок накладных
            int insDOCS = 0;
            //количество обновленных шапок накладных
            int updDOCS = 0;
            //количество новых деталей накладных
            int insDET = 0;
            //количество обновленных деталей накладных
            int updDET = 0;

            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //создание транзакции
            FbTransaction transKIS = con.BeginTransaction();

            FbCommand docsKIS;

            FbCommand detailsKIS;

            // наличие внутреннего ИД документа в КИС
            FbCommand did = new FbCommand(qT.did + " WHERE master_kid=" + master_kid, con, transKIS);

            // наличие ИД шапки заказа (без этого упирается в повторение ключа)
            FbCommand Fmaster_kid = new FbCommand(qT.master_kid + " WHERE did='" + master_kid + "'", con, transKIS);

            // наличие ИД шапки заказа для табличной части
            FbCommand rmaster_kid = new FbCommand(qT.rmaster_kid + " WHERE rmaster_kid=" + Fmaster_kid.ExecuteScalar(), con, transKIS);

            try
            {
                // добавление/обновление шапок заказов
                if (did.ExecuteScalar() == null)
                {
                    // добавление шапок заказов
                    docsKIS = new FbCommand(qT.INS_docs_order +
                                       "('" + master_kid.ToString() + "-NK'" + ", '"
                                       + vdate.ToString().Substring(0, 10) + "', '"
                                       + vshipping_date.ToString().Substring(0, 10) + "', "
                                       + vdiscont + ", '"
                                       + vnum + "', '"
                                       + vrem + "', "
                                       + "1, '" + DateTime.Now.ToString() + "', 4, "
                                       + "1, 0, 0, 0)", 
                                       con, transKIS);
                    docsKIS.ExecuteNonQuery();
                    insDOCS++;

                }
                else 
                {
                    // помечание шапок заказов на удаление
                    docsKIS = new FbCommand(qT.UPD_docs_order_del + " AND vdate BETWEEN '" + bdate.ToShortDateString() + "' AND '" + edate.ToShortDateString() + "'", con, transKIS);
                    docsKIS.ExecuteNonQuery();

                    // обновление данных в шапке заказа
                    docsKIS = new FbCommand(qT.UPD_docs_order + ", vshipping_date='" + vshipping_date.ToString().Substring(0, 10) + "', vdiscont=" + vdiscont + ", vrem='" + vrem + "' WHERE did='" + master_kid + "'", con, transKIS);
                    docsKIS.ExecuteNonQuery();
                    updDOCS++;
                }

                // добавление/обновление табличной части заказов
                if (rmaster_kid.ExecuteScalar() == null)
                {
                    // добавление товарной позиции
                    detailsKIS = new FbCommand(qT.INS_det_order +
                                   "('" + Fmaster_kid.ExecuteScalar() + ", '"
                                   + vdistr_obj + "', "
                                   + vamount + ", '"
                                   + vcost_rub.ToString().Replace(',', '.') + "', '"
                                   + vsum_rub.ToString().Replace(',', '.') + "', "
                                   + ftype + ") "
                                   , con, transKIS);

                    detailsKIS.ExecuteNonQuery();
                    insDET++;
                }
                else 
                {
                    // ИД товарной позиции в КИС
                    FbCommand kid = new FbCommand(qT.kid + " WHERE rmaster_kid=" + Fmaster_kid.ExecuteScalar() + " AND vdistr_obj='" + vdistr_obj + "'", con, transKIS);

                    if (kid.ExecuteScalar() == null)
                    {
                        // добавление новой товарной позиции в обновленном заказе
                        detailsKIS = new FbCommand(qT.INS_det_order_updDOC +
                               "('" + Fmaster_kid.ExecuteScalar() + ", '"
                               + vdistr_obj + "', "
                               + vamount + ", '"
                               + vcost_rub.ToString().Replace(',', '.') + "', '"
                               + vsum_rub.ToString().Replace(',', '.') + "', "
                               + ftype + ") "
                               , con, transKIS);

                        detailsKIS.ExecuteNonQuery();
                    }
                    else
                    {
                        // помечание товарной позиции на удаление
                        detailsKIS = new FbCommand(qT.UPD_det_order_del + " WHERE rmaster_kid = " + Fmaster_kid.ExecuteScalar() + " AND vdistr_obj ='" + vdistr_obj + "'", con, transKIS);
                        detailsKIS.ExecuteNonQuery();

                        // обновление данных в товарной позиции
                        detailsKIS = new FbCommand(qT.UPD_det_order + ", " +
                                                   "vamount =" + vamount + ", " +
                                                   "vcost_rub='" + vcost_rub.ToString().Replace(',', '.') + "', " +
                                                   "vsum_rub='" + vsum_rub.ToString().Replace(',', '.') + "', " +
                                                   "ftype=" + ftype + " WHERE rmaster_kid = " + Fmaster_kid.ExecuteScalar() + " AND vdistr_obj ='" + vdistr_obj + "'", con, transKIS);

                        detailsKIS.ExecuteNonQuery();
                    }
                    updDET++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            transKIS.Commit();

            // массив с количеством загруженных шапок, количеством обновленных шапок, количеством загруженных деталей, количеством обновленных деталей, внутреннним ID документа дистра
            string[] res = { insDOCS.ToString(), updDOCS.ToString(), insDET.ToString(), updDET.ToString(), master_kid.ToString() + "-NK" };
            return res;
        }

        #region накладные
        /// <summary>
        /// получение шапок накладных из КИС
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="con">подключение к КИС</param>
        /// <returns>таблица с данными</returns>
        public FbDataReader getDOCS(string query, FbConnection con)
        {
            //формирование команды на получение остатков из КИС
            FbCommand DOCS_kis = new FbCommand(query, con);

            //для запросов, которые возвращают результат в виде набора данных
            return DOCS_kis.ExecuteReader();
        }

        /// <summary>
        /// получение табличной накладных из КИС
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="con">подключение к КИС</param>
        /// <returns>таблица с данными</returns>
        public FbDataReader getDETAILS(string query, FbConnection con)
        {
            //задаем запрос на выборку
            FbCommand Details_kis = new FbCommand(query, con);

            //для запросов, которые возвращают результат в виде набора данных
            return Details_kis.ExecuteReader();
        } 
        #endregion

        #region справочники
        /// <summary>
        /// получение контрагентов из КИС
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="con">подключение к КИС</param>
        /// <returns>таблица с контрагентами</returns>
        public FbDataReader getCLN(string query, FbConnection con)
        {
            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //задаем запрос на выборку
            FbCommand cln_kis = new FbCommand(query, con);

            //для запросов, которые возвращают результат в виде набора данных
            return cln_kis.ExecuteReader();
        }

        /// <summary>
        /// получение контрагентов из КИС
        /// </summary>
        /// <param name="query">запрос</param>
        /// <param name="con">подключение к КИС</param>
        /// <returns>таблица с номенклатурой</returns>
        public FbDataReader getPROD(string query, FbConnection con)
        {
            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //задаем запрос на выборку
            FbCommand prod_kis = new FbCommand(query, con);

            //для запросов, которые возвращают результат в виде набора данных
            return prod_kis.ExecuteReader();
        }
        #endregion

        #region количество записей в базе
        /// <summary>
        /// Количество загружаемых накладных
        /// </summary>
        /// <param name="query">Запрос к базе дистрибьютора</param>
        /// <param name="con">подключение к КИС</param>
        /// <returns>количество</returns>
        public int countDocsKIS(string query, FbConnection con)
        {
            // Открытие подключения к базе
            if (con.State == ConnectionState.Closed)
                con.Open();

            //количество загружаемых накладных из кис в мап
            FbCommand countDocs = new FbCommand(query, con);

            //для запросов, которые возвращают результат
            return Convert.ToInt32(countDocs.ExecuteScalar().ToString());
        }

        /// <summary>
        /// Количество загружаемых деталей в накладных
        /// </summary>
        /// <param name="query">Запрос к базе дистрибьютора</param>
        /// <param name="con">подключение к КИС</param>
        /// <returns>количество</returns>
        public int countDetsKIS(string query, FbConnection con)
        {
            //Количество загружаемых деталей в накладных из кис в мап
            FbCommand countDets = new FbCommand(query, con);

            //для запросов, которые возвращают результат
            return Convert.ToInt32(countDets.ExecuteScalar().ToString());
        }

        /// <summary>
        /// Количество загружаемых контрагентов
        /// </summary>
        /// <param name="query">Запрос к базе дистрибьютора</param>
        /// <param name="con">подключение к КИС</param>
		/// <returns>количество</returns>
        public int countClnKIS(string query, FbConnection con)
        {
            //количество выгружаемых накладных из кис в мап
            FbCommand countCLN = new FbCommand(query, con);

            //для запросов, которые возвращают результат
            return Convert.ToInt32(countCLN.ExecuteScalar().ToString());
        }

        /// <summary>
        /// Количество загружаемой номенклатуры
        /// </summary>
        /// <param name="query">Запрос к базе дистрибьютора</param>
        /// <param name="con">подключение к КИС</param>
		/// <returns>количество</returns>
        public int countProdKIS(string query, FbConnection con)
        {
            //количество выгружаемых накладных из кис в мап
            FbCommand countProd = new FbCommand(query, con);

            //для запросов, которые возвращают результат
            return Convert.ToInt32(countProd.ExecuteScalar().ToString());
        }

        /// <summary>
        /// Количество загружаемой номенклатуры с остатками
        /// </summary>
        /// <param name="query">Запрос к базе дистрибьютора</param>
        /// <param name="con">подключение к КИС</param>
		/// <returns>количество</returns>
        public int countOstKIS(string query, FbConnection con)
        {
            //количество выгружаемых накладных из кис в мап
            FbCommand countOst = new FbCommand(query, con);

            //для запросов, которые возвращают результат
            return Convert.ToInt32(countOst.ExecuteScalar().ToString());
        } 
        #endregion
    }
}
