using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DummyProcon
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
            //Application.Run(new MainForm1());
            //Application.Run(new T900ReaderForm());
            //Application.Run(new ParseTestingForm());
            Application.Run(new Data4HSS5Form());
        }
    }
}