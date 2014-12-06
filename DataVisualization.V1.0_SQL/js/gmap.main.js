// JScript source code
var map;
var ip;
var lat;
var lng;


//��ͼ��ʼ��   
function initialize() {
    var mapOptions = {
        zoom: 9,                //���ż���     
        center: new google.maps.LatLng(31.838463501293745, 117.17588437182617),       //����ͼ����������Ϊָ���ĵ���� ����ʹ�� 0��������ż����ڵ�ͼ�Ͽ��Կ����������磩�� 19��������ż��𣬿��Կ������������֮������ż���   
        mapTypeId: google.maps.MapTypeId.ROADMAP,   //ROADMAP-Ĭ����ͼ SATELLITE-��ʾGoogle��������ͼ�� HYBRID-�����ʾ��ͨ��ͼ��������ͼ TERRAIN-����ͼ    
        scaleControl: true,    //������   
        mapTypeControl: true,
        mapTypeControlOptions: { style: google.maps.MapTypeControlStyle.DROPDOWN_MENU }
    };
    map = new google.maps.Map(document.getElementById("map"), mapOptions); //��д JavaScript ����������map������   
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