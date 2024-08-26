using Rejestracja_użytkownika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using LibraryApp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Katalog_Biblioteczny
{
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';


        }

        private void button2_Click(object sender, EventArgs e)
        {

            Rejestracja form2 = new Rejestracja();


            form2.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (SprawdzDaneLogowania(username, password, out string userType))
            {

                // Tutaj możesz otworzyć główne okno aplikacji
                this.Hide();
                if (userType == "Admin")
                {
                    MessageBox.Show("Zalogowano jako Administrator", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LibraryApp.strona_glowna stronaGlownaForm = new LibraryApp.strona_glowna(username);
                    stronaGlownaForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Zalogowano jako użytkownik", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LibraryApp.strona_glowna stronaGlownaForm = new LibraryApp.strona_glowna(username);

                    stronaGlownaForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SprawdzDaneLogowania(string username, string password, out string userType)
        {
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=book_projekt1";
            userType = string.Empty;
            bool zalogowano = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Tworzenie zapytania SQL do sprawdzenia danych logowania i pobrania typu użytkownika
                    string query = "SELECT Hasło, UserType FROM user WHERE Emial = @username";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPasswordHash = reader["Hasło"].ToString();
                            userType = reader["UserType"].ToString();

                            string hashedPassword = HashujHaslo(password);

                            if (storedPasswordHash == hashedPassword)
                            {
                                zalogowano = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą danych: " + ex.Message);
            }

            return zalogowano;
        }

        private string HashujHaslo(string haslo)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(haslo));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Logowanie_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



