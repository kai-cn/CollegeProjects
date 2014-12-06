<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecEditor.ascx.cs" Inherits="admin_rec_UC_RecEditor" %>

<table width="100%" border="1">
    <tr>
        <td align="center" valign="middle" colspan="9">
            <asp:Label ID="LabelTitle" Text="苏州大学校办接待安排登记表" runat="server" Font-Bold="true"></asp:Label>
            <br />&nbsp;

        </td>
    </tr>
    <tr>
        <td align="right" colspan="9">
            <b>日期：&nbsp;&nbsp;&nbsp;</b><asp:TextBox ID="Calendar1" runat="server" />（格式：XXXX-XX-XX）&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </td>
    </tr>
    <tr>
        <td width="20%">
            <b>来宾单位：</b>
        </td>
        <td colspan="4" width="40%">
            <asp:TextBox ID="TBUnit" runat="server"></asp:TextBox>
        </td>
        <td width="10%">
            <b>人数：</b>
        </td>
        <td width="30%" colspan="3">
            <asp:TextBox ID="TBNum" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>来宾姓名：</b>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
        </td>
        <td>
            <b>职务：</b>
        </td>
        <td colspan="3">
            <asp:TextBox ID="TBPos" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>考察内容：</b>
        </td>
        <td colspan="8">
            <asp:TextBox ID="TBContent" TextMode="MultiLine" Width="98%" Height="200px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>抵离时间：</b>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TBArrDepTime" runat="server"></asp:TextBox>
        </td>
        <td>
            <b>用车：</b>
        </td>
        <td colspan="3">
            <asp:TextBox ID="TBCar" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>陪同：</b>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TBAccompany" runat="server"></asp:TextBox>
        </td>
        <td rowspan="2">
            <b>宴请：</b>
        </td>
        <td colspan="3" rowspan="2">
            <asp:TextBox ID="TBDinner" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>住宿：</b>
        </td>
        <td colspan="2">
            <asp:TextBox ID="TBHotel" runat="server"></asp:TextBox>
        </td>
        <td colspan="2">
            <b>房号</b>：
            <asp:TextBox ID="TBRoom" runat="server"></asp:TextBox>
        </td>
    </tr>
        
    <tr>
        <td>
            <b>拟办意见：</b>
        </td>
        <td colspan="8">
            <asp:TextBox ID="TBFirstOpinion" TextMode="MultiLine" Width="98%" Height="200px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>工作安排：</b>
        </td>
        <td colspan="8">
            <table width="100%">
                <tr>
        <td width="9%">
            <asp:CheckBox ID="CBMaterial" Text="材料" runat="server" />
        </td>
        <td width="9%">
            <asp:CheckBox ID="CBPub" Text="宣传" runat="server" />
        </td>
        <td width="9%">
            <asp:CheckBox ID="CBPhoto" Text="拍照" runat="server" />
        </td>
        <td width="9%">
            <asp:CheckBox ID="CBGuard" Text="保卫" runat="server" />
        </td>
        <td width="9%">
            <asp:CheckBox ID="CBVideo" Text="录像" runat="server" />
        </td>
        <td width="16%">
            <asp:CheckBox ID="CBCir" Text="环境绿化" runat="server" />
        </td>
        <td width="22%">
            <asp:CheckBox ID="CBLogo" Text="欢迎牌、会标" runat="server" />
        </td>
        <td width="12%">
            <asp:CheckBox ID="CBMeetingRoom" Text="会议室" runat="server" />
        </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <b>领导意见：</b>
        </td>
        <td colspan="8">
            <asp:TextBox ID="TBFinalOpinion" TextMode="MultiLine" Width="98%" Height="200px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>备注：</b>
        </td>
        <td colspan="8">
            <asp:TextBox ID="TBNote" TextMode="MultiLine" Width="98%" Height="120px" runat="server"></asp:TextBox>
        </td>
    </tr>
        
    <tr>
        <td colspan="9" align="center">
            <br /><br /><br />
            <asp:Button ID="ButtonSubmit" Text="确  定" runat="server" 
                onclick="ButtonSubmit_Click" />
        </td>
    </tr>
</table>