using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;





namespace TraCuuVB
{
    public partial class WebNotes : System.Web.UI.Page
    {
        private string ChuoiKetNoi2MayChu = Mixx.ChuoiKetNoiServer();
        DanhMucHeThong dm_hethong; 
        SqlConnection conn;
      
        
                
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (Session["TenDangNhap"].ToString() != "")
            {
                conn = new SqlConnection(ChuoiKetNoi2MayChu);
                dm_hethong = new DanhMucHeThong(conn);
          
                if (!IsPostBack)
                {
                    CreatGrid();
                    //dm_hethong.Load_DMDonViCungCap(dropCongTy);
                }
            } // end kiểm tra Status đăng nhập
            //else
            //{
            //    Response.Redirect("DangNhap.aspx");
            //}

        }

        protected void CreatGrid()
        {

            SqlCommand command = new SqlCommand("spRNote_Select", conn);
            command.CommandType = CommandType.StoredProcedure;            
            //command.Parameters.Add("MaDonViCC", SqlDbType.Char).Value = "ALL";//maDonViCC;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "DMTTBHSC");
            rptDMTTBHSC.DataSource = ds;
            rptDMTTBHSC.DataBind();

            conn.Close();


        }
    }
}