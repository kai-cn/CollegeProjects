<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MerchantList.ascx.cs" Inherits="admin_finance_UC_merchant_list" %>
<table width="100%">

    <tr>
        <td width="100%" align="center">
    <asp:DataList ID="DataList1" RepeatColumns="5" RepeatDirection="Horizontal" HorizontalAlign="Left" RepeatLayout="Table" runat="server">
         <ItemTemplate>
            <td style="height:50px" width="20%" align="left">
            <a href="finance_stat.aspx?merchant_id=<%#Eval("merchant_id") %>&type=<%=Request.QueryString["type"] %>"> <%# Eval("merchant_name") %></a>
                   <%-- <a href="month_list.aspx?merchant_id=<%#Eval("merchant_id") %>&type=<%=Request.QueryString["type"] %>"> <%# Eval("merchant_name") %></a>--%>
            </td>
         </ItemTemplate>
         </asp:DataList>
         <br />
         <asp:Label ID="LabelNotice" Text="暂无商户列表" Visible="false" runat="server"></asp:Label>
        </td>
        </tr>

</table>
