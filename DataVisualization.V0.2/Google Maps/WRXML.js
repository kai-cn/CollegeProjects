// JavaScript Document

var map;

function intialize()
{
    if(GBrowserIsCompatible()){
        map=new GMap2(document.getElementById("map"));
    map.setCenter(new GLatLng(43.89391,125.32214),6);	
    map.addControl(new GLargeMapControl());
    map.addControl(new GMapTypeControl());
    map.addControl(new GScaleControl());
    

}


function LoadXml()
{
    var request=GXmlHttp.create();
    
    request.open("GET","KML_BT_Internal.xml",true);
    request.onreadystatechange=function(){
        if(request.readyState==4){
            var xmlDoc=request.responseXML;
            var PerPos=xmlDoc.document.childNodes;
            //取得XML文件中礚NG和LAT的节点值
            
            for(var i=0;i<PerPos.length;i++){
                var lnglat=PerPos[i].getElementsByTagName("coordinates")[0].text;
                var l=lnglat.split(',',2);
                
                var latlngObj=new GLatLng(l[0],l[1]);
                map.addOverlay(new GMarker(latlngObj));
            }
        }
    }
    request.send(null);
}
