<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusTranster.aspx.cs" Inherits="BusTranster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3" ><</script>
    <script type="text/javascript" src="Scripts/util.ajax.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    
    <div>
    <asp:Panel ID="panelOne" runat="server">
    
    </asp:Panel>
    
    
    </div>
    <div id="container" style=" width:500px; height:500px">
    </div>
        <div id="log"></div>
    <input  runat="server" type="hidden" id="busTranster"/>
    </form>
</body>
</html>
