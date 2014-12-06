<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MonthList.ascx.cs" Inherits="admin_finance_UC_MonthList" %>
<table width="100%">
    <tr>
        <td width="100%" align="center">
    <asp:DataList ID="DataList1" RepeatColumns="5" RepeatDirection="Horizontal" HorizontalAlign="Left" RepeatLayout="Table" runat="server">
         <ItemTemplate>
            <td style="height:50px" width="20%" align="center">
                    <a href='finance_stat.aspx?year=<%#Eval("finance_year") + "&month=" + Eval("finance_month") + "&merchant_id=" + Eval("finance_merchant_id") + "&type=" + Eval("finance_type") %>'> <%#Eval("finance_year") + "-" + Eval("finance_month") %> </a>
            </td>
         </ItemTemplate>
         </asp:DataList>
        </td>
    </tr>
</table>