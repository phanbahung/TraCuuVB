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
    public partial class DoiMatKhau : System.Web.UI.Page
    {
        private string ChuoiKetNoi2MayChu = System.Configuration.ConfigurationManager.ConnectionStrings["TraCuuVanBanConnectionString"].ConnectionString;
        //private SqlConnection conn;
        string kqDangNhap;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text=Session["TenDangNhap"].ToString();
        }
       

        public string ChangePass(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            if (matKhauCu.Trim() == "") return "Mật khẩu cũ không được để trống";
            if (matKhauMoi.Trim() == "") return "Mật khẩu mới không được để trống";

            SqlConnection conn = new SqlConnection(ChuoiKetNoi2MayChu);
            try
            {
                SqlCommand command = new SqlCommand("spQLVB_DoiMatKhau", conn);
                command.CommandType = CommandType.StoredProcedure;                
                command.Parameters.Add("@TenDangNhap", SqlDbType.Char).Value = tenDangNhap.Trim();
                command.Parameters.Add("@MatKhauCu", SqlDbType.Char).Value = TongHop.encryptMD5( matKhauCu.Trim());
                command.Parameters.Add("@MatKhaumoi", SqlDbType.Char).Value =TongHop.encryptMD5( matKhauMoi.Trim());
                conn.Open();
                kqDangNhap = command.ExecuteScalar().ToString();
                conn.Close();
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

        protected void butDoiMatKhau_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi1=txtMatKhauMoi1.Text.Trim();
            string matKhauMoi2=txtMatKhauMoi2.Text.Trim();
            if (matKhauMoi1 == matKhauMoi2)
            {
                Session["TenDangNhap"] = "";
                lbThongBao.Text = ChangePass(tenDangNhap, matKhauCu, matKhauMoi1);

            }
            else
                lbThongBao.Text = "Mật khẩu mới không giống nhau";
        }

        
    }

}