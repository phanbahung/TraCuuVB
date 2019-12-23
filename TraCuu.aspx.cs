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

//<a href="mailto:someone@example.com?Subject=Hello%20again">Send mail!</a>

namespace TraCuuVB
{
    public partial class TraCuu : System.Web.UI.Page
    {
        private string ChuoiKetNoi2MayChu = System.Configuration.ConfigurationManager.ConnectionStrings["TraCuuVanBanConnectionString"].ConnectionString;
        private SqlConnection conn;
        private DanhMucHeThong dm_HeThong;



        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ChuoiKetNoi2MayChu);

            dm_HeThong = new DanhMucHeThong(conn);
            if (!IsPostBack)
            {
                dm_HeThong.Load_DM_LoaiVanBan_ALL(dropLoaiVB);
                dm_HeThong.Load_DM_SacThue_ALL(dropSacThue);
                dm_HeThong.Load_DM_CqBanHanh_ALL(dropCqBanHanh);
                
            }
            lbThongBao.Text = "";

        }


        protected void butTraCuu_Click(object sender, EventArgs e)
        {             
            string SoHieuVB = txtSoHieuVB.Text.Trim();
            string NgayBanHanh_From = txtTuNgay.Text.Trim();
            string NgayBanHanh_To = txtDenNgay.Text.Trim();
            string CqBanHanh = dropCqBanHanh.SelectedValue;
            string LoaiVB = dropLoaiVB.SelectedValue;
            string SacThue = dropSacThue.SelectedValue;

            if ((NgayThang.IsDate_AllowEmpty(NgayBanHanh_From))&&(NgayThang.IsDate_AllowEmpty(NgayBanHanh_To)))
            {
                TraCuuVanBan(SoHieuVB, NgayBanHanh_From, NgayBanHanh_To, CqBanHanh, LoaiVB, SacThue);
                lbThongBao.Text = "";
            }
            else
            {
                lbThongBao.Text = "Ngày ban hành không hợp lệ!";
            }
        }


     

        protected void  TraCuuVanBan(string SoHieuVB ,string NgayBanHanh_From , string NgayBanHanh_To,  string CqBanHanh ,
            string LoaiVB ,  string SacThue)
        {            
            SqlCommand myComm = new SqlCommand("spTCVB_TraCuuVanBan", conn);
            myComm.CommandType = CommandType.StoredProcedure;
            
            myComm.Parameters.Add("@SoHieuVB", SqlDbType.NVarChar).Value = SoHieuVB;
            myComm.Parameters.Add("@CqBanHanh", SqlDbType.NVarChar).Value = CqBanHanh;
            myComm.Parameters.Add("@LoaiVB", SqlDbType.NVarChar).Value = LoaiVB;            
            myComm.Parameters.Add("@SacThue", SqlDbType.NVarChar).Value = SacThue;            

            //NgayBanHanh from
            if ((NgayBanHanh_From != "") && (NgayThang.IsDate(NgayBanHanh_From)))
                myComm.Parameters.Add("NgayBanHanh_From", SqlDbType.DateTime).Value = NgayThang.NewDateTime(NgayBanHanh_From);
            else
                myComm.Parameters.Add("NgayBanHanh_From", SqlDbType.Char).Value = "";// cho null luôn 

            //NgayBanHanh to
            if ((NgayBanHanh_To != "") && (NgayThang.IsDate(NgayBanHanh_To)))
                myComm.Parameters.Add("NgayBanHanh_To", SqlDbType.DateTime).Value = NgayThang.NewDateTime(NgayBanHanh_To);
            else
                myComm.Parameters.Add("NgayBanHanh_To", SqlDbType.Char).Value = "";// cho null luôn 

            conn.Open();
            SqlDataReader myReader = myComm.ExecuteReader();
            rptKetQua.DataSource = myReader;
            rptKetQua.DataBind();
            myReader.Close();
            conn.Close();            

        }// End InsertOneNguoiPhuThuoc




        // Export to Excel file

        public void ExportToExcel(string MSTCqChiTra, string fileName)
        {

            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.ContentEncoding = Encoding.Unicode;
            Response.BinaryWrite(Encoding.Unicode.GetPreamble());
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "spDSNPT_ExportToExcel", new SqlParameter("@MSTCqChiTra", MSTCqChiTra));

            DataTable dtb = ds.Tables[0];

            //try
            //{
            StringBuilder sb = new StringBuilder();
            //Tạo dòng tiêu đề cho bảng tính
            for (int count = 0; count < dtb.Columns.Count; count++)
            {
                if (dtb.Columns[count].ColumnName != null)
                    sb.Append(dtb.Columns[count].ColumnName);
                if (count < dtb.Columns.Count - 1)
                {
                    sb.Append("\t");
                }
            }
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            //Duyệt từng bản ghi
            int soDem = 0;
            while (dtb.Rows.Count >= soDem + 1)
            {
                sb = new StringBuilder();

                for (int col = 0; col < dtb.Columns.Count - 1; col++)
                {
                    if (dtb.Rows[soDem][col] != null)
                        sb.Append(dtb.Rows[soDem][col].ToString().Replace(",", " "));
                    sb.Append("\t");
                }
                if (dtb.Rows[soDem][dtb.Columns.Count - 1] != null)
                    sb.Append(dtb.Rows[soDem][dtb.Columns.Count - 1].ToString().Replace(",", " "));

                Response.Write(sb.ToString() + "\n");
                Response.Flush();
                soDem = soDem + 1;
            }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write(ex.Message);
            //}
            dtb.Dispose();
            Response.End();
        }

        protected void butExportExcel_Click(object sender, EventArgs e)
        {


        } // End protected void butExportExcel_Click(object sender, EventArgs e)


    }
}