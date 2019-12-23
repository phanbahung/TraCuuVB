using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TraCuuVB
{
    public partial class MasterPage_BackEnd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenDangNhap"].ToString() != "")
            {
                // Nếu thành công thì 
                lbThongTinNSD.Text = "Người SD: " + Session["TenDangNhap"].ToString();
                lnkLogOut.Visible = true;
            }
            else lnkLogOut.Visible = false;
             lbHomNay.Text = "Hôm nay: "+ DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session["TenDangNhap"] = "";
            lnkLogOut.Visible = false;
            Response.Redirect("TraCuu.aspx");
        }
    }
}