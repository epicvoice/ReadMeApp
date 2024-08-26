using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class contact : Form
    {
        private string email;

        public contact(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Przekazanie wymaganego parametru 'email' do konstruktora strona_glowna
            strona_glowna strona_glowna = new strona_glowna(email);
            strona_glowna.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Przekazanie wymaganego parametru 'email' do konstruktora witamy
            witamy witamy = new witamy(email);
            witamy.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Przekazanie wymaganego parametru 'email' do konstruktora news
            news news = new news(email);
            news.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Przekazanie wymaganego parametru 'email' do konstruktora contact
            contact contact = new contact(email);
            contact.Show();
            this.Hide();
        }

        private void contact_Load(object sender, EventArgs e)
        {
            // Twoja logika tutaj
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Przekazanie wymaganego parametru 'email' do konstruktora profile
            profile profile = new profile(email);
            profile.Show();
            this.Hide();
        }
    }
}
