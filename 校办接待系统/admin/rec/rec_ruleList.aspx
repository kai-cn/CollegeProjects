<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="rec_ruleList.aspx.cs" Inherits="admin_rec_rec_ruleList" %>

<%@ Register src="UC/RecRuleList.ascx" tagname="RecRuleList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:RecRuleList ID="RecRuleList1" runat="server" />
</asp:Content>

