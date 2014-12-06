<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="contact_uni_list.aspx.cs" Inherits="admin_uni_contact_contact_uni_list" %>

<%@ Register src="UC/UniList.ascx" tagname="UniList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UniList ID="UniList1" runat="server" />
</asp:Content>

