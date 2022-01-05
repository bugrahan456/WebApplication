using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SON
{
    public partial class AdminBilgiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Hocaİd2 = Convert.ToInt32(Request.QueryString["İd"]);
            DataSet1TableAdapters.PdfFilesTableAdapter dt = new DataSet1TableAdapters.PdfFilesTableAdapter();
            Repeater1.DataSource = dt.KullanıcıVeriGetir(Hocaİd2);
            Repeater1.DataBind();

        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
             string constr = "Data Source=DESKTOP-L0TLU75;Initial Catalog = Yazlab3; Integrated Security = True";
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












    }










}