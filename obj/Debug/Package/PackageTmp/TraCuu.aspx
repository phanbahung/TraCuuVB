<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBeta.master" AutoEventWireup="true" CodeBehind="TraCuu.aspx.cs" Inherits="TraCuuVB.TraCuu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<span class="form-title">1. Tra cứu văn bản</span> 

<div class='dieukien'>
    
     <div class="row">
                <span class="col-1">Số hiệu văn bản/ Nội dung </span>
                <span class="col-2">  <asp:TextBox ID="txtSoHieuVB" runat="server"  Width="150%"  ></asp:TextBox>           </span>                
     </div> <%--end row 1--%>

     
     <div class="row">
                <span class="col-1">Ngày ban hành </span>
                <span class="col-2"><asp:TextBox ID="txtTuNgay" runat="server"  Width="40%"  ></asp:TextBox> 
                            đến <asp:TextBox ID="txtDenNgay" runat="server"  Width="35%"  > </asp:TextBox>          </span>
                <span class="col-3">Sắc thuế </span>
                <span class="col-4"><asp:DropDownList ID="dropSacThue" runat="server" Width="90%">  </asp:DropDownList> </span>
     </div> <%--end row 2--%>   


      <div class="row">
                <span class="col-1">Loại văn bản</span>
                <span class="col-2"> <asp:DropDownList ID="dropLoaiVB" runat="server" Width="90%">  </asp:DropDownList></span>                
                <span class="col-3">Cơ quan ban hành </span>
                <span class="col-4"> <asp:DropDownList ID="dropCqBanHanh" runat="server" Width="90%">  </asp:DropDownList></span>
     </div> <%--end row 3--%>

      <div class="row">
        <span class="col-1"></span>
        <span class="col-2">   </span>
        <span class="col-3"> <asp:Button ID="butTraCuu" runat="server" Text="Tra cứu"    onclick="butTraCuu_Click" />  </span>
        <span class="col-4"> <asp:Label ID="lbThongBao" runat="server" Text="" ForeColor="Red"></asp:Label> </span>
        </div> <%--end row 2--%>
    
 </div>
        
  <div class="form-title">Kết quả</div>   

 <table id="example" class="display" cellpadding="0" cellspacing="0" border="0">
        <thead>
            <tr>
                <th style="height: 14px; width: 120px;"> Số hiệu văn bản</th>
                <th style="height: 14px;">  Cơ quan ban hành</th>
                <th style="height: 14px;">  Loại văn bản</th>
                <th style="height: 14px;">  Ngày ban hành</th>
                <th style="height: 14px;">  Nội dung</th>            
                <th style="height: 14px;">  Văn bản</th>                
                <th style="height: 14px;width: 60px;">  Chi tiết</th> 
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptKetQua" runat="server">
                <ItemTemplate>
                    <tr class="gradeA">
                        <td><%#Eval("SoHieuVB")%></td>
                        <td><%#Eval("CqBanHanh")%> </td>
                        <td><%#Eval("LoaiVB")%></td>
                        <td><%#Eval("NgayBanHanh")%></td>
                        <td><%#Eval("NoiDung")%> </td>  
                        <td><a href="vanban/<%#Eval("LinkVanBan")%>">Download</a> </td>   
                        <td><a href="./Edit.aspx?id=<%#Eval("IdVanBan")%>">Chi tiết</a> </td> 
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


 <%-- <script type="text/javascript" src="./jquery/jquery-1.7.2.min.js"></script> --%> 
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
