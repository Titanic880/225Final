using System;
using System.IO;
using Sql_Interface;
using System.Data.SqlClient;

/// <summary>
/// Used to output or check for errors within the main project
/// </summary>
namespace ErrorLogging
{
    public static class Logging
    {
        #region Variables
        /// <summary>
        /// Determines the output type of the error
        /// </summary>
        public enum ErrorLevel
        {
            Startup = 69,
            Debug,
            None = 0,
            Minor,
            Intermediate,
            Major,
            Extreme
        }
        /// <summary>
        /// Standard Sql Interface
        /// </summary>
        public static Interface sql;
        /// <summary>
        /// Changing this changes the table for the entire file
        /// </summary>
        private const string TableName = "[Logging]";
        /// <summary>
        /// Changing this changes the File that this points to
        /// </summary>
        private const string file = "ErrorLog.txt";
        /// <summary>
        /// Says if the table has been built
        /// </summary>
        public static bool TableBuilt = false;
        /// <summary>
        /// True is Database, false is File
        /// </summary>
        public static bool OutputType = false;
        #endregion Variables

        /// <summary>
        /// Builds the Data base table that is used
        /// </summary>
        /// <returns></returns>
        private static void Build_Table()
        {
            string Table_Loggging = "Create Table "+TableName+" (" +
                "ID int not null Primary key Identity(0,1)," +
                "LogLevel int not null," +
                "Error_Desc varchar(50)," +
                "Time_Of_Error DateTime not null" +
                ");";

            sql.NonExecute(Table_Loggging);
            TableBuilt = true;
        }

        #region Outputs
        /// <summary>
        /// Accepts the error values and passes them to the respective output type
        /// </summary>
        /// <param name="level"></param>
        /// <param name="input"></param>
        public static void Output(string input, ErrorLevel level = ErrorLevel.None)
        {
            if (OutputType)
            {
                if (!TableBuilt)
                    Build_Table();

                ToDB(level, input);
            }
            else
            {
                ToFile(level, input);
            }
        }
        /// <summary>
        /// Outputs error to a File
        /// </summary>
        /// <param name="level"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool ToFile(ErrorLevel level, string input)
        {
            try
            {
                if (!File.Exists(file))
                {
                    File.Create(file).Close();
                    File.WriteAllText(file, ErrorLevel.Startup + " Error File created");
                }
                File.AppendAllText(file, level +" "+input);
            }
            catch //(Exception ex)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Outputs error to a Database table
        /// </summary>
        /// <param name="level"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static void ToDB(ErrorLevel level, string input)
        {
            //Inserts Data to the table 
            SqlCommand cmd = new SqlCommand($"Insert into {TableName} Values " +
                $"('@level','@input','{DateTime.Now}')");

            cmd.Parameters.AddWithValue("@level", level);
            cmd.Parameters.AddWithValue("@input", input);
            sql.NonExecute(cmd);
        }
        #endregion Outputs
    }
}
