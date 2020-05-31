using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;


namespace CalendarProject
{
    public partial class MainWindow : Form
    {
        public event EventHandler OnLogout;
        #region methods
        public MainWindow()
        {
            Calendar.CurrentDate = DateTime.Now;
            InitializeComponent();

        }

        public void DrawMonthCalendar()
        {
            monthCalendarGrid.Rows.Clear();
            ResetAppointmentsDetails();
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
            ResetAppointmentsDetails();
            List<string[]> currentWeekHours = Calendar.GetCurrentWeekHours();
            ChangeWeekCalendarHeaders();
            ChangeWeekCalendarMonthTitle();
            foreach (string[] hour in currentWeekHours)
            {
                weekCalendarGrid.Rows.Add(hour);
            }
        }
        public void MainWindowLoad(object sender, EventArgs e)
        {
            HideWeekCalendar();
            DrawWeekCalendar();
            DrawMonthCalendar();
            viewModeSelector.SelectedIndex = Constants.MonthCalendarSelectorIndex;
            monthCalendarGrid.ClearSelection();
            appointmentsDataGrid.ClearSelection();
        }

        private void ChangeWeekCalendarMonthTitle()
        {
            string monthTitle = GetWeekCalendarMonthTitle();
            currentDateWeekTitle.Text = monthTitle;
        }

        private string GetWeekCalendarMonthTitle()
        {
            List<DateTime> currentWeekDates = Calendar.GetCurrentWeekDates();
            string monthTitle = "";
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
            string selectedViewMode = viewModeSelector.SelectedItem.ToString();
            Constants.VisualizationTypes viewMode = Constants.VisualizationTypes.Month;
            Enum.TryParse(selectedViewMode, out viewMode);
            if (viewMode == Constants.VisualizationTypes.Month)
            {
                ShowMonthCalendar();
                HideWeekCalendar();
            }
            if (viewMode == Constants.VisualizationTypes.Week)
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
            string currentCellValue = monthCalendarGrid.SelectedCells[0].Value as string;
            ShowAppointmentsDetailsMonthCalendar(currentCellValue);
            appointmentsDataGrid.ClearSelection();
        }

        private void ResetAppointmentsDetails()
        {
            appointmentsDataGrid.Rows.Clear();
        }

        private void ShowAppointmentsDetailsMonthCalendar(string currentCellValue)
        {
            List<string[]> appointmentDetails = GetAppointmentsOfSelectedDayMonthCalendar(currentCellValue);
            ShowAppointmentDetailsForSelectedDateTime(appointmentDetails);
        }

        private List<string[]> GetAppointmentsOfSelectedDayMonthCalendar(string currentCellValue)
        {
            string selectedDay = currentCellValue.Split(new string[] { Constants.AppointmentsSeparator }, StringSplitOptions.None)[Constants.MonthCalendarSelectorIndex];
            DateTime selectedDate = new DateTime(Calendar.CurrentDate.Year, Calendar.CurrentDate.Month, Convert.ToInt32(selectedDay));
            List<string[]> appointmentsDetails = Calendar.GetAppointmentsDetailsMonthCalendar(selectedDate);
            return appointmentsDetails;
        }

        private void WeekCalendarGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell selectedCell = weekCalendarGrid.SelectedCells[Constants.MonthCalendarSelectorIndex];
            ShowAppointmentsDetailsWeekCalendar(selectedCell);
            appointmentsDataGrid.ClearSelection();
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
        #endregion

        private void MainWindowFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LogoutButtonClick(object sender, EventArgs e)
        {
            OnLogout(this, null);
        }

        private void AppointmentsDataGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = appointmentsDataGrid.SelectedRows[Constants.MonthCalendarSelectorIndex];
            int selectedId = Convert.ToInt32(selectedRow.Cells[0].Value);
            Appointment selectedAppointment = Calendar.GetAppointmentFromId(selectedId);
            if (Calendar.CurrentUser.Username == selectedAppointment.Owner.Username)
            {
                EditAppointment editAppointmentForm = new EditAppointment(this, selectedId);
                editAppointmentForm.Show();
            }
            else
            {
                MessageBox.Show(Constants.NotYourAppointmentMessage);
            }
        }
    }
}
