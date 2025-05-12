using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ramen_period.Dialogs
{
    public static class BindL<T>
    {
        static Thread th_HANDLER;
        private static void th_HANDLER_INVOKE(object p)
        {
            Form frm = (p as Form);
            while (!frm.IsDisposed)
            {
                if (frm.DialogResult == DialogResult.Abort)
                {

                    Debugger.Log(9, PATHCODE.MESSAGE, $"CLOSE [{p}] FORM BY bak.StateUpdater.cs", typeof(T));
                    try
                    {

                        frm.Invoke(new Action(() =>
                        {
                            frm.Close();
                        }));

                        break;
                    }
                    catch (Exception g)
                    {
                        break;
                    }
                }

                Thread.Sleep(1000);

            }
           
            Debugger.Log(0, PATHCODE.ERROR, $"WHILE END by BindL.th_handler", typeof(T));
            
        }
        public static void Set(T f)
        {
            (f as Form).Load += (a, b) =>
            {
                if ((f as Form).DialogResult == DialogResult.None)
                {
                    th_HANDLER = new Thread(th_HANDLER_INVOKE);
                    th_HANDLER.IsBackground = true;
                    th_HANDLER.Start(f);
                }
            };
        }
    }

}
