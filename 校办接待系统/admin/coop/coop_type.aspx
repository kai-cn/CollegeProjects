<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="coop_type.aspx.cs" Inherits="admin_coop_coop_type" %>

<%@ Register src="UC/CoopType.ascx" tagname="CoopType" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:CoopType ID="CoopType1" runat="server" />
</asp:Content>

