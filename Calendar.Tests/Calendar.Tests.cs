using NUnit.Framework;
using System.Collections.Generic;
using CalendarProject;
using System;
namespace Calendar.Tests
{
    [TestFixture]
    public class Tests
    {
        private Appointment _appointment = null;
        private User _user = null;
        private User _invitedUser = null;
        private DateTime currentDateToTest = new DateTime(2020, 12, 3);
        private TimeSpan appointmentStartTime = new TimeSpan(12, 30, 00);
        private TimeSpan appointmentEndTime = new TimeSpan(14, 45, 00);

        [SetUp]
        public void Setup()
        {
            _user = new User("Username");
            _invitedUser = new User("InvitedUser");
            _appointment = new Appointment("Test title", "Test description", appointmentStartTime, appointmentEndTime, currentDateToTest, _user, new List<User>() { } );
            CalendarProject.Calendar.CurrentDate = currentDateToTest;
            CalendarProject.Calendar.Appointments = new List<Appointment> { _appointment };
            CalendarProject.Calendar.Users = new List<User> { _user, _invitedUser };
            CalendarProject.Calendar.CurrentUser = _user;
        }

        [TearDown]
        public void TearDown()
        {
            _appointment = null;
            _user = null;
            CalendarProject.Calendar.Appointments = null;
            CalendarProject.Calendar.Users = null;
            CalendarProject.Calendar.CurrentUser = null;
        }
    

        [Test]
        [Category("Calendar.cs Tests")]
        public void GetCurrentMonthWeeks_NotSundayFirstDayOfWeek_ReturnsCorrectMonthWeeks()
        {
            string[] firstWeek = new string[] { string.Empty, "1", "2", "3\n12:30Hrs - Tes...", "4", "5", "6" };
            string[] secondWeek = new string[] { "7", "8", "9", "10", "11", "12", "13" };
            string[] thirdWeek = new string[] { "14", "15", "16", "17", "18", "19", "20" };
            string[] fourthWeek = new string[] { "21", "22", "23", "24", "25", "26", "27" };
            string[] fifthWeek = new string[] { "28", "29", "30", "31", string.Empty, string.Empty, string.Empty };

            List<string[]> expected = new List<string[]> {firstWeek, secondWeek, thirdWeek, fourthWeek, fifthWeek  };
            List<string[]> result = CalendarProject.Calendar.GetCurrentMonthWeeks();

            Assert.AreEqual(expected, result);
       
        }

        [Test]
        [Category("Calendar.cs Tests")]
        public void GetCurrentWeekHours_WeekWithTwoMonthsAndOneAppointment_ReturnCorrectWeekHours()
        {

            List<string[]> expected = new List<string[]> { };
            for (int hour = 0; hour < 24; hour++)
            {
                if (hour == appointmentStartTime.Hours)
                {
                    expected.Add(new string[] { $"{hour} Hrs - {hour + 1} Hrs", string.Empty, string.Empty, string.Empty, "12:30-Tes...\n", string.Empty, string.Empty, string.Empty });
                }
                else if(hour > appointmentStartTime.Hours && hour <= appointmentStartTime.Hours + 2)
                {
                    expected.Add(new string[] { $"{hour} Hrs - {hour + 1} Hrs", string.Empty, string.Empty, string.Empty, "Test title\n", string.Empty, string.Empty, string.Empty });
                }
                else
                {
                    expected.Add(new string[] { $"{hour} Hrs - {hour + 1} Hrs", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty });
                }
                
            }
            List<string[]> result = CalendarProject.Calendar.GetCurrentWeekHours();

            Assert.AreEqual(expected, result);
        }

        [Test]
        [Category("Calendar.cs Tests")]
        public void GetAppointmentsDetailsMonthCalendar_DateWithAppointmentSelected_ReturnsCorrectDetails()
        {
            List<string[]> expected = new List<string[]> { new string[] { _appointment.Id.ToString(), _appointment.Title, _appointment.Description, _appointment.StartTime.ToString(@"hh\:mm"), _appointment.EndTime.ToString(@"hh\:mm") } };
            List<string[]> result = CalendarProject.Calendar.GetAppointmentsDetailsMonthCalendar(currentDateToTest);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [Category("Calendar.cs Tests")]
        public void GetCurrentWeekDays_DateWithTwoMonthOnWeek_ReturnsWeekWithTwoMonths()
        {
            List<int> expected = new List<int> {30, 1, 2, 3, 4, 5, 6 };
            List<int> result = CalendarProject.Calendar.GetCurrentWeekDays();
            Assert.AreEqual(expected, result);
        }

        [Test]
        [Category("Calendar.cs Tests")]
        public void GetAppointmentsDetailsWeekCalendar_SelectedDateAndTimeIntervalWithAppointment_ReturnDetailsWithAppointment()
        {
            (TimeSpan, TimeSpan) timeInterval = (new TimeSpan(13, 0, 0), new TimeSpan(14, 0, 0));
            List<string[]> expected = new List<string[]> { new string[] { _appointment.Id.ToString(), _appointment.Title, _appointment.Description, _appointment.StartTime.ToString(@"hh\:mm"), _appointment.EndTime.ToString(@"hh\:mm") } }; 
            List<string[]> result = CalendarProject.Calendar.GetAppointmentsDetailsWeekCalendar(currentDateToTest, timeInterval);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [Category("Calendar.cs Tests")]
        public void GetPossibleInvitedUsers_DateWithAnAvailableUser_ReturnListWithAnUser()
        {
            List<User> expected = new List<User> { _invitedUser };
            List<User> result = CalendarProject.Calendar.GetPossibleInvitedUsers(currentDateToTest, appointmentStartTime, appointmentEndTime);
            Assert.AreEqual(expected, result);
        }

    }
}