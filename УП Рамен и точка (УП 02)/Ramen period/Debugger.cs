using System;
namespace Ramen_period
{
    /// <summary>
    /// Перечисление СООБЩЕНИЕ,ПРЕДУПРЕЖДЕНИЕ,ОШИБКА,ВЫЛЕТ
    /// </summary>
    internal enum PATHCODE
    {
        MESSAGE = 0,
        WARNING = 1,
        ERROR = 2,
        CRITICAL_ERROR = 3
    }
    internal static class Debugger
    {


        /// <summary>
        /// Поле определяет состояние дебаггера
        /// </summary>
        public static bool IsDebug = true;
        /// <summary>
        /// Поле определяет состояние записи в файл
        /// </summary>
        public static bool IsWriteFile = true;
        /// <summary>
        /// Поле определяет состояние вывода в консоль
        /// </summary>
        public static bool IsWriteConsole = true;

        /// <summary>
        /// Метод по выводе ошибок и сообщений
        /// </summary>
        /// <param name="LEVEL">УРОВЕНЬ (НАПРИМЕР ИТЕРАЦИЯ ЦИКЛА)</param>
        /// <param name="PATH_CODE">КОД ОШИБКА,ПРЕДУПРЕЖДЕНИЕ</param>
        /// <param name="MESSAGE">ТЕЛО ПРЕДУПРЕЖДЕНИЯ/ОШИБКИ</param>
        public static void Log(int LEVEL, PATHCODE PATH_CODE, object MESSAGE,Type AccessPoint = null)
        {
            if (IsDebug)
            {
                System.Diagnostics.Debugger.Log(LEVEL, "Debug", MESSAGE.ToString().TrimEnd('\n')+"\n");
                if(PATH_CODE == PATHCODE.CRITICAL_ERROR)
                {
                    System.IO.File.AppendAllText("CRITICAL_ERROR.log", $"{System.DateTime.Now.ToShortTimeString()}\tCRIT CODE:\nLEVEL: {LEVEL}\nMESSAGE:{MESSAGE}{Environment.NewLine}", System.Text.Encoding.UTF8);
                    Environment.Exit(LEVEL);
                }
                switch (PATH_CODE)
                {
                    case PATHCODE.MESSAGE:  Console.ForegroundColor = ConsoleColor.White; 
                        break;
                    case PATHCODE.WARNING: Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case PATHCODE.ERROR: Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }

                if(AccessPoint != null)
                {
                    MESSAGE = MESSAGE.ToString().TrimEnd('\n') + $"{Environment.NewLine}PointNamespace: {AccessPoint.FullName}{Environment.NewLine}";
                }

                if (IsWriteConsole)
                    Console.WriteLine($"\tLEVEL: {LEVEL}\nMESSAGE: {MESSAGE}");
                Console.ForegroundColor = ConsoleColor.White;
                if(IsWriteFile && PATH_CODE != PATHCODE.MESSAGE)
                    System.IO.File.AppendAllText("Debug.log", $"[{System.DateTime.Now.ToShortDateString()} {System.DateTime.Now.ToShortTimeString()}]: {PATH_CODE} LEVEL: {LEVEL}{Environment.NewLine}{MESSAGE}{Environment.NewLine}{Environment.NewLine}", System.Text.Encoding.UTF8);
            }
        }
    }
}
