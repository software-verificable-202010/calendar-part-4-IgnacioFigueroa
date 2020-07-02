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
        #region fields
        private string userName;
        #endregion
        #region properties
        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public User(string userName)
        {
            this.userName = userName;
        }
        #endregion
    }
}
