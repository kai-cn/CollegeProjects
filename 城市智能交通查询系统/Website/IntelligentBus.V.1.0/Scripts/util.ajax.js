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

var map;
var dv;

window.onload = function () {

    //if (document.getElementById("busTranster").value != "") {
    map = new BMap.Map("container"); // 创建地图实例 创建地图实例
   var point = new BMap.Point(120.58, 31.30); // 创建点坐标
   // var point = new BMap.Point(116.404, 39.915);
    map.centerAndZoom(point, 15); // 初始化地图，设置中心点坐标和级别 初
    // eval("dv =" + document.getElementById("busTranster").value + ";");

    initMap();
    setMarker();
    //    alert("hello;");
    //}
}




function initMap() {
    if (map != null) {
        map.enableScrollWheelZoom();
        map.addControl(new BMap.NavigationControl());
        map.addControl(new BMap.ScaleControl());
        map.addControl(new BMap.OverviewMapControl());
        map.addControl(new BMap.MapTypeControl());
        //initTrafficLayer();
        initTraffic();
        //var myButtonCtrl = new ButtonControl();
        //map.addControl(myButtonCtrl);
    }
}

function initTrafficLayer() {
    var traffic = new BMap.TrafficLayer("北京市");
    map.addTileLayer(traffic);
}

function initTraffic() {
    var transit = new BMap.TransitRoute("苏州市");
    transit.setSearchCompleteCallback(function (results) {
        if (transit.getStatus() == BMAP_STATUS_SUCCESS) {
            var firstPlan = results.getPlan(0);

            //绘制步行线路
            for (var i = 0; i < firstPlan.getNumRoutes(); i++) {
                var walk = firstPlan.getRoute(i);
                if (walk.getDistance(false) > 0) {
                    map.addOverlay(new BMap.Polyline(walk.getPoints(), { lineColor: "green" }));
                }
            }
            //绘制公交线路
            for (i = 0; i < firstPlan.getNumLines(); i++) {
                var line = firstPlan.getLine(i);
                map.addOverlay(new BMap.Polyline(line.getPath()));
            }

            //输出方案信息
            var s = [];
            for (i = 0; i < results.getNumPlans(); i++) {
                s.push((i+1)+"."+results.getPlan(i).getDescription());
                }
            document.getElementById("log").innerHTML=s.join("");
             
        }
    });

    var station = document.getElementById("busStation").value.split(";");
    var beginStation = station[0];
    var endStation = station[1];

    //transit.search(beginStation,endStation);
    transit.search("相门", "夏园新村");
    //var local=new BMap.LocalSearch(map,{
    //    renderOptions:{map:map}
    //});
    //local.search("天安门");
    //
    //map.addTi
}

function setMarker() {
    var point = new BMap.Point(116.404, 39.915);
    var marker = new BMap.Marker(point); 
    map.addOverlay(marker);
}

function ButtonControl() {
    this.defaultAnchor = BMAP_ANCHOR_TOP_LEFT;
    this.defaultOffset = new BMap.Size(10, 10);
}

ButtonControl.prototype = new BMap.Control();

ButtonControl.prototype.initialize = function (map) {
    //创建一个DOM元素
    var div = document.createElement("input");

    div.setAttribute("type", "text");
    //添加文字说明
    div.appendChild(document.createTextNode("放大2级"));

    //设置样式
    div.style.cursor = "pointer";
    div.style.border = "1px solid gray";
    div.style.backgroundColor = "white";

    //绑定事件,点击一次放大两级

    div.onclick = function (e) {
        map.zoomTo(map.getZoom() + 2);
    }
    //添加DOM元素到地图中
    map.getContainer().appendChild(div);

    //将DOM元素返回
    return div;

}