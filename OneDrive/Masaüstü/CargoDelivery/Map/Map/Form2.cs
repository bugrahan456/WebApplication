using FireSharp.Response;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Map
{
    public partial class Form2 : Form
    {


        public EventStreamResponse listener;
        string[,] mesafe = new string[10, 10];
        firebasebaglanti con = new firebasebaglanti();
        public List<Lokasyonlar> yeniLokasyonlar2 = new List<Lokasyonlar>();
        List<Edge> Rota;
        GMapOverlay markers = new GMapOverlay("markers");
        GMapOverlay routes = new GMapOverlay("routes");
        Root2 myDeserializedClass2;

        async void SetListener()
        {

            listener = await con.client.OnAsync("lokasyonlar/",
            added: (s, args, context) => { herSey(); },
            changed: (s, args, context) => { },
            removed: (s, args, context) => { Thread.Sleep(7000); herSey(); });
        }
        public Form2()
        {
            InitializeComponent();
            con.client = new FireSharp.FirebaseClient(con.config);
            Control.CheckForIllegalCrossThreadCalls = false;
            SetListener();
        }

        public string cevir(string nokta)
        {

            char[] a = nokta.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {

                if (a[i] == ',')
                {
                    a[i] = '.';
                }
            }
            string noktaX = new string(a);

            return noktaX;
        }
        public void markerla(double enlem, double boylam, int a)
        {

            map.Overlays.Clear();
            map.Position = new PointLatLng(enlem, boylam);
            if (a == 0)
            {
                PointLatLng point = new PointLatLng(enlem, boylam);
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot)
                {

                    ToolTipText = $"Enlem:{map.Position.Lat}, \nBoylam:{map.Position.Lng}"
                };


                var toolTip = new GMapToolTip(marker)
                {
                    Fill = new SolidBrush(Color.Teal),
                    Foreground = new SolidBrush(Color.White),
                    Offset = new Point(100, -30),
                    // Stroke = new Pen(new SolidBrush(Color.Red))
                };
                marker.ToolTip = toolTip;
                markers.Markers.Add(marker);
            }
            else
            {
                PointLatLng point2 = new PointLatLng(enlem, boylam);
                GMapMarker marker2 = new GMarkerGoogle(point2, GMarkerGoogleType.blue_dot)
                {

                    ToolTipText = $"Enlem:{map.Position.Lat}, \nBoylam:{map.Position.Lng}"
                };


                var toolTip = new GMapToolTip(marker2)
                {
                    Fill = new SolidBrush(Color.Teal),
                    Foreground = new SolidBrush(Color.White),
                    Offset = new Point(100, -30),
                    // Stroke = new Pen(new SolidBrush(Color.Red))
                };
                marker2.ToolTip = toolTip;
                markers.Markers.Add(marker2);
            }


            map.Overlays.Add(markers);

        }



        public void rotaCiz(List<Edge> asdfff, List<Lokasyonlar> lokasyonlar, int er)
        {
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyCuHa6ysM83enPlNdAdbHUUFxIUClCDeuc";
            map.MapProvider = GMapProviders.GoogleMap;
            map.MapProvider = GMapProviders.GoogleMap;


            PointLatLng noktalarMerkez = new PointLatLng();
            PointLatLng noktalarVaris = new PointLatLng();
            int i;

            for (i = 0; i < er; i++)
            {

                noktalarMerkez.Lat = Convert.ToDouble(lokasyonlar[asdfff[i].Source].enlem);
                noktalarMerkez.Lng = Convert.ToDouble(lokasyonlar[asdfff[i].Source].boylam);
                noktalarVaris.Lat = Convert.ToDouble(lokasyonlar[asdfff[i].Destination].enlem);
                noktalarVaris.Lng = Convert.ToDouble(lokasyonlar[asdfff[i].Destination].boylam);
                int B = Convert.ToInt32(lokasyonlar[asdfff[i].Destination].ID);


                var route = GoogleMapProvider.Instance.GetRoute(noktalarMerkez, noktalarVaris, false, false, 10);
                var r = new GMapRoute(route.Points, "My Route")
                {
                    Stroke = new Pen(Color.Teal, 5)
                };
                routes.Routes.Add(r);
                map.Overlays.Add(routes);

            }
        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            map.DragButton = MouseButtons.Left;
            map.MinZoom = 0;
            map.MaxZoom = 100;
            map.Zoom = 10;
            map.ShowCenter = false;
            map.MapProvider = GMapProviders.GoogleMap;
            map.SetPositionByKeywords("Izmit,Turkey");
            string a = "232";

        }

        public void herSey()
        {
            markers.Clear();
            routes.Clear();
            Graph graph = new Graph();
            List<Edge> ffgh = new List<Edge>();
            //firebase 

            String adres2 = "https://maps-576fd-default-rtdb.firebaseio.com/.json";
            WebRequest istek2 = HttpWebRequest.Create(adres2);
            WebResponse cevap2;
            cevap2 = istek2.GetResponse();
            StreamReader donenBilgiler2 = new StreamReader(cevap2.GetResponseStream());
            string json2 = donenBilgiler2.ReadToEnd();
            myDeserializedClass2 = JsonConvert.DeserializeObject<Root2>(json2);



            //veri yazma

            for (int i = 0; i < (myDeserializedClass2.lokasyonlar.Count) - 1; i++)
            {
                for (int j = i + 1; j < myDeserializedClass2.lokasyonlar.Count; j++)
                {

                    String adres = "https://maps.googleapis.com/maps/api/distancematrix/json?destinations=" + cevir(myDeserializedClass2.lokasyonlar[j].enlem) + "%2C" + cevir(myDeserializedClass2.lokasyonlar[j].boylam) + "&origins=" + cevir(myDeserializedClass2.lokasyonlar[i].enlem) + "%2C" + cevir(myDeserializedClass2.lokasyonlar[i].boylam) + "&key=AIzaSyD0dBwD9Fr00SuGZtqcGilliPhmT04XgKA";
                    WebRequest istek = HttpWebRequest.Create(adres);
                    WebResponse cevap;
                    cevap = istek.GetResponse();
                    StreamReader donenBilgiler = new StreamReader(cevap.GetResponseStream());
                    string json = donenBilgiler.ReadToEnd();
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);

                    ffgh.Add(new Edge()
                    {
                        Source = Convert.ToInt32(myDeserializedClass2.lokasyonlar[i].ID),
                        Destination = Convert.ToInt32(myDeserializedClass2.lokasyonlar[j].ID),
                        Weight = myDeserializedClass.rows[0].elements[0].distance.value
                    });
                    // MessageBox.Show(i +" ile "+j+"arasi "+"\n"+ Convert.ToString(mesafe[i,j]) + " yeni");

                }
            }

            //en kısa yol algoritması

            Kruskal a = new Kruskal();
            int er = ((myDeserializedClass2.lokasyonlar.Count) * (myDeserializedClass2.lokasyonlar.Count - 1)) / 2;

            Rota = a.Calistir(ffgh, myDeserializedClass2.lokasyonlar.Count, ffgh.Count);
            int yu = a.deger();


            for (int i = 0; i < myDeserializedClass2.lokasyonlar.Count; i++)
            {
                markerla(Convert.ToDouble(myDeserializedClass2.lokasyonlar[i].enlem), Convert.ToDouble(myDeserializedClass2.lokasyonlar[i].boylam), Convert.ToInt32(myDeserializedClass2.lokasyonlar[i].kargocuMu));

            }

            rotaCiz(Rota, myDeserializedClass2.lokasyonlar, yu);

        }

        private void map_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("adsaadas");
        }
        private void login2(int a, int b)
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
            herSey();


            #region Silme

            if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(Rota[0].Source) == 0 )
            {
                for (int i = 0; i < 7; i++)
                {

                    login2(i + 1, Rota[0].Source);

                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(Rota[0].Source) == 1 )
            {
                for (int i = 0; i < 6; i++)
                {
                    login2(i + 2, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(Rota[0].Source) == 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    login2(i + 3, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(Rota[0].Source) == 3 )
            {
                for (int i = 0; i < 4; i++)
                {
                    login2(i + 4, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(Rota[0].Source) == 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    login2(i + 5, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(Rota[0].Source) == 5 )
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 6, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(Rota[0].Source) == 6 )
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 7, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 8 && Convert.ToInt32(Rota[0].Source) == 7)
            {
                con.response = con.client.Delete("lokasyonlar/" + 7);

            }


            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(Rota[0].Source) == 0 )
            {
                for (int i = 0; i < 6; i++)
                {
                    login2(i + 1, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(Rota[0].Source) == 1 )
            {
                for (int i = 0; i < 5; i++)
                {
                    login2(i + 2, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(Rota[0].Source) == 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    login2(i + 3, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(Rota[0].Source) == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    login2(i + 4, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(Rota[0].Source) == 4)
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 5, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(Rota[0].Source) == 5 )
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 6, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 7 && Convert.ToInt32(Rota[0].Source) == 6 )
            {
                con.response = con.client.Delete("lokasyonlar/" + Rota[0].Source);

            }


            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(Rota[0].Source) == 0 )
            {
                for (int i = 0; i < 5; i++)
                {
                    login2(i + 1, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(Rota[0].Source) == 1 )
            {
                for (int i = 0; i < 4; i++)
                {
                    login2(i + 2, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(Rota[0].Source) == 2 )
            {
                for (int i = 0; i < 3; i++)
                {
                    login2(i + 3, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(Rota[0].Source) == 3  )
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 4, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(Rota[0].Source) == 4)
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 5, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 6 && Convert.ToInt32(Rota[0].Source) == 5 )
            {
                con.response = con.client.Delete("lokasyonlar/" + Rota[0].Source);

            }


            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(Rota[0].Source) == 0 )
            {
                for (int i = 0; i < 4; i++)
                {
                    login2(i + 1, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(Rota[0].Source) == 1 )
            {
                for (int i = 0; i < 3; i++)
                {
                    login2(i + 2, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(Rota[0].Source) == 2 )
            {
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 3, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(Rota[0].Source) == 3)
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 4, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 5 && Convert.ToInt32(Rota[0].Source) == 4 )
            {
                con.response = con.client.Delete("lokasyonlar/" + Rota[0].Source);

            }
            else if (myDeserializedClass2.lokasyonlar.Count == 4 && Convert.ToInt32(Rota[0].Source) == 0 )
            {
              
                for (int i = 0; i < 3; i++)
                {
              
                    login2(i + 1, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 4 && Convert.ToInt32(Rota[0].Source) == 1)
            {
               
                for (int i = 0; i < 2; i++)
                {

                    login2(i + 2, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 4 && Convert.ToInt32(Rota[0].Source) == 2 )
            {
             
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 3, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 4 && Convert.ToInt32(Rota[0].Source) == 3)
            {
                con.response = con.client.Delete("lokasyonlar/" + 3);
            }


            else if (myDeserializedClass2.lokasyonlar.Count == 3 && Convert.ToInt32(Rota[0].Source) == 0 )
            {
               
                for (int i = 0; i < 2; i++)
                {
                    login2(i + 1, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 3 && Convert.ToInt32(Rota[0].Source) == 1 )
            {
              
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 2, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 3 && Convert.ToInt32(Rota[0].Source) == 2 )
            {
                con.response = con.client.Delete("lokasyonlar/" + 2);
             
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 2 && Convert.ToInt32(Rota[0].Source) == 0 )
            {
                for (int i = 0; i < 1; i++)
                {
                    login2(i + 1, Rota[0].Source);
                }
            }
            else if (myDeserializedClass2.lokasyonlar.Count == 2 && Convert.ToInt32(Rota[0].Source) == 1 )
            {
                
                for (int i = 0; i < 1; i++)
                {
                    con.response = con.client.Delete("lokasyonlar/" + 1);
                }
            }
            #endregion

        }




        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //json mesafeyi almak için                             
        public class Distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Element
        {
            public Distance distance { get; set; }
            public Duration duration { get; set; }
            public string status { get; set; }
        }

        public class Row
        {
            public List<Element> elements { get; set; }
        }

        public class Root
        {
            public List<string> destination_addresses { get; set; }
            public List<string> origin_addresses { get; set; }
            public List<Row> rows { get; set; }
            public string status { get; set; }
        }


        public class Kullanıcılar
        {

            public string kullanici_adi { get; set; }
            public string sifre { get; set; }
        }


        //normal
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

    }
}
