<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="admin/UC/Top.ascx" tagname="Top" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="images/skin.css" rel="stylesheet" type="text/css">
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;

}
    .editbox4
    {}
    .style2
    {
        width: 100%;
    }
    .style3
    {
        width: 60px;
        text-align: right;
    }
    .style4
    {
        text-align: left;
    }
    .wenbenkuang
    {
        width: 57px;
    }
-->
</style>


    <title></title>
</head>
<body style="background-color:#7e807f;">
<center>
    <form id="form1" runat="server">
    <div>
      <%--  <uc1:Top ID="Top1" runat="server" />--%>



        <table width="100%" height="166" border="0" cellpadding="0" cellspacing="0" ">
  <tr>
    <td height="42" valign="top" colspan=2><table width="100%" height="89" border="0" cellpadding="0" cellspacing="0" class="login_top_bg">
      <tr>
        <td width="1%" colspan=3 height="42"><table width="100%"><tr><td width="15%"></td><td><img src="images/2_1.jpg" /></td></tr></table></td>
        
      </tr>
    </table></td>
  </tr>
  <tr>
  <td style="width:16%"></td>
    <td valign="top" style="width:60%">
    <table height="450"  border="0" cellpadding="0" cellspacing="0" style="background-color:White;" >
      <tr>
      <td style=" width:25%"></td>
        <td width="50%">
        <table width="100%" height="59" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td height="21"><table cellSpacing="0" cellPadding="0" width="100%" border="0" id="table211" height="328">
                  <tr>
                  <td></td>
                    <td height="164" align="center">
                    <form name="myform" action="login_in.aspx" method="post" id="myform" onsubmit="abc()">
                        <table class="style2">
                            <tr>
                                <td class="style3">
                                    <span class="login_txt"><asp:Label ID="LabelUserName" Text="用户名：" runat="server"></asp:Label>&nbsp;&nbsp; </span></td>
                            <td height="38" class="style4"><asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox> 
                            <div id="div1" style="color:Red; font-size:smaller; display:none">管理员帐号不能为空！</div></td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                  <span class="login_txt">&nbsp; <asp:Label ID="Label1" Text="密  码：" runat="server"></asp:Label> &nbsp;&nbsp; </span></td>
                            <td height="35" class="style4"> <asp:TextBox ID="TextBoxPwd" TextMode="Password" runat="server"></asp:TextBox> 
                            
                              <img src="images/luck.gif" width="19" height="18"> <div id="div2" style="color:Red; font-size:smaller; display:none">密码不能为空！</div></td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                  <span class="login_txt"> <asp:Label ID="Label2" Text="验证码：" runat="server"></asp:Label></span></td>
                            <td height="35" class="style4"><asp:TextBox ID="TextBoxValidateCode" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                            
                             <asp:Image ID="ImageValidateCode" ImageUrl="~/ValidateCode.aspx" runat="server" />
                            <div id="div3" style="color:Red; font-size:smaller; display:none">请输入验证码！</div></td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    &nbsp;</td>
                            <td height="35" class="style4"><asp:Button ID="ButtonSubmit" Text="登 录" runat="server" 
                                    onclick="ButtonSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input name="cs" type="button" class="button" id="cs" value="取 消" onClick="showConfirmMsg1()">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <br>
                    </form></td>
                  </tr>
                  </table></td>
            </tr>
          </table>
          </td>
      </tr>
    </table></td>
  </tr>
  </table>

        <%--<table width="1000px">
            <tr>
                <td align="center">
                    <table width="35%" border="0">
                        <tr>
                            <td>
                                <asp:Label ID="LabelUserName" Text="用户名：" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" Text="密  码：" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxPwd" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" Text="验证码：" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxValidateCode" runat="server"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:Image ID="ImageValidateCode" ImageUrl="~/ValidateCode.aspx" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="ButtonSubmit" Text="登 录" runat="server" 
                                    onclick="ButtonSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>--%>    
    </div>
    </form>
</center>
</body>
</html>
