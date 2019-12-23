<%@ Page Language="C#" MasterPageFile="~/MasterPageBeta.master" AutoEventWireup="True"
    CodeBehind="WebNotes.aspx.cs" Inherits="TraCuuVB.WebNotes" Title="Ghi chu" %>

  <asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
<span class="form-title">  Ghi chú nhanh </span>


    
    <table id="example" class="display" cellpadding="0" cellspacing="0" border="0">
        <thead>
            <tr>
               <th style="height: 14px;">
                    Tiều đề</th>
                <th style="height: 14px;">
                    Nội dung</th>
               
                    <th style="height: 14px;">
                    Public</th> 
                <th style="height: 14px;">
                </th>
                <th style="height: 14px;">
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptDMTTBHSC" runat="server">
                <ItemTemplate>
                    <tr class="gradeA">
                        <td>
                            <%#Eval("TieuDe")%>
                        </td>
                        <td>
                            <%#Eval("NoiDung")%>
                        </td>                       
                       
                         <td>
                            <%#Eval("CongKhai")%>
                        </td>
                        <td>
                            <input id="<%#Eval("ID")%>" type="button" class="xemTTBHSC" value="Chi tiết" />
                        </td>
                        <td>
                            <input id="edit<%#Eval("Id")%>" type="button" class="suaTTBHSC" value="Sửa" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td class="rounded-foot-left" colspan='6'>
                </td>
            </tr>
        </tfoot>
    </table>
    <br />
    <span class="row-control">        
        <input id="themTTBHSC" type="button" value="Thêm mới" style="text-align:center;"/>
        <input id="butExitForm" type="button" value=" Thoát " />        
    </span>
    <%-- Popup Details--%>
    <div id="popupDetails" style="height: auto; display: none;">
        <span class="tieude-form row gradient">THÔNG TIN CHI TIẾT</span>        
        
        
        <span class="row">
                <span class="bhsc-col1">Tiêu đề:</span> <span class="bhsc-col2">
                    <input id="tieuDe" type="text" style="width: 90%;" class="control" /></span> </span>
                    
        <span class="row"><span class="bhsc-col1">Nội dung:</span> <span class="bhsc-col2">
           <textarea rows="2" cols="20" id="noiDung" style="height: 60px; width: 90%;" class="control"></textarea></span> </span>

              <span class="row"><span class="bhsc-col1">Tag:</span>    
              <span class="bhsc-col2">
               <textarea rows="2" cols="20" id="tag" style="height: 60px; width: 90%;" class="control"></textarea></span>                            
            </span>
            
       <span class="row">
                <span class="bhsc-col1">Public:</span> <span class="bhsc-col2">

                    <input id="congKhai" type="checkbox" />                 
                    
                    </span> </span> 
    
                    
                    <span id="infoLoi">
                        
                    </span>
                    
    <span class="row">
                        <input id="inputSave" type="button" class="" value="Lưu thay đổi" />
                        <input id="inputNew" type="button" class="" value="Đồng ý" />
                        <input id="no" type="button" class="no" value=" Đóng " />
    </span>
    </div>
    <%--End popup--%>

    <script type="text/javascript" src="./jquery/jquery-1.7.2.min.js"></script>

    <%--Giao dien moi cho bang table  --%>
    <script type="text/javascript" src="./table/media/js/jquery.dataTables.js"></script>    
    <script type="text/javascript" src="./js/jquery.blockUI.js?v2.38"></script>    
    <script type="text/javascript" src="./js/common.js"></script>
    <script type="text/javascript" src="./js/common.user_rights.js"></script>    
    <script type="text/javascript" src="./js/ghichu.js"></script>
    
        
    <script type="text/javascript">
      
    function Empty_Text_Input()
        {
           $(".control").val("");        
        }              
        
        
    function fnAddNewRow(tieuDe, noiDung,tag, public) 
        {
          $('#example').dataTable().fnAddData( 
           [tieuDe,                
            tenDayDu,
            thuocCongTy,
            "<input id=" + maTT + " type='button' class='xemTTBHSC' value='Chi tiết'/>",
            "<input id='edit" + maTT + "' type='button' class='suaTTBHSC' value='Sửa' />"]);   
        }



        $(document).ready(function () {


            $('#example').dataTable(
		{
		    "bJQueryUI": true,
		    "sPaginationType": "full_numbers"
		});


            // Phân quyền tại đây        
            //fnShowHide(5,Quyen_SuaThongTin_TTBH());  
            //$('#themTTBHSC').prop("disabled",!Quyen_DMHopDong());                   

            // show popup Thêm mới		
            $('#themTTBHSC').click(function () {
                Empty_Text_Input();
                $('#inputSave').addClass("hidden");
                Disabled_Input4Edit(false);
                $.blockUI({ message: $('#popupDetails'), css: { width: '600px', left: '350px', top: '200px'} });
            });


            $('.suaTTBHSC').live('click', function () {
                var maTT = $(this).closest('tr').children('td').children('input').attr("id");
                Load_TTBHSC_To_Detail(maTT);
                Disabled_Input4Edit(false);
                $('#inputNew').addClass("hidden");
                $('#inputSave').removeClass("hidden");
                $.blockUI({ message: $('#popupDetails'), css: { width: '600px', left: '350px', top: '200px'} });
            });


            $('.xemTTBHSC').live('click', function () {
                $('#inputSave').addClass("hidden");
                $('#inputNew').addClass("hidden");
                var id = $(this).closest('tr').children('td').children('input').attr("id");
                //$('input#tieuDe').val(id);
                Get_One_GhiChu(id);
                Disabled_Input4Edit(true);
                $.blockUI({ message: $('#popupDetails'), css: { width: '600px', left: '350px', top: '200px'} });
            });

            $('.no').click(function () {
                $.unblockUI();
                $('#inputSave').removeClass("hidden");
                $('#inputNew').removeClass("hidden");
                return false;
            });
            // end show popup	


            // Lưu thay đổi thông tin TTBHSC
            $('#inputSave').click(function () {
                var kq = Edit_TrungTamBHSC($('#inputMaTTBHSC').val());
                if (kq = '0') {
                    $.unblockUI();
                    $('#inputSave').addClass("hidden");
                    $('span#infoLoi').text(kq);
                }
                else $('span#infoLoi').text(kq);

            });
            // ---- End Lưu thay đổi thông tin TTBHSC

            // Lưu đăng ký ttbh sc mới
            $('#inputNew').click(function () {
                // Lây các giá trị trên bảng popupDetails
                var tieuDe = $('input#tieuDe').val();
                var noiDung = $('#noiDung').val();
                var tag = $('#tag').val();
                var congKhai = '1';// $('#tenTTBHSC').val();
                // Đăng kí TT và lấy ID trả về
                var kq = Reg_GhiChu(tieuDe, noiDung, tag, congKhai);
                // Thêm vào vào bảng trên client right now

                if (jQuery.isNumeric(kq)) {
                    fnAddNewRow(kq, tieuDe, noiDung, tag, congKhai);
                    $.unblockUI();
                    $('#inputNew').addClass("hidden");
                    $('#inputSave').addClass("hidden");
                }
                else $('span#infoLoi').text(kq);

            });
            // ---- End Lưu thay đổi thông tin TTBHSC








        });  // End ready
			
</script>

</asp:Content>
