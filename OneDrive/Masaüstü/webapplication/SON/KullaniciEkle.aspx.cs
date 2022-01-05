using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SON
{
    public partial class KullaniciEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = TextBox1.Text;

            string kullaniciSifre = TextBox2.Text;

           DataSet1TableAdapters.Table_UserTableAdapter dt = new DataSet1TableAdapters.Table_UserTableAdapter();
           dt.AdminEkle(kullaniciAdi,kullaniciSifre);
           Response.Redirect("AdminForm.aspx");

        }
    }
}