﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IMS_ProductList.aspx.cs" Inherits="InvantoryManagementSystem.UI.IMS_ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>

        <legend>Input Product</legend>
        <table class="table table-borde">

            <tr>
                <td style="width: 127px">
                    <asp:Label ID="lblproduct_name" runat="server" Text="Product Name" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtproduct_name" runat="server" CssClass="form-control" Height="35px" Width="170px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 127px">
                    <asp:Label ID="lblproduct_id" runat="server" Text= "Product Id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtproduct_id" runat="server" CssClass= "form-control" Height="35px" Width="170px"></asp:TextBox>
                </td>
            </tr>
        </table>

    </fieldset>

    <fieldset>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnInsert" runat="server" Text="Insert Product" CssClass="btn btn-success" OnClick="btnInsert_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <br />
    <fieldset>
        <div style="height: 500px; width: 1200px; overflow: auto;">
            <asp:GridView ID="gv_ProductList" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered" AutoGenerateDeleteButton="true" OnRowDeleting="gv_ProductList_RowDeleting">

                <Columns>

                    <asp:TemplateField HeaderText="Product ID">
                        <ItemTemplate>
                            <asp:Label ID="lbl_product_id" Text='<%# Eval("product_id") %>' runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Name">
                        <ItemTemplate>
                            <asp:Label ID="lbl_product_name" Text='<%# Eval("product_name") %>' runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>
    </fieldset>

</asp:Content>