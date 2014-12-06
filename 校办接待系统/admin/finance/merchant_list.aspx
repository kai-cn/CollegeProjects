<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="merchant_list.aspx.cs" Inherits="admin_finance_MerchantList" %><%@ Register src="UC/MerchantList.ascx" tagname="MerchantList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:MerchantList ID="MerchantList1" runat="server" />
</asp:Content>

