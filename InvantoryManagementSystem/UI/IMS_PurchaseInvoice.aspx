<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IMS_PurchaseInvoice.aspx.cs" Inherits="InvantoryManagementSystem.UI.IMS_PurchaseInvoice" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <CR:CrystalReportSource ID="crsource" runat="server"></CR:CrystalReportSource>
    <CR:CrystalReportViewer ID="crviewer" runat="server" AutoDataBind="true" />

</asp:Content>
