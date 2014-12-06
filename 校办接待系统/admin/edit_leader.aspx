<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="edit_leader.aspx.cs" Inherits="admin_edit_leader" %>

<%@ Register src="UC/leader_editor.ascx" tagname="leader_editor" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:leader_editor ID="leader_editor1" runat="server" />
</asp:Content>

