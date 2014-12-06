<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="leader_type.aspx.cs" Inherits="admin_leader_type" %>

<%@ Register src="UC/leader_type.ascx" tagname="leader_type" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:leader_type ID="leader_type1" runat="server" />
</asp:Content>

