using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    [Serializable]
    public class User
    {
        private string username;

        public string Username
        {
            get => username;
            set => username = value;
        }

        public User(string username)
        {
            this.username = username;
        }
    }
}
