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
using CrystalDecisions.Shared;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Manager;
using Label = System.Web.UI.WebControls.Label;

namespace InvantoryManagementSystem.UI
{
    public partial class IMS_Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["username"] == null)
                //{
                //    Response.Redirect("IMS_Login.aspx", true);
                //}

                DataTable dt = Customer_INFOManager.GetAllCustomer_INFOInfo();
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string p_id = dt.Rows[i]["CustomerID"].ToString();
                        int newid = Int32.Parse(p_id);
                        int id = newid + 1;
                        this.txtCustomerId.Text = id.ToString();
                    }
                }
                else
                {
                    string p_id = "1100011";
                    this.txtCustomerId.Text = p_id;
                }
                txtCustomerId.Enabled = false;

                Calendar_buydate.Visible = false;
                txtbuydate.Text = (DateTime.Now).ToString();
                FillDropdownProductname();
                FillDropdownCustomerid();
                FillGridViewCustomer();                
            }
        }

        private void FillDropdownCustomerid()
        {
            DataTable dt = Customer_INFOManager.GetAllCustomer_INFOInfo();
            dropdown_customerid.DataSource = dt;
            dropdown_customerid.DataTextField = "CustomerID";
            dropdown_customerid.DataValueField = "CustomerID";
            dropdown_customerid.DataBind();
            dropdown_customerid.Items.Insert(0, new ListItem("Customer ID", "0"));
        }

        private void FillGridViewCustomer()
        {
            string customerid = dropdown_customerid.Text;
            DataTable dt = TEMP_CustomerOrderManager.MakeInvoice();
            gv_orderdetails.DataSource = dt;
            gv_orderdetails.DataBind();

            decimal total = 0;
            for (int i = 0; i < gv_orderdetails.Rows.Count; i++)
            {
                total += Convert.ToDecimal(((Label)gv_orderdetails.Rows[i].FindControl("lbl_Amount")).Text);
                gv_orderdetails.FooterRow.Cells[10].Text = "Total";
                gv_orderdetails.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                gv_orderdetails.FooterRow.Cells[11].Text = total.ToString("N2");
            }
            if (gv_orderdetails.Rows.Count != 0)
            {
                btnConfirm.Visible = true;
                btnInvoice.Visible = true;
            }
            else
            {
                btnConfirm.Visible = false;
                btnInvoice.Visible = false;
            }
        }

        private void FillDropdownProductname()
        {
            DataTable dt = Product_ListManager.GetAllProduct_ListInfo();
            dropdown_productname.DataSource = dt;
            dropdown_productname.DataTextField = "product_name";
            dropdown_productname.DataValueField = "product_name";
            dropdown_productname.DataBind();
            dropdown_productname.Items.Insert(0, new ListItem("Product Name", "0"));
        }

        protected void imgbtn_buydate_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar_buydate.Visible)
            {
                Calendar_buydate.Visible = false;
            }
            else
            {
                Calendar_buydate.Visible = true;
            }
            Calendar_buydate.Attributes.Add("style", "position:absolute");
        }

        protected void Calendar_buydate_SelectionChanged(object sender, EventArgs e)
        {
            txtbuydate.Text = Calendar_buydate.SelectedDate.ToString("dd/MM/yyyy");
            Calendar_buydate.Visible = false;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            sendEmail();

            CustomerDAO objcustomerDAO = new CustomerDAO();
            StockDAO objstockDAO = new StockDAO();           

            int result = 0;

            for (int i = 0; i < gv_orderdetails.Rows.Count; i++)
            {
                objcustomerDAO.customerid = ((Label)gv_orderdetails.Rows[i].FindControl("lbl_customerid")).Text; ;
                objcustomerDAO.product_name= ((Label)gv_orderdetails.Rows[i].FindControl("lbl_product_name")).Text;
                objcustomerDAO.product_quantity =Convert.ToDecimal(((Label)gv_orderdetails.Rows[i].FindControl("lbl_product_quantity")).Text);
                objcustomerDAO.product_unitprice = Convert.ToDecimal(((Label)gv_orderdetails.Rows[i].FindControl("lbl_product_unitprice")).Text);
                objcustomerDAO.totalamount = Convert.ToDecimal(((Label)gv_orderdetails.Rows[i].FindControl("lbl_Amount")).Text);
                objcustomerDAO.buy_date = DateTime.Parse(((Label)gv_orderdetails.Rows[i].FindControl("lbl_buydate")).Text);

                int orderplaced = CustomerManager.InsertCustomerInfo(objcustomerDAO);

                DataTable dt = StockManager.GetAllStockInfoByProductName(objcustomerDAO.product_name);
                for (int j = 0; j < dt.Rows.Count;)
                {
                    decimal stockquantity = Convert.ToDecimal(dt.Rows[j]["product_quantity"].ToString());
                    decimal newQuantity = stockquantity - objcustomerDAO.product_quantity;
                    int finalquantity = StockManager.UpdateStockInfoByQuantity(newQuantity, objcustomerDAO.product_name);
                    break;
                }
            }
            TEMP_CustomerOrderManager.DeleteTEMP_CustomerOrderInfo();
            gv_orderdetails.Visible = false;
            FillGridViewCustomer();
            
        }

        private void clear()
        {
            FillDropdownProductname();
            txtproduct_quantity.Text = string.Empty;
            txtproduct_unitprice.Text = string.Empty;
            txtbuydate.Text = (DateTime.Now).ToString();
        }

        protected void gv_orderdetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropdown_productname.SelectedValue = gv_orderdetails.SelectedRow.Cells[2].Text;
            txtproduct_quantity.Text = gv_orderdetails.SelectedRow.Cells[5].Text;            
        }

        protected void gv_orderdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_orderdetails.Rows[e.RowIndex];
            int id = int.Parse((row.FindControl("lblid") as System.Web.UI.WebControls.Label).Text);
            TEMP_CustomerOrderManager.DeleteTEMP_CustomerOrderInfoByID(id);
            FillGridViewCustomer();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            gv_orderdetails.Visible = true;
            if(txtproduct_quantity.Text!="" && dropdown_productname.Text!="0" && txtproduct_unitprice.Text!="" && txtbuydate.Text!="")
            {
                DataTable dt = StockManager.GetAllStockInfoByProductName(dropdown_productname.Text);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal product_quantity = Convert.ToDecimal(dt.Rows[i]["product_quantity"].ToString());
                    if(product_quantity>=Convert.ToDecimal(txtproduct_quantity.Text))
                    {
                        temp();
                        FillGridViewCustomer();
                        clear();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Stock Unavailable');", true);
                    }
                }
                                                   
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Insert Correctly');", true);                
            }            
        }

        protected void dropdown_productname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedproduct_name = dropdown_productname.SelectedValue.ToString();
            DataTable dt = StockManager.GetUnitPriceByProduct_Name(selectedproduct_name);
            if(dt.Rows.Count!=0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal product_quantity = Convert.ToDecimal(dt.Rows[i]["product_quantity"].ToString());
                    if (product_quantity > 0)
                    {
                        decimal product_unitprice = Convert.ToDecimal(dt.Rows[i]["product_unitprice"].ToString());
                        txtproduct_unitprice.Text = product_unitprice.ToString();
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Stock Unavailable');", true);
                        clear();
                    }

                }
            }
            else
            {
                clear();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Stock Unavailable');", true);
            }
                                 
        }

        private void temp()
        {
            TEMP_CustomerOrderDAO objTEMP_CustomerOrderDAO = new TEMP_CustomerOrderDAO();

            objTEMP_CustomerOrderDAO.customerid = dropdown_customerid.Text;
            objTEMP_CustomerOrderDAO.product_name = dropdown_productname.Text;
            objTEMP_CustomerOrderDAO.buy_date = DateTime.Parse(txtbuydate.Text);
            objTEMP_CustomerOrderDAO.product_quantity = Convert.ToDecimal(txtproduct_quantity.Text);
            objTEMP_CustomerOrderDAO.product_unitprice= Convert.ToDecimal(txtproduct_unitprice.Text);
            objTEMP_CustomerOrderDAO.totalamount = Convert.ToDecimal(txtproduct_quantity.Text) * Convert.ToDecimal(txtproduct_unitprice.Text);

            int insert = TEMP_CustomerOrderManager.InsertTEMP_CustomerOrderInfo(objTEMP_CustomerOrderDAO);
        }

        protected void btnInvoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("IMS_Invoice.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Customer_INFODAO objCustomer_INFODAO = new Customer_INFODAO();

            objCustomer_INFODAO.customerid = txtCustomerId.Text;
            objCustomer_INFODAO.name = txtName.Text;
            objCustomer_INFODAO.phone = int.Parse(txtPhone.Text);
            objCustomer_INFODAO.mail = txtMail.Text;
            objCustomer_INFODAO.address = txtAddress.Text;

            Customer_INFOManager.InsertCustomer_INFOInfo(objCustomer_INFODAO);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        private void sendEmail()
        {
            DataTable dt = TEMP_CustomerOrderManager.MakeInvoice();

            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Server.MapPath("~/Report/Invoice.rpt"));
            reportDocument.SetDataSource(dt);

            Stream stream = reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            byte[] file = new byte[stream.Length];
            stream.Read(file, 0, (int)stream.Length);
            stream.Close();

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            message.From = new MailAddress("ashraful.prime24@gmail.com");
            message.To.Add(new MailAddress("morpheousantu@gmail.com"));
            message.Subject = "Invoice";
            message.Body = "Thanks For Buying";
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