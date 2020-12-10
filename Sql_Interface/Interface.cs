using System;
using System.Data;
using System.Data.SqlClient;

// Main Sql Interface Class  --This is the EXACT same code between all 3/4 final assignments
// just in case you think you've seen it before

namespace Sql_Interface
{
    /// <summary>
    /// Primary interaction with the Sql Database
    /// </summary>
    public class Interface
    {
        /// <summary>
        /// Declares whether or not the connection is successful
        /// </summary>
        public bool Connected { get; private set; }
        #region Constructors
        /// <summary>
        /// Takes a Connection and tests it
        /// </summary>
        /// <param name="sql"></param>
        public Interface(SqlConnection sql)
        {
            Connections.sql = sql;
            if (Connections.Test_Conn())
                Connected = true;
            else
                Connected = false;
        }
        /// <summary>
        /// Takes a connection and tests it
        /// </summary>
        /// <param name="Connection"></param>
        public Interface(string Connection)
        {
            Connections.sql = new SqlConnection(Connection);
            if (Connections.Test_Conn())
                Connected = true;
            else
                Connected = false;
        }
        #endregion Constructors


        /// <summary>
        /// Basic Query that returns one value
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public string Scalar(string Query)
        {
            return Connections.RunScalar(Query);
        }

        /// <summary>
        /// Basic Query that returns one value
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public string Scalar(SqlCommand Query)
        {
            return Connections.RunScalar(Query);
        }
        /// <summary>
        /// Basic Query that returns a table
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public DataTable Execute(string Query)
        {
            return Connections.Query(Query);
        }

        /// <summary>
        /// Basic Query that has no return
        /// </summary>
        /// <param name="Query"></param>
        public void NonExecute(string Query)
        {
            Connections.RunNonQuery(Query);
        }
        /// <summary>
        /// Basic Query that has no return
        /// </summary>
        /// <param name="Query"></param>
        public void NonExecute(SqlCommand Query)
        {
            Connections.RunNonQuery(Query);
        }
    }

    /// <summary>
    /// Holds the methods that are used to connect to the DB
    /// </summary>
    internal static class Connections
    {
        /// <summary>
        /// Is the master connection for the file ;; Hidden af
        /// </summary>
        internal static SqlConnection sql;

        /// <summary>
        /// Tests the Sql Connection
        /// </summary>
        //Yes this is the Same code from ErrorLogging, but modified
        internal static bool Test_Conn()
        {
            string Table_Loggging = "Create Table Test_conn (" +
                 "ID int not null Primary key Identity(0,1)," +
                 "LogLevel int not null," +
                 "Error_Desc varchar(50)," +
                 "Time_Of_Error DateTime not null" +
                 ");";
            string check_tbl = "Select * from Test_conn";
            
            bool test = true;
            
            try
            {
                sql.Open();

                //Tests to see if the table exists, if it doesn't the runs the Table create
                try
                {
                    SqlCommand comm = new SqlCommand(check_tbl, sql);
                    comm.ExecuteScalar();
                }
                catch
                {
                    test = false;
                }
                if (!test)
                {
                    SqlCommand cmd = new SqlCommand(Table_Loggging, sql);
                    cmd.ExecuteScalar();
                }
                    SqlCommand drop = new SqlCommand("Drop Table Test_conn;",sql);
                    drop.ExecuteScalar();
                test = true;
            }
            catch
            {
                test = false;
            }
            finally
            {
                if (sql.State != ConnectionState.Closed)
                    sql.Close();
            }

            return test;
        }

        #region Execution
        /// <summary>
        /// Runs the Scalar method and returns the result, or the error log : check for error by substring(0,2)
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        //Credit to my version from 'ChatApp270'
        internal static string RunScalar(string Query)
        {
            try
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand(Query, sql);
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return "--"+ex.Message;
            }
            finally
            {
                if (sql.State != ConnectionState.Closed)
                    sql.Close();
            }
        }
        /// <summary>
        /// Takes command and runs it
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        internal static string RunScalar(SqlCommand Query)
        {
            try
            {
                sql.Open();
                Query.Connection = sql;
                return Query.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return "--" + ex.Message;
            }
            finally
            {
                if (sql.State != ConnectionState.Closed)
                    sql.Close();
            }
        }
        /// <summary>
        /// Fills a DataTable and returns it
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        internal static DataTable Query(string Query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Query,sql);
            adapter.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Executes a Query without a return
        /// </summary>
        /// <param name="Query"></param>
        public static void RunNonQuery(string Query)
        {
            try
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand(Query, sql);
                cmd.ExecuteNonQuery().ToString();
            }
            catch
            {
                
            }
            finally
            {
                if (sql.State != ConnectionState.Closed)
                    sql.Close();
            }
        }

        /// <summary>
        /// Executes a Query without a return
        /// </summary>
        /// <param name="Query"></param>s
        internal static void RunNonQuery(SqlCommand Query)
        {
            try
            {
                sql.Open();
                Query.Connection = sql;
                Query.ExecuteNonQuery().ToString();
            }
            catch
            {

            }
            finally
            {
                if (sql.State != ConnectionState.Closed)
                    sql.Close();
            }
        }
        #endregion Execution
    }
}