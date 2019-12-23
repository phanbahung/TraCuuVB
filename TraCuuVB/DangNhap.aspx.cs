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

namespace TraCuuVB
{
    public partial class DangNhap : System.Web.UI.Page
    {
        private string ChuoiKetNoi2MayChu = System.Configuration.ConfigurationManager.ConnectionStrings["TraCuuVanBanConnectionString"].ConnectionString;
        //private SqlConnection conn;
        string kqDangNhap;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            if (tenDangNhap.Trim() == "") return "Tên đăng nhập để trống.";
            if (matKhau.Trim() == "") return "Mật khẩu để trống.";
            SqlConnection conn = new SqlConnection(ChuoiKetNoi2MayChu);
            try
            {
                SqlCommand command = new SqlCommand("spQLVB_KiemTraDangNhap", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@TenDangNhap", SqlDbType.Char).Value = tenDangNhap.Trim();
                command.Parameters.Add("@MatKhau", SqlDbType.Char).Value =TongHop.encryptMD5( matKhau);                        
                conn.Open();
                kqDangNhap = command.ExecuteScalar().ToString();

                if (kqDangNhap.Length <= 3)
                {
                    Session["TenDangNhap"] = tenDangNhap.Trim();
                    
                }

                return kqDangNhap;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                // conn.Dispose();
            }
        }       


        public static string encryptMD5(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            string matKhauMD5 = BitConverter.ToString(hashedBytes);
            //matKhauMD5 = matKhauMD5.Replace("-", String.Empty);
            return matKhauMD5;

        }
      

        protected void butDangNhap_Click(object sender, EventArgs e)
        {
            lbThongBao.Text= KiemTraDangNhap(txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim());
            if (Session["TenDangNhap"].ToString() != "")
            {
                lbThongBao.Text = "Đăng nhập thành công!";
                Response.Redirect("TraCuu.aspx");
            }

        }
    }

}