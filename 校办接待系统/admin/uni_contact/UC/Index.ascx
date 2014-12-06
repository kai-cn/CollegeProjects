<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Index.ascx.cs" Inherits="admin_uni_contact_UC_Index" %>

<center>
<table width="80%">
  <tr>
    <td colspan=4 align="right" style="padding-bottom:10px;">
    <asp:TextBox runat="server" ID="txt_id" Width="148px"></asp:TextBox>
    <asp:Button  runat="server" ID="btn_ok" Text="搜索" Font-Size="14px"  onclick="btn_ok_Click"/>
    </td>
    </tr>
    <tr>
        <td width="50%" align="center">
            <asp:HyperLink ID="HLBasic" Text="基本高校" NavigateUrl="~/admin/uni_contact/contact_uni_list.aspx?type=basic" runat="server"></asp:HyperLink>
        </td>
        <td width="50%" align="center">
            <asp:HyperLink ID="HL211985" Text="211+985" NavigateUrl="~/admin/uni_contact/province_list.aspx" runat="server"></asp:HyperLink>
        </td>
    </tr>
</table>
</center>
