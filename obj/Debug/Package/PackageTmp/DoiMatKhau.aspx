<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBeta.master" AutoEventWireup="true" CodeBehind="DoiMatKhau.aspx.cs" Inherits="TraCuuVB.DoiMatKhau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="divDoiMatKhau"  >
     <span class="form-title">ĐỔI MẬT KHẨU</span> 
    <div class="row">
                <span class="col-1">Tên đăng nhập </span>
                <span class="col-2"> <asp:TextBox ID="txtTenDangNhap" runat="server"  Width="90%"  Font-Bold="true"></asp:TextBox> </span>               
     </div> <%--end row 1--%>
     <div class="row">
                <span class="col-1">Mật khẩu cũ:</span>
                <span class="col-2"> <asp:TextBox ID="txtMatKhauCu" runat="server"  Width="90%"  Font-Bold="true" TextMode="Password"></asp:TextBox>  </span>
                              
     </div> <%--end row 1--%>   
      <div class="row">
                <span class="col-1">Mật khẩu mới</span>
                <span class="col-2"> <asp:TextBox ID="txtMatKhauMoi1" runat="server"  Width="90%"  Font-Bold="true" TextMode="Password"></asp:TextBox>  </span>
                              
     </div> <%--end row 1--%>        

     <div class="row">
                <span class="col-1">Xác nhận mật khẩu mới</span>
                <span class="col-2"> <asp:TextBox ID="txtMatKhauMoi2" runat="server"  Width="90%"  Font-Bold="true" TextMode="Password"></asp:TextBox>  </span>                           
     </div> <%--end row 1--%>  
     
       <asp:Button ID="butDoiMatKhau" runat="server" Text="Đồng ý"   onclick="butDoiMatKhau_Click" />     
      <asp:Label ID="lbThongBao" runat="server" Text="" ForeColor="Red"></asp:Label>
   

    </div> <%--end div Doimat kahu--%>


</asp:Content>
