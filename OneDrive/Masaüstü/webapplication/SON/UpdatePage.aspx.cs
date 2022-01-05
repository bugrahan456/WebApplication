using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SON
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Update = Convert.ToInt32(Request.QueryString["İd"].ToString());
            DataSet1TableAdapters.Table_UserTableAdapter dt = new DataSet1TableAdapters.Table_UserTableAdapter();
            TextBox3.Text = Update.ToString();
            TextBox3.Enabled = false;
            if (Page.IsPostBack == false)
            {
                TextBox1.Text = dt.VeriGetir(Convert.ToInt32(TextBox3.Text))[0].KullaniciAdi;
                TextBox2.Text = dt.VeriGetir(Convert.ToInt32(TextBox3.Text))[0].KullaniciSifre;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.Table_UserTableAdapter dt = new DataSet1TableAdapters.Table_UserTableAdapter();
            dt.AdminUpdate(TextBox1.Text, TextBox2.Text, Convert.ToInt32(TextBox3.Text));
            Response.Redirect("AdminForm.aspx");

        }
    }
}