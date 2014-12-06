<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p2p_dataAnalysis.aspx.cs" Inherits="p2p_dataAnalysis" %>

<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
<link href="style/dataAnalysis.css" rel="stylesheet" type="text/css" />
<!--<link href="style/mSelect.css" rel="stylesheet" type="text/css"/>-->
<!--<link href="style/alixixi.css" rel="stylesheet" type="text/css" />-->

<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
<script type="text/javascript" src="js/Highcharts/highcharts.js"></script>
<script type="text/javascript" src="js/Highcharts/modules/exporting.js"></script>

<script type="text/javascript" src="js/chart/page.js"></script>
<script type="text/javascript" src="js/resize.js"></script>

<script type="text/javascript" src="js/folder.js"></script>
<script type="text/javascript" src="js/ui.core.js"></script>
<script type="text/javascript" src="js/ui.tabs.js"></script>

<!--<script type="text/javascript" src="js/mSelect.js"></script>-->
<!--<script type="text/javascript" src="js/xixi.js"></script>-->

<script type="text/javascript" src="js/gmap.main.js"></script>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&language=zh-CN"></script>

<script type="text/javascript">
    function ShowGoogleMap() {
        document.getElementById("chart").style.display = "none";
        document.getElementById("map").style.display = "block";
        initialize();
    }

    function ShowChart() {
        document.getElementById("map").style.display = "none";
        document.getElementById("chart").style.display = "block";

    }
</script>

<link href="style/ui.tabs.css" rel="stylesheet" type="text/css" />
<link href="style/folder.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<div id="top">
    	<img src="images/titleTxt.png" alt="全球P2P网络主动探测及分析系统" />
    	<div id="bottomShadow"></div>
    </div>
    <div id="left">

    	<div id="time">
        <form id="form1" runat="server"> 
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager> 
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="True">
            <ContentTemplate>                
                            <div class="ddl">
                            <span>年份</span>
                                <asp:DropDownList ID="DropDownList1" runat="server" 
                                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="ddl">
                            <span>月份</span>
                                <asp:DropDownList ID="DropDownList2" runat="server" 
                                    onselectedindexchanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                    <!--<div class="ddl">
                    <span>周</span>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                    </div>-->

            </ContentTemplate>
        </asp:UpdatePanel>
        </form>
        </div>
        
        <div id="rotate">
            <ul>
                <li><a href="#fragment-1" onclick="ShowChart()"><span>Charts</span></a></li>
                <li><a href="#fragment-2" onclick="ShowGoogleMap()"><span>Map</span></a></li>
                
            </ul>
            <div id="fragment-1">
                <div class="suckerdiv">
                    <ul id="suckertree1">
                    
                    <li><a href="#">国家分布</a>
                      <ul>
                      <li><a href="#" id="countryRankBt">BT</a></li>
                      <li><a href="#" id="countryRankEm">Emule</a></li>
                      </ul>
                    </li>
                    <li><a href="#">端口分布</a>
                      <ul>
                      <li><a href="#" id="portRankBt">BT</a></li>
                      <li><a href="#" id="portRankEm">Emule</a></li>
                      </ul>
                    </li>
                    <li><a href="#">黑名单统计</a>
                      <ul>
                      <li><a href="#" id="blRankBt">BT</a></li>
                      <li><a href="#" id="blRankEm">Emule</a></li>
                      </ul>
                    </li>
                    <li><a href="#">服务器统计</a>
                      <ul>
                      <li><a href="#" id="serverRankBt">BT</a></li>
                      <li><a href="#" id="serverRankEm">Emule</a></li>
                      </ul>
                    </li>
                    <!--
                    <li><a href="#">Folder 2</a>
                      <ul>
                          <li><a href="#">Sub Item 2.1</a></li>
                          <li><a href="#">Folder 2.1</a>
                            <ul>
                            <li><a href="#">Sub Item 2.1.1</a></li>
                            <li><a href="#">Sub Item 2.1.2</a></li>
                            <li><a href="#">Sub Item 2.1.3</a></li>
                            <li><a href="#">Sub Item 2.1.4</a></li>
                            </ul>
                          </li>
                       </ul>
                    </li>
                    <li><a href="#">Item 4</a></li>-->

                    </ul>
				</div>
            </div>
            <div id="fragment-2">
                <div class="suckerdiv">
                    <ul id="Ul1">
                    
                    <li><a href="#">国家分布</a>
                      <ul>
                      <li><a href="#" id="A1">BT</a></li>
                      <li><a href="#" id="A2">Emule</a></li>
                      </ul>
                    </li>
                    <li><a href="#">端口分布</a>
                      <ul>
                      <li><a href="#" id="A3">BT</a></li>
                      <li><a href="#" id="A4">Emule</a></li>
                      </ul>
                    </li>
                    
                    </ul>
				</div>
            </div>
            
    </div>
        
        
        <!--
        <div id="item">
                	<ul class="container">
      <li class="menu">
          <ul>
		    <li class="button"><a href="#" class="blue">国家分布<span></span></a></li>

            <li class="dropdown">
                <ul>
                    <li><a href="#" id="countryRankBt">BT</a></li>
                    <li><a href="#" id="countryRankEm">Emule</a></li>
                </ul>
			</li>
          </ul>
      </li>
      
      <li class="menu">
          <ul>
		    <li class="button"><a href="#" class="blue">端口分布<span></span></a></li>          	

            <li class="dropdown">
                <ul>
                    <li><a href="#" id="portRankBt">BT</a></li>
                    <li><a href="#" id="portRankEm">Emule</a></li>
                </ul>
			</li>
          </ul>
      </li>
 
      <li class="menu">
          <ul>
		    <li class="button"><a href="#" class="blue">text<span></span></a></li>

            <li class="dropdown">
                <ul>
                    <li><a href="#">Wiki page</a></li>
                    <li>Text label 1</li>
                    <li>Text label 2</li>
                    <li><a href="#">Flickr Stream</a></li>
                </ul>
			</li>
          </ul>
      </li>

    
      <li class="menu">
          <ul>
		    <li class="button"><a href="#" class="blue">text<span></span></a></li>

            <li class="dropdown">
                <ul>
                    <li><a href="#">crop circles</a></li>
                    <li><a href="#">Iphone wallpaper</a></li>
                    <li><a href="#">Lanrentuku</a></li>
                    <li><a href="#">myq</a></li>
                </ul>
			</li>
          </ul>
      </li>
  </ul>
        </div>
        -->

        <div id="rightShadow"></div>

    </div>
    <div id="right">
        <div id="chart">
        	<div class="chartContainer" id="chart1"></div>
            <div class="chartContainer" id="chart2"></div>
            <div class="chartContainer" id="chart3"></div>
            <div class="chartContainer" id="chart4"></div>
        </div>
        <div id="map"></div>
    </div>
</body>
</html>
