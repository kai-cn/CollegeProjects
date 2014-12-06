<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="leader_list.aspx.cs" Inherits="admin_leader_list" %>

<%@ Register src="UC/leader_list.ascx" tagname="leader_list" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:leader_list ID="leader_list1" runat="server" />
</asp:Content>

