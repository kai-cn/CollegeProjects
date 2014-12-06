// JavaScript Document
function DefCountryMapInfo(){
    this.Markers=new Array();
    
    this.SetMarkers=function(){
        var strIPs=document.getElementById("TextIP");
        var strPoints =document.getElementById("TextPoint");
        
        strIPs=strIPs.value.split(",");
        strPoints=strPoints.value;
        
        var starts = 0;
        var ends = 0;
        var i=0;
        
        while (starts != strPoints.length) {
            ends = strPoints.indexOf(";",ends);
            var point = strPoints.substring(starts, ends);
            var lat = point.split(',', 2)[0];
            var lng = point.split(',', 2)[1];
            point=new GLatLng(lat, lng);

            ends=ends+1;
            starts = ends ;
            
            this.CreateMarker(point,strIPs[i++]);
        }
    }
    
    this.RemoveMarkers=function(){

            map.clearOverlays();
    }
    

    
    this.CreateMarker=function(point,IP){
        var myIcon = new GIcon(G_DEFAULT_ICON,"http://www.google.com/mapfiles/marker.png");
        var marker = new GMarker(point,{icon:myIcon, draggable:true , bouncy:true});
        
  	/*	GEvent.addListener(marker,'dragstart',function()
		{
			marker.setImage("http://www.google.com/mapfiles/dd-start.png");
		});
		
		//dragend事件，换回原图标
		GEvent.addListener(marker,'dragend',function()
		{
			marker.setImage("http://www.google.com/mapfiles/marker.png");
			
		});*/
		
				//单击显示行程安排
		GEvent.addListener(marker,'click',function()
		{
			marker.openInfoWindowHtml(IP);
			//alert(marker.getLatLng());
		});
		
		map.addOverlay(marker);
		
        this.Markers.push(marker);
    }
    
}
