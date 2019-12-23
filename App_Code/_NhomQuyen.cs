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
/// Summary description for _NhomQuyen
/// </summary>
public class _NhomQuyen
{
    public _NhomQuyen()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string _maNhomQuyen;
    private string _tenNhomQuyen;
    private bool _checked;
    private bool _traCuuToanTinh;

    public string MaNhomQuyen   { set { _maNhomQuyen = value; }    get { return _maNhomQuyen; }  }
    public string TenNhomQuyen  { set { _tenNhomQuyen = value; }   get { return _tenNhomQuyen; } }
    public bool Checked         { set { _checked = value; }        get { return _checked; }    }
    public bool TraCuuToanTinh { set { _traCuuToanTinh = value; } get { return _traCuuToanTinh; } }
}
