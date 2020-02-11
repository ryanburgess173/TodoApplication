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

        public void executeScript()
        {
            this.command = new SqlCommand(this.sql, this.getConn());
            this.dataReader = command.ExecuteReader();
        }

        public void groupByUsersQuery()
        {
            this.sql = "EXECUTE groupByUsers;";
            this.executeScript();
        }
    }
}
