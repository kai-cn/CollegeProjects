<%@ Control Language="C#" AutoEventWireup="true" CodeFile="leader_detail.ascx.cs" Inherits="admin_UC_leader_detail" %>

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
                                <table width="100%">
                                    <tr>
                                        <td align="center" colspan="2" height="150px">
                                            <asp:Label ID="LabelName" Font-Bold="true" Font-Size="X-Large" Text='<%#Eval("leader_name") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">
                        类别：
                     
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label1" Text='<%#Eval("leader_type_name") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                        详细信息：
                     
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label2" Text='<%#Eval("leader_info") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                    名片：
                 
                                        </td>
                                        <td align="left">
                                            <img  src="<%# Eval("leader_card") %>" style="width:180px; height:105px" id="leaderCard" alt="名片"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                    照片：
                 
                                        </td>
                                        <td align="left">
                                            <img  src="<%# Eval("leader_photo") %>" style="width:200px; height:150px" id="leaderPhoto" alt="照片"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:HyperLink ID="HLEdit" Text="编  辑" NavigateUrl='<%#Eval("leader_id","~/admin/edit_leader.aspx?action=edit&id={0}") %>' runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </li>
    </ol>
</center>