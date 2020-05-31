using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CalendarProject
{
    public static class Calendar
    {
        #region fields
        private static DateTime currentDate;
        private static User currentUser;
        private static List<Appointment> appointments;
        private static List<User> users;
        #endregion
        #region properties

        public static DateTime CurrentDate
        {
            get => currentDate;
            set => currentDate = value;
        }

        public static List<Appointment> Appointments
        {
            get => appointments;
            set => appointments = value;
        }

        public static User CurrentUser
        {
            get => currentUser;
            set => currentUser = value;
        }

        public static List<User> Users
        {
            get => users;
            set => users = value;
        }
        #endregion
        #region methods

        public static List<string[]> GetCurrentMonthWeeks()
        {
            DateTime firstDayOfTargetMonth = new DateTime(currentDate.Year, currentDate.Month, Constants.IndexToCreateMonth);
            int currentMonthDays = DateTime.DaysInMonth(firstDayOfTargetMonth.Year, firstDayOfTargetMonth.Month);
            int firstDayOfFirstWeek = (int)firstDayOfTargetMonth.DayOfWeek;

            if (firstDayOfFirstWeek == (int)DayOfWeek.Sunday)
            {
                firstDayOfFirstWeek = Constants.SundayIndex;
            }

            int firstDayIndexOnWeek = firstDayOfFirstWeek - Constants.IndexNormalizer;

            List<string[]> monthWeeks = CreateMonthCalendarWeeks(firstDayIndexOnWeek, currentMonthDays);
            return monthWeeks;
        }

        public static List<string[]> GetCurrentWeekHours()
        {
            List<string[]> weekHours = new List<string[]> { };
            List<string> currentHourToInsert;
            foreach ((TimeSpan, TimeSpan) hourInterval in Constants.WeekCalendarTimeIntervals)
            {
                currentHourToInsert = InitializeEmptyWeekCalendarHour(hourInterval);

                weekHours.Add(currentHourToInsert.ToArray());
            }
            List<string[]> weekHoursWithAppointments = InsertAppointmentsOnWeekCalendarHour(weekHours);
            return weekHoursWithAppointments;
        }

        private static List<string[]> InsertAppointmentsOnWeekCalendarHour(List<string[]> weekHours)
        {
            List<DateTime> currentWeekDates = GetCurrentWeekDates();
            List<Appointment> appointmentsToInsert = new List<Appointment> { };
            int columnIndexToInsert = Constants.FirstDayOfweek;
            int intervalIndexOfStartTime = 0;
            int intervalIndexOfEndTime = 0;
            string appointmentNameWithTime = "";
            string appointmentNameWithoutTime = "";
            StringBuilder appointmentBuilder = new StringBuilder("");
            foreach (DateTime dateToInsertInto in currentWeekDates)
            {
                List<Appointment> currentUserAppointments = appointments.FindAll(appointment => appointment.Date.Date == dateToInsertInto.Date && appointment.Owner.Username == currentUser.Username);
                List<Appointment> appointmentsUserHasBeenInvited = appointments.FindAll(appointment => appointment.Date.Date == dateToInsertInto.Date && appointment.InvitedUsers.Select(user => user.Username).Contains(currentUser.Username));
                appointmentsToInsert = currentUserAppointments.Concat(appointmentsUserHasBeenInvited).ToList();
                foreach (Appointment appointmentToInsert in appointmentsToInsert)
                {
                    (TimeSpan, TimeSpan) intervalOfStartTime = Constants.WeekCalendarTimeIntervals.Find(interval => appointmentToInsert.StartTime <= interval.Item2);
                    intervalIndexOfStartTime = Constants.WeekCalendarTimeIntervals.IndexOf(intervalOfStartTime);
                    (TimeSpan, TimeSpan) intervalOfEndTime = Constants.WeekCalendarTimeIntervals.Find(interval => appointmentToInsert.EndTime <= interval.Item2);
                    intervalIndexOfEndTime = Constants.WeekCalendarTimeIntervals.IndexOf(intervalOfEndTime);
                    appointmentNameWithTime = GetAppointmentNameWithTimeFormat(appointmentToInsert);
                    appointmentBuilder.Clear();
                    appointmentBuilder.Append(weekHours[intervalIndexOfStartTime][columnIndexToInsert]);
                    appointmentBuilder.Append($"{appointmentToInsert.StartTime.ToString(Constants.TimeSpanHourMinutesFormat)}-{appointmentNameWithTime}\n");
                    weekHours[intervalIndexOfStartTime][columnIndexToInsert] = appointmentBuilder.ToString();
                    appointmentNameWithoutTime = GetAppointmentNameWithoutTimeFormat(appointmentToInsert);
                    if (intervalIndexOfStartTime != intervalIndexOfEndTime)
                    {
                        for (int currentIntervalIndex = intervalIndexOfStartTime + Constants.IndexNormalizer; currentIntervalIndex <= intervalIndexOfEndTime; currentIntervalIndex++)
                        {
                            appointmentBuilder.Clear();
                            appointmentBuilder.Append(weekHours[currentIntervalIndex][columnIndexToInsert]);
                            appointmentBuilder.Append($"{appointmentNameWithoutTime}\n");
                            weekHours[currentIntervalIndex][columnIndexToInsert] = appointmentBuilder.ToString();
                        }
                    }
                }
                columnIndexToInsert++;
            }
            return weekHours;
        }

        public static string GetAppointmentNameWithTimeFormat(Appointment appointmentToInsert)
        {
            string appointmentNamewithTime;
            if (appointmentToInsert.Title.Length > Constants.MaxLengthTitleWithTime)
            {
                appointmentNamewithTime = $"{appointmentToInsert.Title.Substring(0, Constants.MaxLengthTitleWithTimeToShow)}...";
            }
            else
            {
                appointmentNamewithTime = appointmentToInsert.Title;
            }
            return appointmentNamewithTime;
        }
        //This function gives format the title to be shown properly in the week calendar.
        public static string GetAppointmentNameWithoutTimeFormat(Appointment appointmentToInsert)
        {
            string appointmentName;
            if (appointmentToInsert.Title.Length > Constants.MaxLenghtTitleWithoutTime)
            {
                appointmentName = $"{appointmentToInsert.Title.Substring(0, Constants.MaxLenghtTileWithoutTimeToShow)}...";
            }
            else
            {
                appointmentName = appointmentToInsert.Title;
            }

            return appointmentName;
        }

        public static List<string[]> GetAppointmentsDetailsMonthCalendar(DateTime selectedDate)
        {
            List<Appointment> selectedDateUserOwnerAppointments = appointments.FindAll(appointment => appointment.Date.Date == selectedDate.Date && appointment.Owner.Username == currentUser.Username);
            List<Appointment> appointmentsUserHasBeenInvited = appointments.FindAll(appointment => appointment.Date.Date == selectedDate.Date && appointment.InvitedUsers.Select(user => user.Username).Contains(currentUser.Username));
            List<Appointment> selectedDateAppointments = selectedDateUserOwnerAppointments.Concat(appointmentsUserHasBeenInvited).ToList();
            List<string[]> appointmentsDetails = FormatAppointmentsDetails(selectedDateAppointments);
            return appointmentsDetails;
        }

        public static List<string[]> GetAppointmentsDetailsWeekCalendar(DateTime selectedDate, (TimeSpan, TimeSpan) timeInterval)
        {
            List<Appointment> selectedDateUserOwnerAppointments = appointments.FindAll(appointment => appointment.Date.Date == selectedDate.Date && appointment.Owner.Username == currentUser.Username);
            List<Appointment> appointmentsUserHasBeenInvited = appointments.FindAll(appointment => appointment.Date.Date == selectedDate.Date && appointment.InvitedUsers.Select(user => user.Username).Contains(currentUser.Username));
            List<Appointment> selectedDateAppointments = selectedDateUserOwnerAppointments.Concat(appointmentsUserHasBeenInvited).ToList();
            List<Appointment> selectedDateAndTimeAppointments = selectedDateAppointments.FindAll(appointment => FilterAppointmentIntersectsInterval(appointment, timeInterval));
            List<string[]> appointmentsDetails = FormatAppointmentsDetails(selectedDateAndTimeAppointments);
            return appointmentsDetails;
        }

        public static List<string[]> FormatAppointmentsDetails(List<Appointment> appointmentsDetails)
        {
            List<string[]> appointmentsDetailsFormated = new List<string[]> { };
            foreach (Appointment appointment in appointmentsDetails)
            {

                appointmentsDetailsFormated.Add(new string[] {appointment.Id.ToString(),
                                                      appointment.Title,
                                                      appointment.Description,
                                                      appointment.StartTime.ToString(Constants.TimeSpanHourMinutesFormat),
                                                      appointment.EndTime.ToString(Constants.TimeSpanHourMinutesFormat)});
            }
            return appointmentsDetailsFormated;
        }

        public static bool FilterAppointmentIntersectsInterval(Appointment appointment, (TimeSpan, TimeSpan) timeInterval)
        {
            bool appointmentIntersects = false;
            bool appointmentStartTimeLowerThanIntervalStart = appointment.StartTime <= timeInterval.Item1;
            bool appointmentEndTimeBetweenTimeInterval = appointment.EndTime >= timeInterval.Item1 && appointment.EndTime <= timeInterval.Item2;
            if (appointmentStartTimeLowerThanIntervalStart && appointmentEndTimeBetweenTimeInterval)
            {
                appointmentIntersects = true;
            }
            bool appointmentEndTimeGreaterThanIntervalEnd = appointment.EndTime >= timeInterval.Item2;
            bool appointmentStartTimeBetweenTimeInterval = appointment.StartTime >= timeInterval.Item1 && appointment.StartTime <= timeInterval.Item2;
            if (appointmentEndTimeGreaterThanIntervalEnd && appointmentStartTimeBetweenTimeInterval)
            {
                appointmentIntersects = true;
            }
            if (appointmentStartTimeLowerThanIntervalStart && appointmentEndTimeGreaterThanIntervalEnd)
            {
                appointmentIntersects = true;
            }
            return appointmentIntersects;
        }

        public static List<DateTime> GetCurrentWeekDates()
        {
            List<DateTime> weekDates = new List<DateTime> { };
            int currentDayOfWeek = (int)currentDate.DayOfWeek;

            if (currentDayOfWeek == (int)DayOfWeek.Sunday)
            {
                currentDayOfWeek = Constants.SundayIndex;
            }

            DateTime firstDayOfCurrentWeek = currentDate.AddDays((currentDayOfWeek - Constants.IndexNormalizer) * Constants.ConvertNegative);
            for (int dayOfWeekNumber = Constants.FirstDayOfWeekIndex; dayOfWeekNumber <= Constants.DaysIndexInWeek; dayOfWeekNumber++)
            {
                weekDates.Add(firstDayOfCurrentWeek.AddDays(dayOfWeekNumber));
            }
            return weekDates;

        }

        public static void SaveAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
            SerializeAppointments();
        }


        public static List<int> GetCurrentWeekDays()
        {
            List<int> dayNumbers = new List<int> { };
            int currentDayOfWeek = (int)currentDate.DayOfWeek;

            if (currentDayOfWeek == (int)DayOfWeek.Sunday)
            {
                currentDayOfWeek = Constants.SundayIndex;
            }

            DateTime firstDayOfCurrentWeek = currentDate.AddDays((currentDayOfWeek - Constants.IndexNormalizer) * Constants.ConvertNegative);

            for (int dayOfWeekNumber = Constants.FirstDayOfWeekIndex; dayOfWeekNumber <= Constants.DaysIndexInWeek; dayOfWeekNumber++)
            {
                dayNumbers.Add(firstDayOfCurrentWeek.AddDays(dayOfWeekNumber).Day);
            }
            return dayNumbers;
        }

        public static void LoadAppointments()
        {
            appointments = new List<Appointment> { };
            try
            {
                using (Stream stream = File.Open(Constants.AppointmentsSerializationPath, FileMode.Open))
                {
                    BinaryFormatter appointmentsData = new BinaryFormatter();
                    appointments = (List<Appointment>)appointmentsData.Deserialize(stream);
                    SetCurrentAppointmentId(appointments);
                }
            }
            catch (FileNotFoundException)
            {
                return;
            }
        }

        public static void SetCurrentAppointmentId(List<Appointment> appointments)
        {
            int lastId = appointments.Max(appointment => appointment.Id);
            Appointment.nextId = lastId + Constants.IndexNormalizer;
        }

        public static void LoadUsers()
        {
            users = new List<User> { };
            try
            {
                using (Stream stream = File.Open(Constants.UsersSerializationPath, FileMode.Open))
                {
                    BinaryFormatter userData = new BinaryFormatter();
                    users = (List<User>)userData.Deserialize(stream);
                }
            }
            catch
            {
                return;
            }
        }
        public static void LogInOrCreateUser(string username)
        {
            List<User> coincidentUsers = users.FindAll(user => user.Username == username);
            if (coincidentUsers.Any())
            {
                currentUser = coincidentUsers.First();
            }
            else
            {
                CreateUser(username);
            }
        }

        public static List<User> GetPossibleInvitedUsers(DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            List<User> possibleUsers = users.FindAll(user => user.Username != currentUser.Username);
            List<User> validUsers = new List<User> { };
            (TimeSpan, TimeSpan) actualInterval = (startTime, endTime);
            foreach (User user in possibleUsers)
            {
                List<Appointment> possibleUserIntersectAppointments = appointments.FindAll(appointment => appointment.Owner.Username == user.Username
                                                                                && FilterAppointmentIntersectsDateTime(date, actualInterval, appointment));
                if (!possibleUserIntersectAppointments.Any())
                {
                    validUsers.Add(user);
                }

            }
            return validUsers;
        }

        public static Appointment GetAppointmentFromId(int appointmentId)
        {
            Appointment selectedAppointment = appointments.Find(appointment => appointment.Id == appointmentId);
            return selectedAppointment;
        }

        public static void SerializeAppointments()
        {
            using (Stream stream = File.Open(Constants.AppointmentsSerializationPath, FileMode.OpenOrCreate))
            {
                BinaryFormatter appointmentsData = new BinaryFormatter();
                appointmentsData.Serialize(stream, appointments);
            }

        }

        public static void DeleteAppointment(ref Appointment appointment)
        {
            appointments.Remove(appointment);
            SerializeAppointments();
        }

        private static bool FilterAppointmentIntersectsDateTime(DateTime date, (TimeSpan, TimeSpan) timeInterval, Appointment appointment)
        {
            bool appointmentIntersectsDateTime = false;
            if (appointment.Date.Date == date.Date)
            {
                if (FilterAppointmentIntersectsInterval(appointment, timeInterval))
                {
                    appointmentIntersectsDateTime = true;
                }
            }
            return appointmentIntersectsDateTime;
        }

        private static void CreateUser(string username)
        {
            User newUser = new User(username);
            users.Add(newUser);
            currentUser = newUser;
            SerializeUsers();
        }
        private static List<string> InitializeEmptyWeekCalendarHour((TimeSpan, TimeSpan) hourInterval)
        {
            List<string> emptyHour = new List<string> { };
            TimeSpan intervalInitialTime = hourInterval.Item1;
            TimeSpan intervalEndTime = hourInterval.Item2;
            emptyHour.Add($"{intervalInitialTime.Hours} Hrs - {intervalEndTime.Hours + 1} Hrs");
            for (int dayIndex = Constants.FirstDayOfWeekIndex; dayIndex <= Constants.DaysIndexInWeek; dayIndex++)
            {
                emptyHour.Add(Constants.DataGridPlaceHolder);
            }

            return emptyHour;
        }

        private static void SerializeUsers()
        {
            using (Stream stream = File.Open(Constants.UsersSerializationPath, FileMode.OpenOrCreate))
            {
                BinaryFormatter usersData = new BinaryFormatter();
                usersData.Serialize(stream, users);
            }
        }

        private static List<string[]> CreateMonthCalendarWeeks(int firstDayIndexOnWeek, int currentMonthDays)
        {
            List<string> currentWeektoInsert = new List<string> { };
            List<string[]> monthWeeks = new List<string[]> { };
            int dayCounter = Constants.FirstDayOfweek;
            currentWeektoInsert = InitializeEmptyMonthCalendarWeek();
            for (int currentDayIndex = firstDayIndexOnWeek; currentDayIndex <= Constants.DaysIndexInWeek; currentDayIndex++)
            {
                currentWeektoInsert[currentDayIndex] = InsertAppointmentsOnMonthCalendarDay(dayCounter.ToString());

                dayCounter++;
            }
            monthWeeks.Add(currentWeektoInsert.ToArray());
            for (int weekNumber = Constants.SecondWeekOfMonth; weekNumber < Constants.WeeksToShowOnCalendar; weekNumber++)
            {
                currentWeektoInsert = InitializeEmptyMonthCalendarWeek();
                for (int currentDayIndex = Constants.FirstDayOfWeekIndex; currentDayIndex <= Constants.DaysIndexInWeek; currentDayIndex++)
                {
                    currentWeektoInsert[currentDayIndex] = InsertAppointmentsOnMonthCalendarDay(dayCounter.ToString());
                    dayCounter++;
                    if (DaysLimitReached(dayCounter, currentMonthDays))
                    {
                        break;
                    }
                }
                monthWeeks.Add(currentWeektoInsert.ToArray());
                if (DaysLimitReached(dayCounter, currentMonthDays))
                {
                    break;
                }
            }
            return monthWeeks;
        }
        private static bool DaysLimitReached(int dayCounter, int daysInMonth)
        {
            if (dayCounter > daysInMonth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static List<string> InitializeEmptyMonthCalendarWeek()
        {
            List<string> emptyWeek = new List<string> { };
            for (int dayIndex = Constants.FirstDayOfWeekIndex; dayIndex <= Constants.DaysIndexInWeek; dayIndex++)
            {
                emptyWeek.Add(Constants.DataGridPlaceHolder);
            }
            return emptyWeek;

        }

        private static string InsertAppointmentsOnMonthCalendarDay(string dayNumber)
        {
            DateTime appointmentDate = new DateTime(currentDate.Year, currentDate.Month, Convert.ToInt32(dayNumber));
            List<Appointment> currentUserAppointments = appointments.FindAll(appointment => appointment.Date.Date == appointmentDate.Date && appointment.Owner.Username == currentUser.Username);
            List<Appointment> appointmentsUserHasBeenInvited = appointments.FindAll(appointment => appointment.Date.Date == appointmentDate.Date && appointment.InvitedUsers.Select(user => user.Username).Contains(currentUser.Username));
            List<Appointment> appointmentsToInsert = currentUserAppointments.Concat(appointmentsUserHasBeenInvited).ToList();
            string dayNumberWithAppointments = dayNumber;
            string appointmentName = "";
            string appointmentTime = "";
            foreach (Appointment appointment in appointmentsToInsert)
            {
                appointmentTime = appointment.StartTime.ToString(Constants.TimeSpanHourMinutesFormat);
                if (appointment.Title.Length > Constants.MaxLengthTitleWithTime)
                {
                    appointmentName = $"{appointment.Title.Substring(0, Constants.MaxLengthTitleWithTimeToShow)}...";
                }
                else
                {
                    appointmentName = appointment.Title;
                }

                dayNumberWithAppointments += $"\n{appointmentTime}Hrs - {appointmentName}";
            }
            return dayNumberWithAppointments;
        }


        #endregion
    }
}
