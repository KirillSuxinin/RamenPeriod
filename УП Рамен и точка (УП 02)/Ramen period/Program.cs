using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ramen_period
{
    internal static partial class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread thInitOpenServer = new Thread(() =>
            {
                try
                {
                    Debugger.Log(0, PATHCODE.WARNING, "Start connect server", typeof(Program));
                    SQL.Open();
                    Debugger.Log(1, PATHCODE.MESSAGE, $"End connect server / state: {SQL.State}", typeof(Program));
                }
                catch(Exception g)
                {
                    Debugger.Log(-1, PATHCODE.CRITICAL_ERROR, g, typeof(Program));
                }
            });
            thInitOpenServer.Start();
            Debugger.Log(0, PATHCODE.MESSAGE, "Main StartUp()!", typeof(Program));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    
}
