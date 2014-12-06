<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="department_type.aspx.cs" Inherits="admin_department_department_type" %>

<%@ Register src="UC/DeparmentType.ascx" tagname="DeparmentType" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:DeparmentType ID="DeparmentType1" runat="server" />

</asp:Content>

