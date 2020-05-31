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
    public partial class EditAppointment : Form
    {
        #region fields
        private readonly MainWindow mainWindow;
        private readonly int selectedAppointmentId;
        #endregion
        #region methods
        public EditAppointment(MainWindow mainWindow, int selectedAppointmentId)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.selectedAppointmentId = selectedAppointmentId;
        }

        private void InitializeUsersListBox()
        {
            usersListBox.Items.Clear();
            List<User> possibleInvitedUsers = Calendar.GetPossibleInvitedUsers(datePicker.Value, startTimePicker.Value.TimeOfDay, endTimePicker.Value.TimeOfDay);
            foreach (User user in possibleInvitedUsers)
            {
                usersListBox.Items.Add(user.Username);
            }
        }
        private void EditAppointmentLoad(object sender, EventArgs e)
        {
            Appointment appointmentToEdit = Calendar.GetAppointmentFromId(selectedAppointmentId);
            titleTextBox.Text = appointmentToEdit.Title;
            descriptionTextBox.Text = appointmentToEdit.Description;
            startTimePicker.Value = DateTime.Today.Add(appointmentToEdit.StartTime);
            endTimePicker.Value = DateTime.Today.Add(appointmentToEdit.EndTime);
            datePicker.Value = appointmentToEdit.Date;
            InitializeUsersListBox();
            SelectInvitedUsers();
        }
        private void SelectInvitedUsers()
        {
            Appointment appointmentToEdit = Calendar.GetAppointmentFromId(selectedAppointmentId);
            List<string> invitedUsersUsernames = appointmentToEdit.InvitedUsers.Select(user => user.Username).ToList();
            for (int currentIndex = 0; currentIndex < usersListBox.Items.Count; currentIndex++)
            {
                if (invitedUsersUsernames.Contains(usersListBox.Items[currentIndex].ToString()))
                {
                    usersListBox.SetSelected(currentIndex, true);
                }
            }
        }

        private void EditAppointmentButtonClickUpdateAppointment(object sender, EventArgs e)
        {
            Appointment appointmentToEdit = Calendar.GetAppointmentFromId(selectedAppointmentId);
            appointmentToEdit.Title = titleTextBox.Text;
            appointmentToEdit.Description = descriptionTextBox.Text;
            appointmentToEdit.Date = datePicker.Value;
            appointmentToEdit.StartTime = startTimePicker.Value.TimeOfDay;
            appointmentToEdit.EndTime = endTimePicker.Value.TimeOfDay;
            List<User> invitedUsers = new List<User> { };
            List<string> selectedUsers = usersListBox.SelectedItems.Cast<string>().ToList();
            foreach (string username in selectedUsers)
            {
                invitedUsers.Add(Calendar.Users.Find(user => user.Username == username));
            }
            appointmentToEdit.InvitedUsers = invitedUsers;
            Calendar.SerializeAppointments();
            mainWindow.DrawMonthCalendar();
            this.Close();
        }

        private void DatePickerValueChanged(object sender, EventArgs e)
        {
            InitializeUsersListBox();
            SelectInvitedUsers();
        }

        private void StartTimePickerValueChanged(object sender, EventArgs e)
        {
            InitializeUsersListBox();
            SelectInvitedUsers();
        }

        private void EndTimePickerValueChanged(object sender, EventArgs e)
        {
            InitializeUsersListBox();
            SelectInvitedUsers();
        }

        private void DeleteAppointmentButtonClick(object sender, EventArgs e)
        {
            Appointment appointmentToDelete = Calendar.GetAppointmentFromId(selectedAppointmentId);
            Calendar.DeleteAppointment(ref appointmentToDelete);
            mainWindow.DrawMonthCalendar();
            mainWindow.DrawWeekCalendar();
            this.Close();
        }
        #endregion
    }
}
