using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleCustomException
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var hasInnerException = false;
            var exception = e.ExceptionObject as Exception;

            if (exception.InnerException != null)
                hasInnerException = true;

            string exceptionMessage;
            if (hasInnerException)
                exceptionMessage = $"{ exception.InnerException.Message} : {exception.InnerException.StackTrace}";
            else
                exceptionMessage = $"{exception.Message} : {exception.StackTrace}";

            MessageBox.Show(exceptionMessage, exception.Message);
            Application.Exit();
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            var hasInnerException = false;
            var exception = e.Exception;

            if (exception.InnerException != null)
                hasInnerException = true;

            string exceptionMessage;
            if (hasInnerException)
                exceptionMessage = $"{ exception.InnerException.Message} : {exception.InnerException.StackTrace}";
            else
                exceptionMessage = $"{exception.Message} : {exception.StackTrace}";

            MessageBox.Show(exceptionMessage, exception.Message);
            Application.Exit();
        }
    }
}
