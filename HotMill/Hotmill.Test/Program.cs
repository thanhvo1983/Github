using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hotmill.Test
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
            //Application.Run(new BinaryTextConverterForm());
            Application.Run(new BackupDataForm());
            //Application.Run(new TestChartForm_V4());
            //Application.Run(new Kvics.HotMill.Forms.FormFinishSupport1_V4());
        }
    }
}