using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CMAPIntegrator
{
    /// <summary>
    /// Основная форма и логика работы с модулем интеграции (обмен данными)
    /// </summary>
    public partial class Mainform : Form
    {
        /// <summary>
        /// Создание объекта класса для других классов
        /// </summary>
        otherClass otherClass = new otherClass();
                
        /// <summary>
        /// Создание объекта класса для данных по складам для остатков
        /// </summary>
        Sklads_data sklads = new Sklads_data();

        /// <summary>
        /// Создание объекта структуры для строковых переменных для подключения
        /// </summary>
        StringCon @string = new StringCon();

        /// <summary>
        /// Создание объекта класса текстов запросов
        /// </summary>
        Querys_text qT = new Querys_text();

        public Mainform()
        {
            InitializeComponent();

            // период для выгрузки накладных
            date_docs_from.Value = date_docs_to.Value.Date.AddDays(-9);

            // период для загрузки заказов
            date_order_from.Value = date_order_to.Value.Date.AddDays(-9);
        }

        /// <summary>
        /// Ссылка на сайт nefco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.nefco.ru");
        }

        #region вкладка ПОДКЛЮЧЕНИЕ
        /// <summary>
        /// Открыте формы подключения к учетной системе дистрибьютора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_form_connect_KIS_Click(object sender, EventArgs e)
        {
            FormConnectKIS connectKIS = new FormConnectKIS();
            connectKIS.ShowDialog();

            #region присвоение данных из дочерней формы подключения к КИС
            @string.IPadrKIS = connectKIS.text_IP_KIS.Text;
            @string.DataPthKIS = connectKIS.text_path_KIS.Text;
            @string.userKIS = connectKIS.text_login_KIS.Text;
            @string.passKIS = connectKIS.text_pass_KIS.Text;
            #endregion
        }

        #region подключение
        /// <summary>
        /// Строки для подключения к СМАР и КИС
        /// </summary>
        public void connetionDBs()
        {
            @string.conMAP = otherClass.cMAP.ConnectionStringCMAP(text_login_CMAP.Text, text_pass_CMAP.Text, text_IP_CMAP.Text, text_path_CMAP.Text);
            @string.conKIS = otherClass.cKIS.ConnectionStringKIS(@string.userKIS, @string.passKIS, @string.IPadrKIS, @string.DataPthKIS);
        }

        /// <summary>
        /// Строка для подключения к СМАР 
        /// </summary>
        public void connetionMAPdb()
        {
            @string.conMAP = otherClass.cMAP.ConnectionStringCMAP(text_login_CMAP.Text, text_pass_CMAP.Text, text_IP_CMAP.Text, text_path_CMAP.Text);
        }

        /// <summary>
        /// Строка для подключения к КИС 
        /// </summary>
        public void connetionKISdb()
        {
            @string.conKIS = otherClass.cKIS.ConnectionStringKIS(@string.userKIS, @string.passKIS, @string.IPadrKIS, @string.DataPthKIS);
        }

        /// <summary>
        /// проверка и открытие баз МАР и КИС
        /// </summary>
        public void openDBs()
        {
            try
            {
                if (otherClass.cKIS.fb_KIS.State == ConnectionState.Closed)
                    otherClass.cKIS.fb_KIS.Open();

                if (otherClass.cMAP.fb.State == ConnectionState.Closed)
                    otherClass.cMAP.fb.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
		/// закрытие баз МАР и КИС
		/// </summary>
		public void closeDB()
        {
            otherClass.cMAP.fb.Close();
            otherClass.cKIS.fb_KIS.Close();
        }
        #endregion

        /// <summary>
        /// Открытие настроек при запуске модуля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mainform_Load(object sender, EventArgs e)
        {
            ReadSettings();
        }

        /// <summary>
        /// чтение настроек из файла MAP_KIS.ini при запуске модуля
        /// </summary>
        public void ReadSettings()
        {
            SaveSettings ss = new SaveSettings();
            if(File.Exists(otherClass.l.CMAP_log))
                text_path_log.Text = otherClass.l.CMAP_log;

            if (File.Exists(ss.pathCMAP))
            {
                text_path_save_settings.Text = ss.pathCMAP;                

                StreamReader reader = new StreamReader(ss.pathCMAP);

                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine(); // чтение строки

                    #region Загрузка настроек подключения к базе CMAP
                    if (s.Contains("CMAPDatabaseHost"))
                        text_IP_CMAP.Text = s.Substring(s.IndexOf('=') + 1);

                    if (s.Contains("CMAPDatabasePath"))
                        text_path_CMAP.Text = s.Substring(s.IndexOf('=') + 1);

                    if (s.Contains("CMAPDatabaseUserName"))
                        text_login_CMAP.Text = s.Substring(s.IndexOf('=') + 1);

                    if (s.Contains("CMAPDatabasePassword"))
                        text_pass_CMAP.Text = s.Substring(s.IndexOf('=') + 1);
                    #endregion

                    #region Загруза настроек подключения к базе КИС (учетная система дистрибьютора)
                    if (s.Contains("KISDatabaseHost"))
                        @string.IPadrKIS = s.Substring(s.IndexOf('=') + 1);

                    if (s.Contains("KISDatabasePath"))
                        @string.DataPthKIS = s.Substring(s.IndexOf('=') + 1);

                    if (s.Contains("KISDatabaseUserName"))
                        @string.userKIS = s.Substring(s.IndexOf('=') + 1);

                    if (s.Contains("KISDatabasePassword"))
                        @string.passKIS = s.Substring(s.IndexOf('=') + 1);
                    #endregion

                    #region загрузка списка складов
                    if (s.Contains("Sklads"))
                    {
                        warehouses.Items.Clear();
                        string[] a = s.Substring(s.IndexOf('=') + 1).Split(',');

                        if (!String.IsNullOrEmpty(s.Substring(s.IndexOf('=') + 1)))
                            for (int i = 0; i < a.Length; i++)
                                warehouses.Items.Add(a[i].Trim());
                        else
                            for (int i = 0; i < a.Length - 1; i++)
                                warehouses.Items.Add(a[i].Trim());
                    }
                    #endregion                     
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("Файл настроек не найден или не создан.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Сохранение настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_settings_Click(object sender, EventArgs e)
        {
            File.Delete(otherClass.ss.pathCMAP);

            text_path_save_settings.Text = otherClass.ss.SaveSettingCMAP(text_IP_CMAP.Text, text_path_CMAP.Text, text_login_CMAP.Text, text_pass_CMAP.Text);

            otherClass.ss.SaveSettingKIS(@string.IPadrKIS, @string.DataPthKIS, @string.userKIS, @string.passKIS);

            sklads.count_wh = warehouses.Items.Count - 1;

            // сохранение списка складов
            using (StreamWriter sw = new StreamWriter(otherClass.ss.pathCMAP, true, Encoding.GetEncoding(1251)))
            {
                sw.WriteLine("[KISDocsParams]");

                sklads.str = "";

                for (int i = 0; i < sklads.count_wh; i++)
                    sklads.str += warehouses.Items[i] + ",";
                try
                {
                    sklads.str += warehouses.Items[sklads.count_wh];
                }
                catch (Exception)
                {
                    sklads.str = String.Empty;
                }

                sw.WriteLine("Sklads=" + sklads.str);
                MessageBox.Show("Настройки складов сохранены");
            }
        }

        /// <summary>
        /// проверка подключения к базе СМАР
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connect_CMAP_Click(object sender, EventArgs e)
        {
            connetionMAPdb();
            try
            {
                if (otherClass.cMAP.fb.State == ConnectionState.Open)
                    MessageBox.Show("Соединение установлено", "Подключение к базе МАП");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                otherClass.cMAP.fb.Close();
            }
        } 
        #endregion

        #region вкладка ОСТАТКИ
        #region работа со списком складов для остатков
        /// <summary>
        /// Открыте формы добавления склада для остатков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_warehouse_Click(object sender, EventArgs e)
        {
            Add_warehouse warehouse = new Add_warehouse();
            warehouse.Owner = this; //При создании формы устанавливаем владельца
            warehouse.ShowDialog();
        }

        /// <summary>
        /// Удаление выбранного склада
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_warehouse_Click(object sender, EventArgs e)
        {
            warehouses.Items.Remove(warehouses.SelectedItem);
        }

        /// <summary>
        /// Очистка списка - Удаление всех складов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clear_w_hoses_Click(object sender, EventArgs e)
        {
            warehouses.Items.Clear();
        }
        #endregion
                
        /// <summary>
        /// Обработчик для загрузки остатков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ost_Click(object sender, EventArgs e)
        {
            connetionDBs();

            text_path_log.Text = otherClass.l.CMAP_log;

            label_info.Text = "Выгрузка остатков";

            bg_OST.RunWorkerAsync();

            closeDB();
        }
        #endregion

        #region вкладка ПРОДАЖИ И ЗАКАЗЫ
        /// <summary>
        /// Обработчик для загрузки заказов в КИС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_orders_Click(object sender, EventArgs e)
        {
            connetionDBs();

            text_path_log.Text = otherClass.l.CMAP_log;

            label_info.Text = "Загрузка заказов";

            bg_ORDERS.RunWorkerAsync();

            closeDB();
        }

        /// <summary>
        /// Обработчик для загрузки накладных в МАР
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sales_Click(object sender, EventArgs e)
        {
            connetionDBs();

            text_path_log.Text = otherClass.l.CMAP_log;

            label_info.Text = "Выгрузка накладных";
                        
            bg_DOCS.RunWorkerAsync();
            
            closeDB();
        }
        #endregion

        #region вкладка СИНХРОНИЗАЦИЯ ДАННЫХ
        /// <summary>
        /// Обработчик для загрузки контрагентов в МАР
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_client_sinhr_Click(object sender, EventArgs e)
        {
            connetionDBs();

            text_path_log.Text = otherClass.l.CMAP_log;

            label_info.Text = "Выгрузка контрагентов";

            bg_CLN.RunWorkerAsync();

            closeDB();
        }

        /// <summary>
        ///  Обработчик для загрузки номенклатуры в МАР
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_prods_sinhr_Click(object sender, EventArgs e)
        {
            connetionDBs();

            text_path_log.Text = otherClass.l.CMAP_log;

            label_info.Text = "Выгрузка номенклатуры";

            bg_PROD.RunWorkerAsync();

            closeDB();
        }

        /// <summary>
        /// Обработчик для загрузки остатков, накладных и выгрузке заказов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_totalDocs_sinhr_Click(object sender, EventArgs e)
        {
            connetionDBs();

            text_path_log.Text = otherClass.l.CMAP_log;

            bg_Sinh_DOC.RunWorkerAsync();

            closeDB();
        }

        /// <summary>
        /// Обработчик для загрузки контрагентов, номенклатуры, остатков, накладных и выгрузке заказов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_total_sinhr_Click(object sender, EventArgs e)
        {
            connetionDBs();

            text_path_log.Text = otherClass.l.CMAP_log;

            bg_FULL.RunWorkerAsync();

            closeDB();
        }
        #endregion

        #region выполнение действий в отдельном потоке(фоне)
        /// <summary>
        /// Выгрузка контрагентов в фоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bg_CLN_DoWork(object sender, DoWorkEventArgs e)
        {
            otherClass.MAPq.MT_SET_CLN(qT.set_CLN, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);

            MessageBox.Show("Контрагенты выгружены", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Выгрузка номенклатуры в фоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bg_PROD_DoWork(object sender, DoWorkEventArgs e)
        {
            otherClass.MAPq.MT_SET_OBJ(qT.set_OBJ, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);

            MessageBox.Show("Номенклатура выгружена", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Выгрузка накладных в фоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bg_DOCS_DoWork(object sender, DoWorkEventArgs e)
        {
            otherClass.MAPq.MT_DROP_DOC_ACTUAL(date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, rich_log_text_sales);

            otherClass.MAPq.MT_SET_DOC2(qT.set_DOCS + " WHERE rdoc_type=2 AND vdate BETWEEN '" + date_docs_from.Value.ToShortDateString() + "' and '" + date_docs_to.Value.ToShortDateString() + "'", date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text_sales, check_log_extended, progress_sinhronization);

            otherClass.MAPq.MT_SET_DETAILS2(qT.set_DETS + " WHERE d.rdoc_type=2 AND d.vdate BETWEEN '" + date_docs_from.Value.ToShortDateString() + "' and '" + date_docs_to.Value.ToShortDateString() + "'", date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text_sales, check_log_extended, progress_sinhronization);

            otherClass.MAPq.MT_SET_DOC_DEL2(date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, rich_log_text_sales);

            MessageBox.Show("Накладные выгружены", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// Выгрузка остатков в фоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bg_OST_DoWork(object sender, DoWorkEventArgs e)
        {
            otherClass.MAPq.delRES(otherClass.cMAP.fb, rich_log_text_ost);

            #region количество складов
            int count_wh1 = warehouses.Items.Count - 1;

            string str1 = String.Empty;

            for (int i = 0; i < count_wh1; i++)
                str1 += warehouses.Items[i] + ",";
            try
            {
                str1 += warehouses.Items[count_wh1];
            }
            catch (Exception)
            {
                MessageBox.Show("не добавлен склад - остатки не выгружены");
                otherClass.l.LOG("не добавлен склад - остатки не выгружены", rich_log_text_ost);
            }
            #endregion

            otherClass.MAPq.loadRES(qT.ost + " WHERE rscl in (" + str1 + ") AND vdate ='" + DateTime.Now.ToShortDateString() + "'", otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text_ost, check_log_extended, progress_sinhronization);

            MessageBox.Show("Остатки выгружены", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Загрузка заказов в фоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bg_ORDERS_DoWork(object sender, DoWorkEventArgs e)
        {
            otherClass.MAPq.MT_GET_ORDERS(date_order_from.Value, date_order_to.Value, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text_sales, progress_sinhronization);

            MessageBox.Show("Заказы загружены", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Синхронизаци документов в фоне: загрузка заказов, выгрузка остатков, выгрузка накладных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bg_Sinh_DOC_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Выгрузка остатков в МАР
            //делегат для изменения текста в основном потоке
            Action<string> ostText = s => label_info.Text = s;
            label_info.Invoke(ostText, "Выгрузка остатков");

            otherClass.MAPq.delRES(otherClass.cMAP.fb, rich_log_text);

            #region количество складов
            int count_wh1 = warehouses.Items.Count - 1;

            string str1 = String.Empty;

            for (int i = 0; i < count_wh1; i++)
                str1 += warehouses.Items[i] + ",";
            try
            {
                str1 += warehouses.Items[count_wh1];
            }
            catch (Exception)
            {
                MessageBox.Show("не добавлен склад - остатки не выгружены");
                otherClass.l.LOG("не добавлен склад - остатки не выгружены", rich_log_text_ost);
            }
            #endregion

            otherClass.MAPq.loadRES(qT.ost + " WHERE rscl in (" + str1 + ") AND vdate ='" + DateTime.Now.ToShortDateString() + "'", otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);
            #endregion

            #region Выгрузка накладных в МАР
            //делегат для изменения текста в основном потоке
            Action<string> docsText = s => label_info.Text = s;
            label_info.Invoke(docsText, "Выгрузка накладных");

            otherClass.MAPq.MT_DROP_DOC_ACTUAL(date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, rich_log_text);

            otherClass.MAPq.MT_SET_DOC2(qT.set_DOCS + " WHERE rdoc_type=2 AND vdate BETWEEN '" + date_docs_from.Value.ToShortDateString() + "' and '" + date_docs_to.Value.ToShortDateString() + "'", date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);


            otherClass.MAPq.MT_SET_DETAILS2(qT.set_DETS + " WHERE d.rdoc_type=2 AND d.vdate BETWEEN '" + date_docs_from.Value.ToShortDateString() + "' and '" + date_docs_to.Value.ToShortDateString() + "'", date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);

            otherClass.MAPq.MT_SET_DOC_DEL2(date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, rich_log_text);
            #endregion

            #region Загрузка заказов в КИС
            if (group_orders.Enabled)
            {
                //делегат для изменения текста в основном потоке
                Action<string> orderText = s => label_info.Text = s;
                label_info.Invoke(orderText, "Загрузка заказов");

                otherClass.MAPq.MT_GET_ORDERS(date_order_from.Value, date_order_to.Value, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, progress_sinhronization);
            }
            #endregion

            MessageBox.Show("Документы загружены", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Полная синхронизация в фоне: выгрузка котрагентов и номенклатуры, загрузка заказов, выгрузка остатков и накладных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bg_FULL_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Выгрузка контрагентов в МАР
            //делегат для изменения текста в основном потоке
            Action<string> clnText = s => label_info.Text = s;
            label_info.Invoke(clnText, "Выгрузка контрагентов");

            otherClass.MAPq.MT_SET_CLN(qT.set_CLN, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);
            #endregion

            #region Выгрузка номенклатуры в МАР
            //делегат для изменения текста в основном потоке
            Action<string> prodText = s => label_info.Text = s;
            label_info.Invoke(prodText, "Выгрузка номенклатуры");

            otherClass.MAPq.MT_SET_OBJ(qT.set_OBJ, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);
            #endregion

            #region Выгрузка остатков в МАР
            //делегат для изменения текста в основном потоке
            Action<string> ostText = s => label_info.Text = s;
            label_info.Invoke(ostText, "Выгрузка остатков");

            otherClass.MAPq.delRES(otherClass.cMAP.fb, rich_log_text);

            #region количество складов
            int count_wh1 = warehouses.Items.Count - 1;

            string str1 = String.Empty;

            for (int i = 0; i < count_wh1; i++)
                str1 += warehouses.Items[i] + ",";
            try
            {
                str1 += warehouses.Items[count_wh1];
            }
            catch (Exception)
            {
                MessageBox.Show("не добавлен склад - остатки не выгружены");
                otherClass.l.LOG("не добавлен склад - остатки не выгружены", rich_log_text_ost);
            }
            #endregion

            otherClass.MAPq.loadRES(qT.ost + " WHERE rscl in (" + str1 + ") AND vdate ='" + DateTime.Now.ToShortDateString() + "'", otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);
            #endregion

            #region Выгрузка накладных в МАР
            //делегат для изменения текста в основном потоке
            Action<string> docsText = s => label_info.Text = s;
            label_info.Invoke(docsText, "Выгрузка накладных");

            otherClass.MAPq.MT_DROP_DOC_ACTUAL(date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, rich_log_text);

            otherClass.MAPq.MT_SET_DOC2(qT.set_DOCS + " WHERE rdoc_type=2 AND vdate between '" + date_docs_from.Value.ToShortDateString() + "' AND '" + date_docs_to.Value.ToShortDateString() + "'", date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);

            otherClass.MAPq.MT_SET_DETAILS2(qT.set_DETS + " WHERE d.rdoc_type=2 AND d.vdate BETWEEN '" + date_docs_from.Value.ToShortDateString() + "' AND '" + date_docs_to.Value.ToShortDateString() + "'", date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, check_log_extended, progress_sinhronization);

            otherClass.MAPq.MT_SET_DOC_DEL2(date_docs_from.Value, date_docs_to.Value, otherClass.cMAP.fb, rich_log_text);
            #endregion

            #region Загрузка заказов в КИС
            if (group_orders.Enabled)
            {
                //делегат для изменения текста в основном потоке
                Action<string> orderText = s => label_info.Text = s;
                label_info.Invoke(orderText, "Загрузка заказов");

                otherClass.MAPq.MT_GET_ORDERS(date_order_from.Value, date_order_to.Value, otherClass.cMAP.fb, otherClass.cKIS.fb_KIS, rich_log_text, progress_sinhronization);
            }
            #endregion

            MessageBox.Show("Синхронизация завершена", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 
        #endregion
    }

    /// <summary>
    /// класс для создания объектов других классов
    /// </summary>
    class otherClass
    {
        /// <summary>
        /// создание объекта класса соединения с СМАР
        /// </summary>
        public ConnectionCMAP cMAP = new ConnectionCMAP();

        /// <summary>
        /// создание объекта класса соединения с КИС дистрибьютора
        /// </summary>
        public ConnectionKIS cKIS = new ConnectionKIS();

        /// <summary>
        /// создание объекта класса сохранения настроек
        /// </summary>
        public SaveSettings ss = new SaveSettings();

        /// <summary>
        /// создание объекта класса запросов для МАП
        /// </summary>
        public MAPquerys MAPq = new MAPquerys();

        /// <summary>
		/// создание объекта класса для логирования
		/// </summary>
		public Logging l = new Logging();
    }

    /// <summary>
    /// Объявление строковых переменных для подключения
    /// </summary>
    struct StringCon
    {
        #region переменные для подключения к КИС дистра
        /// <summary>
        /// IP адрес к базе КИС дистрибьютора 
        /// </summary>
        public string IPadrKIS;

        /// <summary>
        /// локальный путь к базе КИС дистрибьютора
        /// </summary>
        public string DataPthKIS;

        /// <summary>
        /// логин к базе КИС дистрибьютора
        /// </summary>
        public string userKIS;

        /// <summary>
        /// пароль к базе КИС дистрибьютора
        /// </summary>
        public string passKIS;
        #endregion

        #region переменные для подключения к МАР и КИС
        /// <summary>
        /// строка подключения к МАП
        /// </summary>
        public string conMAP;

        /// <summary>
        /// строка подключения к КИС
        /// </summary>
        public string conKIS;
        #endregion
    }

    /// <summary>
    /// данные по складам для остатков
    /// </summary>
    class Sklads_data
    {
        /// <summary>
		/// количество складов
		/// </summary>
		public int count_wh = 0;

        /// <summary>
        /// Список складов в форме строки
        /// </summary>
        public string str = String.Empty;
    }
}
