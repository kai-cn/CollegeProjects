<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="edit_uni.aspx.cs" Inherits="admin_uni_contact_edit_uni" %>

<%@ Register src="UC/UniEditor.ascx" tagname="UniEditor" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UniEditor ID="UniEditor1" runat="server" />
</asp:Content>

