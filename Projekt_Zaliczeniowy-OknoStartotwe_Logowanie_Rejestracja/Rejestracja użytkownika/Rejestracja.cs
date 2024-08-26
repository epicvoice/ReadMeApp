using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace Rejestracja_użytkownika
{
    

   
    public partial class Rejestracja : Form
    {
        public Rejestracja()
        {
            InitializeComponent();
            text_password.PasswordChar = '*';
            text_repPass.PasswordChar = '*';

            comboBox_TypeUser.Items.Add("User");
            comboBox_TypeUser.Items.Add("Admin");
            comboBox_TypeUser.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string imie = (string)this.text_Name.Text;      //pobieranie zmiennych z textboxów
            string nazwisko = (string)this.Text_sName.Text;
            string email = (string)this.text_eMail.Text;
            string haslo = (string)this.text_password.Text;
            string powhaslo = (string)this.text_repPass.Text;


            if (string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(haslo) || string.IsNullOrEmpty(powhaslo)) //sprawdzanie czy pola nie są puste
            {
                MessageBox.Show("Proszę uzupełnić puste pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (powhaslo != haslo)   //sprawdzanie czy hasła są identyczne
            {
                MessageBox.Show("Hasła nie są identyczne", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string haslohash = HashujHaslo(haslo); //hashowanie hasła


            string userType = comboBox_TypeUser.SelectedItem.ToString();

            if (userType == "Admin")
            {
                string adminLevel = "DefaultAdminLevel";
                Admin nowyAdmin = new Admin(imie, nazwisko, email, haslohash, adminLevel);
                DodajUzytkownikaDoBazyDanych(nowyAdmin);
            }
            else
            {

                User nowyUzytkownik = new User(imie, nazwisko, email, haslohash);
                DodajUzytkownikaDoBazyDanych(nowyUzytkownik);
            }
            wyczysc();
            Close();
        }
        public class User //obiekt użytkownik
        {
            public string Imie;
            public string Nazwisko; 
            public string Email;   
            public string Haslo;

            public User(string imie, string nazwisko, string email, string haslohash)
            {
                Imie = imie;
                Nazwisko = nazwisko;
                Email = email;
                Haslo = haslohash;

            }
        }
        public class Admin : User
        {
            public string AdminLevel;

            public Admin(string imie, string nazwisko, string email, string haslohash, string adminLevel)
                : base(imie, nazwisko, email, haslohash)
            {
                AdminLevel = adminLevel;
            }
        }

        private void DodajUzytkownikaDoBazyDanych(User user)
        {
            try
            {
                string server = "localhost"; // Adres serwera MySQL, w Twoim przypadku może być inny
                string database = "book_projekt1"; // Nazwa Twojej bazy danych
                string uid = "root"; // Użytkownik bazy danych
                string password = ""; // Hasło użytkownika bazy danych

                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query;

                    if (user is Admin admin)
                    {
                        query = "INSERT INTO user (Imie, Nazwisko, Emial, Hasło, UserType, AdminLevel) VALUES (@Imie, @Nazwisko, @Emial, @Hasło, 'Admin', @AdminLevel)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Imie", user.Imie);
                        command.Parameters.AddWithValue("@Nazwisko", user.Nazwisko);
                        command.Parameters.AddWithValue("@Emial", user.Email);
                        command.Parameters.AddWithValue("@Hasło", user.Haslo);
                        command.Parameters.AddWithValue("@AdminLevel", admin.AdminLevel);

                        // Wykonanie zapytania
                        command.ExecuteNonQuery();

                    }
                    else
                    {
                        query = "INSERT INTO user (Imie, Nazwisko, Emial, Hasło, UserType) VALUES (@Imie, @Nazwisko, @Emial, @Hasło, 'User')";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Imie", user.Imie);
                        command.Parameters.AddWithValue("@Nazwisko", user.Nazwisko);
                        command.Parameters.AddWithValue("@Emial", user.Email);
                        command.Parameters.AddWithValue("@Hasło", user.Haslo);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania użytkownika do bazy danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string HashujHaslo(string haslo) // funckja hashowania hasła 
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(haslo));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }        
        private void wyczysc()
        {
            text_Name.Text = "";
            Text_sName.Text = "";
            text_eMail.Text = "";
            text_password.Text = "";
            text_repPass.Text = "";
        } // funkcja czyszczenia formularza


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
