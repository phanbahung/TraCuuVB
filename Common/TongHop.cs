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



/// <summary>
/// Summary description for Mix
/// </summary>
///
namespace TraCuuVB
{

    public  class TongHop
    {

        public  TongHop()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public static string ChuoiKetNoiServer()
        {
            return ConfigurationManager.ConnectionStrings["NguoiPhuThuocConnectionString"].ConnectionString;
        }         

        public static bool IsNumber_02(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
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

        public static string NonUnicode( string text)
        {
            string[] arr1 = new string[] { 
            "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",  
            "đ", "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",  
            "í","ì","ỉ","ĩ","ị",  
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",  
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",  
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] 
            { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",  
              "d", "e","e","e","e","e","e","e","e","e","e","e",  
              "i","i","i","i","i",  
              "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",  
              "u","u","u","u","u","u","u","u","u","u","u",  
              "y","y","y","y","y",};

            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }  



    }
}


