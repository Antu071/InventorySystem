<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IMS_Product.aspx.cs" Inherits="InvantoryManagementSystem.UI.IMS_Product"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>

        <legend>Input Product Details</legend>

        <table class="table">
            <tr>
                <td style="width: 127px">

                    <asp:DropDownList ID="dropdownsupplier" runat="server" Height="35px" Width="170px" BackColor="WhiteSmoke" AutoPostBack="true"  ></asp:DropDownList>
                </td>

                <td>
                    <asp:DropDownList ID="dropdownProductName" runat="server" Height="35px" Width="170px" BackColor="WhiteSmoke" OnSelectedIndexChanged="dropdownProductName_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                </td>

                <td style="width: 127px">
                    <asp:Label ID="lblproduct_id" runat="server" Text="Product ID"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtproduct_id" runat="server" CssClass="form-control" AutoPostBack="true" Height="35px" Width="80px"></asp:TextBox>
                </td>

                <td style="width: 127px">
                    <asp:Label ID="lblproduct_quantity" runat="server" Text="Product Quantity"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtproduct_quantity" runat="server" CssClass="form-control" Height="35px" Width="80px" ></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator runat="server" ID="regQuantity" ForeColor="Red" ControlToValidate="txtproduct_quantity" ErrorMessage="Insert In Correct Format" ValidationExpression="^[0-9]+(\.[0-9][0-9]?)?"></asp:RegularExpressionValidator>
                </td>


                <td style="width: 127px">
                    <asp:Label ID="lblproduct_unitprice" runat="server" Text="Product Unit Price"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtproduct_unitprice" runat="server" CssClass="form-control" Height="35px" Width="80px" ></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator runat="server" ID="regPrice" ForeColor="Red" ControlToValidate="txtproduct_unitprice" ErrorMessage="Insert In Correct Format" ValidationExpression="^[0-9]+(\.[0-9][0-9]?)?"></asp:RegularExpressionValidator>
                </td>

                <td style="width: 127px">
                    <asp:Label ID="lblpurchasedate" runat="server" Text="Purchase Date"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtpurchasedate" runat="server" CssClass="form-control" AutoPostBack="true" Height="35px" Width="170px"></asp:TextBox>
                    <asp:ImageButton ID="imgbtn_purchase" runat="server" ImageUrl="~/Photos/clndr.png" Height="50px" Width="50px" OnClick="imgbtn_purchase_Click" ImageAlign="AbsBottom" Style="margin-left: 0px" />
                    <asp:Calendar ID="Calendar_purchase" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="200px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="200px" OnSelectionChanged="Calendar_purchase_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                        <DayStyle Width="14%" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                        <TodayDayStyle BackColor="#CCCC99" />
                    </asp:Calendar>
                </td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
        <table class="table">
            <tr>
                <td style="width: 127px">
                    <asp:Button ID="btnPurchase" runat="server" Text="Add Product" CssClass="btn btn-primary" OnClick="btnPurchase_Click" UseSubmitBehavior="false" />
                </td>
                <td></td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" Visible="false" OnClick="btnUpdate_Click" UseSubmitBehavior="false" />
                </td>
            </tr>
        </table>
    </fieldset>
    <input type="button" id="btnAddSupplier" class="btn btn-primary" value="Add New Supplier" style="float: right;" />
    <br />
    <br />
    <br />
    <fieldset>
        <legend>Purchase Details</legend>
        <div style="height: 500px; width: 1200px; overflow: auto;">
            <asp:GridView ID="gv_purchaseinvoice" runat="server" CssClass="table table-hover table-bordered" AutoGenerateColumns="false" ShowFooter="true" AutoGenerateDeleteButton="true" OnRowDeleting="gv_purchaseinvoice_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="id">
                        <ItemTemplate>
                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier ID">
                        <ItemTemplate>
                            <asp:Label ID="lbl_supplier_id" Text='<%# Eval("supplier_id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Supplier Name">
                        <ItemTemplate>
                            <asp:Label ID="lbl_supplier_name" Text='<%# Eval("name") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Phone Number">
                        <ItemTemplate>
                            <asp:Label ID="lbl_supplier_phone" Text='<%# Eval("phone") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Supplier Email">
                        <ItemTemplate>
                            <asp:Label ID="lbl_supplier_email" Text='<%# Eval("email") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product ID">
                        <ItemTemplate>
                            <asp:Label ID="lbl_product_id" Text='<%# Eval("product_id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Name">
                        <ItemTemplate>
                            <asp:Label ID="lbl_product_name" Text='<%# Eval("product_name") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="lbl_buydate" Text='<%# Eval("purchasedate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lbl_product_quantity" Text='<%# Eval("product_quantity") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Product Unit Price">
                        <ItemTemplate>
                            <asp:Label ID="lbl_product_unitprice" Text='<%# Eval("product_unitprice") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total Price">
                        <ItemTemplate>
                            <asp:Label ID="lbl_totalamount" runat="server" Text='<%# Eval("totalamount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnInvoice" runat="server" Text="Invoice" CssClass="btn btn-primary" Visible="false" OnClick="btnInvoice_Click" UseSubmitBehavior="false" />
            <asp:Button ID="btnInsert" runat="server" Text="Confirm" CssClass="btn btn-success" Visible="false" OnClick="btnInsert_Click" Style="float: right;" UseSubmitBehavior="false" />
            <br />
            <br />            
        </div>
    </fieldset>

    
    <formview>
        <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
        <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
        <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
            media="screen" />
        &nbsp;<script type="text/javascript">
                  $(function () {
                      $("#btnAddSupplier").click(function () {
                          $('#AddSupplierModal').modal('show');
                      });
                  });
        </script>
        <div class="modal fade" id="AddSupplierModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;</button>
                        <h4 class="modal-title" id="ModalTitle">Supplier Information</h4>
                    </div>
                    <div class="modal-body">
                        <table>
                            <tr>
                                <td>
                                    <label for="lblsupplier_id">
                                        SupplierID</label>
                                    <asp:TextBox ID="txtsupplier_id" runat="server" CssClass="form-control" placeholder="Enter SupplierID"
                                        required />
                                    <br />
                                </td>
                                <td>
                                    <label for="lblname">
                                        Supplier Name</label>
                                    <asp:TextBox ID="txtsuppliername" runat="server" CssClass="form-control" placeholder="Enter Name"
                                        required />
                                    <br />
                                </td>
                                <td>
                                    <label for="lblphone">
                                        Phone</label>
                                    <asp:TextBox ID="txtsupplierphone" runat="server" CssClass="form-control" placeholder="Enter Phone Number"
                                        required />
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <label for="lblmail">
                                        Email</label>
                                    <asp:TextBox ID="txtsuppliermail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter Email"
                                        required />
                                    <br />
                                </td>
                            </tr>
                        </table>

                        <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
                            <strong>Error!</strong>
                            <asp:Label ID="lblMessage" runat="server" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAdd" Text="Add" runat="server" OnClick="btnAdd_Click" Class="btn btn-primary" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
    </formview>

</asp:Content>
 