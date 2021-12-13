<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PR_PIInfo.aspx.cs" Inherits="InvantoryManagementSystem.UI.PR_PIInfo" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content > --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>--%>
	<asp:HiddenField ID="SKprefixHF" runat="server" />
	<asp:HiddenField ID="SKcurNoHF" runat="server"/>
	<table class="table">
		<tr>
			<td>ID</td>
			<td><asp:TextBox ID="IDTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>PINO</td>
			<td><asp:TextBox ID="PINOTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>PIDate</td>
			<td><asp:TextBox ID="PIDateTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
		</tr>
		<tr>
			<td>BuyerName</td>
			<td><asp:TextBox ID="BuyerNameTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>BuyerCode</td>
			<td><asp:TextBox ID="BuyerCodeTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>YarnCount</td>
			<td><asp:TextBox ID="YarnCountTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
		</tr>
		<tr>
			<td>YarnCode</td>
			<td><asp:TextBox ID="YarnCodeTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>Rate</td>
			<td><asp:TextBox ID="RateTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>PIQuantity</td>
			<td><asp:TextBox ID="PIQuantityTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
		</tr>
		<tr>
			<td>PIValue</td>
			<td><asp:TextBox ID="PIValueTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>Ref</td>
			<td><asp:TextBox ID="RefTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>CompanyID</td>
			<td><asp:DropDownList ID="companyidDropdownlist" runat="server" AutoPostBack="true" data-toggle="dropdown" class="btn btn-default dropdown-toggle"></asp:DropDownList></td>
		</tr>
		<tr>
			<td>LCStatus</td>
			<td><asp:TextBox ID="LCStatusTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>LotNo</td>
			<td><asp:TextBox ID="LotNoTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>DeliveryPlace</td>
			<td><asp:TextBox ID="DeliveryPlaceTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
		</tr>
		<tr>
			<td>TBDFrom</td>
			<td><asp:TextBox ID="TBDFromTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>SPComment</td>
			<td><asp:TextBox ID="SPCommentTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>ProdRefNo</td>
			<td><asp:TextBox ID="ProdRefNoTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
		</tr>
		<tr>
			<td>ActiveMode</td>
			<td><asp:TextBox ID="ActiveModeTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>Tenor</td>
			<td><asp:TextBox ID="TenorTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>ExpiryDate</td>
			<td><asp:TextBox ID="ExpiryDateTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
		</tr>
		<tr>
			<td>InquiryNo</td>
			<td><asp:TextBox ID="InquiryNoTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>Discount</td>
			<td><asp:TextBox ID="DiscountTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>Commission</td>
			<td><asp:TextBox ID="CommissionTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
		</tr>
		<tr>
			<td>BrokerCode</td>
			<td><asp:TextBox ID="BrokerCodeTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
			<td>AppStatus</td>
			<td><asp:TextBox ID="AppStatusTextBox" runat="server" CssClass="form-control" Width="100"></asp:TextBox></td>
		</tr>
		<tr>
			<td><asp:Button ID="btnAdd" CssClass="btn btn-primary" runat="server" Text="Add" OnClick="btnAdd_Click"/></td>
		</tr>
	</table>
<asp:GridView ID="TemporaryDataGridView" runat="server" CssClass="mGrid" RowStyle-Font-Italic="true" AutoGenerateColumns="false"></asp:GridView>
<asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnAdd_Click"/>
<asp:GridView ID="DataGridView" runat="server" CssClass="mGrid" RowStyle-Font-Italic="true" AutoGenerateColumns="false"></asp:GridView>
	
</asp:Content>
