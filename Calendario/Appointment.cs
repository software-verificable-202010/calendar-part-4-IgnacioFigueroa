using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    [Serializable]
    public class Appointment
    {
        #region fields
        public static int nextId = 1;
        private int id;
        private string title;
        private string description;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private DateTime date;
        private User owner;
        private List<User> invitedUsers;
        #endregion
        #region properties
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public TimeSpan StartTime
        {
            get => startTime;
            set => startTime = value;
        }

        public TimeSpan EndTime
        {
            get => endTime;
            set => endTime = value;
        }

        public DateTime Date
        {
            get => date;
            set => date = value;
        }

        public List<User> InvitedUsers
        {
            get => invitedUsers;
            set => invitedUsers = value;
        }

        public User Owner
        {
            get => owner;
            set => owner = value;
        }
        #endregion
        #region methods
        public Appointment(string title, string description, TimeSpan startTime, TimeSpan endTime, DateTime date, User owner, List<User> invitedUsers)
        {
            id = nextId;
            this.title = title;
            this.description = description;
            this.startTime = startTime;
            this.endTime = endTime;
            this.date = date;
            this.owner = owner;
            this.invitedUsers = invitedUsers;
            nextId += Constants.IndexNormalizer;
        }
        #endregion
    }
}
