//Var option = " < option value='1'> 1< /option> < option value='2'selected> 2< /option> < option value='3'> 3< /option> "
//$('select').Append (option);


function populateSelectTTBHSC(el, items) { 
    el.options.length = 0; 
    //if (items.length > 0)   el.options[0] = new Option(' Tất cả ', '');            
    $.each(items, function () { 
        el.options[el.options.length] = new Option(this.name, this.value); 
    }); 
}  


// Sử dụng cho BHSC.aspx
 function Load_DM_TTBHSC_To_Select_NotSet(selectID, maDonViCC)
    {
        dm_ttbhsc= [];
        $.ajax({
            type: "POST",
            url: "~/WsDMTTBHSC.asmx/Load_One_GhiChu",                              
            data: "{'Id':'" + maDonViCC + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                for(i=0; i<data.d.length; i++)
                {  dm_ttbhsc.push({"MaTTBHSC": data.d[i].MaTTBHSC, "TenTTBHSC": data[i].TenTTBHSC});   }                                                            
               
                populateSelectTTBHSC($('#'+selectID).get(0), $.map(dm_ttbhsc, function(tt) { return { name: tt.TenTTBHSC, value: tt.MaTTBHSC} }));                 
          
            }// end success                           
        });// ajax
    }
    
    
    // Sử dụng cho BHSC.aspx
 function Load_DM_TTBHSC_To_Select(selectID, maDonViCC, selected_val)
    {
        
        dm_ttbhsc= [];
        $.ajax({
            type: "POST",  
            async: false,             
            url: "/TraCuuVB/WsDMTTBHSC.asmx/Load_DM_TTBHSC",                              
            data: "{'maDonViCC':'" + maDonViCC + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json", 
            success: function (data) {
                var option = "";
                for(i=0; i<data.d.length; i++)
                {
                    if (data.d[i].MaTTBHSC!=selected_val)
                    {
                        option += "<option value='"+data.d[i].MaTTBHSC +"'> "+ data.d[i].TenTTBHSC + "</option>"                
                    }
                    else {
                        option += "<option selected value='"+data.d[i].MaTTBHSC +"'>"+ data.d[i].TenTTBHSC + "</option>"                
                    }
                }  
                //$("textarea#txtareaMoTaLoi_bhsc").val(option);                                                          
                $('select#'+selectID).html(option);
               
               
          
            }// end success                           
        });// ajax
    }


   // Sử dụng cho TraCuu.aspx
 function Load_DM_DonViCC_TTBHSC(select_DVCC, select_TTBHSC)
    {
        
        dm_ttbhsc= [];
   $('#'+select_DVCC).bind('change', function()            
     { 
           var maDonViCC= this.value;                 
            $.ajax({
                type: "POST",  
                async: false,             
                url: "/TraCuuVB/WsDMTTBHSC.asmx/Load_DM_TTBHSC",                              
                data: "{'maDonViCC':'" + maDonViCC + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json", 
                success: function (data) {
                    var option = "";
                    for(i=0; i<data.d.length; i++)
                    {
                      option += "<option value='"+data.d[i].MaTTBHSC +"'> "+ data.d[i].TenTTBHSC + "</option>"                                    
                    }          
                    $('select#'+select_TTBHSC).html(option);
              
                }// end success                           
            });// ajax
      }); // end bind change   
    }


function Get_One_GhiChu(id) {

 $.ajax({
            type: "POST",
            url: "./WsGhiChu.asmx/Get_One_GhiChu",                              
            data: "{'id':'" + id + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json", 
            success: function (data1) {
                $('input#tieuDe').val(data1.d[0].TieuDe);
                $('textarea#noiDung').val(data1.d[0].NoiDung);              
                $('textarea#tag').val(data1.d[0].Tag);
               //Set_SelectedOption("ctl00_ContentPlaceHolder1_dropCongTy",data1.d[0].CongKhai);
          
            }// end success                           
        });// ajax
    }

function fnUpdateTable(maTT, tenVietTat,tenDayDu, thuocCongTy) {                                                     
              var $td = $('#example td input#'+maTT).closest('tr').children('td');                                    
              $td.eq(1).text(tenVietTat);       
              $td.eq(2).text(tenDayDu);       
              $td.eq(3).text(thuocCongTy);                      
            }       
    
    
function Edit_TrungTamBHSC(maTT)
    {     
        var tenVietTat= $('input#tenVietTat').val();
        var diaChi= $('textarea#diaChi').val();
        var dienThoai= $('textarea#dienThoai').val();          
        var tenTTBHSC=$('input#tenTTBHSC').val();                    
        var ghiChu=$('textarea#ghiChu').val();                    
        var maDonViCC=$('select#ctl00_ContentPlaceHolder1_dropCongTy option:selected').val();                    
        var kq='';      
        $.ajax({               
            type: "POST",  
            async: false,             
            url: "/TraCuuVB/WsDMTTBHSC.asmx/Edit_GhiChu",                              
            data: "{'maTTBHSC': '"       + maTT+ 
                     "','tenVietTat': '" + tenVietTat+
                     "','tenTTBHSC': '"  + tenTTBHSC+ 
                     "','diaChi': '"     + diaChi+
                     "','dienThoai': '"  + dienThoai + 
                     "','ghiChu': '"     + ghiChu + 
                     "','maDonViCC': '"  + maDonViCC+"'}",     
                
            contentType: "application/json; charset=utf-8",
            dataType: "json",             
            success: function (data) { 
                if(data.d=='0')            
                    fnUpdateTable(maTT, tenVietTat, tenTTBHSC, maDonViCC);           
                kq=data.d;
            }// end success
            
                                   
        });// ajax
        return kq;
    }// End function Edit_TrungTamBHSC(maTT)


    
    
function Reg_GhiChu(tieuDe, noiDung, tag, congKhai)
    {   
        var kq="";
        $.ajax({               
            type: "POST", 
            async: false,
            //url: "http://localhost:4546/WsGhiChu.asmx/Reg_GhiChu",
            //url: "../../WsGhiChu.asmx/Reg_GhiChu",
            url: "./WsGhiChu.asmx/Reg_GhiChu",                              
            data:   "{'tieuDe': '"     + tieuDe+                         
                     "','noiDung': '"  + noiDung+ 
                     "','tag': '"      + tag+                   
                     "','congKhai': '" + congKhai+"'}",     
                
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                kq = data.d;            
            }// end success                           
        });// ajax
        return kq;
} // End function Reg_GhiChu()