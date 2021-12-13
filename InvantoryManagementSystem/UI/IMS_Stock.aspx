<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IMS_Stock.aspx.cs" Inherits="InvantoryManagementSystem.UI.IMS_Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>STOCK Available</legend>

        <div style="height: 500px; width: 1200px; overflow: auto;">

            <asp:GridView ID="gv_stockdetails" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered">

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
                    <asp:TemplateField HeaderText="Product Unitprice">
                        <ItemTemplate>
                            <asp:Label ID="lbl_product_unitprice" Text='<%# Eval("product_unitprice") %>' runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lbl_product_quantity" Text='<%# Eval("product_quantity") %>' runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Purchase Date">
                        <ItemTemplate>
                            <asp:Label ID="lbl_purchasedate" Text='<%# Eval("purchasedate") %>' runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>
    </fieldset>
</asp:Content>
