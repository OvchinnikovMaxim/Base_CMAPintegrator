using FirebirdSql.Data.FirebirdClient;
using System;
using System.Windows.Forms;

namespace CMAPIntegrator
{
    /// <summary>
    /// Класс для подключения к базе CMAP.FDB
    /// </summary>
    class ConnectionCMAP
    {
        /// <summary>
        /// Соединение к базе CMAP
        /// </summary>
        public FbConnection fb; //fb ссылается на соединение с базой данных

        /// <summary>
        /// Строка подключения к базе CMAP
        /// </summary>
        public FbConnectionStringBuilder fb_con = new FbConnectionStringBuilder();

        /// <summary>
        /// Формирование строки подключения к базе CMAP
        /// </summary>
        /// <param name="user">Логин</param>
        /// <param name="pass">Пароль</param>
        /// <param name="IPadres">IP адрес компьютера</param>
        /// <param name="data_path">Локальный путь до базы</param>
        public string ConnectionStringCMAP(string user, string pass, string IPadres, string data_path)
        {
            fb_con.Port = 3050; //порт по умолчанию
            fb_con.Charset = "WIN1251"; //используемая кодировка
            fb_con.UserID = user;//логин
            fb_con.Password = pass; //пароль
            fb_con.DataSource = IPadres;// ip адрес компьютера
            fb_con.Database = data_path; //путь к файлу базы данных
            fb_con.ServerType = 0; //указываем тип сервера (0 - "полноценный Firebird" (classic или super server), 1 - встроенный (embedded))

            // создаем подключение
            try
            {
                fb = new FbConnection(fb_con.ToString()); //передаем нашу строку подключения объекту класса FbConnection
                fb.Open(); //открываем БД
            }
            catch (Exception ex)
            {
                MessageBox.Show("Соединение с базой CMAP не установлено"+"\n"+ex.Message);
            }
            return fb_con.ToString();
        }
    }
}
