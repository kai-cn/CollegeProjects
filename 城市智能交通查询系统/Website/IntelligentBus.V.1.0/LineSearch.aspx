<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LineSearch.aspx.cs" Inherits="LineSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="Styles/styles.css" rel="Stylesheet" type="text/css"/>
    <title>线路查询</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_div">
    <div><h1>线路查询</h1></div>
    <div><asp:TextBox ID="txtLine"  runat="server" Text=""/><asp:Button ID="btnSearch" 
            runat="server" Text="查询" onclick="btnSearch_Click" /></div>
    <div style="margin-top:50px">
    <div style=" height:400px;">
    <asp:Panel ID="busLinePanel" runat="server">
    
    </asp:Panel>
    </div>
    
    </div>
    </div>
    </form>
</body>
</html>
