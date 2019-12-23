<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBeta.master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="TraCuuVB.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="divDangNhap"  >
    <span class="form-title">ĐĂNG NHẬP</span> 

   <div class="row">
                <span class="col-1">Tên đăng nhập </span>
                <span class="col-2"> <asp:TextBox ID="txtTenDangNhap" runat="server"  Width="90%"  Font-Bold="true"></asp:TextBox> </span>
                <span class="col-3"></span>
                <span class="col-4"></span>
     </div> <%--end row 1--%>
      <div class="row">
                <span class="col-1">Mật khẩu</span>
                <span class="col-2"> <asp:TextBox ID="txtMatKhau" runat="server"  Width="90%"  Font-Bold="true" TextMode="Password"></asp:TextBox>  </span>
                <span class="col-3"> </span>
                <span class="col-4"></span>                
     </div> <%--end row 1--%>
    <asp:Button ID="butDangNhap" runat="server" Text="Đăng nhập" onclick="butDangNhap_Click" />

        
    <asp:Label ID="lbThongBao" runat="server" Text="" ForeColor="Red"></asp:Label>
    
    </div> <%--end div dangnhap--%>

   


</asp:Content>
