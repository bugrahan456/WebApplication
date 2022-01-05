using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SON
{
    public partial class UserAra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                int Hocaid = Convert.ToInt32(Request.QueryString["İd"]);

                string connection = "Data Source=DESKTOP-L0TLU75;Initial Catalog = Yazlab3; Integrated Security = True";
                SqlConnection x = new SqlConnection(connection);
                x.Open();
                SqlCommand komut = new SqlCommand("Select * From Table_UserPdf Where Hocaİd=@Hocaİd", x);

                komut.Parameters.AddWithValue("@Hocaİd", Hocaid);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {

                   string YazarBilgileri = dr[1].ToString();
                   string dersAdi=dr[2].ToString();
                   string teslimTarih=dr[4].ToString();
                   string projeAdi = dr[5].ToString();
                   string anahtarKelimeler = dr[6].ToString();
                    ListBox1.Items.Add(YazarBilgileri);
                    ListBox2.Items.Add(dersAdi);
                    ListBox3.Items.Add(teslimTarih);
                    ListBox4.Items.Add(projeAdi);
                    ListBox5.Items.Add(anahtarKelimeler);

                }
                x.Close();



            }

        }










        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int Hocaİd2 = Convert.ToInt32(Request.QueryString["İd"]);
            DataSet1TableAdapters.Table_UserPdfTableAdapter dt=new DataSet1TableAdapters.Table_UserPdfTableAdapter();
            Repeater1.DataSource = dt.YazarBilgileriUser(ListBox1.SelectedItem.Text,Hocaİd2);
            Repeater1.DataBind();

            /* DataSet1TableAdapters.PdfFilesTableAdapter dt = new DataSet1TableAdapters.PdfFilesTableAdapter();
             Repeater1.DataSource = dt.KullanıcıVeriGetir(Hocaİd2);
             Repeater1.DataBind();*/







        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int Hocaİd2 = Convert.ToInt32(Request.QueryString["İd"]);
            DataSet1TableAdapters.Table_UserPdfTableAdapter dt = new DataSet1TableAdapters.Table_UserPdfTableAdapter();
            Repeater1.DataSource = dt.DersAdiUser(ListBox2.SelectedItem.Text, Hocaİd2);
            Repeater1.DataBind();


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int Hocaİd2 = Convert.ToInt32(Request.QueryString["İd"]);
            DataSet1TableAdapters.Table_UserPdfTableAdapter dt = new DataSet1TableAdapters.Table_UserPdfTableAdapter();
            Repeater1.DataSource = dt.teslimTarihUser(ListBox3.SelectedItem.Text, Hocaİd2);
            Repeater1.DataBind();

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int Hocaİd2 = Convert.ToInt32(Request.QueryString["İd"]);
            DataSet1TableAdapters.Table_UserPdfTableAdapter dt = new DataSet1TableAdapters.Table_UserPdfTableAdapter();
            Repeater1.DataSource = dt.ProjeBaslikUser(ListBox4.SelectedItem.Text, Hocaİd2);
            Repeater1.DataBind();

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            int Hocaİd2 = Convert.ToInt32(Request.QueryString["İd"]);
            DataSet1TableAdapters.Table_UserPdfTableAdapter dt = new DataSet1TableAdapters.Table_UserPdfTableAdapter();
            Repeater1.DataSource = dt.AnahtarKelimelerUser(ListBox5.SelectedItem.Text, Hocaİd2);
            Repeater1.DataBind();

        }
    }
}