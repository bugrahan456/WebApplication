using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SON
{
    public partial class DeletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int sil = Convert.ToInt32(Request.QueryString["İd"].ToString());
            DataSet1TableAdapters.Table_UserTableAdapter dt = new DataSet1TableAdapters.Table_UserTableAdapter();
            dt.AdminSil(sil);
            Response.Redirect("AdminForm.aspx");



            
        }
    }
}