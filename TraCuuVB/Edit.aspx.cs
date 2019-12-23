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
    public partial class Edit : System.Web.UI.Page
    {
       
        private string ChuoiKetNoi2MayChu = System.Configuration.ConfigurationManager.ConnectionStrings["TraCuuVanBanConnectionString"].ConnectionString;
        private SqlConnection conn;
        private DanhMucHeThong dm_HeThong;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"].ToString() != "")//======================
            {
                butThayDoi.Enabled = true;
                fuUpload1.Enabled = true;
                txtBoSungThayThe.ReadOnly = false;
                txtNgayBanHanh.ReadOnly = false;
                txtNgayHieuLuc.ReadOnly = false;
                txtNoiDung.ReadOnly = false;
                txtSoHieuVB.ReadOnly = false;
                dropCqBanHanh.Enabled = true;
                dropLoaiVB.Enabled = true;
                dropSacThue.Enabled = true;
                
            }
            else
            {
                butThayDoi.Enabled = false;
                fuUpload1.Enabled = false;
                txtBoSungThayThe.ReadOnly = true;
                txtNgayBanHanh.ReadOnly = true;
                txtNgayHieuLuc.ReadOnly = true;
                txtNoiDung.ReadOnly = true;
                txtSoHieuVB.ReadOnly = true;
                dropCqBanHanh.Enabled = false;
                dropLoaiVB.Enabled = false;
                dropSacThue.Enabled = false;                 

            }

                conn = new SqlConnection(ChuoiKetNoi2MayChu);
                dm_HeThong = new DanhMucHeThong(conn);
                if (!IsPostBack)
                {
                    dm_HeThong.Load_DM_LoaiVanBan(dropLoaiVB);
                    dm_HeThong.Load_DM_SacThue(dropSacThue);
                    dm_HeThong.Load_DM_CqBanHanh(dropCqBanHanh);
                    HttpContext c = HttpContext.Current; 
                    string IdVanBan = c.Request["id"];
                    Load_VanBan(IdVanBan);
                }

               
                
            
        }

        protected void butLuuThayDoi_Click(object sender, EventArgs e)
        {
            string idVanBan = txtIdVanBan.Text.Trim();
            string SoHieuVB = txtSoHieuVB.Text.Trim();
            string NgayBanHanh = txtNgayBanHanh.Text.Trim();
            string CqBanHanh = dropCqBanHanh.SelectedValue;
            string LoaiVB = dropLoaiVB.SelectedValue;
            string NoiDung = txtNoiDung.Text.Trim();
            string SacThue = dropSacThue.SelectedValue;          
            string BoSungThayTheVB = txtBoSungThayThe.Text.Trim();
            string NgayHieuLuc = txtNgayHieuLuc.Text.Trim();
            string LinkVanBan="";
            
           // if (NgayThang.IsDate(NgayBanHanh) & (NgayBanHanh != ""))
            {
                DateTime tgBanHanh = NgayThang.NewDateTime(NgayBanHanh);
                string namBanHanh = tgBanHanh.Year.ToString();
                if (fuUpload1.HasFile)
                {
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
                    // ReUp new file
                    LinkVanBan = UploadFile(this.fuUpload1, SoHieuVB, namBanHanh);
                    // Del old file
                    DelFile(lnkVanBan.NavigateUrl);
                }
                else LinkVanBan = "";

                Edit_VanBan(idVanBan,SoHieuVB, NgayBanHanh, CqBanHanh, LoaiVB, NoiDung, SacThue, LinkVanBan, BoSungThayTheVB, NgayHieuLuc);
                
            }       // end if
        
        }


        protected string UploadFile(FileUpload fu, string soHieuVanBan, string namBanHanh)
        {
            //string fileName1111 = null; fileName = Path.GetFileName(fu.FileName);
            //string cleanPath1111 = String.Join("", path.Split(Path.GetInvalidPathChars()));

            string fileName1 = Path.GetFileName(fu.FileName);
            // Get extension
            string extension = Path.GetExtension(fileName1).ToLower();

            string filePath = null;
            CreateFolder(namBanHanh);
            string cleanSoHieuVB = String.Join("_", soHieuVanBan.Split(System.IO.Path.GetInvalidFileNameChars()));
            string fileName2Save = cleanSoHieuVB + "_" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss") +  extension;
            filePath = Server.MapPath("~/vanban/" + namBanHanh + "//" + fileName2Save);
            fu.SaveAs(filePath);
            return namBanHanh + "/" + fileName2Save;
        }
       
        protected void CreateFolder(string folder)
        {
            string directoryPath = Server.MapPath(string.Format("~/vanban/"+folder));
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }            
        }

        protected void DelFile(string pathFile)
        {
            string directoryPath = Server.MapPath(string.Format(pathFile));
            if ((System.IO.File.Exists(directoryPath)))
            {
                System.IO.File.Delete(directoryPath);
            }

        }

        protected void Load_VanBan(string idVanBan)
        {
            SqlConnection connVanBan = new SqlConnection(ChuoiKetNoi2MayChu);

            try
            {
                System.Data.DataSet ds = SqlHelper.ExecuteDataset(connVanBan, CommandType.StoredProcedure, "[spTCVB_LoadVanBan_ByID]", new SqlParameter("@IdVanBan", idVanBan));
                DataTable dtbVanBan = ds.Tables[0];
                  txtIdVanBan.Text = dtbVanBan.Rows[0]["IdVanBan"].ToString().Trim();
                  txtSoHieuVB.Text  = dtbVanBan.Rows[0]["SoHieuVB"].ToString().Trim();
                  txtNgayBanHanh.Text = dtbVanBan.Rows[0]["NgayBanHanh"].ToString().Trim();
                  txtNoiDung.Text=dtbVanBan.Rows[0]["NoiDung"].ToString().Trim();
                  txtNgayHieuLuc.Text = dtbVanBan.Rows[0]["NgayHieuLuc"].ToString().Trim();
                  SetIndexOfDropDownList(dropCqBanHanh,dtbVanBan.Rows[0]["CqBanHanh"].ToString().Trim());
                  SetIndexOfDropDownList(dropSacThue,dtbVanBan.Rows[0]["SacThue"].ToString().Trim());
                  SetIndexOfDropDownList(dropLoaiVB, dtbVanBan.Rows[0]["LoaiVB"].ToString().Trim());      
                  lnkVanBan.NavigateUrl = "vanban/"+dtbVanBan.Rows[0]["LinkVanBan"].ToString().Trim();
                
            }
            catch (Exception e)
            {
                // Bắt lỗi
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
                //conn.Dispose();
            }
        }

        protected string Get_Link_VanBan(string idVanBan)
        {
            SqlConnection connVanBan = new SqlConnection(ChuoiKetNoi2MayChu);           
                System.Data.DataSet ds = SqlHelper.ExecuteDataset(connVanBan, CommandType.StoredProcedure, "[spTCVB_LoadVanBan_ByID]", new SqlParameter("@IdVanBan", idVanBan));
                DataTable dtbVanBan = ds.Tables[0];               
                string linkVanBan= dtbVanBan.Rows[0]["LinkVanBan"].ToString().Trim();
                conn.Close();
                //conn.Dispose();           
                return linkVanBan;
        }

        protected void SetIndexOfDropDownList(DropDownList dropList, string valueOfDropDL)
        {
            int soItem = dropList.Items.Count;
            int i; int ketqua = -1; ;
            for (i = 0; i < soItem; i++)
            {
                if (valueOfDropDL.Trim().ToUpper() == dropList.Items[i].Value.Trim().ToUpper())
                { ketqua = i; }
            }
            dropList.SelectedIndex = ketqua;
        }



        protected string Edit_VanBan(string IdVanBan,string SoHieuVB, string NgayBanHanh, string CqBanHanh, string VietTatLoaiVB, string NoiDung,
            string SacThue, string LinkVanBan, string BoSungThayTheVB, string NgayHieuLuc)
        {
            string kqChen = "";
            SqlCommand myComm = new SqlCommand("spQLVB_Edit_VanBan", conn);
            myComm.CommandType = CommandType.StoredProcedure;
            myComm.Parameters.Add("@IdVanBan", SqlDbType.Int).Value = IdVanBan;
            myComm.Parameters.Add("@SoHieuVB", SqlDbType.NVarChar).Value = SoHieuVB;
            myComm.Parameters.Add("@CqBanHanh", SqlDbType.NVarChar).Value = CqBanHanh;
            myComm.Parameters.Add("@LoaiVB", SqlDbType.NVarChar).Value = VietTatLoaiVB;
            myComm.Parameters.Add("@NoiDung", SqlDbType.NVarChar).Value = NoiDung;
            myComm.Parameters.Add("@SacThue", SqlDbType.NVarChar).Value = SacThue;
            myComm.Parameters.Add("@LinkVanBan", SqlDbType.NVarChar).Value = LinkVanBan;
            myComm.Parameters.Add("@BoSungThayTheVB", SqlDbType.NVarChar).Value = BoSungThayTheVB;
            myComm.Parameters.Add("NgayHieuLuc", SqlDbType.NVarChar).Value = NgayHieuLuc;


            //NgayBanHanh
            if ((NgayBanHanh != "") && (NgayThang.IsDate_AllowEmpty(NgayBanHanh)))
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