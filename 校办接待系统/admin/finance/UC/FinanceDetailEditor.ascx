<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FinanceDetailEditor.ascx.cs" Inherits="admin_finance_UC_FinanceDetailEditor" %>


<table width="80%">
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="LabelTitle" Text="财务报销明细录入" Font-Bold="true" runat="server"></asp:Label>
            <br />&nbsp;
        </td>
    </tr>
    <tr>
        <td width="20%">
            <asp:Label ID="Label1" Text="时间：" Font-Bold="true" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TBTime" runat="server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>
            <asp:Label ID="Label4" Text="酒店/礼品名称：" Font-Bold="true" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TBGiftName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" Text="金额：" Font-Bold="true" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TBGiftPrice" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" Text="已报销：" Font-Bold="true" runat="server"></asp:Label>
        </td>
        <td>
            <asp:CheckBox runat="server" Text="" ID="check1"/>
        </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="label7" Text="报销明细：" Font-Bold="true" runat="server"></asp:Label>
    </td>
    <td>
    <asp:TextBox runat="server" ID="TBDetail" TextMode="MultiLine" Height="300px" Width="455px" />
    </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <br />
            <asp:Button ID="ButtonSubmit" Text="确 定" runat="server" 
                onclick="ButtonSubmit_Click" />
        </td>
    </tr>
</table>