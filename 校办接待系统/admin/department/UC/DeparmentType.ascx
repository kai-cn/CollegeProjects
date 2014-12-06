<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeparmentType.ascx.cs" Inherits="admin_department_UC_DeparmentType" %>

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
    &nbsp;&nbsp;
    <asp:TextBox runat="server" ID="txt_id"></asp:TextBox>&nbsp;
    <asp:DropDownList runat="server" ID="dropDownList1" style="margin-left: 0px" 
        Height="16px">
        <asp:ListItem Value="0">全部</asp:ListItem>
        <asp:ListItem Value="1">院校</asp:ListItem>
        <asp:ListItem Value="2">部门</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;
    <asp:Button runat="server" Text="搜索" ID="btn_ok" OnClick="btn_ok_Click"/>
    &nbsp;</td>
    </tr>
    <tr>
        <td>
        <!--<asp:HyperLinkField DataNavigateUrlFields="finance_activity_id" DataNavigateUrlFormatString="~/admin/rec/edit_rec.aspx?action=edit&id={0}" DataTextField="visitor_unit" HeaderText="单位名称" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />-->
            <asp:GridView ID="GVList" AutoGenerateColumns="false" runat="server" 
                GridLines="Both" Width="100%" AllowPaging="true" PageSize="10" 
                onpageindexchanging="GVList_PageIndexChanging" 
                onrowcommand="GVList_RowCommand" onrowdeleting="GVList_RowDeleting" >
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="department_id" DataNavigateUrlFormatString="~/admin/department/department_office_info.aspx?id={0}" DataTextField="department_name" HeaderText="单位名称" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="department_address" HeaderText="地址" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="department_fax" HeaderText="传真" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                   <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemStyle ForeColor="Red" />
                    <ItemTemplate>
　                    <asp:LinkButton ID="BtnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="修改" CommandArgument='<%#Eval("department_id") %>' ></asp:LinkButton>
　                    <asp:LinkButton ID="BtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="删除"  CommandArgument='<%#Eval("department_id") %>'  ></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                  
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center">
            <br />
            <asp:Button ID="ButtonSubmit" Text="添加" runat="server" onclick="ButtonSubmit_Click" 
          />
        </td>
    </tr>
</table>

