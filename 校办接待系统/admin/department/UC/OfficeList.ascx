<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OfficeList.ascx.cs" Inherits="admin_department_UC_OfficeList" %>

<center>
    <table width="90%">
    <tr style="height:50px">
    <td ></td>
    </tr>
    <tr>
<td align="right" style="padding-bottom:10px;">
    &nbsp;&nbsp;
    <asp:TextBox runat="server" ID="txt_id"></asp:TextBox>&nbsp;
    <asp:DropDownList runat="server" ID="dropDownList1" style="margin-left: 0px" 
        Height="16px">
        <asp:ListItem Value="office_person_name">名称</asp:ListItem>
        <asp:ListItem Value="office_name">职务</asp:ListItem>
        <asp:ListItem Value="office_major">专业</asp:ListItem>
        <asp:ListItem Value="office_idcard">身份</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;
    <asp:Button runat="server" Text="搜索" ID="btn_ok" OnClick="btn_ok_Click"/>
    &nbsp;</td>
    </tr>
        <tr>
        <td align="center" style="width:100%">
                <asp:GridView ID="GVOffice" AutoGenerateColumns="false" Width="100%" 
                    runat="server" GridLines="Both" EmptyDataText="暂无来访信息" AllowPaging="true" 
                    PageSize="10" onpageindexchanging="GVOffice_PageIndexChanging" 
                    onrowcommand="GVOffice_RowCommand" onrowdeleting="GVOffice_RowDeleting">
                    <Columns>
                    <asp:TemplateField HeaderText="id" Visible="False">
                     <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Eval("office_major") %>'></asp:Label>
                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("office_idcard") %>'></asp:Label>
                     </ItemTemplate>
                    </asp:TemplateField>
                        <asp:BoundField DataField="office_person_name" HeaderText="名称" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="office_name" HeaderText="职务" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="office_address" HeaderText="地址" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="专业" ShowHeader="False">
                        <ItemTemplate>
                        <asp:DropDownList ID="office_major" runat="server">
                        </asp:DropDownList>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="身份" ShowHeader="false">
                          <ItemTemplate>
                             <asp:DropDownList ID="office_idcard" runat="server">
                        </asp:DropDownList>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="office_phone" HeaderText="联系方式" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        
                              <asp:TemplateField HeaderText="文件" ShowHeader="false">
                          <ItemTemplate>
                          <asp:LinkButton ID="BtnDownload" runat="server" CausesValidation="False" CommandName="Download"
                    Text="下载" CommandArgument='<%#Eval("office_file") %>'></asp:LinkButton>
　                   
                          </ItemTemplate>
                           
                          </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemStyle ForeColor="Red" />
                    <ItemTemplate>
　                    <asp:LinkButton ID="BtnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="修改" CommandArgument='<%#Eval("office_id") %>'></asp:LinkButton>
　                    <asp:LinkButton ID="BtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="删除"  CommandArgument='<%#Eval("office_id") %>' ></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>           
             </td>
            
        </tr>
        <tr>
             <td align="right">
                <asp:LinkButton ID="LBAdd" Text="添  加" runat="server" onclick="LBAdd_Click" ></asp:LinkButton>
             </td>
        </tr>    
    </table>
</center>