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
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace LichHop
{
    public partial class QuanTri : System.Web.UI.Page
    {
        private string ChuoiKetNoi2MayChu = System.Configuration.ConfigurationManager.ConnectionStrings["LichHopConnectionString"].ConnectionString;
        private SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["TenDangNhap"].ToString() == "admin";
            
            if (Session["TenDangNhap"].ToString() == "admin")//======================
            {
                butAddNew.Enabled = true;
                butReset.Enabled = true;
                butChangeStatus.Enabled = true;                
            }
            else
            {
                butAddNew.Enabled = false;
                butReset.Enabled = false;
                butChangeStatus.Enabled = false;
                Response.Redirect("Home.aspx");
            } 
            conn = new SqlConnection(ChuoiKetNoi2MayChu);
            CreateGridView();
        }

        protected void CreateGridView()
        {

            // try
            {
                rptKetQua.DataSource = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "[spLich_NSD_Select]");
                rptKetQua.DataBind();
            }
            //catch (Exception e)
            {
                // Bắt lỗi
                //Console.WriteLine(e.Message);
            }
            //finally
            {
                conn.Close();
                //conn.Dispose();
            }

        }

        protected string NewUser(string tenDangNhap)
        {
            string kqChen = "";
            SqlCommand myComm = new SqlCommand("[spLich_NewUser]", conn);
            myComm.CommandType = CommandType.StoredProcedure;
            myComm.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = tenDangNhap;
            myComm.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = TongHop.encryptMD5(tenDangNhap);           

            conn.Open();
            SqlDataReader myReader = myComm.ExecuteReader();
            while (myReader.Read())
            {
                kqChen = myReader["KetQua"].ToString();
            }
            myReader.Close();
            conn.Close();
            return kqChen;

        }// End InsertOneNguoiPhuThuoc
        protected string ResetPass(string tenDangNhap)
        {
            string kqChen = "";
            SqlCommand myComm = new SqlCommand("[spLich_ResetPass]", conn);
            myComm.CommandType = CommandType.StoredProcedure;
            myComm.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = tenDangNhap;
            myComm.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = TongHop.encryptMD5(tenDangNhap);

            conn.Open();
            SqlDataReader myReader = myComm.ExecuteReader();
            while (myReader.Read())
            {
                kqChen = myReader["KetQua"].ToString();
            }
            myReader.Close();
            conn.Close();
            return kqChen;

        }// End InsertOneNguoiPhuThuoc

        protected void butAddNew_Click(object sender, EventArgs e)
        {
            string tenDangNhap =txtTenDangNhap.Text.Trim();
            if (tenDangNhap != "")
            {
                lbThongBao.Text = NewUser(tenDangNhap);
                txtTenDangNhap.Text = "";
            }
            else lbThongBao.Text = "Tên đăng nhập để trống.";

        }

        protected void butReset_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            if (tenDangNhap != "")
            {
                lbThongBao.Text = ResetPass(tenDangNhap);
                txtTenDangNhap.Text = "";
            }
            else lbThongBao.Text = "Tên đăng nhập để trống.";
        }

        protected void butChangeStatus_Click(object sender, EventArgs e)
        {

        }
    }
}