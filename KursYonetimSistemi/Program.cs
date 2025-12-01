using System;
using System.Windows.Forms;
using KursYonetimSistemi.Forms;
using KursYonetimSistemi.Services;

namespace KursYonetimSistemi
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
            Application.Run(new MainForm());
        }
    }
}
