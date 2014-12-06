<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="province_list.aspx.cs" Inherits="admin_uni_contact_province_list" %>

<%@ Register src="UC/ContactProvinceList.ascx" tagname="ContactProvinceList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ContactProvinceList ID="ContactProvinceList1" runat="server" />
</asp:Content>

