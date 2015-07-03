using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Reminiscent
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //public static bool bKTDongMo = true;                         //true: chưa đóng form _ false: đã đóng form

        [STAThread]
        static void Main()
        {
            Mutex mutex = new System.Threading.Mutex(false, "GUI");
            try
            {
                if (mutex.WaitOne(0, false))
                {
                    // Run the application
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmMain());
                }
                else
                {
                    MessageBox.Show("Reminiscent is already running!", "Reminiscent");
                }
            }
            finally
            {
                if (mutex != null)
                {
                    mutex.Close();
                    mutex = null;
                }
            }
        }
    }
}
