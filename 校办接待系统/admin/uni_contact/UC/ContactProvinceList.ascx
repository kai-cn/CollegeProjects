<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactProvinceList.ascx.cs" Inherits="admin_UC_ContactProvinceList" %>
<table width="100%">
    <tr>
        <td width="100%">
    <asp:DataList ID="DataList1" RepeatColumns="5" RepeatDirection="Horizontal" HorizontalAlign="Left" RepeatLayout="Table" runat="server">
         <ItemTemplate>
                <table width="100%">
                    <tr>
                        <td style="height:50px" width="130px" align="left">
                                <a href="contact_uni_list.aspx?province_id=<%#Eval("province_id") %>"> <%# Eval("province_name") %></a>
                        </td>
                    </tr>
                </table>
         </ItemTemplate>
         </asp:DataList>
        </td>
    </tr>
</table>
