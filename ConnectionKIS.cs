using FirebirdSql.Data.FirebirdClient;
using System;
using System.Windows.Forms;

namespace CMAPIntegrator
{
    /// <summary>
    /// Класс для подключения к базе и КИС
    /// </summary>
    class ConnectionKIS
    {
        /// <summary>
        /// Соединение к базе КИС
        /// </summary>
        public FbConnection fb_KIS; //fb ссылается на соединение с базой данных

        /// <summary>
        /// Строка подключения к базе КИС
        /// </summary>
        public FbConnectionStringBuilder fb_con_KIS = new FbConnectionStringBuilder();

        /// <summary>
		/// Формирование строки подключения к базе KIS
		/// </summary>
		/// <param name="user">Логин</param>
		/// <param name="pass">Пароль</param>
		/// <param name="IPadres">IP адрес компьютера</param>
		/// <param name="data_path">Локальный путь до базы</param>
        public string ConnectionStringKIS(string user, string pass, string IPadres, string data_path)
        {
            fb_con_KIS.Port = 3050; //порт по умолчанию
            fb_con_KIS.Charset = "WIN1251"; //используемая кодировка
            fb_con_KIS.UserID = user; //логин
            fb_con_KIS.Password = pass; //пароль
            fb_con_KIS.DataSource = IPadres; // ip адрес компьютера
            fb_con_KIS.Database = data_path; //путь к файлу базы данных
            fb_con_KIS.ServerType = 0; //указываем тип сервера (0 - "полноценный Firebird" (classic или super server), 1 - встроенный (embedded))

            //создаем подключение
            try
            {
                fb_KIS = new FbConnection(fb_con_KIS.ToString()); //передаем нашу строку подключения объекту класса FbConnection
                fb_KIS.Open(); //открываем БД
            }
            catch (Exception ex)
            {
                MessageBox.Show("Соединение с КИС дистрибьютора не установлено" + "\n" + ex.Message);
            }
            return fb_con_KIS.ToString();
        }    
    }
}
