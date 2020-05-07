using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;


namespace CalendarProject
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            Calendar.CurrentDate = DateTime.Now;
            InitializeComponent();

        }

        private void MainWindowLoad(object sender, EventArgs e)
        {
            HideWeekCalendar();
            Calendar.LoadAppointments();
            DrawWeekCalendar();
            DrawMonthCalendar();
            viewModeSelector.SelectedIndex = Constants.MonthCalendarSelectorIndex;
            monthCalendarGrid.ClearSelection();
        }



        public void DrawMonthCalendar()
        {
            monthCalendarGrid.Rows.Clear();
            currentDateMonthTitle.Text = $"{Calendar.CurrentDate.ToString(Constants.MonthFormat, CultureInfo.InvariantCulture)} {Calendar.CurrentDate.Year.ToString()}".ToUpper();
            List<string[]> currentMonthWeeks = Calendar.GetCurrentMonthWeeks();
            foreach (string[] week in currentMonthWeeks)
            {
                monthCalendarGrid.Rows.Add(week);
            }
        }

        public void DrawWeekCalendar()
        {
            weekCalendarGrid.Rows.Clear();
            List<string[]> currentWeekHours = Calendar.GetCurrentWeekHours();
            ChangeWeekCalendarHeaders();
            ChangeWeekCalendarMonthTitle();
            foreach (string[] hour in currentWeekHours)
            {
                weekCalendarGrid.Rows.Add(hour);
            }
        }

        private void ChangeWeekCalendarMonthTitle()
        {
            string monthTitle = GetWeekCalendarMonthTitle();
            currentDateWeekTitle.Text = monthTitle;
        }

        private string GetWeekCalendarMonthTitle()
        {
            List<DateTime> currentWeekDates = Calendar.GetCurrentWeekDates();
            string monthTitle;
            DateTime firstDayOfWeek = currentWeekDates[Constants.FirstDayOfWeekIndex];
            DateTime lastDayOfWeek = currentWeekDates[currentWeekDates.Count - Constants.IndexNormalizer];
            if (firstDayOfWeek.Month != lastDayOfWeek.Month)
            {
                string firstMonthName = firstDayOfWeek.ToString(Constants.MonthAbbreviatedFormat, CultureInfo.InvariantCulture);
                string lastMonthName = lastDayOfWeek.ToString(Constants.MonthAbbreviatedFormat, CultureInfo.InvariantCulture);
                string firstYearName = "";
                string lastYearName = lastDayOfWeek.Year.ToString();

                if (firstDayOfWeek.Year != lastDayOfWeek.Year)
                {
                    firstYearName = $" of {firstDayOfWeek.Year.ToString()}";
                }
                monthTitle = $"{firstMonthName}{firstYearName} - {lastMonthName} of {lastYearName}";
            }
            else
            {
                monthTitle = $"{firstDayOfWeek.ToString(Constants.MonthFormat, CultureInfo.InvariantCulture)} of {firstDayOfWeek.Year.ToString()}".ToUpper();
            }
            return monthTitle;
        }

        private void ChangeWeekCalendarHeaders()
        {
            List<int> currentWeekDaysNumbers = Calendar.GetCurrentWeekDays();
            string dayName;
            for (int currentDayNumber = Constants.FirstDayOfWeekIndex; currentDayNumber <= Constants.DaysIndexInWeek; currentDayNumber++)
            {
                dayName = Enum.GetName(typeof(Constants.DaysOfWeekAbbreviated), currentDayNumber);
                weekCalendarGrid.Columns[currentDayNumber + Constants.IndexNormalizer].HeaderText = $"{dayName} {currentWeekDaysNumbers[currentDayNumber]}";
            }

        }

        private void NextMonthClick(object sender, EventArgs e)
        {
            Calendar.CurrentDate = Calendar.CurrentDate.AddMonths(Constants.NextMonthInterval);
            DrawMonthCalendar();
        }

        private void PreviousMonthClick(object sender, EventArgs e)
        {
            Calendar.CurrentDate = Calendar.CurrentDate.AddMonths(Constants.PreviousMonthInterval);
            DrawMonthCalendar();
        }

        private void PreviousWeekClick(object sender, EventArgs e)
        {
            Calendar.CurrentDate = Calendar.CurrentDate.AddDays(Constants.PreviousWeekInterval);
            ChangeWeekCalendarHeaders();
            DrawWeekCalendar();
        }

        private void NextWeekClick(object sender, EventArgs e)
        {
            Calendar.CurrentDate = Calendar.CurrentDate.AddDays(Constants.NextWeekInterval);
            ChangeWeekCalendarHeaders();
            DrawWeekCalendar();
        }

        private void ViewModeSelectorSelectedValueChanged(object sender, EventArgs e)
        {
            if ((Constants.VisualizationTypes)viewModeSelector.SelectedItem == Constants.VisualizationTypes.Month)
            {
                ShowMonthCalendar();
                HideWeekCalendar();
            }
            if ((Constants.VisualizationTypes)viewModeSelector.SelectedItem == Constants.VisualizationTypes.Week)
            {
                HideMonthCalendar();
                ShowWeekCalendar();
            }
        }

        private void ShowWeekCalendar()
        {
            weekPanel.Show();
            weekControlPanel.Show();
        }
        private void HideWeekCalendar()
        {
            weekPanel.Hide();
            weekControlPanel.Hide();
        }

        private void ShowMonthCalendar()
        {
            monthPanel.Show();
            monthControlPanel.Show();
        }

        private void HideMonthCalendar()
        {
            monthPanel.Hide();
            monthControlPanel.Hide();
        }

        private void CreateAppointmentClick(object sender, EventArgs e)
        {
            CreateAppointmentForm createAppointmentForm = new CreateAppointmentForm(this);
            createAppointmentForm.Show();
        }

        private void MonthCalendarGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentCellValue = (string)monthCalendarGrid.SelectedCells[0].Value;
            ShowAppointmentsDetailsMonthCalendar(currentCellValue);
        }

        private void ShowAppointmentsDetailsMonthCalendar(string currentCellValue)
        {
            List<string[]> appointmentDetails = GetAppointmentsOfSelectedDayMonthCalendar(currentCellValue);
            ShowAppointmentDetailsForSelectedDateTime(appointmentDetails);
        }

        private List<string[]> GetAppointmentsOfSelectedDayMonthCalendar(string currentCellValue)
        {
            string selectedDay = currentCellValue.Split(new string[] { Constants.appointmentsSeparator }, StringSplitOptions.None)[0];
            DateTime selectedDate = new DateTime(Calendar.CurrentDate.Year, Calendar.CurrentDate.Month, Convert.ToInt32(selectedDay));
            List<string[]> appointmentsDetails = Calendar.GetAppointmentsDetailsMonthCalendar(selectedDate);
            return appointmentsDetails;
        }

        private void WeekCalendarGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell selectedCell = weekCalendarGrid.SelectedCells[0];
            ShowAppointmentsDetailsWeekCalendar(selectedCell);
        }

        private void ShowAppointmentsDetailsWeekCalendar(DataGridViewCell selectedCell)
        {
            List<string[]> appointments = GetAppointmentsOfSelectedDayWeekCalendar(selectedCell);
            ShowAppointmentDetailsForSelectedDateTime(appointments);
        }

        private List<string[]> GetAppointmentsOfSelectedDayWeekCalendar(DataGridViewCell selectedCell)
        {
            int columnIndex = selectedCell.ColumnIndex;
            int rowIndex = selectedCell.RowIndex;
            (TimeSpan, TimeSpan) selectedTimeInterval = Constants.WeekCalendarTimeIntervals[rowIndex];
            List<int> currentWeekDays = Calendar.GetCurrentWeekDays();
            int selectedDay = currentWeekDays[columnIndex - Constants.IndexNormalizer];
            DateTime selectedDate = new DateTime(Calendar.CurrentDate.Year, Calendar.CurrentDate.Month, Convert.ToInt32(selectedDay));
            List<string[]> appointments = Calendar.GetAppointmentsDetailsWeekCalendar(selectedDate, selectedTimeInterval);
            return appointments;
        }

        private void ShowAppointmentDetailsForSelectedDateTime(List<string[]> appointmentDetails)
        {
            appointmentsDataGrid.Rows.Clear();
            foreach (string[] details in appointmentDetails)
            {
                appointmentsDataGrid.Rows.Add(details);
            }
        }
    }
}
