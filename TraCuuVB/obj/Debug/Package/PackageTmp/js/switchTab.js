function SwitchTab(index)
{
    // switch all tabs off
	$(".active").removeClass("active");			
	// switch this tab on
	$("#content_"+index).addClass("active");			
	// slide all content up
	$(".content").hide();//slideUp();			
	// slide this content up		
	$("#content_"+index).show();//slideDown();
	$("a#tab"+index).addClass("active");

}


function Processing_Tab_Event()
{
 // When a link is clicked
	$("a.tab").click(function () {
	
	if( $('span#ctl00_ContentPlaceHolder1_lbMaTB').text()!='' )		
	{
		// switch all tabs off
		$(".active").removeClass("active");			
		// switch this tab on
		$(this).addClass("active");			
		// slide all content up
		$(".content").hide();//slideUp();			
		// slide this content up
		var content_show = $(this).attr("title");
		$("#"+content_show).show();//slideDown();		
    } // end if
    
    else
    {
        
//        $('span#infoGuide').slideDown("slow", function () {
//            $('span#infoGuide').addClass("hidden");
//        });
        
        $('span#infoGuide').slideDown('slow').delay('2000').slideUp('slow');
    }
	  
	});

}

function Processing_Tab_Event_4_Normal()
{
 // When a link is clicked
	$("a.tab").click(function () {	
		// switch all tabs off
		$(".active").removeClass("active");			
		// switch this tab on
		$(this).addClass("active");			
		// slide all content up
		$(".content").hide();//slideUp();			
		// slide this content up
		var content_show = $(this).attr("title");
		$("#"+content_show).show();//slideDown();   
    
	  
	});

}
