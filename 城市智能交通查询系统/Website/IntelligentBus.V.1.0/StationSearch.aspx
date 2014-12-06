<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StationSearch.aspx.cs" Inherits="StationSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link href="Styles/styles.css" rel="Stylesheet" type="text/css"/>
    <title>站点查询</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_div">
    <div><h1>站点查询</h1></div>
    <div><asp:TextBox ID="txtStation"  runat="server" Text=""/><asp:Button ID="btnSearch" runat="server" Text="查询" /></div>
    <div style="margin-top:50px">
    <div style=" height:400px;"></div>
    
    </div>
    </div>
    </form>
</body>
</html>
