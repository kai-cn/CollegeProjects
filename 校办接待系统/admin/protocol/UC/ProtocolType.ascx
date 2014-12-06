<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProtocolType.ascx.cs" Inherits="admin_protocol_UC_protocolType" %>

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
                <asp:HyperLink ID="HyperLink1" Text="高校" NavigateUrl="" runat="server"></asp:HyperLink>
            </td>
         
            
            <td style="width:25%">
                <asp:HyperLink ID="HyperLink4" Text="酒店" NavigateUrl="" runat="server"></asp:HyperLink>
            </td>
        </tr>
    </table>
</center>
