using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SON
{
    public partial class DeleteUserPdfAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int sil = Convert.ToInt32(Request.QueryString["İd"].ToString());
            string hocaİd = Convert.ToInt32(Request.QueryString["Hocaİd"]).ToString();

            DataSet1TableAdapters.PdfFilesTableAdapter dt = new DataSet1TableAdapters.PdfFilesTableAdapter();
            dt.KullanıcıSil(sil);

            Response.Redirect("AdminBilgiler.aspx?İd=" + hocaİd);

        }
    }
}