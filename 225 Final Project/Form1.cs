using System;
using System.IO;
using System.Data;
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
        Sql_Interface.Interface sql = null;

        /// <summary>
        /// Accepts a bool to declare if the save file is found
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Startup();
        }
        #region Buttons
        private void BtnRecheck_Click(object sender, EventArgs e)
        {
            Startup();
        }

        private void BtnAddProj_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.FileName = "Solution Files (*sln)";
            ofd.ShowDialog();
            AddProject(ofd);
        }
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(index);
            ProjectsName.RemoveAt(index);
            ProjectsPath.RemoveAt(index);
            MessageBox.Show("Removed Entry!");
        }
        private void BtnRunProject_Click(object sender, EventArgs e)
        {
            //Must be at the top, checks index of listbox
            if (listBox1.SelectedIndex >= ProjectsPath.Count || listBox1.SelectedIndex < 0)
                listBox1.SelectedIndex = 0;
            string path = ProjectsPath[listBox1.SelectedIndex] + listBox1.SelectedItem;

            RunFile(path);
        }
        
        private void BtnGit_Click(object sender, EventArgs e)
        {
            Resources.GitClone gc = new Resources.GitClone();
            gc.ShowDialog();
            MessageBox.Show("Please add Main object to the list before continuing!");

            //Lets the user add a file without needing to click the Add button
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory()
            };
            ofd.ShowDialog();

            AddProject(ofd);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
            MessageBox.Show("Saved to File!");
        }
        private void BtnErrorChange_Click(object sender, EventArgs e)
        {
            SetError();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            SaveFile();
            this.Close();
        }
        #endregion Buttons

        #region Methods
        /// <summary>
        /// What is run on start up
        /// </summary>
        private void Startup()
        {
            sql = new Sql_Interface.Interface(ConfigurationManager.AppSettings.Get("Connection"));

            LoadFile();

            //Add an errorlog message for Connected status
            SetError(true);

            //Checks to see if the Interface has connected
            if (!sql.Connected)
            {
                MessageBox.Show($"Sql Connection could not be made" +
                                $"{Environment.NewLine}Please check App.Config for connection string" +
                                $"{Environment.NewLine}Some features may not work properly without a working connection");
                Logging.Output("Connection Failed", Logging.ErrorLevel.Startup);
            }
            else
                Logging.Output("Connected!", Logging.ErrorLevel.Startup);
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
                {
                    lblSave.Text = "Database";
                    MessageBox.Show("Now outputting to Database!");
                }
                else
                {
                    lblSave.Text = "File";
                    MessageBox.Show("Now outputting to File!");
                }
            }
        }
        /// <summary>
        /// Adds a given file to the listbox and subsequent lists
        /// </summary>
        /// <param name="ofd"></param>
        private void AddProject(OpenFileDialog ofd)
        {
            //Splits path to be sorted
            string[] PathArr = ofd.FileName.Split('\\');

            //Removes the File Name from the path
            string Path = null;
            for (int i = 0; i < PathArr.Length - 1; i++)
                Path += PathArr[i] + "\\";

            //Adds the path and project to different lists
            ProjectsPath.Add(Path);
            ProjectsName.Add(PathArr[PathArr.Length - 1]);
            listBox1.Items.Add(ProjectsName[ProjectsName.Count - 1]);
            listBox1.Update();
        }
        /// <summary>
        /// Runs the Item Selected in the main listbox
        /// </summary>
        /// <param name="FilePath"></param>
        private void RunFile(string FilePath)
        {
            //https://stackoverflow.com/questions/1283584/how-do-i-launch-files-in-c-sharp
            //FULL CREDIT TO THIS PERSON
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process
                {
                    EnableRaisingEvents = false
                };
                proc.StartInfo.FileName = FilePath;
                proc.Start();
            }
            catch (Exception ex)
            {
                Logging.Output(ex.Message, Logging.ErrorLevel.Intermediate);
                MessageBox.Show("Failed to Launch " + Environment.NewLine + " Check Error log for details");
            }
        }
        /// <summary>
        /// Saves the contents of the listbox to the serialized file
        /// </summary>
        private void SaveFile()
        {
            //Checks if its to database or file
            if (Logging.OutputType)
            {
                //Checks for the tables, if they arent built then builds them
                if (!Logging.TableBuilt)
                    Logging.Output("Tables not built yet before needed!", Logging.ErrorLevel.Intermediate);


                //Sends the Lists to the database
                //Deletes entire Table -- The contents should be within the list regardless
                sql.NonExecute("DELETE FROM [DataSave]");
                //Executes a query for each entry -- There should be a faster method, but time restraint
                for (int i = 0; i < ProjectsName.Count; i++)
                {
                    string Query = "Insert into [DataSave] "
                          + $"Values('{ProjectsName[i]}', '{ProjectsPath[i]}')";
                    sql.NonExecute(Query);
                }
            }
            else
            {
                //Saves to the savefile
                savefile = new Resources.SerializedObject(ProjectsPath, ProjectsName);
                savefile.SerializeClass(SerializedLoc);
            }
        }
        /// <summary>
        /// Loads from both the Database and the File
        /// </summary>
        private void LoadFile()
        {
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
                //Sets the variables from savefile
                if (savefile != null)
                {
                    ProjectsName = savefile.Names;
                    ProjectsPath = savefile.FilePaths;
                    Logging.OutputType = savefile.SaveType;
                    Logging.TableBuilt = savefile.ErrorTable;
                    //Adds Names to the list
                    foreach (string obj in ProjectsName)
                        listBox1.Items.Add(obj);
                }
            }

            //Blank scope for organization
            {
                //Run this to know that the databases exist
                Logging.Output("Loading from Database", Logging.ErrorLevel.Startup);
                string Query = "Select DISTINCT FName, FDirectory from [DataSave]";
                DataTable dt = sql.Execute(Query);
                foreach (DataRow a in dt.Rows)
                {
                    ProjectsName.Add(a.ItemArray[0].ToString());
                    listBox1.Items.Add(a.ItemArray[0].ToString());
                    ProjectsPath.Add(a.ItemArray[1].ToString());
                }
            }
        }
        #endregion Methods

        #region Historical
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
        #endregion Historical
    }
}