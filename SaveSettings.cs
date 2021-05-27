using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CMAPIntegrator
{
    /// <summary>
    /// Класс для сохранения и чтения настроек
    /// </summary>
    class SaveSettings
    {
		/// <summary>
		/// путь к файлу настроек подключения
		/// </summary>
		public string pathCMAP = AppDomain.CurrentDomain.BaseDirectory + @"MAP_KIS.ini";

		/// <summary>
		/// Сохранение настроек подключения к базе CMAP 
		/// </summary>
		/// <param name="IPadr">IP адрес компьютера</param>
		/// <param name="DataPth">Локальный путь до базы</param>
		/// <param name="user">Логин</param>
		/// <param name="pass">Пароль</param>
		/// <returns>путь к файлу настроек</returns>
		public string SaveSettingCMAP(string IPadr, string DataPth, string user, string pass)
        {
			try
			{
				FileStream MAP_KIS = new FileStream(pathCMAP, FileMode.Append);
				StreamWriter fnew = new StreamWriter(MAP_KIS, Encoding.GetEncoding(1251));
				fnew.WriteLine("[CMAPDatabase]");
				fnew.WriteLine("CMAPDatabaseHost=" + IPadr);
				fnew.WriteLine("CMAPDatabasePath=" + DataPth);
				fnew.WriteLine("CMAPDatabaseUserName=" + user);
				fnew.WriteLine("CMAPDatabasePassword=" + pass);
				fnew.Close();
				MessageBox.Show("Настройки СМАР сохранены");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			return pathCMAP;
		}

		/// <summary>
		/// Сохранение настроек подключения к базе КИС дистрибьютора
		/// </summary>
		/// <param name = "IPadrKIS" > IP адрес компьютера для базы КИС</param>
		/// <param name="DataPthKIS">Локальный путь до базы КИС</param>
		/// <param name="userKIS">Логин для базы КИС</param>
		/// <param name="passKIS">Пароль для базы КИС</param>
		public void SaveSettingKIS(string IPadrKIS, string DataPthKIS, string userKIS, string passKIS)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(pathCMAP, true,  Encoding.GetEncoding(1251)))
				{
					sw.WriteLine("[KISconnection]");
					sw.WriteLine("KISDatabaseHost=" + IPadrKIS);
					sw.WriteLine("KISDatabasePath=" + DataPthKIS);
					sw.WriteLine("KISDatabaseUserName=" + userKIS);
					sw.WriteLine("KISDatabasePassword=" + passKIS);

					MessageBox.Show("Настройки КИС сохранены");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

	}
}
