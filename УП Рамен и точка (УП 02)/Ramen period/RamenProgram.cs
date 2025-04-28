using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;
using System.Data.SqlClient;

namespace Ramen_period
{
    /// <summary>
    /// Расширение для класса Program (Чтобы не засорить основной файл Program.cs)
    /// </summary>
    internal static partial class Program
    {
        internal static SqlConnection SQL = new SqlConnection(Properties.Settings.Default.Ramen_PeriodConnectionString);

        /// <summary>
        /// Метод получение изображения
        /// </summary>
        /// <param name="IURL">URL - Адрес изображение как локальный так и из сети</param>
        /// <returns></returns>
        public static Bitmap GetBitmap(string IURL)
        {
            try
            {
                //Экземпляр WebClient (Встроенный класс для примитивной работы с HTTP протоколом)
                WebClient web = new WebClient();
                //Скачиваем массив байтов по ссылке (И не важно удалённый или локальный адрес)
                byte[] dat = web.DownloadData(IURL);
                //Массив байт переводим в поток MemoryStream из System.IO и используем метод FromStream класса Image
                //И делаем привидение типа Image к Bitmap (полеморфизм) и возращаем Bitmap
                return (Bitmap)Image.FromStream(new MemoryStream(dat));
            }
            //Исключение если мало прав (нету доступа для выделения потока)
            catch(NotSupportedException g)
            {
                Debugger.Log(1, PATHCODE.WARNING, $"Ошибка потока. Войдите как администратор.\n{g}");
            }
            //Исключение нету интернета или доступа фаервол
            catch(WebException g)
            {
                Debugger.Log(1, PATHCODE.WARNING, $"Ошибка подключение к интернету!\n{g}");
            }
            //Остальные исключение которые могут возникнуть, не вызываем CRITICAL а вернём избр. вшитое
            catch(Exception g)
            {
                Debugger.Log(0, PATHCODE.ERROR, g,typeof(Program));
            }
            //Возвращаяем избр. по умолчанию
            return Properties.Resources.Empty;
        }

        public static bool IsAuth()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Login) && !string.IsNullOrWhiteSpace(Properties.Settings.Default.Password))
                {
                    var command = SQL.CreateCommand();
                    command.CommandText = $"SELECT * FROM Users WHERE [Email] = \'{Properties.Settings.Default.Login}\' AND [Password] = \'{Properties.Settings.Default.Password}\'";
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                }
            }
            catch(Exception g)
            {
                Debugger.Log(0, PATHCODE.CRITICAL_ERROR, g, typeof(Program));
            }
            
            return false;
        }
    }
}
