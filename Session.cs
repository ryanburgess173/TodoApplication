using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    class Session
    {
        private DatabaseManipulator dm;
        private string user;

        public Session(string username)
        {
            this.dm = new DatabaseManipulator();
            this.user = username;
        }

        public void setUser(string user)
        {
            this.user = user;
        }
        public string getUser()
        {
            return this.user;
        }

        public DatabaseManipulator getDatabaseManipulator()
        {
            return this.dm;
        }
    }
}
