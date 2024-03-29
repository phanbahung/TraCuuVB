using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for NgayThang
/// </summary>
/// 
namespace TraCuuVB
{
    public class NgayThang
    {

        public NgayThang()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static bool IsDate1(string strDate)
        {
            bool boolIsDate = false;
            try
            {
                DateTime myDateTime = DateTime.Parse(strDate);
                boolIsDate = true;
            }
            catch { }
            return (boolIsDate);
        }

        public static bool IsDate_AllowEmpty(string strDate)
        {
            bool boolIsDate = false;
            if (strDate.Trim() == "") boolIsDate = true;
            else
            {
                try
                {
                    DateTime myDateTime = DateTime.Parse(strDate);
                    boolIsDate = true;
                }
                catch { }
            }
            return (boolIsDate);
        }

        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public static bool IsDate(string strDate)
        {
            bool kq = true;

            int dd, mm, yyyy;
            dd = int.Parse(strDate.Substring(0, 2));
            mm = int.Parse(strDate.Substring(3, 2));
            yyyy = int.Parse(strDate.Substring(6, 4));

            if (dd <= 0 || mm <= 0 || mm > 12)
                kq = false;
            else
            {
                if (mm == 1 || mm == 3 || mm == 5 || mm == 7 || mm == 8 || mm == 10 || mm == 12)
                {
                    if (dd <= 31)
                        kq = true;
                    else
                        kq = false;
                }
                else
                {
                    if (mm == 4 || mm == 6 || mm == 9 || mm == 11)
                    {
                        if (dd <= 30)
                            kq = true;
                        else
                            kq = false;
                    }
                    else
                    {
                        if (mm == 2 && yyyy % 4 == 0 && yyyy % 100 != 0)
                        {
                            if (dd <= 29)
                                kq = true;
                            else
                                kq = false;
                        }
                    }
                }
            }


            return kq;
        }

        public static DateTime NewDateTime(string chuoiNgayThangNam)
        {
            int ngay, thang, nam;
            ngay = int.Parse(chuoiNgayThangNam.Substring(0, 2));
            thang = int.Parse(chuoiNgayThangNam.Substring(3, 2));
            nam = int.Parse(chuoiNgayThangNam.Substring(6, 4));
            DateTime kq = new DateTime(nam, thang, ngay);
            return kq;


        }
        /// <summary>
        /// Trả về định dang DD/yyyy
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DinhDangThangNam(DateTime dt)
        {
            //int thang;
            //string strThangNam;
            //thang = dt.Month;

            //if (thang < 10)
            //{ strThangNam = "0" + thang.ToString() + "/" + dt.Year.ToString(); }
            //else
            //{ strThangNam = thang.ToString() + "/" + dt.Year.ToString(); }        


            return dt.ToString("MM/yyyy");
        }
    }
}