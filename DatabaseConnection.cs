using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoApplication
{
    public class DatabaseConnection
    {
        private string connectionString;
        private SqlConnection conn;

        public DatabaseConnection()
        {
            this.connectionString = @"Data Source=DESKTOP-U4J07QN\SQLEXPRESS;Integrated Security=False;Initial Catalog=Todos;User ID=sa;Password=programmer;";
            this.conn = new SqlConnection(connectionString);
            this.conn.Open();
        }

        public void closeConnection()
        {
            this.conn.Close();
        }

        public SqlConnection getConn()
        {
            return this.conn;
        }
    }
}
