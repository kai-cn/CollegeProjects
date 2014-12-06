<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="rec_rule.aspx.cs" Inherits="admin_rec_rec_rule" %>



<%@ Register src="UC/RecRule.ascx" tagname="RecRule" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:RecRule ID="RecRule1" runat="server" />


</asp:Content>

