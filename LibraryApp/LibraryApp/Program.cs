using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
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

            // Przykładowy e-mail użytkownika, który można pobrać z zewnętrznej bazy danych lub z formularza logowania
            string userEmail = "example@example.com";

            Application.Run(new strona_glowna(userEmail));
        }
    }
}
