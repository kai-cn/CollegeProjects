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

var titleTxt;
var yName="number";

function showChart(dataType,chartType,renderID,dataPart,topAmount){
	var request = new XMLHttpRequest();
    request.open("Post", "p2p_dataAnalysis.aspx",true);
    request.onreadystatechange = function(){
    	if (request.readyState == 4 && request.status == 200) {
        	var response = request.responseText;
        	eval("dv =" + response + ";");
        	if(dv==null){
        		var id='#'+renderID;
        		var text=titleTxt+"暂无此月数据";
        		$(id).html(text);
        	}
        	else{
        		if(dataPart=='top'){
        			var dp=dv.top;
        		}
        		else if(dataPart=='all'){
        			var dp=dv.all;
        		}
        		switch(chartType)
        		{
        			case 'pie': pie(renderID,dp); break;
        			case 'line': line(renderID,dp); break;
        			case 'column': column(renderID,dp); break;
        		}
        	}
    	}
    };
    request.setRequestHeader("dataType",dataType);
    request.setRequestHeader("topAmount",topAmount);
    request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    request.send();
}

function pie(renderID,dp) {
    var chart;
        chart = new Highcharts.Chart({
            chart: {
                renderTo: renderID,
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                //shadow: true,
                height: $(window).height()-120-16
            },
            title: {
                text: titleTxt //title
            },
            tooltip: {
                formatter: function () {
                    return '<b>' + this.point.name + '</b>: ' +Highcharts.numberFormat(this.percentage, 2)+ ' %'+' | '+this.point.y;
                }
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true
                    },
                    showInLegend: true
                }
            },
            series: [{
                type: 'pie',
                name: 'country',
                data: dp.dataWithName
                
                /*
                [
                    ['Firefox', 45.0],
                    ['IE', 26.8],
                    {
                        name: 'Chrome',
                        y: 12.8,
                        sliced: true,
                        selected: true
                    },
                    ['Safari', 8.5],
                    ['Opera', 6.2],
                    ['Others', 0.7]
                ]
                */
            }]
        });

}

function line(renderID,dp) {
    var chart;
        chart = new Highcharts.Chart({
            
            chart: {
                renderTo: renderID,
                zoomType: 'xy',
                //shadow: true,
                height: $(window).height()-120-16,
            },
            
            title: {
                text: titleTxt //title
            },
            
            xAxis: {
            	categories: dp.categorie
                //categories: ['Jan', 'Feb', 'Mar', 'Apr']
            },
            
            yAxis: {
                type: 'logarithmic',
                title: {
                	text: yName //yName
            	}
            },
            
            tooltip: {
                headerFormat: '<b>{series.name}</b><br />',
                pointFormat: 'x = {point.x}, y = {point.y}'
            },
            
            series: [{            
                data: dp.dataNoName
                //data: [23,56,78,90],
            }]
        });
    
}

