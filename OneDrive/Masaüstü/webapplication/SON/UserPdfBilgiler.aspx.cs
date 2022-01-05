using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SON
{
    public partial class UserPdfBilgiler : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;         
            TextBox5.Enabled = false;
            TextBox4.Enabled = false;

            TextBox6.Enabled = false;
            TextBox7.Enabled = false;
            TextBox8.Enabled = false;
            TextBox9.Enabled = false;

            int İd = Convert.ToInt32(Request.QueryString["İd"]);

            string connection = "Data Source=DESKTOP-L0TLU75;Initial Catalog = Yazlab3; Integrated Security = True";
            SqlConnection x = new SqlConnection(connection);
            x.Open();
            SqlCommand komut = new SqlCommand("Select * From Table_UserPdf Where İd=@İd",x);
            
            komut.Parameters.AddWithValue("@İd", İd);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                TextBox1.Text=dr[0].ToString();
                TextBox2.Text = dr[1].ToString();
                TextBox3.Text = dr[2].ToString();
                
                TextBox4.Text = dr[3].ToString();
                TextBox5.Text = dr[4].ToString();
                TextBox6.Text = dr[5].ToString();
                TextBox7.Text = dr[6].ToString();
                TextBox8.Text = dr[7].ToString();
                TextBox9.Text = dr[8].ToString();






            }








            x.Close();











            
        }



















    }
}