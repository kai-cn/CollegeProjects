<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="add_office.aspx.cs" Inherits="admin_department_add_office" %>

<%@ Register src="UC/AddOfficeEditor.ascx" tagname="AddOfficeEditor" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddOfficeEditor ID="AddOfficeEditor1" runat="server" />
</asp:Content>