function column(renderID,dp) {
    var chart;
    chart = new Highcharts.Chart({
        chart: {
            renderTo: renderID,
            zoomType: 'x',
            type: 'column',
            //shadow: true,
            height: $(window).height()-120-16,
        },
        title: {
            text: titleTxt //title
        },
        xAxis: {
            categories: dp.categorie,
            labels: {
                rotation: -90,
                align: 'right',
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: yName //yName
            },
			stackLabels: {
                enabled: true,
                formatter: function () {
                return Highcharts.numberFormat(this.total, 0);
            }
            }
        },
        plotOptions: {
            column:{
                stacking: 'normal',
                pointPadding: 0,
                groupPadding: 0.1,
                dataLabels: {
                    enabled: false
                }
            }
        },
        legend: {
            enabled: false
        },
        tooltip: {
            formatter: function () {
                return '<b>' + this.x + '<br/>' + Highcharts.numberFormat(this.y, 1);
            }
        },
        series: [{
            name: '',
            data: dp.dataNoName,
            dataLabels: {
                enabled: false,
                rotation: -90,
                color: '#FFFFFF',
                align: 'right',
                x: -5,
                formatter: function () {
                    return this.x;
                },
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        }]
    });
}

function clearChart(){
	$("#chart1").html("");
	$("#chart2").html("");
	$("#chart3").html("");
	$("#chart4").html("");
}

$(document).ready(function () {
    //var json={"top":{"dnn":[1,2,3],"dwn":[['n1',1],['n2',2],['n3',3]],"categorie":['n1','n2','n3']},"all":{"dnn":[1,2,4],"dwn":[['n1',1],['n2',2],['n4',4]],"categorie":['n1','n2','n4']}};
    //alert(json.all.categorie);
    
    $("#countryRankBt").click(function() {
    	clearChart();
    	
    	titleTxt="BT节点国家分布（国内）";//设置标题
    	showChart('countryRankInBt','pie','chart1','top',10);

        setTimeout(function(){
    		titleTxt="BT节点国家分布（国外）";//设置标题；注意需要延时！
    		showChart('countryRankFoBt','pie','chart2','top',10);
    		} ,1000);

        setTimeout(function(){
    		titleTxt="BT节点国家分布（国内）";
    		showChart('countryRankInBt','column','chart3','top',10);
    		} ,2000);
    	
        setTimeout(function(){
            titleTxt="BT节点国家分布（国外）";
            showChart('countryRankFoBt','column','chart4','top',10);
            } ,3000);
	});
	
	$("#countryRankEm").click(function() {
        clearChart();
    	
    	titleTxt="电驴节点国家分布（国内）";
    	showChart('countryRankInEm','pie','chart1','top',10);

        setTimeout(function(){
    		titleTxt="电驴节点国家分布（国外）";
    		showChart('countryRankFoEm','pie','chart2','top',10);
    		} ,1000);

        setTimeout(function(){
    		titleTxt="电驴节点国家分布（国内）";
    		showChart('countryRankInEm','column','chart3','top',10);
    		} ,2000);
    	
        setTimeout(function(){
            titleTxt="电驴节点国家分布（国外）";
            showChart('countryRankFoEm','column','chart4','top',10);
            } ,3000);
	});
	
	$("#portRankBt").click(function() {
		clearChart();
		titleTxt="BT节点端口分布（国内）";
		showChart('portRankInBt','pie','chart1','top',10);
    	
    	setTimeout(function(){
    		titleTxt="BT节点端口分布（国外）";
    		showChart('portRankFoBt','pie','chart2','top',10);
    		} ,2000);
	});
	
    $("#portRankEm").click(function() {
		clearChart();
		titleTxt="电驴节点端口分布（国内）";
		showChart('portRankInEm','pie','chart1','top',10);
    	
    	setTimeout(function(){
    		titleTxt="电驴节点端口分布（国外）";
    		showChart('portRankFoEm','pie','chart2','top',10);
    		} ,2000);
	});
	
	$("#blRankBt").click(function() {
		clearChart();
		titleTxt="BT节点黑名单统计（国内）";
		showChart('blRankInBt','column','chart1','all',0);
		
		setTimeout(function(){
    		titleTxt="BT节点黑名单统计（国外）";
    		showChart('blRankFoBt','column','chart2','all',0);
    		} ,2000);
	});
	
	$("#blRankEm").click(function() {
		clearChart();
		titleTxt="电驴节点黑名单统计（国内）";
		showChart('blRankInEm','column','chart1','all',0);
		
		setTimeout(function(){
    		titleTxt="电驴节点黑名单统计（国外）";
    		showChart('blRankFoEm','column','chart2','all',0);
    		} ,2000);
	});
	
	$("#serverRankBt").click(function() {
		clearChart();
		titleTxt="BT服务器统计（国内）";
		showChart('serverRankInBt','column','chart1','top',10);
		
		setTimeout(function(){
    		titleTxt="BT服务器统计（国外）";
    		showChart('serverRankFoBt','column','chart2','top',10);
    		} ,2000);
	});
	
	$("#serverRankEm").click(function() {
		clearChart();
		titleTxt="电驴服务器统计（国内）";
		showChart('serverRankInEm','column','chart1','top',10);
		
		setTimeout(function(){
    		titleTxt="电驴服务器统计（国外）";
    		showChart('serverRankFoEm','column','chart2','top',10);
    		} ,2000);
	});
	
});