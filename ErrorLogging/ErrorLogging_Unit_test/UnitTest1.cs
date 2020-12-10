using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErrorLogging_Unit_test
{
    [TestClass]
    public class UnitTest1
    {
        ErrorLogging.Logging log;
        SqlConnection sql;
        /// <summary>
        /// Creates a new instance of the Logging Class
        /// </summary>
        [TestMethod]
        public void CreateNewLogging()
        {
            SqlConnection sql1 = new SqlConnection();
            log = new ErrorLogging.Logging((SqlConnection)sql1);
        }
        [TestMethod]
        public void WriteToFile()
        {

            
            Assert.IsTrue(log.ToFile());
        }

        [TestMethod]
        public void WriteToDB()
        {

        }
    }
}
