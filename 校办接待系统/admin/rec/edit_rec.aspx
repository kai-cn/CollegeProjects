<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="edit_rec.aspx.cs" Inherits="admin_rec_edit_rec" %>

<%@ Register src="UC/RecEditor.ascx" tagname="RecEditor" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:RecEditor ID="RecEditor1" runat="server" />
</asp:Content>

