<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecList.ascx.cs" Inherits="admin_rec_UC_rec_list" %>


<center>
    <table width="90%">
    <tr>
    <td align="right" style="padding-bottom:10px;">
    <asp:TextBox runat="server" ID="txt_id"></asp:TextBox>
    <asp:Button  runat="server" ID="btn_ok" Text="搜索" Font-Size="14px"  onclick="btn_ok_Click"/>
    </td>
    </tr>
        <tr>
            <td align="center" style="width:100%">
                <asp:GridView ID="GVRec" AutoGenerateColumns="false" Width="100%" 
                    runat="server" GridLines="Both" EmptyDataText="暂无来访信息" AllowPaging="true" 
                    PageSize="10" OnPageIndexChanging="GVRec_PageIndexChanging" 
                    onrowcommand="GVRec_RowCommand" onrowdeleting="GVRec_RowDeleting">
                    <Columns>
                    <asp:TemplateField HeaderText="id" Visible="False">
                     <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Eval("visit_major") %>'></asp:Label>
                     </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="visitor_name" HeaderText="姓名"  FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        <asp:HyperLinkField DataNavigateUrlFields="visit_id" DataNavigateUrlFormatString="~/admin/rec/edit_rec.aspx?action=edit&id={0}" DataTextField="visitor_unit" HeaderText="来宾单位" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="visitor_pos" HeaderText="职务" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="visitor_num" HeaderText="人数" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        
                        <asp:BoundField DataField="visit_new_date" ItemStyle-Width="100px" HeaderText="来访时间" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemStyle ForeColor="Red" />
                    <ItemTemplate>
　                    <asp:LinkButton ID="BtnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="修改" CommandArgument='<%#Eval("visit_id") %>'></asp:LinkButton>
　                    <asp:LinkButton ID="BtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="删除"  CommandArgument='<%#Eval("visit_id") %>' ></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>           
             </td>
        </tr>
        <tr>
             <td align="right">
                <asp:LinkButton ID="LBAdd" Text="添  加" runat="server" onclick="LBAdd_Click"></asp:LinkButton>
             </td>
        </tr>    
    </table>
</center>
