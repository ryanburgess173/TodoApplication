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

        public Session()
        {
            this.dm = new DatabaseManipulator();
        }

        public void setUser(string user)
        {
            this.user = user;
        }

        public DatabaseManipulator getDatabaseManipulator()
        {
            return this.dm;
        }
    }
}
