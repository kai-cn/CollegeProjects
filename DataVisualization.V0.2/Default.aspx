<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Google Maps</title>
  <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true_or_false&amp;key=ABQIAAAAWt4CmeXpKjnXFd_aasNX2xQn_3OAdtLBebz4OH8vVOOKPJ-TmhRdbg33kZDNYrXp1gKxQuE3TlcX_A" type="text/javascript"></script>
      <script  type="text/javascript"  src="MainJs.js" defer="defer">
    </script>
    <script type="text/javascript" src="DefCountryMapInfo.js"></script>
</head>
<body  onload="load()" onunload="GUnload()">
<script src="http://maps.google.com/maps/api/js?sensor=false&callback=initialize" type="text/javascript" language=javascript></script>
    <form id="form1" runat="server">
<div id="map" style="width:800px; height:600px">
    </div>

<asp:HiddenField ID="TextPoint"  runat="server" Value="" />
<asp:HiddenField ID="TextIP" runat="server" Value="" />
<asp:DropDownList ID="SetMarkers" runat="server" ontextchanged="Page_Load" 
        onselectedindexchanged="SetMarkers_SelectedIndexChanged">
<asp:ListItem Text="InternalBT"></asp:ListItem>
<asp:ListItem Value="ForeignBT"></asp:ListItem>
<asp:ListItem Text="eMule"></asp:ListItem>
</asp:DropDownList>
<input type="button" value="加载KML" onclick="loadXML('doc.kml')" />
<input type="button" value="SetMarkers" onclick="SetMarkersFunc()" />
<input type="button" value="RemoveMarkers" onclick="RemoveMarkersFunc()" />

    </form>

</body>
</html>