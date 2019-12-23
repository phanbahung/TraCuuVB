using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text;
using System.Drawing.Imaging;
using System.Configuration;
using System.IO;

namespace TraCuuVB
{
    public partial class Test : System.Web.UI.Page
    {
        private string ChuoiKetNoi2MayChu = System.Configuration.ConfigurationManager.ConnectionStrings["TraCuuVanBanConnectionString"].ConnectionString;
        private SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ChuoiKetNoi2MayChu);
            //TextBox1.Text = String.Format("{0:0,0}", 20000000);
            //TextBox2.Text = String.Format("{0:00}", TextBox1.Text);
            //string soHieuVanBan = "2395/CT-TH";
                    

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string cleanFileName = String.Join("_", TextBox1.Text.Split(System.IO.Path.GetInvalidFileNameChars()));
            //TextBox2.Text = cleanFileName;  
            TextBox3.Text = TinhNgayKetThuc(TextBox1.Text.Trim(), TextBox2.Text.Trim());


        }
        protected string TinhNgayKetThuc(string NgayBD, string SoNgayKT)
        {
            SqlConnection connVanBan = new SqlConnection(ChuoiKetNoi2MayChu);
            System.Data.DataSet ds = SqlHelper.ExecuteDataset(connVanBan, 
                CommandType.StoredProcedure, "[spTDKT_TinhNgayKetThucKiemTra]", 
            new SqlParameter("@NgayBD", NgayBD),new SqlParameter("@SoNgayKT", SoNgayKT));

            DataTable dtbVanBan = ds.Tables[0];
            string linkVanBan = dtbVanBan.Rows[0]["NgayKT"].ToString().Trim();
            conn.Close();
            //conn.Dispose();           
            return linkVanBan;
        }
    }
}