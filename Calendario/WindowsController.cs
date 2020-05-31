using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    public class WindowsController
    {
        #region fields
        private MainWindow mainWindow;
        private LoginForm loginForm;
        #endregion
        #region
        public WindowsController(LoginForm loginForm, MainWindow mainWindow)
        {
            this.loginForm = loginForm;
            this.mainWindow = mainWindow;
            loginForm.Show();
            mainWindow.Hide();
        }

        public void ChangeToMainWindow(object sender, EventArgs eventArgs)
        {
            mainWindow.Show();
            loginForm.Hide();
        }

        public void ChangeToLoginWindow(object sender, EventArgs eventArgs)
        {
            mainWindow.Hide();
            loginForm.Show();
        }
        #endregion
    }
}
