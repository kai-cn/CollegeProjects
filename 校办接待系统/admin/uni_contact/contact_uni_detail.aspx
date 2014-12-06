<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="contact_uni_detail.aspx.cs" Inherits="admin_uni_contact_contact_uni_detail" %>

<%@ Register src="UC/UniDetail.ascx" tagname="UniDetail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UniDetail ID="UniDetail1" runat="server" />
</asp:Content>

