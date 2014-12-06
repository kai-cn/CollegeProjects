<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddOfficeEditor.ascx.cs" Inherits="admin_department_UC_AddOfficeEditor" %>


<table width="100%" border="1">
    <tr>
        <td align="center" valign="middle" colspan="5">
            <asp:Label ID="Label2" Text="部门信息" Font-Bold="true" runat="server"></asp:Label><br />&nbsp;

        </td>
    </tr>
    <tr>
        <td width="20%">
            <b>姓名：</b>
        </td>
        <td colspan="2" width="40%">
            <asp:TextBox ID="TBPerson" runat="server"></asp:TextBox>
        </td>
        <td width="10%">
            <b>地址：</b>
        </td>
        <td width="30%">
            <asp:TextBox ID="TBAddress" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>职务：</b>
        </td>
        <td colspan="2">
            <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
        </td>
        <td>
            <b>电话：</b>&nbsp;</td>
        <td>
            <asp:TextBox ID="TBPhone" runat="server"></asp:TextBox>&nbsp;</td>
    </tr>
        <tr>
        <td>
            <b>专业：</b>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TextBox6" runat="server"  Text="输入的专业名称请以‘，’隔开" ReadOnly="true" 
                Width="399px"></asp:TextBox>
            <asp:TextBox ID="TBMajor" TextMode="MultiLine" Width="98%" Height="200px" runat="server"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <td>
            <b>身份：</b>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TextBox2" runat="server"  Text="输入的专业名称请以‘，’隔开" ReadOnly="true" 
                Width="399px"></asp:TextBox>
            <asp:TextBox ID="TBidCard" TextMode="MultiLine" Width="98%" Height="200px" runat="server"></asp:TextBox>
        </td>
    </tr>
    

    <tr>
        <td>
            <b>备注：</b>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TBNote" TextMode="MultiLine" Width="98%" Height="120px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
        <b>文件上传：</b>
        </td>
        <td colspan="4">
            <asp:FileUpload ID="FileUpload1"  runat="server" />
            <asp:Label runat="server" ID="label_hidden_name" Visible="false"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="5" align="center">
            <br /><br /><br />
            <asp:Button ID="ButtonSubmit" Text="确  定" runat="server" 
                onclick="ButtonSubmit_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonCancel" Text="取 消" runat="server" 
                onclick="ButtonCancel_Click" />
        </td>
    </tr>
</table>