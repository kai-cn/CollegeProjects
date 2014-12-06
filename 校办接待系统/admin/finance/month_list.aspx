<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="month_list.aspx.cs" Inherits="admin_finance_month_list" %>

<%@ Register src="UC/MonthList.ascx" tagname="MonthList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:MonthList ID="MonthList1" runat="server" />
</asp:Content>

