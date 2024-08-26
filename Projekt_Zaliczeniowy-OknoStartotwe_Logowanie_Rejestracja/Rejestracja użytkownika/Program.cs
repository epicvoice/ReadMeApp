using Katalog_Biblioteczny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rejestracja_użytkownika
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EkranWczytywania splashScreen = new EkranWczytywania();
            splashScreen.ShowDialog();

            Application.Run(new Logowanie());
        }
    }
}
