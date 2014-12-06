<%@ Control Language="C#" AutoEventWireup="true" CodeFile="leader_list.ascx.cs" Inherits="admin_UC_leader_list" %>
<table width="100%">

    <tr>
        <td width="100%">
    <asp:DataList ID="DataList1" RepeatColumns="5" RepeatDirection="Horizontal" HorizontalAlign="Left" RepeatLayout="Table" runat="server">
         <ItemTemplate>
                <table width="100%">
                    <tr>
                        <td style="height:100px" width="130px" align="left">
                                <a href="leader_detail.aspx?id=<%#Eval("leader_id") %>"> <%# Eval("leader_name") %></a>
                        </td>
                    </tr>
                </table>
         </ItemTemplate>
         </asp:DataList>
        </td>
    </tr>
    <tr>
        <td align="right">
            <br /><br /><br /><br />
            <asp:LinkButton ID="LBAdd" Text="添加领导" runat="server" onclick="LBAdd_Click"></asp:LinkButton>
        </td>
    </tr>
</table>
