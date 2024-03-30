$(window).load(function(){
	$("#loadingPage").delay(1e3).fadeOut(600),
	$("#pageHeadTitle1").delay(1e3).animate({color:"#ffd700"})}),

$(document).ready(function()
	{ldpageWidth=$("#pageHead").width(),ldpageHeight=$("#pageHead").height(),ldpageLoadingPos=ldpageHeight/2+60,
	$("#loadingPage").css({width:ldpageWidth+"px",height:ldpageHeight+"px"}),
	$("#loadingPagebox").css({"margin-top":ldpageLoadingPos+"px"}),$("#pageHeadTitle1").css({color:"#fff"})});