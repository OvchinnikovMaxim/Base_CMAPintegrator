using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CMAPIntegrator
{
    public partial class FormConnectKIS : Form
    {
        /// <summary>
        /// создание объекта класса сохранения настроек
        /// </summary>
        SaveSettings ss = new SaveSettings();

        /// <summary>
        /// создание объекта класса соединения с КИС дистрибьютора
        /// </summary>
        ConnectionKIS cKIS = new ConnectionKIS();

        public FormConnectKIS()
        {
            InitializeComponent();
        }

        /// <summary>
        /// чтение настроек из файла MAP_KIS.ini при запуске формы соединения с КИС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConnectKIS_Load(object sender, EventArgs e)
        {
            if (File.Exists(ss.pathCMAP))
            {
                StreamReader reader = new StreamReader(ss.pathCMAP);
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine(); // чтение строки
                     
                    #region Загруза настроек подключения к базе КИС (учетная система дистрибьютора)
                    if (s.Contains("KISDatabaseHost"))
                    {
                        text_IP_KIS.Text =  s.Substring(s.IndexOf('=') + 1);
                    }
                    if (s.Contains("KISDatabasePath"))
                    {
                        text_path_KIS.Text = s.Substring(s.IndexOf('=') + 1);
                    }
                    if (s.Contains("KISDatabaseUserName"))
                    {
                        text_login_KIS.Text = s.Substring(s.IndexOf('=') + 1);
                    }
                    if (s.Contains("KISDatabasePassword"))
                    {
                        text_pass_KIS.Text = s.Substring(s.IndexOf('=') + 1);
                    }
                    #endregion                                     
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("Настройки не созданы.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Строка для подключения к КИС дистрибьютора 
        /// </summary>
        public void connetionKISdb()
        {
            cKIS.ConnectionStringKIS(text_login_KIS.Text, text_pass_KIS.Text, text_IP_KIS.Text, text_path_KIS.Text);
        }

        /// <summary>
        /// проверка подключения к базе КИС дистра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connect_KIS_Click(object sender, EventArgs e)
        {
            connetionKISdb();
            try
            {
                if (cKIS.fb_KIS.State == ConnectionState.Open)
                {
                    MessageBox.Show("Соединение установлено", "Подключение к КИС дистрибьютора");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cKIS.fb_KIS.Close();
            }
        }
    }
}
