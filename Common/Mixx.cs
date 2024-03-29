using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;

//using Microsoft.ApplicationBlocks.Data;


/// <summary>
/// Summary description for Mix
/// </summary>
namespace TraCuuVB
{

    public  class Mixx
    {

        //string kq;// của ChuyenChuoiThanhSo(string chuoi)

        public Mixx()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string TinhThoiHanBaoHanh(int tgBh, DateTime ngayCap)
        {
            DateTime ngayHienTai = DateTime.Now;

            int nguyen1 = Mixx.LayNguyen(tgBh, 12); // số năm
            int du1 = tgBh % 12; // số tháng   

            int thangHetBH = ngayCap.Month + du1;
            int namHetBH = ngayCap.Year + nguyen1;

            if (thangHetBH > 12)
            {
                thangHetBH = thangHetBH % 12; // lấy dư
                namHetBH = namHetBH + 1; // Cộng thêm lấy nguyên
            }
            if (thangHetBH < 10)
                return "" + thangHetBH.ToString() + "/" + namHetBH.ToString();
            else
                return "" + thangHetBH.ToString() + "/" + namHetBH.ToString();
        }

        public static string ChuoiKetNoiServer()
        {
            return ConfigurationManager.ConnectionStrings["TraCuuVanBanConnectionString"].ConnectionString;
        }


        public static bool IsNumber(string pText)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }






        public static void SetIndexOfDropDownList(System.Web.UI.WebControls.ListBox dropList, string valueOfDropDL)
        {
            int soItem = dropList.Items.Count;
            int i; int ketqua = -1; ;
            for (i = 0; i < soItem; i++)
            {
                if (valueOfDropDL.Trim() == dropList.Items[i].Value.Trim())
                { ketqua = i; }
            }

            dropList.SelectedIndex = ketqua;

        }

        public bool IsValidFileExtension(string filename)
        {
            int index = filename.LastIndexOf(".");
            string[] strFileExts = { "xls" };
            return false;
            if (index > 0)
            {
                string ext = filename.Substring(index + 1).ToLower();

                int count = 0;

                for (int i = 0; i < strFileExts.Length; i++)
                    if (ext != strFileExts[i])
                        count++;

                if (count == strFileExts.Length) // Duyeetj hết mà cũng ko có
                    return false;
                else
                    return true;
            }

        }


        public static int LayNguyen(int soBiChia, int soChia)
        {
            return (soBiChia - (soBiChia % soChia)) / soChia;

        }



        public static string encryptMD5(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            string matKhauMD5 = BitConverter.ToString(hashedBytes);
            matKhauMD5 = matKhauMD5.Replace("-", String.Empty);
            return matKhauMD5;

        }

        public static string ConvertNaturalNumberToRomanNumber(int soCanChuyen)
        {
            string soLaMa = string.Empty;
            Boolean flag = true;
            string[] ArrayLaMa = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] ArrayNumber = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            int i = 0;
            while (flag)
            {
                while (soCanChuyen >= ArrayNumber[i])
                {
                    soCanChuyen -= ArrayNumber[i];
                    soLaMa += ArrayLaMa[i];
                    if (soCanChuyen < 1)
                        flag = false;
                }
                i++;
            }
            return soLaMa;
        } // end ConvertNaturalNumberToRomanNumber

        public static string ConvertNaturalNumberToAlphabe(int soCanChuyen)
        {
            string[] ArrayAlphabe = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
            return ArrayAlphabe[soCanChuyen];
        } // end ConvertNaturalNumberToAlphabe

    }

}