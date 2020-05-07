using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarProject
{
    class Program
    {
        //IMPORTANT: ALL THIS CODE AND COMMENTS ARE GENERATED AUTOMATICALlY. MIGUEL SAID IN CLASS THAT WE DO NOT HAVE TO MODIFY THIS
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow mainWindow = new MainWindow();
            Application.Run(mainWindow);
        }
    }
}
