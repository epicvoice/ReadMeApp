using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryApp
{
    public partial class strona_glowna : Form
    {
        private string userEmail;

        public strona_glowna(string email)
        {
            InitializeComponent();
            userEmail = email;
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            profile profile = new profile(userEmail);
            profile.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            strona_glowna strona_glowna = new strona_glowna(userEmail);
            strona_glowna.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            witamy witamy = new witamy(userEmail);
            witamy.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            contact contact = new contact(userEmail);
            contact.Show();
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            news news = new news(userEmail);
            news.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            string searchText = textBox1.Text;
            LoadData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            string connectionString = "server=localhost;database=book_projekt1;user=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM katalog_biblioteczny WHERE Tytuł LIKE @searchText OR Autor LIKE @searchText";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd w wyszukiwaniu: " + ex.Message);
                }
            }
        }

        private void LoadData()
        {
            string connectionString = "server=localhost;database=book_projekt1;user=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Id_Książki, Tytuł, Autor, Data_Wydania, Opis, ilośćSztuk FROM katalog_biblioteczny";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string bookId = row.Cells["Id_Książki"].Value.ToString();
                string title = row.Cells["Tytuł"].Value.ToString();

                DialogResult result = MessageBox.Show($"Czy na pewno chcesz wypożyczyć książkę \"{title}\"?", "Potwierdzenie wypożyczenia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    RentBook(bookId);
                }
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
                    string insertQuery = "INSERT INTO wypożyczenia (Id_książki, Tytuł, Autor, Data_Wydania, Opis, ilośćSztuk, UUID) " +
                                         "SELECT Id_Książki, Tytuł, Autor, Data_Wydania, Opis, ilośćSztuk, UUID " +
                                         "FROM katalog_biblioteczny WHERE Id_Książki = @bookId";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
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
                    LoadData(); // Odświeżenie danych po wypożyczeniu
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas wypożyczania książki: " + ex.Message);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                string bookId = selectedRow.Cells["Id_Książki"].Value.ToString();

                RentBook(bookId);
            }
            else
            {
                MessageBox.Show("Wybierz książkę do wypożyczenia.");
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Obsługa kliknięcia na pictureBox1
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Obsługa kliknięcia na label6
        }
    }
}









