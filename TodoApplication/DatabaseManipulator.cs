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

        public string setSQL(String sql)
        {
            this.sql = sql;
            try
            {
                this.command = new SqlCommand(this.sql, this.getConnection());
                return "Success.";
            }catch(Exception exception)
            {
                return exception.ToString();
            }
        }

        public string executeQueryScript()
        {
            try
            {
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

        public void newDataReader()
        {
            this.dataReader = command.ExecuteReader();
        }

        public void closeDataReader()
        {
            this.dataReader.Close();
        }
    }
}
