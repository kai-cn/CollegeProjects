<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecRule.ascx.cs" Inherits="admin_rec_UC_RecRule" %>

<table>
<tr>
<td>
<embed src="<%=Request.QueryString["src"] %>" quality=high pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width=920 height=700></embed>
</td>
</tr>
<tr>
<td>
<table>
<tr style="text-decoration:none">
<td>
<a href="rec_rule.aspx?src=/flash/附件1.swf" >附件1</a>
</td>
<td>
<a href="rec_rule.aspx?src=/flash/附件2.swf">附件2</a>
</td>
<td>
<a href="rec_rule.aspx?src=/flash/附件3.swf">附件3</a>
</td>
<td>
<a href="rec_rule.aspx?src=/flash/附件4.swf">附件4</a>
</td>
</tr>
</table>
</tr>
   <tr>
        <td align="right">
        <br /><br />
            <asp:LinkButton ID="LBAdd" Text="下载文档" runat="server"  
                style="text-decoration:none" onclick="LBAdd_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>


    </table>