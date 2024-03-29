using System;
using System.Data;
using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for ExcelHelp
/// </summary>
public class ExcelHelp
{
    public ExcelHelp()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Đọc file Excel. Return  DataTable.
    /// </summary>
    public DataTable GetDataTableFromExcel(string TenDuongdan)
    {
        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + TenDuongdan + ";Extended Properties=Excel 8.0;";

        OleDbConnection cn = new OleDbConnection(connString);
        //try
        {
            cn.Open();
            DataTable dbSchema = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dbSchema == null)
            {
                throw new Exception("Khong tim tahy work sheet dau tien");
            }
            string WorkSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from [" + WorkSheetName + "]", cn);
            DataTable dt = new DataTable(WorkSheetName);
            da.Fill(dt);
            return dt;
            //cn.Close();
            //cn.Dispose();
        }// end try
        //catch (Exception e1)
        //{
        //    // Bắt lỗi
        //    Console.WriteLine(e1.Message);

        //}

        //finally
        //{
        //    cn.Close();
        //    cn.Dispose();
        //}

    }


    public string[] ReadExcel(string TenDuongdan)
    {
        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + TenDuongdan + ";Extended Properties=Excel 8.0;";
        string[] ketQua;
        OleDbConnection cn = new OleDbConnection(connString);
        //try
        {
            cn.Open();
            DataTable dbSchema = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dbSchema == null)
            {
                throw new Exception("Khong tim tahy work sheet dau tien");
            }
            string WorkSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from [" + WorkSheetName + "]", cn);
            DataTable dt = new DataTable(WorkSheetName);
            da.Fill(dt);            
            int tong = dt.Rows.Count;
            ketQua = new string[tong];
            int i = 0;           
            while (i < tong)
            {
                //if (dt.Rows[i][0].ToString().Trim() != "") // Nếu ô bỏ trống thì bỏ qua, ko đưa vào DS                
                    ketQua[i] = dt.Rows[i][0].ToString();
                    i = i + 1;                
            }            
            
        }// end try
        //catch (Exception e1)
        {
            // Bắt lỗi
            //Console.WriteLine(e1.Message);

        }

       // finally
        {
            cn.Close();
            cn.Dispose();
            return ketQua;
        }

    }

    






}
