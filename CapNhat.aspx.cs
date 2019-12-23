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
    public partial class CapNhat : System.Web.UI.Page
    {
        //HttpContext c = HttpContext.Current; string album = c.Request["album"];
        private string ChuoiKetNoi2MayChu = System.Configuration.ConfigurationManager.ConnectionStrings["TraCuuVanBanConnectionString"].ConnectionString;
        private SqlConnection conn;
        private DanhMucHeThong dm_HeThong;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"].ToString() != "")//======================
            {
                conn = new SqlConnection(ChuoiKetNoi2MayChu);
                dm_HeThong = new DanhMucHeThong(conn);                
                if (!IsPostBack)
                {
                    dm_HeThong.Load_DM_LoaiVanBan(dropLoaiVB);
                    dm_HeThong.Load_DM_SacThue(dropSacThue);
                    dm_HeThong.Load_DM_CqBanHanh(dropCqBanHanh);
                }                
            }
            
            else //===================================================   
                    Response.Redirect("DangNhap.aspx");
        }

        protected void butLuuVanBan_Click(object sender, EventArgs e)
        {
            string SoHieuVB = txtSoHieuVB.Text.Trim();
            string NgayBanHanh = txtNgayBanHanh.Text.Trim();
            string CqBanHanh = dropCqBanHanh.SelectedValue;
            string LoaiVB = dropLoaiVB.SelectedValue;
            string NoiDung = txtNoiDung.Text.Trim();
            string SacThue = dropSacThue.SelectedValue;          
            string BoSungThayTheVB = txtBoSungThayThe.Text.Trim();
            string NgayHieuLuc = txtNgayHieuLuc.Text.Trim();           


            if (NgayThang.IsDate(NgayBanHanh) & (NgayBanHanh != ""))
            {
                DateTime tgBanHanh = NgayThang.NewDateTime(NgayBanHanh);
                string namBanHanh = tgBanHanh.Year.ToString();
                string fileName1 = Path.GetFileName(fuUpload1.FileName);                

                // Incorrect extension
                string extension = Path.GetExtension(fileName1).ToUpper();
                if (extension != ".DOC" & extension != ".DOCX" & extension != ".PDF" & extension != ".RAR") //OK
                {               
                    lbThongBao.Text = "Chỉ được đính kèm file Word/ PDF/.Rar (.DOC; .DOCX; .PDF; .RAR)";
                    return;
                }

                // File too big?                
                int fileSize1 = fuUpload1.PostedFile.ContentLength;
                FileInfo fInfo1 = new FileInfo(fileName1);
                if (fileSize1 > 1048576 * 5)  // 5mb
                {
                    lbThongBao.Text = "File đính kèm số 1 phải <= 5MB";
                    return;
                }                      

                string LinkVanBan = UploadFile(this.fuUpload1, SoHieuVB, namBanHanh);
                lbThongBao.Text= Insert_VanBan(SoHieuVB, NgayBanHanh, CqBanHanh, LoaiVB, NoiDung, SacThue, LinkVanBan, BoSungThayTheVB, NgayHieuLuc);
            }
        }
       

        protected string UploadFile(FileUpload fu, string soHieuVanBan, string namBanHanh)
        {
            
            string fileName1 = Path.GetFileName(fu.FileName);
            // Get extension
            string extension = Path.GetExtension(fileName1).ToLower();
            string filePath = null;
            CreateFolder(namBanHanh);           
            string cleanSoHieuVB = String.Join("_", soHieuVanBan.Split(System.IO.Path.GetInvalidFileNameChars()));
            // Non Unicode
            cleanSoHieuVB = TongHop.NonUnicode(cleanSoHieuVB);
            string fileName2Save = cleanSoHieuVB + "_" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + extension;
            filePath = Server.MapPath("~/vanban/" + namBanHanh +"//"+fileName2Save  );            
           
            fu.SaveAs(filePath);
            return namBanHanh+"/"+ fileName2Save;
        }
       

        protected void CreateFolder(string folder)
        {
            string directoryPath = Server.MapPath(string.Format("~/vanban/"+folder));
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }            
        }


        protected string Insert_VanBan(string SoHieuVB, string NgayBanHanh, string CqBanHanh, string VietTatLoaiVB, string NoiDung,
            string SacThue, string LinkVanBan, string BoSungThayTheVB, string NgayHieuLuc)
        {
            string kqChen = "";
            SqlCommand myComm = new SqlCommand("spQLVB_Insert_VanBan", conn);
            myComm.CommandType = CommandType.StoredProcedure;
            myComm.Parameters.Add("@SoHieuVB", SqlDbType.NVarChar).Value = SoHieuVB;
            myComm.Parameters.Add("@CqBanHanh", SqlDbType.NVarChar).Value = CqBanHanh;
            myComm.Parameters.Add("@LoaiVB", SqlDbType.NVarChar).Value = VietTatLoaiVB;
            myComm.Parameters.Add("@NoiDung", SqlDbType.NVarChar).Value = NoiDung;
            myComm.Parameters.Add("@SacThue", SqlDbType.NVarChar).Value = SacThue;
            myComm.Parameters.Add("@LinkVanBan", SqlDbType.NVarChar).Value = LinkVanBan;
            myComm.Parameters.Add("@BoSungThayTheVB", SqlDbType.NVarChar).Value = BoSungThayTheVB;
            myComm.Parameters.Add("NgayHieuLuc", SqlDbType.NVarChar).Value = NgayHieuLuc;
            

            //NgayBanHanh
            if ((NgayBanHanh != "") && (NgayThang.IsDate(NgayBanHanh)))
                myComm.Parameters.Add("NgayBanHanh", SqlDbType.DateTime).Value = NgayThang.NewDateTime(NgayBanHanh);
            else
                myComm.Parameters.Add("NgayBanHanh", SqlDbType.Char).Value = "";// cho null luôn 

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
    }
}