<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LineSearchDetail.aspx.cs" Inherits="LineSearchDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Styles/styles.css" rel="Stylesheet" type="text/css"/>

<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3" ><</script>
<script type="text/javascript" src="Scripts/util.ajax.js"></script>

    <title>线路详情</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_div">
    <div><h1>线路详情</h1></div>
    <div style="margin-top:50px">
    <div id="container" style="height:400px;">
    </div>
    <asp:Panel ID="busLinePanel" runat="server">
    <asp:TextBox  ID="txtBusStation" Width="400px" Height="100px" TextMode="MultiLine" runat="server"></asp:TextBox>
    </asp:Panel>

     <div id="log"></div>
    <input  id="busStation" type="hidden" runat="server"/>
    </div>
    </div>
    </form>
</body>
</html>
