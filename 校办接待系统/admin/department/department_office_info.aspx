<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="department_office_info.aspx.cs" Inherits="admin_department_department_office_info" %>

<%@ Register src="UC/OfficeList.ascx" tagname="OfficeList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:OfficeList ID="OfficeList1" runat="server" />
</asp:Content>

