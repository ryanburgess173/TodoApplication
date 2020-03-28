using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace TodoApplication.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void createDatabaseConnection()
        {
            try
            {
                DatabaseConnection db_connection = new DatabaseConnection();
                string connectionString = @"Data Source=DESKTOP-U4J07QN\SQLEXPRESS;Integrated Security=False;Initial Catalog=Todos;User ID=sa;Password=programmer2;MultipleActiveResultSets=True;";
                SqlConnection expected_result = new SqlConnection(connectionString);
                expected_result.Open();

                Assert.AreEqual(expected_result, db_connection.getConnection());
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
            
        }
    }
}
