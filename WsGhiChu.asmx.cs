using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.Services.Protocols;


namespace TraCuuVB
{
    /// <summary>
    /// Summary description for WsGhiChu
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WsGhiChu : System.Web.Services.WebService
    {

        private string maTTBHSC;
        //private string kq;
        private string ChuoiKetNoiServer = System.Configuration.ConfigurationManager.ConnectionStrings["TraCuuVanBanConnectionString"].ConnectionString;
               

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod(EnableSession = true)]
        public string Reg_GhiChu(string tieuDe, string noiDung, string tag, string congKhai)
        {
            //if (tenVietTat.Trim()=="")
            //    return "Tên viết tắt không được để trống";
            //if (tenTTBHSC.Trim() == "")
            //    return "Tên Trung tâm BH-SC không được để trống";
            //if (maDonViCC.Trim()=="0")
            //    return "Phải chọn công ty";            
            
            SqlConnection conn = new SqlConnection(ChuoiKetNoiServer);

           // try
            {
                SqlCommand command = new SqlCommand("[spRNote_ThemXoaSua]", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("Action", SqlDbType.NVarChar).Value = "them";
                command.Parameters.Add("Id", SqlDbType.Char).Value = "0";
                command.Parameters.Add("TieuDe", SqlDbType.NVarChar).Value = tieuDe;
                command.Parameters.Add("NoiDung", SqlDbType.NVarChar).Value = noiDung.Trim();
                command.Parameters.Add("Tag", SqlDbType.NVarChar).Value = tag.Trim();
                command.Parameters.Add("CongKhai", SqlDbType.Char).Value = "1";// congKhai.Trim();
                command.Parameters.Add("NguoiCapNhat", SqlDbType.Char).Value = "";// Session["TenDangNhap"].ToString();
                conn.Open();
                maTTBHSC = command.ExecuteScalar().ToString();
                conn.Close();

                return maTTBHSC;

            }
           // catch (Exception e)
            {
                // Bắt lỗi
               // Console.WriteLine(e.Message);
                return maTTBHSC;
            }
          //  finally
            {
               // conn.Close();
               // conn.Dispose();
            }

        } // End Reg ghi chu


        [WebMethod]
        public _GhiChu[] Get_One_GhiChu(string id)
        {

            SqlConnection conn = new SqlConnection(Mixx.ChuoiKetNoiServer());
            List<_GhiChu> list = new List<_GhiChu>();

            try
            {
                SqlCommand command = new SqlCommand("spRNote_Select_One", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Id", SqlDbType.Char).Value = id.Trim();
                conn.Open();
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    _GhiChu ghiChu = new _GhiChu();
                    ghiChu.ID = myReader["ID"].ToString().Trim();
                    ghiChu.TieuDe = myReader["TieuDe"].ToString().Trim();
                    ghiChu.NoiDung = myReader["NoiDung"].ToString().Trim();
                    ghiChu.CongKhai = myReader["CongKhai"].ToString().Trim();
                    ghiChu.Tag = myReader["Tag"].ToString().Trim();                  

                    list.Add(ghiChu);
                }
                conn.Close();
                return list.ToArray();

            }
             catch (Exception e)
            {
                // Bắt lỗi
                Console.WriteLine(e.Message);
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return list.ToArray();


        }



       


    }
}
