// JScript source code
var map;
var ip;
var lat;
var lng;


//地图初始化   
function initialize() {
    var mapOptions = {
        zoom: 9,                //缩放级别     
        center: new google.maps.LatLng(31.838463501293745, 117.17588437182617),       //将地图的中心设置为指定的地理点 可以使用 0（最低缩放级别，在地图上可以看到整个世界）到 19（最高缩放级别，可以看到独立建筑物）之间的缩放级别   
        mapTypeId: google.maps.MapTypeId.ROADMAP,   //ROADMAP-默认视图 SATELLITE-显示Google地球卫星图像 HYBRID-混合显示普通视图和卫星视图 TERRAIN-地形图    
        scaleControl: true,    //比例尺   
        mapTypeControl: true,
        mapTypeControlOptions: { style: google.maps.MapTypeControlStyle.DROPDOWN_MENU }
    };
    map = new google.maps.Map(document.getElementById("map"), mapOptions); //编写 JavaScript 函数创建“map”对象   
}


function ipGlobalAnalysis() {
    var li = document.getElementById("item");
    li.style.display = "none";
    var ipGA = document.getElementById("ipGA");
    ipGA.style.display = "block";
}


if (!window.XMLHttpRequest) {
    window.XMLHttpRequest = function window$XMLHttpRequest() {
        var progIDs = ['Msxml2.XMLHTTP', 'Microsoft.XMLHTTP'];
        for (var i = 0; i < progIDs.length; i++) {
            try {
                var xmlHttp = new ActiveXObject(progIDs[i]);
                return xmlHttp;
            }
            catch (ex) { }
        }
        return null;
    }
}


function showPeer(type) {
    request = new XMLHttpRequest();
    request.open("Post", "p2p_peerAndSysAnalysis.aspx");
    request.onreadystatechange = readyStateChangeCallback;
    request.setRequestHeader(type, "true");
    request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    request.send("");
}

function readyStateChangeCallback() {
    if (request.readyState == 4 && request.status == 200) {

        var response = request.responseText;
        if (response != null) {

            eval("var doc =" + response + ";");
            for(var i=0;i<doc.length;i++)
            {
                ip = doc[i].ip;
                lat = doc[i].lat;
                lng = doc[i].lng;
                //alert(lat);
                //alert(lng);
                var point = new google.maps.LatLng(lat, lng);
                //var gsize = new google.maps.Size(10, 10);
                var gimage = new google.maps.MarkerImage("http://www.google.com/mapfiles/marker.png");
                var gmarker = new google.maps.Marker({
                    position: point,
                    title: ip
                });
                gmarker.setIcon(gimage);
                gmarker.setMap(map);
            }
        }
    }
}