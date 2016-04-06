using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Facebook;
using FacebookWrapper;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
           
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm facebookFeaturesForm = new MainForm();
            if (facebookFeaturesForm.LoggedIn)
            {
                Application.Run(facebookFeaturesForm);
            }
        }
    }
}
