using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace CalendarProject
{
    public static class Calendar
    {

        private static DateTime currentDate;
        private static List<Appointment> appointments;


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

        private static List<string[]> CreateMonthCalendarWeeks(int firstDayIndexOnWeek, int currentMonthDays)
        {
            List<string> currentWeektoInsert;
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
            List<Appointment> appointmentsToInsert = appointments.FindAll(appointment => appointment.Date.Date == appointmentDate.Date);
            string dayNumberWithAppointments = dayNumber;
            string appointmentName;
            string appointmentTime;
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
            List<Appointment> appointmentsToInsert;
            int columnIndexToInsert = Constants.FirstDayOfweek;
            int intervalIndexOfStartTime;
            int intervalIndexOfEndTime;
            string appointmentNameWithTime;
            string appointmentNameWithoutTime;
            foreach (DateTime dateToInsertInto in currentWeekDates)
            {
                appointmentsToInsert = appointments.FindAll(appointment => appointment.Date.Date == dateToInsertInto.Date);
                foreach (Appointment appointmentToInsert in appointmentsToInsert)
                {
                    (TimeSpan, TimeSpan) intervalOfStartTime = Constants.WeekCalendarTimeIntervals.Find(interval => appointmentToInsert.StartTime <= interval.Item2);
                    intervalIndexOfStartTime = Constants.WeekCalendarTimeIntervals.IndexOf(intervalOfStartTime);
                    (TimeSpan, TimeSpan) intervalOfEndTime = Constants.WeekCalendarTimeIntervals.Find(interval => appointmentToInsert.EndTime <= interval.Item2);
                    intervalIndexOfEndTime = Constants.WeekCalendarTimeIntervals.IndexOf(intervalOfEndTime);
                    appointmentNameWithTime = GetAppointmentNameWithTimeFormat(appointmentToInsert);
                    weekHours[intervalIndexOfStartTime][columnIndexToInsert] += $"{appointmentToInsert.StartTime.ToString(Constants.TimeSpanHourMinutesFormat)}-{appointmentNameWithTime}\n";
                    appointmentNameWithoutTime = GetAppointmentNameWithoutTimeFormat(appointmentToInsert);
                    if (intervalIndexOfStartTime != intervalIndexOfEndTime)
                    {
                        for (int currentIntervalIndex = intervalIndexOfStartTime + Constants.IndexNormalizer; currentIntervalIndex <= intervalIndexOfEndTime; currentIntervalIndex++)
                        {
                            weekHours[currentIntervalIndex][columnIndexToInsert] += $"{appointmentNameWithoutTime}\n";
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
        //This function gives format the title to be shown properly in the week calendar
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

            List<Appointment> selectedDateAppointments = appointments.FindAll(appointment => appointment.Date.Date == selectedDate.Date);
            List<string[]> appointmentsDetails = FormatAppointmentsDetails(selectedDateAppointments);
            return appointmentsDetails;
        }

        public static List<string[]> GetAppointmentsDetailsWeekCalendar(DateTime selectedDate, (TimeSpan, TimeSpan) timeInterval)
        {
            List<Appointment> selectedDateAppointments = appointments.FindAll(appointment => appointment.Date.Date == selectedDate.Date);
            List<Appointment> selectedDateAndTimeAppointments = selectedDateAppointments.FindAll(appointment => FilterAppointmentIntersectsInterval(appointment, timeInterval));
            List<string[]> appointmentsDetails = FormatAppointmentsDetails(selectedDateAndTimeAppointments);
            return appointmentsDetails;
        }

        public static List<string[]> FormatAppointmentsDetails(List<Appointment> appointmentsDetails)
        {
            List<string[]> appointmentsDetailsFormated = new List<string[]> { };
            foreach (Appointment appointment in appointmentsDetails)
            {
                appointmentsDetailsFormated.Add(new string[] {appointment.Title,
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
            using (Stream stream = File.Open(Constants.SerializationPath, FileMode.Open))
            {
                BinaryFormatter appointmentsData = new BinaryFormatter();
                appointments = (List<Appointment>)appointmentsData.Deserialize(stream);
            }
        }

        public static void SerializeAppointments()
        {
            using (Stream stream = File.Open(Constants.SerializationPath, FileMode.OpenOrCreate))
            {
                BinaryFormatter appointmentsData = new BinaryFormatter();
                appointmentsData.Serialize(stream, appointments);
            }

        }
    }
}
