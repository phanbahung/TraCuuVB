<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBeta.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TraCuuVB.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    BD<asp:TextBox ID="TextBox1" runat="server" CssClass="money"></asp:TextBox>
    So Ngay<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    Kq<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <br />
</asp:Content>
