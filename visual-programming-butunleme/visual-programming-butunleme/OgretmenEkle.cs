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
    public partial class OgretmenEkle : Form
    {
        public OgretmenEkle()
        {
            InitializeComponent();
        }
        // ad	soyad	mail	sifre	telno	alan	

        private void Ogretmen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string mail = textBox3.Text;
            string sifre = textBox4.Text;
            string telno = textBox5.Text;
            if (ad != "" && soyad != "" && mail != "" && sifre != "" && telno != "")
            {
                string alan = comboBox1.Text;
                string query = $"insert into ogretmenler(ad,soyad,mail,sifre,telno,alan) values('{ad}','{soyad}','{mail}','{sifre}','{telno}','{alan}')";
                MySqlCommand command = new MySqlCommand(query,Veritabani.connection);
                command.ExecuteNonQuery();
                MessageBox.Show("kaydedildi");
            }
            else
            {
                MessageBox.Show("İlgili alanları doldurunuz");            
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaForm anaForm = new AnaForm();
            anaForm.Show();
            this.Close();
        }
    }
}
