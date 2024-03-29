﻿using System;
using System.Windows.Forms;

namespace _225_Final_Project
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
            Application.Run(new Form1());
            ErrorLogging.Logging.Output("End of Program!", ErrorLogging.Logging.ErrorLevel.None);
        }
    }
}
