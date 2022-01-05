using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace SON
{
    
   
    public partial class MainForm : System.Web.UI.Page
    {
        static public string TeslimDonem;
        static public string AnahtarKelime;
        static public string Ogrenci;
        static public string DersAdi;
        static public string Ozet;
        static public string Danisman;
        static public string Juri;
        static public string ProjeAdi;
        static public void AnaFonksiyon(string pdff)
        {
           
            string MetinGiris = pdf_giris(pdff);
            string MetinOnay = pdf_onay(pdff);
            Tarihbul(MetinOnay);
            AnahtarKelimeBul(MetinOnay);
            OgrenciBul(MetinGiris);
            DersAdıBul(MetinOnay);
            OzetBul(MetinGiris);
            JuriBul(MetinOnay);
            DanismanBul(MetinOnay);
            ProjeAdıBul(MetinOnay);

        }



        static public string pdf_giris(string pdfYolu)
        {
            if (File.Exists(pdfYolu))
            {
                PdfReader pdfOkuyucu = new PdfReader(pdfYolu);
                string icerik = "";
                for (int sayfa = 2; sayfa <= pdfOkuyucu.NumberOfPages; sayfa++)
                {
                    icerik += PdfTextExtractor.GetTextFromPage(pdfOkuyucu, sayfa);
                }
                pdfOkuyucu.Close();
                //Console.WriteLine(icerik);
                return icerik;
            }
            else
            {
                return "bos";
            }

        }





        static public string pdf_onay(string pdfYolu)
        {
            if (File.Exists(pdfYolu))
            {
                PdfReader pdfOkuyucu = new PdfReader(pdfYolu);
                string icerik = "";
                for (int sayfa = 1; sayfa <= pdfOkuyucu.NumberOfPages; sayfa++)
                {
                    icerik += PdfTextExtractor.GetTextFromPage(pdfOkuyucu, sayfa);
                }
                pdfOkuyucu.Close();
                //Console.WriteLine(icerik);
                return icerik;
            }
            else
            {
                Console.WriteLine("Dosya bulunamadı");
                return "bos";
            }

        }





        static public void ProjeAdıBul(string metin)
        {
            string asd = "";
            char[] strArray = metin.ToCharArray();
            int a = DersAdi.Length;
            int Sonuc1 = metin.IndexOf(DersAdi, 0, metin.Length - 1);
            Sonuc1 = Sonuc1 + a;
            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz";
            int refe = 0;
            for (int i = Sonuc1; i < metin.Length; i++)
            {
                int t = harfler.IndexOf(strArray[i], 0, harfler.Length - 1);
                if (t != -1)
                {
                    int e = 0;
                    for (int j = i; j < metin.Length; j++)
                    {
                        if (strArray[j] == '\n')
                            e++;

                        if (e > 1)
                        {
                            refe = j;
                            break;
                        }

                    }
                    break;
                }
            }
            ProjeAdi = metin.Substring(Sonuc1, refe - Sonuc1);
            ProjeAdi = ProjeAdi.Replace("\n", String.Empty);
        }







        static public void DanismanBul(string metin)
        {
            string asd = "";
            char[] strArray = metin.ToCharArray();
            int Sonuc1 = metin.IndexOf("Danışman", 0, metin.Length - 1);
            int a = 0;
            for (int i = Sonuc1 - 1; i > 0; i--)
            {
                a++;
                if (strArray[i - 1] == '\n')
                {
                    asd += metin.Substring(i - 1, a);
                    break;
                }
            }
            for (int i = Sonuc1; i < Sonuc1 + 8; i++)
            {
                strArray[i] = 'a';
            }
            metin = new string(strArray);
            //Console.WriteLine(metin);
            int b = 1;
            for (int e = 0; e < 5; e++)
            {
                Sonuc1 = metin.IndexOf("Danışman", 0, metin.Length - 1);
                if (Sonuc1 != -1)
                {
                    a = 0;
                    for (int i = Sonuc1 - 1; i > 0; i--)
                    {
                        a++;
                        if (strArray[i - 1] == '\n')
                        {
                            asd += "-  " + metin.Substring(i, a);
                            b++;
                            break;
                        }
                    }
                    for (int i = Sonuc1; i < Sonuc1 + 8; i++)
                    {
                        strArray[i] = 'a';
                    }
                    metin = new string(strArray);
                }
            }
            Danisman = asd;
            Danisman = Danisman.Replace("\n", String.Empty);


        }








        static public void JuriBul(string metin)
        {
            string qwe = metin;
            char[] strArray = metin.ToCharArray();
            int Sonuc1 = metin.IndexOf("Jüri Üyesi", 0, metin.Length - 1);
            int a = 0;
            for (int i = Sonuc1 - 1; i > 0; i--)
            {
                a++;
                if (strArray[i] == '\n')
                {
                    Juri += metin.Substring(i, a);
                    break;
                }
            }
            for (int i = Sonuc1; i < Sonuc1 + 10; i++)
            {
                strArray[i] = 'a';
            }
            metin = new string(strArray);
            //Console.WriteLine(metin);
            int b = 1;
            for (int e = 0; e < 5; e++)
            {
                Sonuc1 = metin.IndexOf("Jüri Üyesi", 0, metin.Length - 1);
                if (Sonuc1 != -1)
                {
                    a = 0;
                    for (int i = Sonuc1 - 1; i > 0; i--)
                    {
                        a++;
                        if (strArray[i - 1] == '\n')
                        {
                            Juri += "-  " + metin.Substring(i, a);
                            b++;
                            break;
                        }
                    }
                    for (int i = Sonuc1; i < Sonuc1 + 8; i++)
                    {
                        strArray[i] = 'a';
                    }
                    metin = new string(strArray);
                }
            }
            metin = qwe;
            Juri = Juri;
            Juri = Juri.Replace("\n", String.Empty);
            Juri = Juri.Replace("    ", String.Empty);
        }









        static void OzetBul(string metin)
        {
            int Sonuc1 = metin.LastIndexOf("ÖZET");
            int Sonuc2 = metin.LastIndexOf("Anahtar kelimeler:");
            Sonuc2 = Sonuc2 - Sonuc1 - 5;
            Ozet = metin.Substring(Sonuc1 + 5, Sonuc2);
        }






        static void DersAdıBul(string metin)
        {
            int Sonuc1 = metin.IndexOf("ARAŞTIRMA PROBLEMLERİ", 0, metin.Length - 1);
            int Sonuc2 = metin.IndexOf("BİTİRME PROJESİ", 0, metin.Length - 1);

            if (Sonuc1 != -1)
            {
                DersAdi = metin.Substring(Sonuc1, 21);
            }
            else
                DersAdi = metin.Substring(Sonuc2, 15);
        }






        static public void OgrenciBul(string metin)
        {
            string asd = metin;
            char[] strArray = metin.ToCharArray();

            int Sonuc1 = metin.IndexOf("Öğrenci No:", 0, metin.Length - 1);
            int Sonuc2 = metin.IndexOf("İÇİNDEKİLER", 0, metin.Length - 1);

            Ogrenci = metin.Substring(Sonuc1, Sonuc2 - Sonuc1);
            Ogrenci = Ogrenci.Replace("Öğrenci No:", String.Empty);
            Ogrenci = Ogrenci.Replace("Adı Soyadı:", String.Empty);
            Ogrenci = Ogrenci.Replace("İmza:", String.Empty);
            Ogrenci = Ogrenci.Replace("...", String.Empty);
            Ogrenci = Ogrenci.Replace("_", String.Empty);
            Ogrenci = Ogrenci.Replace("-", String.Empty);
            Ogrenci = Ogrenci.Replace("    ", String.Empty);
            Ogrenci = Ogrenci.Replace("\n", String.Empty);
        }












        static public void AnahtarKelimeBul(string metin)
        {
            string asd = metin;
            char[] strArray = metin.ToCharArray();
            int b, a = 0;

            int Sonuc = metin.IndexOf("Anahtar kelimeler:", 0, metin.Length - 1);

            b = Sonuc + 18;
            for (int i = Sonuc + 18; i < strArray.Length; i++)
            {
                a++;
                if (strArray[i] == ',' || strArray[i] == '.')
                {
                    AnahtarKelime += metin.Substring(b, a - 1) + "  -   ";
                    b = i + 1;
                    a = 0;
                }
                if (strArray[i] == '.')
                    break;
            }
            AnahtarKelime = AnahtarKelime + "  ";
            AnahtarKelime = AnahtarKelime.Replace("\n", String.Empty);
            AnahtarKelime = AnahtarKelime.Replace("-     ", String.Empty);
        }







        static public void Tarihbul(string metin)
        {
            string asd = metin;
            int a = metin.IndexOf("Tarih:", 0, metin.Length - 1);

            TeslimDonem = metin.Substring(a + 6, 15);
            TeslimDonem = TeslimDonem.Replace(" ", String.Empty);
            char[] strArray = TeslimDonem.ToCharArray();
            int b = 0;
            for (int i = 1; i < strArray.Length; i++)
            {
                if (char.IsDigit(strArray[i]))
                    if (char.IsDigit(strArray[i + 1]))
                        if (char.IsDigit(strArray[i + 2]))
                            if (char.IsDigit(strArray[i + 3]))
                            {
                                b = i;
                                TeslimDonem = TeslimDonem.Substring(i - 3, 7);
                                break;
                            }
            }

            TeslimDonem = TeslimDonem.Replace(" ", String.Empty);

            int ay = Convert.ToInt32(TeslimDonem.Substring(0, 2));
            int yil = Convert.ToInt32(TeslimDonem.Substring(TeslimDonem.Length - 4, 4));
            if (ay < 9)
            {
                TeslimDonem = (yil - 1).ToString() + "-" + yil.ToString() + " BAHAR";
            }
            else
            {
                TeslimDonem = (yil).ToString() + (yil + 1).ToString() + " GÜZ";
            }
        }

        string constr = "Data Source=DESKTOP-L0TLU75;Initial Catalog = Yazlab3; Integrated Security = True";
        //your database connection string
        protected void Page_Load(object sender, EventArgs e)
        {
          
            int Hocaİd2 = Convert.ToInt32(Request.QueryString["İd"]);
            DataSet1TableAdapters.PdfFilesTableAdapter dt= new DataSet1TableAdapters.PdfFilesTableAdapter();
            Repeater1.DataSource = dt.KullanıcıVeriGetir(Hocaİd2);
            Repeater1.DataBind();
            if (!IsPostBack)
            {
              //  BindDataGrid();
            }
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
           // string constr = "Data Source=DESKTOP-L0TLU75;Initial Catalog = Yazlab3; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select FileName, FileData, ContentType from PdfFiles where İd=@İd";
                    cmd.Parameters.AddWithValue("@İd", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["FileData"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["FileName"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();


        }
            
        
       protected void Button1_Click(object sender, EventArgs e)
        {
            int idPdf=0;


                string Pdffilename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string contentType = FileUpload1.PostedFile.ContentType;
                using (Stream fs = FileUpload1.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            //inserting data into database
                            string query = "insert into PdfFiles values (@FileName, @FileData, @ContentType,@Hocaİd)";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@FileName", Pdffilename);
                                cmd.Parameters.AddWithValue("@FileData", bytes);
                                cmd.Parameters.AddWithValue("@ContentType", contentType);
                              string t = Request.QueryString["İd"].ToString();
                                cmd.Parameters.AddWithValue("@Hocaİd",t);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }

                }
               
           


            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-L0TLU75;Initial Catalog=Yazlab3;Integrated Security=True");
            connection.Open();
            SqlCommand komutt = new SqlCommand("Select İd From PdfFiles  where FileName=@P1  AND ContentType=@P3 AND Hocaİd=@P4 ", connection);
           
            komutt.Parameters.AddWithValue("@P1", Pdffilename);         
            komutt.Parameters.AddWithValue("@P3", contentType);
            string b = Request.QueryString["İd"].ToString();
            komutt.Parameters.AddWithValue("@P4", b);



            
            SqlDataReader dataReader6 = komutt.ExecuteReader();
            if (dataReader6.Read())
            {
                 idPdf = Convert.ToInt32(dataReader6["İd"]);
              

            }

            connection.Close();

            string filePath2;



            // Burada calısmayabilir,
            //@"C:\Users\90505\Desktop\pdff.pdf";
            //pdf in masasustundeki yolunu bulamıyor hata var
          //  filePath2 = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
             filePath2 = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
              string yol = @"C:\Users\90505\Desktop\" + filePath2;

              // Label1.Text = filePath2;
               AnaFonksiyon(yol);

               using (SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-L0TLU75;Initial Catalog=Yazlab3;Integrated Security=True"))
               {
                   //inserting data into database
          string query = "insert into Table_UserPdf values (@İd, @YazarBilgileri, @DersAdi,@ProjeÖzeti,@TeslimTarih,@ProjeBaslik,@AnahtarKelimeler,@DanismanBilgileri,@JuriBilgileri,@Hocaİd)";
                   using (SqlCommand cmd5 = new SqlCommand(query))
                   {
                    int HocaİdX = Convert.ToInt32(Request.QueryString["İd"]);

                    cmd5.Connection = con2;
                       cmd5.Parameters.AddWithValue("@İd",idPdf);
                       cmd5.Parameters.AddWithValue("@YazarBilgileri",Ogrenci);
                       cmd5.Parameters.AddWithValue("@DersAdi",DersAdi);
                       cmd5.Parameters.AddWithValue("ProjeÖzeti",Ozet);
                       cmd5.Parameters.AddWithValue("@TeslimTarih",TeslimDonem);
                       cmd5.Parameters.AddWithValue("@ProjeBaslik",ProjeAdi);
                       cmd5.Parameters.AddWithValue("@AnahtarKelimeler",AnahtarKelime);
                       cmd5.Parameters.AddWithValue("@DanismanBilgileri",Danisman);
                       cmd5.Parameters.AddWithValue("@JuriBilgileri",Juri);
                    cmd5.Parameters.AddWithValue("@Hocaİd", HocaİdX);




                    con2.Open();
                       cmd5.ExecuteNonQuery();
                       con2.Close();
                   }

               }

          Response.Redirect(Request.Url.AbsoluteUri);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int Hocaİd2 = Convert.ToInt32(Request.QueryString["İd"]);
              Response.Redirect("UserAra.aspx?İd="+Hocaİd2);
        }
    }
}