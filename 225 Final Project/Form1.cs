using System;
using System.IO;
using ErrorLogging;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

namespace _225_Final_Project
{
    public partial class Form1 : Form
    {
        public List<string> ProjectsPath { get; private set; } = new List<string>();
        public List<string> ProjectsName { get; private set; } = new List<string>();
        private const string SerializedLoc = "Save_File";
        Resources.SerializedObject savefile;
        //Outside Solution 
        readonly Sql_Interface.Interface sql = null;

        /// <summary>
        /// Accepts a bool to declare if the save file is found
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            savefile = new Resources.SerializedObject();

            //checks the save file
            if (!File.Exists(SerializedLoc))
            {
                File.Create(SerializedLoc).Close();
                MessageBox.Show("Save file not found, New one has been made");
                Logging.Output("Save File not found, new one has been made", Logging.ErrorLevel.Startup);
            }
            else
            {
                savefile = Resources.SerializedObject.DeSerializeClass(SerializedLoc);
            }
            //Sets the variables from savefile
            if(savefile != null)
            {
                ProjectsName = savefile.Names;
                ProjectsPath = savefile.FilePaths;
                Logging.OutputType = savefile.SaveType;
                Logging.TableBuilt = savefile.ErrorTable;
            }

            sql = new Sql_Interface.Interface(ConfigurationManager.AppSettings.Get("Connection"));

            //Add an errorlog message for Connected status
            SetError(true);

            if (!sql.Connected)
            {
                MessageBox.Show($"Sql Connection could not be made" +
                                $"{Environment.NewLine}Please check App.Config for connection string" +
                                $"{Environment.NewLine}Some features may not work properly without a working connection");
                Logging.Output("Connection Failed", Logging.ErrorLevel.Startup);
            }
            else
            {
                Logging.Output("Connected!",Logging.ErrorLevel.Startup);
            }
        }

        ~Form1()
        {
            //Saves to the savefile
            savefile.Save(ProjectsPath, ProjectsName);
            savefile.SerializeClass(SerializedLoc);

            //Deletes all the files
            Directory.Delete("Temp");
            Logging.Output("End of Program!", Logging.ErrorLevel.None);
        }

        private void BtnErrorChage_Click(object sender, EventArgs e)
        {
            if (Logging.sql == null)
                Logging.sql = sql;

            //Flips the output type
            Logging.OutputType = !Logging.OutputType;

            //Checks the output type, and flips it
            if (Logging.OutputType)
                MessageBox.Show("Now outputting to Database!");
            else
                MessageBox.Show("Now outputting to File!");
        }

        /// <summary>
        /// uses a bool to check if its the startup process, leave blank otherwise
        /// </summary>
        /// <param name="startup"></param>
        private void SetError(bool startup = false)
        {
            if (Logging.sql == null)
                Logging.sql = sql;

            //Checks for startup
            if (!startup) 
            { 
            //Flips the output type
            Logging.OutputType = !Logging.OutputType;

            //Checks the output type, and flips it
            if (Logging.OutputType)
                MessageBox.Show("Now outputting to Database!");
            else
                MessageBox.Show("Now outputting to File!");
            }
        }

        private void BtnTestDB_Click(object sender, EventArgs e)
        {
            
        }


        #region FileManip
        private void BtnRunProject_Click(object sender, EventArgs e)
        {
            //Must be at the top, checks index of listbox
            if (listBox1.SelectedIndex >= ProjectsPath.Count || listBox1.SelectedIndex < 0)
                listBox1.SelectedIndex = 0;
            string copypath = ProjectsPath[listBox1.SelectedIndex] + listBox1.SelectedItem;
            string runpath = "Temp\\" + listBox1.SelectedItem;

           //if(listBox1.SelectedItem.ToString().Split('.')[1].ToLower() != ".csproj")
           //    copypath = projectsPath[listBox1.SelectedIndex] + listBox1.SelectedItem;
            CopyDir(copypath);
            RunDir(runpath);
        }

        private void BtnAddProj_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.FileName = "Solution Files (*sln)";
            ofd.ShowDialog();

            //Splits path to be sorted
            string[] PathArr = ofd.FileName.Split('\\');


            //Removes the File Name from the path
            string Path = null;
            for(int i = 0; i < PathArr.Length-1 ;i++)
                Path += PathArr[i]+"\\";

            //Adds the path and project to different lists
            ProjectsPath.Add(Path);
            ProjectsName.Add(PathArr[PathArr.Length-1]);
            listBox1.Items.Add(ProjectsName[ProjectsName.Count-1]);
            listBox1.Update();
        }

        private void CopyDir(string SourceFilePath)
        {
            if (!File.Exists("Temp"))
                Directory.CreateDirectory("Temp");

            //if (File.Exists("Temp\\File"))
            //    File.Delete("Temp\\" + listBox1.SelectedItem);

            if(!File.Exists("Temp\\"+listBox1.SelectedItem))
                File.Copy(SourceFilePath, "Temp\\" + listBox1.SelectedItem);
        }

        private void RunDir(string FilePath)
        {
            System.Diagnostics.Process.Start(FilePath);
        }

        /// <summary>
        /// https://stackoverflow.com/questions/40557717/c-sharp-the-system-cannot-find-the-path-specified
        /// Didn't work the way i wanted it to; left for historic purposes
        /// </summary>
        /// <param name="shortcutName"></param>
        /// <param name="shortcutPath"></param>
        /// <param name="targetFileLocation"></param>
        //public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        //{
        //using IWshRuntimeLibrary;
        //    //used to enter this method
        //    //if (listBox1.SelectedIndex < projectsPath.Count || listBox1.SelectedIndex < 0)
        //    //    CreateShortcut("Temp", "", projectsPath[listBox1.SelectedIndex]);
        //
        //    string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
        //    WshShell shell = new WshShell();
        //    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
        //    
        //    shortcut.Description = "My shortcut description";   // The description of the shortcut
        //    shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
        //    shortcut.Save();                                    // Save the shortcut
        //}
        #endregion FileManip

    }
}