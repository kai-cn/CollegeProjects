<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bus.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript">
    function getLocation()
    {document.getElementById("txtBegin").value = "当前位置"; }
</script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
    <div >
    <a href="index.html"><span>返回</span></a>
    <asp:Label Text="苏州" ID="area" runat="server"></asp:Label>
    <asp:HyperLink Text="切换城市" ID="exCity" runat="server" NavigateUrl="~/SelectArea.aspx"></asp:HyperLink>
    </div>

    <div style="margin-top:50px" >
        <div><asp:TextBox ID="txtBegin"  runat="server" Text=""/><input  type="button"  value="当前位置" onclick="getLocation()"/></div>
        <div><asp:TextBox ID="txtEnd" runat="server"></asp:TextBox><input  type="button" value="当前位置" onclick="getLocation()"/></div>
        <div style="margin-top:20px"><asp:Button ID="btnSearch" runat="server" onclick="BtnSearch_Click" Text="公交车换乘查询" /></div>
  </div>
  <div>
  <a href="Bus.aspx">换乘</a>
  <a href="LineSearch.aspx">线路</a>
  <a href="StationSearch.aspx">站点</a>
  </div>
  
    </div>
    </form>
</body>
</html>


