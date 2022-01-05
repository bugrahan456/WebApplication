using FireSharp.Response;
using GMap.NET;
using GMap.NET.MapProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace koordinatGirme
{
    public partial class Form1 : Form
    {

        public EventStreamResponse listener;
        firebasebaglanti con = new firebasebaglanti();
        private List<PointLatLng> pointss = new List<PointLatLng>();
        Root2 myDeserializedClass2;
        async void SetListener()
        {

            listener = await con.client.OnAsync("lokasyonlar/",
            added: (s, args, context) => { json(); },
            changed: (s, args, context) => { json(); },
            removed: (s, args, context) => { Thread.Sleep(7000); json(); });
        }

        public Form1()
        {
            InitializeComponent();
            pointss = new List<PointLatLng>();
            con.client = new FireSharp.FirebaseClient(con.config);
            Control.CheckForIllegalCrossThreadCalls = false;
            SetListener();
        }
        public class Root
        {
            public List<Lokasyonlar> lokasyonlar { get; set; }
        }

        public void tablo() 
        {
           
            dataGridView1.Rows.Clear();
            for (int x = 0; x < myDeserializedClass2.lokasyonlar.Count; x++) {
                dataGridView1.Rows.Add(myDeserializedClass2.lokasyonlar[x].ID, myDeserializedClass2.lokasyonlar[x].enlem, myDeserializedClass2.lokasyonlar[x].boylam);
            } 
          

        }
        public void json()
        {
            Thread.Sleep(4000);
            String adres2 = "https://maps-576fd-default-rtdb.firebaseio.com/.json";
            WebRequest istek2 = HttpWebRequest.Create(adres2);
            WebResponse cevap2;
            cevap2 = istek2.GetResponse();
            StreamReader donenBilgiler2 = new StreamReader(cevap2.GetResponseStream());
            string json2 = donenBilgiler2.ReadToEnd();
            myDeserializedClass2 = JsonConvert.DeserializeObject<Root2>(json2);
           
            tablo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            try
            {
                con.client = new FireSharp.FirebaseClient(con.config);
            }
            catch (Exception)
            {
                MessageBox.Show("internet baglantınızı kontrol ediniz");
            }
        }

        private void login()
        {
            try
            {
                if (textBox1.Text != null && textBox2.Text != null)
                {
                    con.client = new FireSharp.FirebaseClient(con.config);
                    Lokasyonlar kll = new Lokasyonlar()
                    {
                        ID = textBox1.Text,
                        enlem = textBox2.Text,
                        boylam = textBox3.Text,
                    
                        kargocuMu=false
                    };
                
                    var setter = con.client.Set("lokasyonlar/" + textBox1.Text, kll);

                    MessageBox.Show("lokasyon ekleme basarılı");
                }
                else
                {
                    MessageBox.Show("bilgilerinizi eksiksiz doldurunuz");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void login2(int a)
        {
            try
            {
                con.response = con.client.Get("lokasyonlar/" + Convert.ToString(a));
                Lokasyonlar kll1 = con.response.ResultAs<Lokasyonlar>();
                kll1.ID = Convert.ToString(Convert.ToInt32(kll1.ID) - 1);
                var setter = con.client.Set("lokasyonlar/" + Convert.ToString(a - 1), kll1);
                con.response = con.client.Delete("lokasyonlar/" + Convert.ToString(a));

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();

        }
        /*
    
         */


        private void button2_Click(object sender, EventArgs e)
        {

            json();
            #region silme
            if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(textBox1.Text) == 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    login2(i + 1);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(textBox1.Text) == 1)
            {
                for (int i = 0; i < 6; i++)
                {
                    login2(i + 2);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(textBox1.Text) == 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    login2(i + 3);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(textBox1.Text) == 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    login2(i + 4);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(textBox1.Text) == 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    login2(i + 5);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(textBox1.Text) == 5)
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 6);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(textBox1.Text) == 6)
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 7);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(textBox1.Text) == 7)
            {
                con.response = con.client.Delete("lokasyonlar/" + textBox1.Text);

            }


            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(textBox1.Text) == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    login2(i + 1);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(textBox1.Text) == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    login2(i + 2);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(textBox1.Text) == 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    login2(i + 3);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(textBox1.Text) == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    login2(i + 4);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(textBox1.Text) == 4)
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 5);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(textBox1.Text) == 5)
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 6);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(textBox1.Text) == 6)
            {
                con.response = con.client.Delete("lokasyonlar/" + textBox1.Text);

            }


            if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(textBox1.Text) == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    login2(i + 1);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(textBox1.Text) == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    login2(i + 2);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(textBox1.Text) == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    login2(i + 3);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(textBox1.Text) == 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 4);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(textBox1.Text) == 4)
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 5);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(textBox1.Text) == 5)
            {
                con.response = con.client.Delete("lokasyonlar/" + textBox1.Text);

            }


            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(textBox1.Text) == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    login2(i + 1);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(textBox1.Text) == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    login2(i + 2);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(textBox1.Text) == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 3);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(textBox1.Text) == 3)
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 4);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(textBox1.Text) == 4)
            {
                con.response = con.client.Delete("lokasyonlar/" + textBox1.Text);

            }
            else if (myDeserializedClass2.lokasyonlar.Count == 4 && Convert.ToInt32(textBox1.Text) == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    login2(i + 1);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 4 && Convert.ToInt32(textBox1.Text) == 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 2);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 4 && Convert.ToInt32(textBox1.Text) == 2)
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 3);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 4 && Convert.ToInt32(textBox1.Text) == 3)
            {
                con.response = con.client.Delete("lokasyonlar/" + textBox1.Text);

            }


            else if (myDeserializedClass2.lokasyonlar.Count == 3 && Convert.ToInt32(textBox1.Text) == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 1);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 3 && Convert.ToInt32(textBox1.Text) == 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 2);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 3 && Convert.ToInt32(textBox1.Text) == 2)
            {
                con.response = con.client.Delete("lokasyonlar/" + textBox1.Text);

            }
            else if (myDeserializedClass2.lokasyonlar.Count == 2 && Convert.ToInt32(textBox1.Text) == 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 1);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 2 && Convert.ToInt32(textBox1.Text) == 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    con.response = con.client.Delete("lokasyonlar/" + textBox1.Text);
                }
            }

            #endregion
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            map.DragButton = MouseButtons.Left;
            map.MinZoom = 0;
            map.MaxZoom = 100;
            map.Zoom = 10;
            map.ShowCenter = false;
            map.MapProvider = GMapProviders.GoogleMap;
            map.SetPositionByKeywords("Izmit,Turkey");
        }
        public class Kullanıcılar
        {

            public string kullanici_adi { get; set; }
            public string sifre { get; set; }
        }

        public class Lokasyonlar
        {
            public string ID { get; set; }
            public string boylam { get; set; }
            public string enlem { get; set; }
      
            public bool kargocuMu { get; set; }
        }

        public class Root2
        {
            public Kullanıcılar kullanıcılar { get; set; }
            public List<Lokasyonlar> lokasyonlar { get; set; }
        }
        private void map_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var point = map.FromLocalToLatLng(e.X, e.Y);
                double enlem = point.Lat;
                double boylam = point.Lng;
                string a = enlem + "";
                string b = boylam + "";

                if (textBox2.Text != null && textBox3.Text != null)
                {
                    con.client = new FireSharp.FirebaseClient(con.config);

                    Lokasyonlar kll2 = new Lokasyonlar();
                    json();
                    kll2.ID = Convert.ToString(myDeserializedClass2.lokasyonlar.Count);
                    kll2.enlem = a;
                    kll2.boylam = b;
                  
                    kll2.kargocuMu = false;


                    var setter = con.client.Set("lokasyonlar/" + kll2.ID, kll2);

                    MessageBox.Show("lokasyon ekleme basarılı");
                }
                else
                {
                    MessageBox.Show("bilgilerinizi eksiksiz doldurunuz");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text != null && textBox2.Text != null)
                {
                    con.client = new FireSharp.FirebaseClient(con.config);
                    Lokasyonlar kll = new Lokasyonlar()
                    {
                        ID = textBox1.Text,
                        enlem = textBox2.Text,
                        boylam = textBox3.Text,
                       
                        kargocuMu = true
                    };

                    var setter = con.client.Set("lokasyonlar/" + textBox1.Text, kll);

                    MessageBox.Show("Kargocu ekleme basarılı");
                }
                else
                {
                    MessageBox.Show("bilgilerinizi eksiksiz doldurunuz");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}