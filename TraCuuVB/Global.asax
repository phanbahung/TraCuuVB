<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Session["MaCqThue"] = "";                
        Session["Report"] = "print";// dùng trong báo cáo
        //Session["LoaiTB"] = ""; // dùng trong báo cáo
        //Session["TinhTrang"] = "";     // dùng trong báo cáo   
        Session["ReLogin"] = "false"; // đánh dầu NSD login lại
        Session["Permission"] = ""; // lưu mảng chuỗi , các giá trị 1 0, các quyền NSd được và không được dùng
        
        
        // Khai báo để đăng nhập
        Session["TenDangNhap"] = "";        
        Session["MaCqThue_login"] = "";
        // Cho phép tra cứu trên toàn tỉnh
        Session["ToanTinh"] = "False"; 
        // Trang thái đăng nhập của NSD 
        Session["Status"] = "notLogin";// success: login successfully
        Session.Timeout = 30000;
        HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);

        
        
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Session.Abandon();

    }


    void Application_BeginRequest(object sender, EventArgs e)
    {
        ////Khoi tao rule
        //UrlRewritingNet.Web.RegExRewriteRule ruleEditThietBi = new UrlRewritingNet.Web.RegExRewriteRule();
        ////Rule – rewrite cho edit thiết bị
        //ruleEditThietBi.VirtualUrl = "^~/thaydoithongtin/(.*)_(.*).aspx";
        //ruleEditThietBi.DestinationUrl = "~/SuaThietBi.aspx?MaTB=$2";
        //ruleEditThietBi.IgnoreCase = true;
        //ruleEditThietBi.Rewrite = UrlRewritingNet.Web.RewriteOption.Application;
        //ruleEditThietBi.Redirect = UrlRewritingNet.Web.RedirectOption.None;
        //ruleEditThietBi.RewriteUrlParameter = UrlRewritingNet.Web.RewriteUrlParameterOption.ExcludeFromClientQueryString;
        //UrlRewritingNet.Web.UrlRewriting.AddRewriteRule("ruleEditThietBi", ruleEditThietBi);

       
    }

       
</script>
