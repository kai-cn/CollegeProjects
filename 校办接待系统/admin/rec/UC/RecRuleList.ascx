<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecRuleList.ascx.cs" Inherits="admin_rec_UC_RecRuleList" %>
<table width="100%">
    <tr>
        <td width="100%" align="center" style="padding-top:50px">

         <a href="rec_rule.aspx?src=/flash/校办仪式活动标准化建设.swf">苏州大学校长办公室接待规则</a>
         
    <asp:DataList ID="DataList1" RepeatColumns="5" RepeatDirection="Horizontal" HorizontalAlign="Left" RepeatLayout="Table" runat="server">
         <ItemTemplate>
            <td style="height:50px" width="20%" align="left">
            <a href="rec_ruleList.aspx?src=/images/YellowPage.swf">附件1</a>
                   <%-- <a href="month_list.aspx?merchant_id=<%#Eval("merchant_id") %>&type=<%=Request.QueryString["type"] %>"> <%# Eval("merchant_name") %></a>--%>
            </td>
         </ItemTemplate>
         </asp:DataList>
         <br />
         <asp:Label ID="LabelNotice" Text="暂无接待规则" Visible="false" runat="server"></asp:Label>
        </td>
        </tr>
     
</table>