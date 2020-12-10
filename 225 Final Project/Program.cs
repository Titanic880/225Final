using System;
using System.IO;
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

            //Deletes all the files
            Directory.Delete("Temp");
            ErrorLogging.Logging.Output("End of Program!", ErrorLogging.Logging.ErrorLevel.None);
        }
    }
}
