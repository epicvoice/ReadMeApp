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
    public partial class news : Form
    {
        private string email;

        public news(string email)
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

        private void label5_Click(object sender, EventArgs e)
        {
            // Przekazanie wymaganego parametru 'email' do konstruktora contact
            contact contact = new contact(email);
            contact.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Tworzenie nowej instancji news nie jest konieczne w przypadku kliknięcia w label2
            // news news = new news();
            // news.Show();
            // this.Hide();
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
