<%@ Control Language="C#" AutoEventWireup="true" CodeFile="leader_editor.ascx.cs" Inherits="admin_UC_leader_editor" %>

<script type="text/javascript">

    function CheckFile(str) {

        if (str == null || str == "")
            return true;
        var pos = str.lastIndexOf(".");

        var lastname = str.substring(pos, str.length);
        if (lastname.toLowerCase() != ".jpg" && lastname.toLowerCase() != ".gif" && lastname.toLowerCase() != ".png") {
            alert("您上传的文件类型为" + lastname + ",图片必须为.jpg,.gif,.png类型");
            return false;
        }
        else {
            return true;
            
        }
    }
    function CheckFileType() {

        var str = document.getElementById("ctl00_ContentPlaceHolder1_leader_editor1_cardLoad").value;
        CheckFile(str);
        var str = document.getElementById("ctl00_ContentPlaceHolder1_leader_editor1_photoLoad").value;
        CheckFile(str);
        
    }

    
</script>


<center>
<table width="90%" border="1">
    <tr>
        <td align="center" style="width:20%">
            <asp:Label ID="Label1" runat="server">领导姓名：</asp:Label>
        </td>
        <td style="width:80%" align="left">
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" style="width:20%">
            <asp:Label ID="Label2" runat="server">领导类型：</asp:Label>
        </td>
        <td style="width:80%" align="left" valign="top">
            <asp:DropDownList ID="DDLType" runat="server">
                <asp:ListItem Value="1">中央领导</asp:ListItem>
                <asp:ListItem Value="2">省部级领导</asp:ListItem>
                <asp:ListItem Value="3">地方领导</asp:ListItem>
                <asp:ListItem Value="4">高校领导</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" style="width:20%" valign="top">
            <asp:Label ID="Label3" runat="server">详细信息：</asp:Label>
        </td>
        <td style="width:80%" align="left">
            <asp:TextBox ID="TextBoxDetail" TextMode="MultiLine" Height="350px" Width="90%" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td align="center" style="width:20%;" valign="top">
    <asp:Label ID="Label4" runat="server" >名片:</asp:Label>
    </td>
    <td  style="width:80%" align="left">
    <asp:FileUpload  ID="cardLoad" runat="server" Width="300px" />
    </td>
    </tr>
    <tr>
    <td align="center" style="width:20%;" valign="top">
    <asp:Label ID="Label5" runat="server" >照片:</asp:Label>
    </td>
    <td  style="width:80%" align="left">
    <asp:FileUpload  ID="photoLoad" runat="server" Width="300px"/>
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center">
    <asp:Label ID="lb_info" Width="475px" runat="server" ForeColor="Red" ></asp:Label>
    </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
        <br />
            <asp:Button ID="ButtonSubmit" Text="确 定" runat="server" 
             OnClick="ButtonSubmit_Click"    OnClientClick="return  CheckFileType()" />
        <br />&nbsp;
        </td>
    </tr>
</table>
</center>
