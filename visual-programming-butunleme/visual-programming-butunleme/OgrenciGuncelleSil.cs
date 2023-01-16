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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace visual_programming_butunleme
{
    public partial class OgrenciGuncelleSil : Form
    {
        public OgrenciGuncelleSil()
        {
            InitializeComponent();
        }
        int id = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string mail = textBox3.Text;
            string sifre = textBox4.Text;
            string telno = textBox5.Text;
            string adres = richTextBox1.Text;
            if (ad != "" && soyad != "" && mail != "" && sifre != "" && telno != "")
            {
                
                string query = $"UPDATE ogrenciler SET ad='{ad}',soyad='{soyad}',mail='{mail}',sifre='{sifre}',telno='{telno}',adres='{adres}' WHERE id={id}";
                MySqlCommand command = new MySqlCommand(query, Veritabani.connection);
                command.ExecuteNonQuery();
                VeriGuncelle();
                MessageBox.Show("güncellendi");
            }
            else
            {
                MessageBox.Show("İlgili alanları doldurunuz");
            }
        }
        void VeriGuncelle()
        {
            string query = "select * from ogrenciler";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, Veritabani.connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id >= 0)
            {
                string query = $"DELETE FROM ogrenciler  WHERE id={id}";
                MySqlCommand command = new MySqlCommand(query, Veritabani.connection);
                command.ExecuteNonQuery();
                VeriGuncelle();
                MessageBox.Show("silindi");
            }
        }

        private void OgrenciGuncelleSil_Load(object sender, EventArgs e)
        {
            Veritabani.connection.Open();
            VeriGuncelle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaForm anaForm = new AnaForm();
            anaForm.Show();
            this.Close();
        }
    }
}
