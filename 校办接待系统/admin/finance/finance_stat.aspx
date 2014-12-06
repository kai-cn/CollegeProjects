<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="finance_stat.aspx.cs" Inherits="admin_finance_finance_stat" %>

<%@ Register src="UC/FinanceStat.ascx" tagname="FinanceStat" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:FinanceStat ID="FinanceStat1" runat="server" />
</asp:Content>

