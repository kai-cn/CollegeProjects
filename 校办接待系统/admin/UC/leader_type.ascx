<%@ Control Language="C#" AutoEventWireup="true" CodeFile="leader_type.ascx.cs" Inherits="admin_UC_leader_type" %>

<center>
    <table width="90%">
    <tr>
    <td colspan=4 align="right" style="padding-bottom:10px;">
    <asp:TextBox runat="server" ID="txt_id" Width="148px"></asp:TextBox>
    <asp:Button  runat="server" ID="btn_ok" Text="搜索" Font-Size="14px"  onclick="btn_ok_Click"/>
    </td>
    </tr>
        <tr>
            <td style="width:25%">
                <asp:HyperLink ID="HyperLink1" Text="中央领导" NavigateUrl="~/admin/leader_list.aspx?type=1" runat="server"></asp:HyperLink>
            </td>
            <td style="width:25%">
                <asp:HyperLink ID="HyperLink2" Text="省部级领导" NavigateUrl="~/admin/leader_list.aspx?type=2" runat="server"></asp:HyperLink>
            </td>
            <td style="width:25%">
                <asp:HyperLink ID="HyperLink3" Text="地方领导" NavigateUrl="~/admin/leader_list.aspx?type=3" runat="server"></asp:HyperLink>
            </td>
            <td style="width:25%">
                <asp:HyperLink ID="HyperLink4" Text="高校领导" NavigateUrl="~/admin/leader_list.aspx?type=4" runat="server"></asp:HyperLink>
            </td>
        </tr>
    </table>
</center>