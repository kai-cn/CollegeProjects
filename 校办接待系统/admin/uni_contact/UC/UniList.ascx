<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UniList.ascx.cs" Inherits="admin_uni_contact_UC_UniList" %>

<table width="100%">
    <tr>
        <td width="100%">
    <asp:DataList ID="DataList1" RepeatColumns="5" RepeatDirection="Horizontal" HorizontalAlign="Left" RepeatLayout="Table" runat="server">
         <ItemTemplate>
            <td style="height:50px" width="20%" align="left">
                    <a href="contact_uni_detail.aspx?uni_id=<%#Eval("uni_id") %>"> <%# Eval("uni_name") %></a>
            </td>
         </ItemTemplate>
         </asp:DataList>
        </td>
    </tr>
</table>
