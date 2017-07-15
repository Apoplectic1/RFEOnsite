using System;
using System.Windows.Forms;

namespace RFEOnSite
{
    static class Program
    {
        public static GlobalData gRFEOnSite;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
