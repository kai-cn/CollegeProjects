<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FinanceStat.ascx.cs" Inherits="admin_finance_UC_FinanceStat" %>

<table width="100%">
    <tr>
        <td align="center">
            <asp:Label ID="LabelTitle" Font-Bold="true" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;
        </td>
    </tr>
    <tr>
<td align="right" style="padding-bottom:10px;">
<asp:Panel runat="server" ID="panel1">
    <asp:DropDownList runat="server" ID="ddl_year" Height="25px">

    </asp:DropDownList>
    <asp:Label runat="server" Text="年"></asp:Label>
     <asp:DropDownList runat="server" ID="ddl_month">
    </asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Text="月"></asp:Label>
      </asp:Panel>
    &nbsp;&nbsp;
    <asp:DropDownList runat="server" ID="dropDownList1" style="margin-left: 0px">
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;
    <asp:Button runat="server" Text="搜索" ID="btn_ok" OnClick="btn_ok_Click"/>
    &nbsp;</td>
    </tr>

    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td style="width:34%">
                        总金额：<asp:Label ID="LabelAll" runat="server"></asp:Label>
                    </td>
                    <td style="width:33%">
                        已报销：<asp:TextBox ID="TBYBX" Width="100px" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td style="width:33%">
                        未报销：<asp:TextBox ID="TBWBX" 
                            Width="100px" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
        <!--<asp:HyperLinkField DataNavigateUrlFields="finance_activity_id" DataNavigateUrlFormatString="~/admin/rec/edit_rec.aspx?action=edit&id={0}" DataTextField="visitor_unit" HeaderText="单位名称" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />-->
            <asp:GridView ID="GVList" AutoGenerateColumns="false" runat="server" 
                GridLines="Both" Width="100%" AllowPaging="true" PageSize="10" 
                OnPageIndexChanging="GVList_PageIndexChanging" 
                onrowcommand="GVList_RowCommand" onrowdeleting="GVList_RowDeleting" >
                <Columns>
                    
                    <asp:BoundField DataField="finance_occur_time" HeaderText="时间" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="finance_good_name" HeaderText="用途/礼品名称" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="finance_good_price" HeaderText="金额" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:CheckBoxField DataField="finance_ybx" HeaderText="已报销" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"   />
                    <asp:BoundField DataField="finance_people" HeaderText="报销明细" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemStyle ForeColor="Red" />
                    <ItemTemplate>
　                    <asp:LinkButton ID="BtnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="修改" CommandArgument='<%#Eval("finance_id") %>' ></asp:LinkButton>
　                    <asp:LinkButton ID="BtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="删除"  CommandArgument='<%#Eval("finance_id") %>'  ></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                  
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center">
            <br />
            <asp:Button ID="ButtonSubmit" Text="添加" runat="server" 
                onclick="ButtonSubmit_Click" />
        </td>
    </tr>
</table>