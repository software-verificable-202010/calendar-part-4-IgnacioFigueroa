using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    static class Constants
    {
        public const int WeeksToShowOnCalendar = 7;
        public const int IndexToCreateMonth = 1;
        public const int MonthsToRemove = -1;
        public const int FirstWeekOfMonth = 1;
        public const int SecondWeekOfMonth = 2;
        public const int DaysIndexInWeek = 6;
        public const int FirstDayOfweek = 1;
        public const int FirstDayOfWeekIndex = 0;
        public const string DataGridPlaceHolder = "";
        public const int SundayIndex = 7;
        public const int IndexNormalizer = 1;
        public const int NextMonthInterval = 1;
        public const int PreviousMonthInterval = -1;
        public const int NextWeekInterval = 7;
        public const int PreviousWeekInterval = -7;
        public const int ConvertNegative = -1;
        public const int MonthCalendarSelectorIndex = 0;
        public const string MonthFormat = "MMMM";
        public const string MonthAbbreviatedFormat = "MMM";
        public const string TimeSpanHourMinutesFormat = @"hh\:mm";
        public const string ImportantFieldsEmptyMessage = "Please enter title and time";
        public const string StartDateGreaterThanEndDateMessage = "Start time must be greater than end time";
        public const string AppointmentCreatedMessage = "Appointment created";
        public const int MaxLengthTitleWithTime = 6;
        public const int MaxLengthTitleWithTimeToShow = 3;
        public const int MaxLenghtTitleWithoutTime = 13;
        public const int MaxLenghtTileWithoutTimeToShow = 9;
        public const string AppointmentsSerializationPath = "../../appointments.bin";
        public const string UsersSerializationPath = "../../users.bin";
        public const string AppointmentsSeparator = "\n";
        public const string EmptyOrNullUsernameMessage = "Please enter a valid username";
        public const string NotYourAppointmentMessage = "You are not the owner of this appointment";
        public static readonly List<(TimeSpan, TimeSpan)> WeekCalendarTimeIntervals = new List<(TimeSpan, TimeSpan)>
        {
            (new TimeSpan(0,0,0), new TimeSpan(0,59,59)),
            (new TimeSpan(1,0,0), new TimeSpan(1,59,59)),
            (new TimeSpan(2,0,0), new TimeSpan(2,59,59)),
            (new TimeSpan(3,0,0), new TimeSpan(3,59,59)),
            (new TimeSpan(4,0,0), new TimeSpan(4,59,59)),
            (new TimeSpan(5,0,0), new TimeSpan(5,59,59)),
            (new TimeSpan(6,0,0), new TimeSpan(6,59,59)),
            (new TimeSpan(7,0,0), new TimeSpan(7,59,59)),
            (new TimeSpan(8,0,0), new TimeSpan(8,59,59)),
            (new TimeSpan(9,0,0), new TimeSpan(9,59,59)),
            (new TimeSpan(10,0,0), new TimeSpan(10,59,59)),
            (new TimeSpan(11,0,0), new TimeSpan(11,59,59)),
            (new TimeSpan(12,0,0), new TimeSpan(12,59,59)),
            (new TimeSpan(13,0,0), new TimeSpan(13,59,59)),
            (new TimeSpan(14,0,0), new TimeSpan(14,59,59)),
            (new TimeSpan(15,0,0), new TimeSpan(15,59,59)),
            (new TimeSpan(16,0,0), new TimeSpan(16,59,59)),
            (new TimeSpan(17,0,0), new TimeSpan(17,59,59)),
            (new TimeSpan(18,0,0), new TimeSpan(18,59,59)),
            (new TimeSpan(19,0,0), new TimeSpan(19,59,59)),
            (new TimeSpan(20,0,0), new TimeSpan(20,59,59)),
            (new TimeSpan(21,0,0), new TimeSpan(21,59,59)),
            (new TimeSpan(22,0,0), new TimeSpan(22,59,59)),
            (new TimeSpan(23,0,0), new TimeSpan(23,59,59))

        };
        public enum VisualizationTypes { Month, Week }
        public enum DaysOfWeekAbbreviated { Mon, Tue, Wed, Thu, Fri, Sat, Sun }
    }
}
