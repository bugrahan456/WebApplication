using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SON
{
    public partial class AdminForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet1TableAdapters.Table_UserTableAdapter dt = new DataSet1TableAdapters.Table_UserTableAdapter();
            Repeater1.DataSource = dt.AdminListesi();
            Repeater1.DataBind();



        }
    }
}