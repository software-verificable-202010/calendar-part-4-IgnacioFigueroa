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
        private string title;
        private string description;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private DateTime date;

        public Appointment(string title, string description, TimeSpan startTime, TimeSpan endTime, DateTime date)
        {
            this.title = title;
            this.description = description;
            this.startTime = startTime;
            this.endTime = endTime;
            this.date = date;
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
    }
}
