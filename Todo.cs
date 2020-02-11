using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    class Todo
    {
        private string name, description, user, dateTime;
        private bool completed;
        public Todo(string name, string description, string user, string dateTime)
        {
            this.name = name;
            this.description = description;
            this.user = user;
            this.dateTime = dateTime;
            this.completed = false;
        }

        public void complete()
        {
            this.completed = true;
        }
    }
}
