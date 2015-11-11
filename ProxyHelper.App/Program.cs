using System;
using System.Threading;
using System.Windows.Forms;
using Fiddler;

namespace ProxyHelper.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += (sender, args) =>
            {
                if (FiddlerApplication.IsStarted())
                {
                    FiddlerApplication.Shutdown();
                    Thread.Sleep(1000);
                }
            };
            Application.Run(new StatusForm());
        }
    }
}
