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
/// Summary description for _TTBHSC
/// </summary>
namespace TraCuuVB
{
    public class _GhiChu
    {
        public _GhiChu()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        string _id;
        string _tieuDe;
        string _noiDung;
        string _tag;
        string _congKhai;

        public string ID { set { _id = value; } get { return _id; } }
        public string TieuDe { set { _tieuDe = value; } get { return _tieuDe; } }
        public string NoiDung { set { _noiDung = value; } get { return _noiDung; } }
        public string Tag { set { _tag = value; } get { return _tag; } }
        public string CongKhai { set { _congKhai = value; } get { return _congKhai; } }


    }
}// end space