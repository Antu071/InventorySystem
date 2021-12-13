<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IMS_Login.aspx.cs" Inherits="InvantoryManagementSystem.UI.IMS_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="../Content/style.css" rel="stylesheet"/>
        <div class="loginbox">
            <img src="../Photos/1234.jpg" alt="Alternate Text" class="user"/>
            <h2 class="h2">Login Here</h2>
            <br />
            <br />
            <asp:Label Text="Username" CssClass="lblusername" runat="server" />
            <asp:TextBox ID="txtbox_username" runat="server" CssClass="txtusername" placeholder="Enter Username"/>
            <asp:Label Text="Password" CssClass="lblpass" runat="server" ForeColor="White" />
            <asp:TextBox ID="txtbox_password" runat="server" CssClass="txtpass" placeholder=" ******** " TextMode="Password" />
            <asp:Label ID="lbl_checkvalidation" runat="server" Text="Invalid Username And Password" ForeColor="Yellow" Visible="false" />
            <asp:Button ID="btnLogin" runat="server" CssClass="btnsubmit" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
