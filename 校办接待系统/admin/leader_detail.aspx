<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="leader_detail.aspx.cs" Inherits="admin_leader_detail" %>

<%@ Register src="UC/leader_detail.ascx" tagname="leader_detail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:leader_detail ID="leader_detail1" runat="server" />
</asp:Content>

