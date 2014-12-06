// JavaScript Document

$(document).ready(function () {
	target();
});

$(window).resize(function() {
	target();	
});

function target()
{
	var y = $(window).height();
	var x = $(window).width();
	
	$("#right").height(y-120-16);
	$("#right").width(x-240-17);
	$(".chartContainer").width((x-240-35)/2);//16+17+2=35
	$("#map").height(y-120-16);
}
/*
function getWindowSize() {
    var client = {
        x:0,
        y:0
    };
 
    if(typeof document.compatMode != 'undefined' && document.compatMode == 'CSS1Compat') {
        client.x = document.documentElement.clientWidth;
        client.y = document.documentElement.clientHeight;
    } else if(typeof document.body != 'undefined' && (document.body.scrollLeft || document.body.scrollTop)) {
        client.x = document.body.clientWidth;
        client.y = document.body.clientHeight;
    }
 
    return client;
}
*/