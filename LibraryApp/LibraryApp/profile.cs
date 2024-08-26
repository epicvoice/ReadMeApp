using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryApp
{
    public partial class profile : Form
    {
        private string userEmail;

        public profile(string email)
        {
            InitializeComponent();
            userEmail = email;
            LoadUserData();
            LoadUserBooks();
        }

        private void LoadUserData()
        {
            string connectionString = "server=localhost;database=book_projekt1;user=root";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Imie, Nazwisko, Emial FROM user WHERE Emial = @userEmail";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userEmail", userEmail);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelImie.Text = reader["Imie"].ToString();
                            labelNazwisko.Text = reader["Nazwisko"].ToString();
                            labelEmail.Text = reader["Emial"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas ładowania danych użytkownika: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedRowIndex];
                string bookId = selectedRow.Cells["Id_książki"].Value.ToString();

                ReturnBook(bookId);
            }
            else
            {
                MessageBox.Show("Wybierz książkę do zwrotu.");
            }
        }



        private void RentBook(string bookId)
        {
            string connectionString = "server=localhost;database=book_projekt1;user=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Dodanie książki do wypożyczenia
                    string insertQuery = "INSERT INTO wypożyczenia (Id_książki, Tytuł, Autor, Data_Wydania, Opis, ilośćSztuk, UUID, UserEmail) " +
                                         "SELECT Id_Książki, Tytuł, Autor, Data_Wydania, Opis, ilośćSztuk, UUID, @userEmail " +
                                         "FROM katalog_biblioteczny WHERE Id_Książki = @bookId";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@userEmail", userEmail);
                        cmd.ExecuteNonQuery();
                    }

                    // Aktualizacja liczby sztuk w katalogu
                    string updateQuery = "UPDATE katalog_biblioteczny SET ilośćSztuk = ilośćSztuk - 1 WHERE Id_Książki = @bookId";
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Książka została wypożyczona.");
                    LoadUserData(); // Odświeżenie danych po wypożyczeniu
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas wypożyczania książki: " + ex.Message);
                }
            }
        }


        private void LoadUserBooks()
        {
            string connectionString = "server=localhost;database=book_projekt1;user=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT w.Id_książki, k.Tytuł, k.Autor, k.Data_Wydania, k.Opis, k.UUID " +
                                   "FROM wypożyczenia w " +
                                   "JOIN katalog_biblioteczny k ON w.Id_książki = k.Id_Książki";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas ładowania wypożyczonych książek: " + ex.Message);
                }
            }
        }

        private void ReturnBook(string bookId)
        {
            string connectionString = "server=localhost;database=book_projekt1;user=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Usunięcie książki z wypożyczenia
                    string deleteQuery = "DELETE FROM wypożyczenia WHERE Id_książki = @bookId";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();
                    }

                    // Aktualizacja liczby sztuk w katalogu
                    string updateQuery = "UPDATE katalog_biblioteczny SET ilośćSztuk = ilośćSztuk + 1 WHERE Id_Książki = @bookId";
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Książka została zwrócona.");
                    LoadUserBooks(); // Odświeżenie danych po zwróceniu książki
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas zwracania książki: " + ex.Message);
                }
            }
        }


        private int GetUserEmailId()
        {
            string connectionString = "server=localhost;database=book_projekt1;user=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Id FROM user WHERE Emial = @userEmail";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userEmail", userEmail);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("Nie można odnaleźć użytkownika.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Wystąpił błąd podczas pobierania Id użytkownika: " + ex.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Obsługa zdarzenia Paint na panelu
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Obsługa kliknięcia na pictureBox
        }

        private void label1_Click(object sender, EventArgs e)
        {
            profile profileForm = new profile(userEmail);
            profileForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            strona_glowna strona_glownaForm = new strona_glowna(userEmail);
            strona_glownaForm.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            witamy witamyForm = new witamy(userEmail);
            witamyForm.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            contact contactForm = new contact(userEmail);
            contactForm.Show();
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            news newsForm = new news(userEmail);
            newsForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


