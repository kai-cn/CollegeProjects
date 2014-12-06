<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UniDetail.ascx.cs" Inherits="admin_uni_contact_UC_UniDetail" %>

<center>
<table width="450px">
  <tr>
    <td colspan=4 align="right" style="padding-bottom:10px;">
    <asp:TextBox runat="server" ID="txt_id" Width="148px"></asp:TextBox>
    <asp:Button  runat="server" ID="btn_ok" Text="搜索" Font-Size="14px"  onclick="btn_ok_Click"/>
    </td>
    </tr>
<tr>
<td>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <table width="75%">
                <tr>
                    <td align="center" height="150px">
                        <asp:Label ID="LabelName" Font-Bold="true" Font-Size="X-Large" Text='<%#Eval("uni_name") %>' runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label1" Text='<%#Eval("uni_tel") %>' runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" Text='<%#Eval("uni_note") %>' runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center"><asp:HyperLink ID="HLEdit" Text="编  辑" NavigateUrl='<%#Eval("uni_id","~/admin/uni_contact/edit_uni.aspx?action=edit&id={0}") %>' runat="server" /></td>
                </tr>

            </table>
        </ItemTemplate>
    </asp:Repeater>
    </td>
    </tr>
    </table>
</center>