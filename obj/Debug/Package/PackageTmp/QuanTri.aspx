<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBeta.Master" AutoEventWireup="true" CodeBehind="QuanTri.aspx.cs" Inherits="TraCuuVB.QuanTri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<span class="form-title">5. Quản trị người dùng</span> 

 <table id="example" class="display" cellpadding="0" cellspacing="0" border="0">
        <thead>
            <tr>
                <th style="height: 14px; width: 120px;">Id</th>
                <th style="height: 14px;">  User name</th>                                           
                <th style="height: 14px;">  Status</th>                  
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptKetQua" runat="server">
                <ItemTemplate>
                    <tr class="gradeA">
                        <td><%#Eval("MaNSD")%></td>
                        <td><%#Eval("TenDangNhap")%> </td>                        
                        <td><%#Eval("TrangThai")%></td>                        
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td class="rounded-foot-left" colspan='2' style="height: 14px">
                </td>
            </tr>
        </tfoot>
    </table>

 <fieldset><legend>Quản lý user</legend>
     <div class="row">
                <span class="col-1">Tên đăng nhập </span>
                <span class="col-2"><asp:TextBox ID="txtTenDangNhap" runat="server"  Width="40%"  ></asp:TextBox> </span>                            
     </div> <%--end row 2--%>       
     <div class="row">
           <asp:Label ID="lbThongBao" runat="server" Text="" ForeColor="Red"></asp:Label>                           
     </div> <%--end row 2--%>  

     <div class="row"> 
    
                <asp:Button ID="butAddNew" runat="server"   Text="Thêm mới user" onclick="butAddNew_Click" />
                <asp:Button ID="butReset" runat="server"   Text="Reset mật khẩu" onclick="butReset_Click" /> 
                <asp:Button ID="butChangeStatus" runat="server" Text="Khóa/ Mở khóa"    onclick="butChangeStatus_Click" />
                 
     </div> <%--end row 2--%>  
     </fieldset> 

     <%--Giao dien moi cho bang table  --%>
<script type="text/javascript" src="./table/media/js/jquery.dataTables.js"></script>    
    
<script type="text/javascript">
    $(document).ready(function () {

        $('#example').dataTable(
		{
		    "bJQueryUI": true,
		    "sPaginationType": "full_numbers"
		});

    }); // End ready			
</script>


</asp:Content>
