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
        MainWindow mainWindow;
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

        private void CreateAppointment()
        {
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;
            TimeSpan startTime = startTimePicker.Value.TimeOfDay;
            TimeSpan endTime = endTimePicker.Value.TimeOfDay;
            DateTime date = datePicker.Value;
            Appointment appointment = new Appointment(title, description, startTime, endTime, date);
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

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        
        private bool CheckImportantFieldsComplete()
        {
            bool allFieldsComplete = true;
            if (titleTextBox.Text == String.Empty)
            {
                allFieldsComplete = false;
            }
            
            return allFieldsComplete;
        }

        private bool CheckStartDateGreaterThanEndDate()
        {
            bool startDateGreaterThanEndDate = true;
            if(startTimePicker.Value.TimeOfDay > endTimePicker.Value.TimeOfDay)
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
    }
}
