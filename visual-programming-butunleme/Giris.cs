using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visual_programming_butunleme
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mail = textBox1.Text;
            string sifre = textBox2.Text;

            if (mail != "" && sifre != "")
            {
                string query = $"SELECT * FROM ogretmenler WHERE mail='{mail}' AND sifre='{sifre}'";
                MySqlCommand cmd = new MySqlCommand(query, Veritabani.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    AnaForm ana = new AnaForm();
                    reader.Close();
                    ana.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Şifre Boş Olamaz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Giris_Load(object sender, EventArgs e)
        {
            if (Veritabani.connection.State == ConnectionState.Closed)
            {
                Veritabani.connection.Open();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
