using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace visual_programming_butunleme
{
    public partial class DersIslemleri : Form
    {
        public DersIslemleri()
        {
            InitializeComponent();
        }
        int id = -1;
        private void button1_Click(object sender, EventArgs e)
        {

            string dersadi = textBox1.Text;
            string ogretmenadi = textBox2.Text;
            string donem = textBox3.Text;
            if (dersadi != "" && ogretmenadi != "" && donem != "")
            {
                string akts = comboBox1.Text;
                string query = $"insert into dersler(dersadi,akts,donem,ogretmen) values('{dersadi}','{akts}','{donem}','{ogretmenadi}')";
                MySqlCommand command = new MySqlCommand(query, Veritabani.connection);
                command.ExecuteNonQuery();
                DersleriGuncelle();
                MessageBox.Show("kaydedildi");
            }
            else
            {
                MessageBox.Show("İlgili alanları doldurunuz");
            }
        }
        void OgretmenYenile()
        {
            string query = "select * from ogretmenler";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, Veritabani.connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }
        void DersleriGuncelle()
        {
            string query = "select * from dersler";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, Veritabani.connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void DersIslemleri_Load(object sender, EventArgs e)
        {
            DersleriGuncelle();
            OgretmenYenile();
            Veritabani.connection.Open();
        }

        private void btnDersGuncelle_Click(object sender, EventArgs e)
        {
            string dersadi = tbxAdGuncelle.Text;
            string ogretmenadi = tbxOgretmenGuncelle.Text;
            string donem = tbxDonemGuncelle.Text;
            if (dersadi != "" && ogretmenadi != "" && donem != "")
            {
                string akts = cbxAktsGuncelle.Text;
                string query = $"UPDATE dersler SET dersadi='{dersadi}',akts='{akts}',donem='{donem}',ogretmen='{ogretmenadi}' WHERE id={id}";
                MySqlCommand command = new MySqlCommand(query, Veritabani.connection);
                command.ExecuteNonQuery();
                DersleriGuncelle();
                MessageBox.Show("kaydedildi");
            }
            else
            {
                MessageBox.Show("İlgili alanları doldurunuz");
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            tbxAdGuncelle.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbxAktsGuncelle.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxDonemGuncelle.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxOgretmenGuncelle.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (id >= 0)
            {
                string query = $"DELETE FROM dersler  WHERE id={id}";
                MySqlCommand command = new MySqlCommand(query, Veritabani.connection);
                command.ExecuteNonQuery();
                DersleriGuncelle();
                MessageBox.Show("silindi");
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
