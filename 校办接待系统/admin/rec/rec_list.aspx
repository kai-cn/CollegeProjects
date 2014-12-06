<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="rec_list.aspx.cs" Inherits="admin_rec_rec_list" %>

<%@ Register src="UC/RecList.ascx" tagname="RecList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:RecList ID="RecList1" runat="server" />
</asp:Content>

