using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TodoApplication
{
    class DatabaseManipulator : DatabaseConnection
    {
        private SqlCommand command;
        private SqlDataReader dataReader;
        private String sql;

        public DatabaseManipulator(){}

        public void setSQL(String sql)
        {
            this.sql = sql;
        }

        public string executeQueryScript()
        {
            try
            {
                this.command = new SqlCommand(this.sql, this.getConnection());
                this.dataReader = command.ExecuteReader();
                return "Success.";
            }catch(Exception exception)
            {
                return exception.ToString();
            }
        }

        public string executeInsertScript()
        {
            try
            {
                this.command = new SqlCommand(this.sql, this.getConnection());
                command.ExecuteNonQuery();
                return "Success.";
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }


        public void groupByUsersQuery()
        {
            this.sql = "EXECUTE groupByUsers;";
            this.executeQueryScript();
        }

        public SqlDataReader getDataReader()
        {
            return this.dataReader;
        }

        public void closeDataReader()
        {
            this.dataReader.Close();
        }
    }
}
