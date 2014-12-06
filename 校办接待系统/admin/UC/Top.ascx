<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top.ascx.cs" Inherits="admin_UC_Top" %>

<%--<script language=JavaScript>
    function logout() {
        if (confirm("您确定要退出后台管理吗？"))
            top.location = "Login.aspx";
        return false;
    }
</script>
<script language=JavaScript1.2>
function showsubmenu(sid) {
	var whichEl = eval("submenu" + sid);
	var menuTitle = eval("menuTitle" + sid);
	if (whichEl.style.display == "none"){
		eval("submenu" + sid + ".style.display=\"\";");
	}else{
		eval("submenu" + sid + ".style.display=\"none\";");
	}
}
</script>
<script language=JavaScript1.2>
function showsubmenu(sid) {
	var whichEl = eval("submenu" + sid);
	var menuTitle = eval("menuTitle" + sid);
	if (whichEl.style.display == "none"){
		eval("submenu" + sid + ".style.display=\"\";");
	}else{
		eval("submenu" + sid + ".style.display=\"none\";");
	}
}
</script>--%>

<%--<table width="100%" height="64" border="0" cellpadding="0" cellspacing="0" class="admin_topbg">
  <tr>
    <td style=width="61%" height="64"><img src="../../images/logo.gif" width="262" height="64"></td>
    <td width="39%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td style="width="74%" height="38"" class="admin_txt">管理员：<b><%=Session["user"] %></b> 您好,感谢登陆使用！</td>
        <td width="22%"><a href="#" target="_self" onClick="logout();"><img src="../../images/out.gif" alt="安全退出" width="46" height="20" border="0"></a></td>
        <td width="4%">&nbsp;</td>
      </tr>
      <tr>
        <td height="19" colspan="3">&nbsp;</td>
        </tr>
    </table></td>
  </tr>
</table>--%>

    <table>
       <tr>
    <td height="42" valign="top" ><table width="100%" height="89" border="0" cellpadding="0" cellspacing="0" style="background-image: url(/images/1_1.jpg); background-repeat:repeat-x;">
      <tr>
        <td width="1%" colspan=3 height="42"><table width="100%"><tr><td width="15%"></td><td><img src="/images/2_1.jpg" /></td></tr></table></td>
        
      </tr>
    </table></td>
  </tr>
    </table>