using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarProject
{
    public partial class CreateAppointmentForm : Form
    {
        #region fields
        private readonly MainWindow mainWindow;
        #endregion
        #region methods
        public CreateAppointmentForm(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void CreateAppointmentButtonClick(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CreateAppointment();
                ShowMessage(Constants.AppointmentCreatedMessage);
                mainWindow.DrawMonthCalendar();
                this.Close();
            }
        }

        private void CreateAppointmentFormLoad(object sender, EventArgs e)
        {
            InitializeUsersListBox();
            startTimePicker.Value = DateTime.Now;
            endTimePicker.Value = DateTime.Now.AddHours(Constants.IndexNormalizer);
            datePicker.Value = DateTime.Now;
        }

        private void CreateAppointment()
        {
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;
            TimeSpan startTime = startTimePicker.Value.TimeOfDay;
            TimeSpan endTime = endTimePicker.Value.TimeOfDay;
            DateTime date = datePicker.Value;
            List<User> invitedUsers = new List<User> { };
            List<string> selectedUsers = usersListBox.SelectedItems.Cast<string>().ToList();
            foreach (string username in selectedUsers)
            {
                invitedUsers.Add(Calendar.Users.Find(user => user.UserName == username));
            }
            Appointment appointment = new Appointment(title, description, startTime, endTime, date, Calendar.CurrentUser, invitedUsers);
            Calendar.SaveAppointment(appointment);
        }

        private bool ValidateForm()
        {
            bool formValid = true;
            if (!CheckImportantFieldsComplete())
            {
                formValid = false;
                ShowMessage(Constants.ImportantFieldsEmptyMessage);
            }
            if (!CheckStartDateGreaterThanEndDate())
            {
                formValid = false;
                ShowMessage(Constants.StartDateGreaterThanEndDateMessage);
            }
            return formValid;
        }

        private static void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private bool CheckImportantFieldsComplete()
        {
            bool allFieldsComplete = true;
            if (string.IsNullOrEmpty(titleTextBox.Text))
            {
                allFieldsComplete = false;
            }

            return allFieldsComplete;
        }

        private bool CheckStartDateGreaterThanEndDate()
        {
            bool startDateGreaterThanEndDate = true;
            if (startTimePicker.Value.TimeOfDay > endTimePicker.Value.TimeOfDay)
            {
                startDateGreaterThanEndDate = false;
            }
            return startDateGreaterThanEndDate;
        }

        private void CreateAppointmentFormFormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.DrawMonthCalendar();
            mainWindow.DrawWeekCalendar();
        }

        private void DatePickerValueChanged(object sender, EventArgs e)
        {
            InitializeUsersListBox();
        }

        private void StartTimePickerValueChanged(object sender, EventArgs e)
        {
            InitializeUsersListBox();
        }

        private void EndTimePickerValueChanged(object sender, EventArgs e)
        {
            InitializeUsersListBox();
        }

        private void InitializeUsersListBox()
        {
            usersListBox.Items.Clear();
            List<User> possibleInvitedUsers = Calendar.GetPossibleInvitedUsers(datePicker.Value, startTimePicker.Value.TimeOfDay, endTimePicker.Value.TimeOfDay);
            foreach (User user in possibleInvitedUsers)
            {
                usersListBox.Items.Add(user.UserName);
            }
        }
        #endregion
    }
}
