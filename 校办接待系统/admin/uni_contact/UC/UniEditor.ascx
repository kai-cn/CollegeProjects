<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UniEditor.ascx.cs" Inherits="admin_uni_contact_UC_UniEditor" %>

<center>
<table width="90%" border="1">
    <tr>
        <td align="center" style="width:20%">
            <asp:Label ID="Label1" runat="server">学校名称：</asp:Label>
        </td>
        <td style="width:80%" align="left">
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" style="width:20%">
            <asp:Label ID="Label2" runat="server">联系方式：</asp:Label>
        </td>
        <td style="width:80%" align="left">
            <asp:TextBox ID="TextBoxTel" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" style="width:20%" valign="top">
            <asp:Label ID="Label3" runat="server">备注：</asp:Label>
        </td>
        <td style="width:80%" align="left">
            <asp:TextBox ID="TextBoxDetail" TextMode="MultiLine" Height="350px" Width="90%" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
        <br />
            <asp:Button ID="ButtonSubmit" Text="确 定" runat="server" 
                onclick="ButtonSubmit_Click" />
        <br />&nbsp;
        </td>
    </tr>
</table>
</center>
