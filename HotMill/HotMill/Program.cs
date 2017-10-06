using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Kvics.HotMill.Forms;

namespace Kvics.HotMill
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception)
            {
                MainForm.ShowError(HotMillErrorType.UNKNOWN_ERROR);
                Application.Exit();
            }
        }
    }
}