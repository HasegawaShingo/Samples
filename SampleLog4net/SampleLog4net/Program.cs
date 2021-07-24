using System;
using System.Windows.Forms;
using log4net;

namespace SampleLog4net
{
    static class Program
    {
        // Log4net ロガーインスタンス
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Logger.Info("Start Main form");
            Application.Run(new Form1(Logger));
            Logger.Info("End Main form");
        }
    }
}
