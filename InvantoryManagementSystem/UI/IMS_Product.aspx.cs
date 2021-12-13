using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
using InvantoryManagementSystem.Manager;
using Label = System.Web.UI.WebControls.Label;

namespace InvantoryManagementSystem.UI
{
    public partial class IMS_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //if (Session["username"] == null)
                //{
                //    Response.Redirect("IMS_Login.aspx", true);
                //}

                DataTable dt = SupplierManager.GetAllSupplierInfo();
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string p_id = dt.Rows[i]["supplier_id"].ToString();
                        int newid = Int32.Parse(p_id);
                        int id = newid + 1;
                        this.txtsupplier_id.Text = id.ToString();
                    }
                }
                else
                {
                    string p_id = "1100011";
                    this.txtsupplier_id.Text = p_id;
                }
                txtsupplier_id.Enabled = false;

                FillDropDownSupplier();
                FillDropDownProductName();
                FillGridViewInvoice();
                Calendar_purchase.Visible = false;
                txtpurchasedate.Text =(DateTime.Now).ToString();                               
            }
        }

        private void clear()
        {
            txtproduct_id.Text = string.Empty;
            dropdownProductName.SelectedValue = null;
            txtproduct_quantity.Text = string.Empty;
            txtproduct_unitprice.Text = string.Empty;
        }

        private void FillGridViewInvoice()
        {
            DataTable dt = TEMP_ProductManager.MakeInvoice();
            gv_purchaseinvoice.DataSource = dt;
            gv_purchaseinvoice.DataBind();
            decimal total = 0;
            for (int i = 0; i < gv_purchaseinvoice.Rows.Count; i++)
            {
                total += Convert.ToDecimal(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_totalamount")).Text);
                gv_purchaseinvoice.FooterRow.Cells[10].Text = "Total";
                gv_purchaseinvoice.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                gv_purchaseinvoice.FooterRow.Cells[11].Text = total.ToString("N2");
            }
            
            if(gv_purchaseinvoice.Rows.Count!=0)
            {
                btnInsert.Visible = true;
                btnInvoice.Visible = true;
            }
            else
            {
                btnInvoice.Visible = false;
                btnInsert.Visible = false;
            }
        }

        private void FillDropDownProductName()
        {
            DataTable dt = Product_ListManager.GetAllProduct_ListInfo();
            dropdownProductName.DataSource = dt;
            dropdownProductName.DataTextField = "product_name";
            dropdownProductName.DataValueField = "product_name";
            dropdownProductName.DataBind();
            dropdownProductName.Items.Insert(0, new ListItem("Product Name", "0"));
        }

        private void FillDropDownSupplier()
        {
            DataTable dt = SupplierManager.GetAllSupplierInfo();
            dropdownsupplier.DataSource = dt;
            dropdownsupplier.DataTextField = "supplier_id";
            dropdownsupplier.DataValueField = "supplier_id";
            dropdownsupplier.DataBind();
            dropdownsupplier.Items.Insert(0, new ListItem("Supplier ID", "0"));
        }

        protected void imgbtn_purchase_Click(object sender, ImageClickEventArgs e)
        {
            if(Calendar_purchase.Visible)
            {
                Calendar_purchase.Visible = false;
            }
            else
            {
                Calendar_purchase.Visible = true;
            }
            Calendar_purchase.Attributes.Add("style", "position:absolute");
        }

        protected void Calendar_purchase_SelectionChanged(object sender, EventArgs e)
        {
            txtpurchasedate.Text = Calendar_purchase.SelectedDate.ToString("dd/MM/yyyy");
            Calendar_purchase.Visible = false;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            sendEmail();
            ProductDAO objproductDAO = new ProductDAO();
            StockDAO objstockDAO = new StockDAO();
            
            string productid = txtproduct_id.Text;
            DataTable dt = ProductManager.GetAllProductInfoByID(productid);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string product_name = (dt.Rows[i]["product_name"].ToString());
                dropdownProductName.Text = product_name;
            }
            
                DataTable datatable = ProductManager.GetAllProductInfo();
                string invoiceNo = "";
                if (datatable.Rows.Count != 0)
                {
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        invoiceNo = datatable.Rows[i]["invoice_no"].ToString();
                        int newinvoice = Int32.Parse(invoiceNo);
                        int id = newinvoice + 1;
                        
                        invoiceNo = id.ToString();
                    }
                }
                else
                {
                    invoiceNo = "100100";                   
                }
                for (int i = 0; i < gv_purchaseinvoice.Rows.Count; i++)
                {
                    objproductDAO.invoice_no = invoiceNo;
                    objproductDAO.supplier_id = ((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_supplier_id")).Text;
                    objproductDAO.product_id = ((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_id")).Text;
                    objproductDAO.product_name = ((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_name")).Text;
                    objproductDAO.product_quantity = Convert.ToDecimal(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_quantity")).Text);
                    objproductDAO.product_unitprice = Convert.ToDecimal(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_unitprice")).Text);
                    objproductDAO.purchasedate = DateTime.Parse(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_buydate")).Text);                   

                    objstockDAO.product_id = ((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_id")).Text;
                    objstockDAO.product_name = ((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_name")).Text;
                    objstockDAO.product_quantity = Convert.ToDecimal(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_quantity")).Text);
                    objstockDAO.product_unitprice = Convert.ToDecimal(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_unitprice")).Text);
                    objstockDAO.purchasedate = DateTime.Parse(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_buydate")).Text);


                    
                        #region STOCK

                        DataTable dataTable = StockManager.GetProductDetailsID(objstockDAO.product_id);
                        for (int j = 0; j < dataTable.Rows.Count; j++)
                        {
                            decimal stockquantity = Convert.ToDecimal(dataTable.Rows[j]["product_quantity"].ToString());
                            decimal unitprice = Convert.ToDecimal(dataTable.Rows[j]["product_unitprice"].ToString());
                            objstockDAO.product_quantity = stockquantity + Convert.ToDecimal(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_quantity")).Text);
                            decimal old_price = stockquantity * unitprice;
                            decimal new_price = Convert.ToDecimal(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_quantity")).Text) * Convert.ToDecimal(((Label)gv_purchaseinvoice.Rows[i].FindControl("lbl_product_unitprice")).Text);
                            objstockDAO.product_unitprice = (old_price + new_price) / objstockDAO.product_quantity;
                        }

                        if (dataTable.Rows.Count == 0)
                        {

                            int insert_stock = StockManager.InsertStockInfo(objstockDAO);
                        }
                        else
                        {
                            int update_stock = StockManager.UpdateStockInfo(objstockDAO);
                        }

                        #endregion

                        int product_entry = ProductManager.InsertProductInfo(objproductDAO);
                             
                    
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
            
            
            
            btnInsert.Visible = false;
            dropdownsupplier.Enabled = true;
            gv_purchaseinvoice.Visible = false;
            

            gv_purchaseinvoice.DataSource = null;
            gv_purchaseinvoice.DataBind();
            
            TEMP_ProductManager.DeleteTEMP_ProductInfo();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
       
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductDAO objproductDAO = new ProductDAO();
            Product_ListDAO objproduct_ListDAO = new Product_ListDAO();
            StockDAO objstockDAO = new StockDAO();

            int result = 0;
            string productid = txtproduct_id.Text;
            DataTable dt = ProductManager.GetAllProductInfoByID(productid);

            if (txtproduct_id.Text != "" && txtproduct_quantity.Text != "" && txtproduct_unitprice.Text != "" && dropdownProductName.Text != "0" && dropdownsupplier.Text != "0")
            {
                objproductDAO.supplier_id = dropdownsupplier.Text;
                objproductDAO.product_id = txtproduct_id.Text;
                objproductDAO.product_name = dropdownProductName.Text;
                objproductDAO.product_quantity = Convert.ToDecimal(txtproduct_quantity.Text);
                objproductDAO.product_unitprice = Convert.ToDecimal(txtproduct_unitprice.Text);
                objproductDAO.purchasedate = DateTime.Parse(txtpurchasedate.Text);

                objstockDAO.product_id = txtproduct_id.Text;
                objstockDAO.product_name = dropdownProductName.Text;
                objstockDAO.product_quantity = Convert.ToDecimal(txtproduct_quantity.Text);
                objstockDAO.product_unitprice = Convert.ToDecimal(txtproduct_unitprice.Text);
                objstockDAO.purchasedate = DateTime.Parse(txtpurchasedate.Text);


                if (dt.Rows.Count == 1 && objproductDAO.product_id != "" && objproductDAO.product_name != "")
                {
                    result = ProductManager.UpdateProductInfo(objproductDAO);
                    int sctock = StockManager.UpdateStockInfo(objstockDAO);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
                    MessageBox.Show("Successfully Updated");
                    clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please Enter Product ID and Product Name Correctly');", true);
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Insert Correctly');", true);
            }

            
        }

        protected void dropdownProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string product_name = dropdownProductName.Text;
            DataTable dt = Product_ListManager.GetAllProduct_ListInfoByName(product_name);

            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string product_id = (dt.Rows[i]["product_id"].ToString());
                    txtproduct_id.Text = product_id.ToString();
                    txtproduct_id.Enabled = false;
                }
            }
            else
            {
                txtproduct_id.Text = string.Empty;
                txtproduct_id.Enabled = true;
            }
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            if (txtproduct_id.Text != "" && txtproduct_quantity.Text != "" && txtproduct_unitprice.Text != "" && dropdownProductName.Text != "0" && dropdownsupplier.Text != "0")
            {
                gv_purchaseinvoice.Visible = true;
                btnInsert.Visible = true;
                dropdownsupplier.Enabled = false;
                temp();
                FillGridViewInvoice();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Insert Correctly');", true);
            }
            
        }

        protected void gv_purchaseinvoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_purchaseinvoice.Rows[e.RowIndex];
            int id = int.Parse((row.FindControl("lblid") as System.Web.UI.WebControls.Label).Text);
            TEMP_ProductManager.DeleteTEMP_ProductInfoByID(id);

            FillGridViewInvoice();
        }

        private void temp()
        {
            TEMP_ProductDAO objtEMP_ProductDAO = new TEMP_ProductDAO();

            objtEMP_ProductDAO.supplier_id = dropdownsupplier.Text;
            objtEMP_ProductDAO.product_id = txtproduct_id.Text;
            objtEMP_ProductDAO.product_name = dropdownProductName.Text;          
            objtEMP_ProductDAO.product_quantity = Convert.ToDecimal(txtproduct_quantity.Text);           
            objtEMP_ProductDAO.product_unitprice = Convert.ToDecimal(txtproduct_unitprice.Text);
            objtEMP_ProductDAO.purchasedate = DateTime.Parse(txtpurchasedate.Text);
            objtEMP_ProductDAO.totalamount= Convert.ToDecimal(txtproduct_quantity.Text) * Convert.ToDecimal(txtproduct_unitprice.Text);

            int result = TEMP_ProductManager.InsertTEMP_ProductInfo(objtEMP_ProductDAO);
        }

        protected void btnInvoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("IMS_PurchaseInvoice.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SupplierDAO objSupplierDAO = new SupplierDAO();

            objSupplierDAO.supplier_id = txtsupplier_id.Text;
            objSupplierDAO.name = txtsuppliername.Text;
            objSupplierDAO.phone = txtsupplierphone.Text;
            objSupplierDAO.mail = txtsuppliermail.Text;

            SupplierManager.InsertSupplierInfo(objSupplierDAO);

        }

        private void sendEmail()
        {
            DataTable dt = TEMP_ProductManager.MakeInvoice();

            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Server.MapPath("~/Report/PurchaseInvoice.rpt"));
            reportDocument.SetDataSource(dt);

            Stream stream = reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            byte[] file = new byte[stream.Length];
            stream.Read(file, 0, (int)stream.Length);
            stream.Close();

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            message.From = new MailAddress("ashraful.prime24@gmail.com");
            message.To.Add(new MailAddress("morpheousantu@gmail.com"));
            message.Subject = "Purchase Invoice";
            message.Body = "Thanks For The Products";
            message.IsBodyHtml = true;

            smtp.Credentials = new NetworkCredential("ashraful.prime24@gmail.com", "prime10015624");
            smtp.Host = "smtp.gmail.com";
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            
            if (file != null)
            {
                message.Attachments.Add(new Attachment(new MemoryStream(file), "Invoice.pdf"));
            }

            smtp.Send(message);
        }
    }
}