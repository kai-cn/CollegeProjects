<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CoopType.ascx.cs" Inherits="admin_coop_UC_CoopType" %>


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
                <asp:HyperLink ID="HyperLink1" Text="教育部" NavigateUrl="" runat="server"></asp:HyperLink>
            </td>
          <td style="width:25%">
                <asp:HyperLink ID="HyperLink2" Text="教育厅" NavigateUrl="" runat="server"></asp:HyperLink>
            </td>
             <td style="width:25%">
                <asp:HyperLink ID="HyperLink3" Text="科技部" NavigateUrl="" runat="server"></asp:HyperLink>
            </td>
             <td style="width:25%">
                <asp:HyperLink ID="HyperLink5" Text="科技厅" NavigateUrl="" runat="server"></asp:HyperLink>
            </td>
            </tr>
            <tr>
            
            <td style="width:25%">
                <asp:HyperLink ID="HyperLink4" Text="省委省政府" NavigateUrl="" runat="server"></asp:HyperLink>
            </td>
             <td style="width:25%">
                <asp:HyperLink ID="HyperLink6" Text="市委市政府" NavigateUrl="" runat="server"></asp:HyperLink>
            </td>
        </tr>
    </table>
</center>
