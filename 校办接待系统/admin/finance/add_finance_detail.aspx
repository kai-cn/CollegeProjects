<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="add_finance_detail.aspx.cs" Inherits="admin_finance_add_finance_detail" %>

<%@ Register src="UC/FinanceDetailEditor.ascx" tagname="FinanceDetailEditor" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:FinanceDetailEditor ID="FinanceDetailEditor1" runat="server" />
</asp:Content>

