using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SON
{
    public partial class LoginUser : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-L0TLU75;Initial Catalog=Yazlab3;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible= false;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * From Table_User  where KullaniciAdi=@P1 AND KullaniciSifre=@P2",connection);
            komut.Parameters.AddWithValue("@P1",TextBox1.Text);
            komut.Parameters.AddWithValue("@P2", TextBox2.Text);

            SqlDataReader dataReader = komut.ExecuteReader();
            if (dataReader.Read())
            {
                
                connection.Close();
                connection.Open();
                SqlCommand komut2 = new SqlCommand("Select İd From Table_User  where KullaniciAdi=@P3 AND KullaniciSifre=@P4", connection);
                komut.Parameters.AddWithValue("@P3", TextBox1.Text);
                komut.Parameters.AddWithValue("@P4", TextBox2.Text);
                SqlDataReader dataReader2 = komut.ExecuteReader();
                if (dataReader2.Read())
                {
                    int id3= Convert.ToInt32(dataReader2["İd"]);
                    Response.Redirect("MainForm.aspx?İd="+ id3);

                }
               
                connection.Close(); 
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Hatalı Giriş";
              connection.Close();
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * From Table_Admin2  where AdminAdi=@P1 AND AdminSifre=@P2", connection);
            komut.Parameters.AddWithValue("@P1", TextBox3.Text);
            komut.Parameters.AddWithValue("@P2", TextBox4.Text);
            SqlDataReader dataReader = komut.ExecuteReader();
            if (dataReader.Read())
            {
                Response.Redirect("AdminForm.aspx");
                connection.Close();
            }
            else
            {
                Label2.Visible = true;
                Label2.Text = "Hatalı Giriş";
                connection.Close();

            }
        }

    }
}