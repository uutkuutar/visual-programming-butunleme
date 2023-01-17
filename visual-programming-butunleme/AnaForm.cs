using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visual_programming_butunleme
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            havadurumu();
        }
        void havadurumu()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=kutahya&units=metric&lang=tr&appid=18b7da270bfc7233837e5cb92fd84f38");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            try
            {

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);
                    label1.Text = "Hava: "+data["main"]["temp"].ToString()+"°";
                }

            }
            catch { }
        }
       

        private void güncellesilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenGuncelleSil ogretmenGuncelleSil = new OgretmenGuncelleSil();
            ogretmenGuncelleSil.Show();
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Close();

        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenEkle ogretmen = new OgretmenEkle();
            ogretmen.Show();
            this.Close();
        }

        private void ekleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OgrenciEkle ogrenci = new OgrenciEkle();
            ogrenci.Show();
            this.Close();
        }

        private void güncellesilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OgrenciGuncelleSil ogrenciGuncelleSil = new OgrenciGuncelleSil();
            ogrenciGuncelleSil.Show();
            this.Close();
        }

        private void işlemlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DersIslemleri dersIslemleri = new DersIslemleri();
            dersIslemleri.Show();
            this.Close();
        }
    }
}
