

var DefCountryMapInfo;

﻿var map;



function loadXML(url) {
    alert(url);
    var gx = new GGeoXml("2.kml");
    map.addOverlay(gx);

    //        var xmlDoc = document.implementation.createDocument("", "", null);
    //        xmlDoc.async = "false";
    //        xmlDoc.load("KML_BT_Foreign.xml");
    //        alert("加载完成");

    //加载XML
    var xmlhttp = new window.XMLHttpRequest();
    xmlhttp.open("GET", "KML_BT_Foreign.xml", false);
    xmlhttp.send(null);
    var xmlDoc = xmlhttp.responseXML.documentElement;
    alert("加载完成");

    //读取节点的值
    //   var xmlPlacemark = xmlDoc.documentElement.selectSingleNode("kml/Document/Placemark");
    // alert(xmlPlacemark.nodeValue);
    var xmlPlacemark = xmlDoc.documentElement.childNodes;
    alert(xmlPlacemark.nodeValue);
    //alert(xmlPlacemark[0].firstChild.nodeValue);
    alert("读取完成");


}

function load() {
    if (GBrowserIsCompatible()) {
        map = new GMap2(document.getElementById("map"));
        map.setCenter(new GLatLng(31.1993, 120.3775), 1)
        map.addControl(new GLargeMapControl());
        map.addControl(new GSmallZoomControl());
        map.addControl(new GScaleControl());
        map.addControl(new GMapTypeControl());
        map.enableScrollWheelZoom();
        var keyboard = new GKeyboardHandler(map);
        DefCountryMapInfo=new DefCountryMapInfo();
    }
}


function SetMarkersFunc() {
        DefCountryMapInfo.SetMarkers();
}


function RemoveMarkersFunc(){
    DefCountryMapInfo.RemoveMarkers();
}

