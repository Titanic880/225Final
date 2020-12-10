using System;
using System.Diagnostics;
//Required for this to work
//using System.Collections.ObjectModel;
//using System.Management.Automation;
//using System.Management.Automation.Runspaces;

//Ambitious is never a question of whether I should, it is a question of can I?
//https://www.codeproject.com/Articles/18229/How-to-run-PowerShell-scripts-from-C
//For without Ambition, What is the point of progress?
//https://duanenewman.net/blog/post/running-powershell-scripts-from-csharp/
//And without progress, Can we ever say we learned? or lived?
//https://www.guru99.com/powershell-tutorial.html
namespace _225_Final_Project.Resources
{
    /// <summary>
    /// Holds Methods that use powershell to interact with the computer
    /// </summary>
    public class PowerShell
    {
        /// <summary>
        /// Clones a Repo from github and puts it in a folder with the repo name
        /// </summary>
        /// <param name="Link"></param>
        public static bool GitClone(string Link)
        {
            //Gets the repository's Name
            string item = Link.Split('/')[Link.Split('/').Length - 1];

            Byte[] bytes = System.Text.Encoding.Unicode.GetBytes($"cd {item} {Environment.NewLine} git clone {Link}");
            string Scripts = Convert.ToBase64String(bytes);

            ErrorLogging.Logging.Output(Scripts, ErrorLogging.Logging.ErrorLevel.Debug);
            try
            {
                //Makes a process that runs the powershell window with a predefined string input
                ProcessStartInfo start = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy unrestricted -EncodedCommand \"{Scripts}\"",
                    UseShellExecute = false
                };

                Process.Start(start);
            }
            catch (Exception Ex)
            {
                ErrorLogging.Logging.Output(Ex.Message, ErrorLogging.Logging.ErrorLevel.Major);
                return false;
            }

            ErrorLogging.Logging.Output("Cloned Repository Successfully!");
            return true;
        }
    }
}
