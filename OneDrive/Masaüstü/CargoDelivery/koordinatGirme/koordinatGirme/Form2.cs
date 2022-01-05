using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace koordinatGirme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        firebasebaglanti con = new firebasebaglanti();
        Root2 myDeserializedClass2;
        public void json()
        {
            String adres2 = "https://maps-576fd-default-rtdb.firebaseio.com/.json";
            WebRequest istek2 = HttpWebRequest.Create(adres2);
            WebResponse cevap2;
            cevap2 = istek2.GetResponse();
            StreamReader donenBilgiler2 = new StreamReader(cevap2.GetResponseStream());
            string json2 = donenBilgiler2.ReadToEnd();
            myDeserializedClass2 = JsonConvert.DeserializeObject<Root2>(json2);
        }



        private void button1_Click(object sender, EventArgs e)
        {

            con.client = new FireSharp.FirebaseClient(con.config);
            con.response = con.client.Get("kullanıcılar/" + textBox1.Text);

            Kullanıcılar kll1 = con.response.ResultAs<Kullanıcılar>();

            if (textBox1.Text == kll1.kullanici_adi && textBox2.Text == kll1.sifre)
            {
               // MessageBox.Show("giriş basarılı");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("kullanıcı adı veya sifre yanlıs");

            }
        }


   

        private void button3_Click(object sender, EventArgs e)
        {
             kullanıcılar kll = new kullanıcılar()
            {
                kullanici_adi = textBox6.Text,
                sifre = textBox7.Text
                
            };
           
            FirebaseResponse response= con.client.Set("kullanıcılar/" + textBox6.Text, kll);
            MessageBox.Show("basarılı");

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            
                if (textBox3.Text != null && textBox4.Text != null)
                {
                    con.client = new FireSharp.FirebaseClient(con.config);
                    con.response = con.client.Get("kullanıcılar/" + textBox3.Text);

                Kullanıcılar kll1 = con.response.ResultAs<Kullanıcılar>();
                
                    if (textBox3.Text == kll1.kullanici_adi && textBox4.Text == kll1.sifre)
                    {
                    kullanıcılar kll3 = new kullanıcılar()
                    {
                        kullanici_adi = textBox3.Text,
                        sifre = textBox5.Text
                    };
                    FirebaseResponse response = con.client.Set("kullanıcılar/" + textBox3.Text, kll3);

                    // var setter = con.client.Set("kullanıcılar/" + textBox3.Text, kll1);
                    MessageBox.Show("Değişti");
                    }
                    else
                    {
                        MessageBox.Show("kullanıcı adı veya sifre yanlıs");

                    }
                }
                else
                {
                    MessageBox.Show("bilgilerinizi eksiksiz doldurunuz");
                }
            

        }

        private void Form2_Load(object sender, EventArgs e)
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
        }

        public class Root2
        {
            public Kullanıcılar kullanıcılar { get; set; }
            public List<Lokasyonlar> lokasyonlar { get; set; }
        }

    }

}
