<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="add_department.aspx.cs" Inherits="admin_department_add_department" %>

<%@ Register src="UC/AddDepartment.ascx" tagname="AddDepartment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddDepartment ID="AddDepartment1" runat="server" />
</asp:Content>

