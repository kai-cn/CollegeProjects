<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddDepartment.ascx.cs" Inherits="admin_department_UC_AddDepartment" %>
<table width="80%">
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="LabelTitle" Text="单位信息" Font-Bold="true" runat="server"></asp:Label>
            <br />&nbsp;
        </td>
    </tr>
    <tr>
        <td width="20%">
            <asp:Label ID="Label1" Text="名称：" Font-Bold="true" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>
            <asp:Label ID="Label4" Text="地址：" Font-Bold="true" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TBAddress" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" Text="传真：" Font-Bold="true" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TBPhone" runat="server"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" Text="类型：" Font-Bold="true" runat="server"></asp:Label>
        </td>
        <td>
            
            <asp:DropDownList ID="DropDownList1" runat="server" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="1">院校</asp:ListItem>
                <asp:ListItem Value="2">部门</asp:ListItem>
            </asp:DropDownList>
            
        </td>
    </tr>

    <tr>
        <td colspan="2" align="center">
            <br />
            <asp:Button ID="ButtonSubmit" Text="确 定" runat="server" 
                onclick="ButtonSubmit_Click" />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="ButtonCancel" Text="取 消" runat="server" 
                onclick="ButtonCancel_Click" />
        </td>
    </tr>
</table>