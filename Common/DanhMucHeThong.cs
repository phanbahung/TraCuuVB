using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


/// <summary>
/// Summary description for DanhMuc
/// </summary>
namespace TraCuuVB
{
    public class DanhMucHeThong
    {
        SqlConnection conn;

        public DanhMucHeThong(SqlConnection connection)
        {
            //
            // TODO: Add constructor logic here
            //
            this.conn = connection;
        }


        //ddLst.Items.Insert(0, new ListItem("Tất cả","ALL"));

        public void Load_DM_LoaiVanBan(System.Web.UI.WebControls.DropDownList ddl)
        {

            try
            {
                ddl.DataSource = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "[spTCVB_DmLoaiVanBan_Select]");
                ddl.DataValueField = "VietTatLoaiVB";
                ddl.DataTextField = "TenLoaiVB";
                ddl.DataBind();
                
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

        public void Load_DM_LoaiVanBan_ALL(System.Web.UI.WebControls.DropDownList ddl)
        {

            try
            {
                ddl.DataSource = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "[spTCVB_DmLoaiVanBan_Select]");
                ddl.DataValueField = "VietTatLoaiVB";
                ddl.DataTextField = "TenLoaiVB";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Tất cả", "ALL"));
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

        public void Load_DM_SacThue_ALL(System.Web.UI.WebControls.DropDownList ddl)
        {
            try
            {
                ddl.DataSource = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "[spTCVB_DmSacThue_Select]");
                ddl.DataValueField = "VietTatSacThue";
                ddl.DataTextField = "TenSacThue";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Tất cả", "ALL"));
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

        public void Load_DM_SacThue(System.Web.UI.WebControls.DropDownList ddl)
        {
            try
            {
                ddl.DataSource = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "[spTCVB_DmSacThue_Select]");
                ddl.DataValueField = "VietTatSacThue";
                ddl.DataTextField = "TenSacThue";
                ddl.DataBind();
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


        public void Load_DM_CqBanHanh_ALL(System.Web.UI.WebControls.DropDownList ddl)
        {
            try
            {
                ddl.DataSource = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "[spTCVB_DmCqBanHanh_Select]");
                ddl.DataValueField = "VietTatCqBanHanh";
                ddl.DataTextField = "TenCqBanHanh";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Tất cả", "ALL"));
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


        public void Load_DM_CqBanHanh(System.Web.UI.WebControls.DropDownList ddl)
        {
            try
            {
                ddl.DataSource = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "[spTCVB_DmCqBanHanh_Select]");
                ddl.DataValueField = "VietTatCqBanHanh";
                ddl.DataTextField = "TenCqBanHanh";
                ddl.DataBind();
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






    }// End Class
}// End Name space

    
    
