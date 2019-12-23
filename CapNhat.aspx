<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_BackEnd.master" AutoEventWireup="True" CodeBehind="CapNhat.aspx.cs" Inherits="TraCuuVB.CapNhat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <span class="form-title">2. Cập nhật văn bản</span> 
<div class='dieukien'>
    
     <div class="row">
                <span class="col-1">Số hiệu văn bản* </span>
                <span class="col-2">  <asp:TextBox ID="txtSoHieuVB" runat="server"  Width="90%"  Font-Bold="true"></asp:TextBox>    
                         </span>
                <span class="col-3"></span>
                <span class="col-4">  </span>
     </div> <%--end row 1--%>

       <div class="row">
                <span class="col-1"> Nội dung*</span>
                <span class="col-2">  <asp:TextBox ID="txtNoiDung" runat="server" Width="200%" 
                    Height="70px" TextMode="MultiLine" Font-Names="Tahoma" Font-Size="Small"></asp:TextBox>  </span>
                <span class="col-3"> </span>
                <span class="col-4">   </span>
     </div> <%--end row 1--%>
     
     <div class="row">
                <span class="col-1">Ngày ban hành (dd/MM/yyyy)* </span>
                <span class="col-2"><asp:TextBox ID="txtNgayBanHanh" runat="server"  Width="40%"  Font-Bold="true"></asp:TextBox>  </span>
                    <span class="col-3">Cơ quan ban hành </span>
                <span class="col-4"> <asp:DropDownList ID="dropCqBanHanh" runat="server" Width="90%">  </asp:DropDownList></span>
                
     </div> <%--end row 2--%>

      <div class="row">
                <span class="col-1">Loại văn bản</span>
                <span class="col-2"> <asp:DropDownList ID="dropLoaiVB" runat="server" Width="90%">  </asp:DropDownList></span> 
                <span class="col-3">Sắc thuế </span>
                <span class="col-4"><asp:DropDownList ID="dropSacThue" runat="server" Width="90%">  </asp:DropDownList> </span>                           
     </div> <%--end row 3--%>

     <div class="row">
                <span class="col-1">Ngày BĐ hiệu lực</span>
                <span class="col-2"> <asp:TextBox ID="txtNgayHieuLuc" runat="server"  Width="100%"  Font-Bold="true"></asp:TextBox>  </asp:DropDownList></span> 
                <span class="col-3"> </span>
                <span class="col-4"> </span>               
            
     </div> <%--end row 3--%>

    <div class="row">
                <span class="col-1">Bổ sung /thay thế/ hướng dẫn VB:</span>
                <span class="col-2"> <asp:TextBox ID="txtBoSungThayThe" runat="server" Width="90%"></asp:TextBox> </span>                
                <span class="col-3"></span>
                <span class="col-4"> </span>
     </div> <%--end row 4--%>


      <div class="row">
                <span class="col-1">File văn bản*</span>
                <span class="col-2"> <asp:FileUpload ID="fuUpload1" runat="server" /> </span>                
                <span class="col-3"></span>
                <span class="col-4"> </span>
     </div> <%--end row 4--%>

    <div class="row">
        
     </div> <%--end row 4--%>

      <div class="row">
        <span class="col-1"><asp:Button ID="butLuuVanBan" runat="server" Text="Lưu văn bản"    onclick="butLuuVanBan_Click" /> </span>
        <span class="col-2"> </span>
        <span class="col-3">  </span>
        <span class="col-4">      </span></div> <%--end row 5--%>
     

     <div id="note" class="row">
     Lưu ý: </br>- Kích thước các file không quá 5MB (Click chuột phải File văn bản / Chọn Properties để biết )
     </div> <%--end row 4--%>
       
     <div id="error" class="row">
          <asp:Label ID="lbThongBao" runat="server" Text="" ForeColor="Red"></asp:Label>
          </br> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Không được để trống Số hiệu VB" ControlToValidate="txtSoHieuVB"  ForeColor="Red"></asp:RequiredFieldValidator>   
          </br>  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="Không được để trống Nội dung" ControlToValidate="txtNoiDung"   ForeColor="Red" ></asp:RequiredFieldValidator>   
          </br>  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="Không được để trống Ngày ban hành"  ControlToValidate="txtNgayBanHanh"  ForeColor="Red"></asp:RequiredFieldValidator>             
          </br>  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ErrorMessage="File văn bản chưa có"  ControlToValidate="fuUpload1"  ForeColor="Red"></asp:RequiredFieldValidator>                       
          </br>  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
              ErrorMessage="Ngày ban hành không đúng định dạng dd/MM/yyyy hoặc không phải ngày hợp lệ" ControlToValidate="txtNgayBanHanh"                            
              ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$" 
              ForeColor="#FF0066"></asp:RegularExpressionValidator> 
        </div>     <%--end row Dieu Kien BatBuoc--%>
 

    


     
      
       
        
    
 </div>

</asp:Content>
