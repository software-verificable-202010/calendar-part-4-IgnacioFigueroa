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
    public partial class LoginForm : Form
    {
        public event EventHandler OnLogin;
        public LoginForm()
        {
            InitializeComponent();
            Calendar.LoadUsers();
            Calendar.LoadAppointments();
        }
        public void LoginFormLoad(object sender, EventArgs e)
        {
            usernameTextBox.Text = string.Empty;
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            SubmitLogin();
        }

        private void SubmitLogin()
        {
            string userInput = usernameTextBox.Text;
            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show(Constants.EmptyOrNullUsernameMessage);
            }
            else
            {
                Calendar.LogInOrCreateUser(userInput);
                OnLogin(this, null);
            }
        }

        private void LoginFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
