using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CMAPIntegrator
{
    /// <summary>
    /// Логирование действий
    /// </summary>
    class Logging
    {
        /// <summary>
		/// путь к логу выполнения операций
		/// </summary>
		public string CMAP_log = AppDomain.CurrentDomain.BaseDirectory + @"MAP_KIS.log";

		/// <summary>
		/// Добавление записи в MAP_KIS.log
		/// </summary>
		/// <param name="text">Необходимый текст</param>
		public string LOG(string text, RichTextBox richText)
		{
			richText.Invoke(new LogTextDelegate(LogText), text, richText);
			FileStream MAP_KIS_log = new FileStream(CMAP_log, FileMode.Append);
			StreamWriter flog = new StreamWriter(MAP_KIS_log, Encoding.GetEncoding(1251));
			flog.WriteLine(text);
			flog.Dispose();
			flog.Close();

			return text;
		}

		/// <summary>
		/// Делегат для логирования в текстовое поле на форме
		/// </summary>
		/// <param name="text">текст</param>
		/// <param name="richText">поле для логирования</param>
		private delegate void LogTextDelegate(string text, RichTextBox richText);

		/// <summary>
		/// Метод для логирования в текстовое поле на форме
		/// </summary>
		/// <param name="text"></param>
		/// <param name="richText"></param>
		private void LogText(string text, RichTextBox richText)
		{
			richText.Text += text + '\r' + '\n';
		}

	}
}
