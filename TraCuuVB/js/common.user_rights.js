// JScript File

function  GetUserRight()
{
        rights  = [];//new Array()        
        
         $.ajax({
                type: "POST", 
                async: false,              
                url: "/TraCuuVB/WsRight.asmx/ReadRights",                              
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {                                        
                    for(i=0; i<data.d.length; i++)
                    { 
                       rights.push(data.d[i]);                        
                    }                   
                }// end success                                       
        });// ajax
        
        return rights;           
        
} 

 function  GetCqThue()
{
        var cqthue="";     
        $.ajax({
                type: "POST", 
                async: false,              
                url: "/TraCuuVB/WsUser.asmx/GetCqThue",                              
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {                                        
                         cqthue=data.d;             
                }// end success                                       
        });// ajax        
        return cqthue;                   
}  
   
    // Nhớ trừ đi 1
    function  Quyen_DangKiMoiTB() {             var quyen = GetUserRight(); return quyen[0];}//--1
    function  Quyen_DMDonViCungCap(){           var quyen = GetUserRight(); return quyen[1];}//--2    
    function  Quyen_New_TTBHSC(){               var quyen = GetUserRight(); return quyen[2];}
    function  Quyen_DMHopDong(){                var quyen = GetUserRight(); return quyen[3];}
    function  Quyen_DMModel(){                  var quyen = GetUserRight(); return quyen[4];}
    function  Quyen_DMThietBi(){                var quyen = GetUserRight(); return quyen[5];}
    function  Quyen_DMPhongDoi(){               var quyen = GetUserRight(); return quyen[6];}
    function  Quyen_DMNguoiSuDung(){            var quyen = GetUserRight(); return quyen[7];}
    function  Quyen_TraCuuThietBi(){            var quyen = GetUserRight(); return quyen[8];}
    function  Quyen_BaoHanhSuaChua(){           var quyen = GetUserRight(); return quyen[9];}
    function  Quyen_ThanhLy(){                  var quyen = GetUserRight(); return quyen[10];}
    function  Quyen_DiChuyen1ThietBi(){         var quyen = GetUserRight(); return quyen[11];}
    function  Quyen_ThayDoiThongTinTB(){        var quyen = GetUserRight(); return quyen[12];}
    function  Quyen_ThayDoiTepThanhLy(){        var quyen = GetUserRight(); return quyen[13];}
    function  Quyen_PhucHoiThietBiDaThanhLy(){  var quyen = GetUserRight(); return quyen[14];}
    function  Quyen_DangKimoiTepThanhLy(){      var quyen = GetUserRight(); return quyen[15];}
    function  Quyen_DiChuyenNhieuThietBi(){     var quyen = GetUserRight(); return quyen[16];}
    function  Quyen_InBaoCao(){                 var quyen = GetUserRight(); return quyen[17];}
    function  Quyen_ThayDoiModel_HopDong_TB(){  var quyen = GetUserRight(); return quyen[18];}
    function  Quyen_ThanhLyNhieuThietBi(){      var quyen = GetUserRight(); return quyen[19];}
    function  Quyen_CapNhatTenMayVaDiChiIP(){   var quyen = GetUserRight(); return quyen[20];}
    function  Quyen_ResetPass(){                var quyen = GetUserRight(); return quyen[21];}
    function  Quyen_ThemMoiNguoiSuDung(){       var quyen = GetUserRight(); return quyen[22];}
    function  Quyen_ThemMoiModel(){             var quyen = GetUserRight(); return quyen[23];}
    function  Quyen_SuaThongTin_TTBH(){         var quyen = GetUserRight(); return quyen[24];}





    


