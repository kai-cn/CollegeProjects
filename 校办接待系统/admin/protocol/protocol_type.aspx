<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="protocol_type.aspx.cs" Inherits="admin_protocol_protocol_type" %>

<%@ Register src="UC/ProtocolType.ascx" tagname="ProtocolType" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ProtocolType ID="ProtocolType1" runat="server" />
</asp:Content>

