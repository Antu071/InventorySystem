using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
using InvantoryManagementSystem.Manager;
using Label = System.Web.UI.WebControls.Label;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace InvantoryManagementSystem.UI
{
    public partial class IMS_Supplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("IMS_Login.aspx", true);
                }

                FillGridSupplier();
            }
        }

        private void FillGridSupplier()
        {
            DataTable dt = SupplierManager.GetAllSupplierInfo();
            gv_supplydetails.DataSource = dt;
            gv_supplydetails.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SupplierDAO objsupplierDAO = new SupplierDAO();
            int result = 0;
            string id = txtsupply_id.Text;
            DataTable dt = SupplierManager.GetAllSupplierInfoByID(id);
            objsupplierDAO.supplier_id = txtsupply_id.Text;
            objsupplierDAO.name = txtname.Text;
            objsupplierDAO.phone = txtphone.Text;

            if (objsupplierDAO.supplier_id != "" && objsupplierDAO.name != "" && objsupplierDAO.phone!="")
            {
                if(dt.Rows.Count==0)
                {
                    result = SupplierManager.InsertSupplierInfo(objsupplierDAO);
                    clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('ID Already Exist');", true);
                    
                }
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Name and Id Correctly');", true);
            }
            
            FillGridSupplier();
        }

        protected void gv_supplydetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_supplydetails.EditIndex = e.NewEditIndex;
            FillGridSupplier();
        }

        protected void gv_supplydetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_supplydetails.EditIndex = -1;
            FillGridSupplier();
        }

        protected void gv_supplydetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_supplydetails.Rows[e.RowIndex];

            string supplierid = ((Label)gv_supplydetails.Rows[e.RowIndex].FindControl("lblsupply_id")).Text;
            SupplierManager.DeleteSupplierById(supplierid);
            FillGridSupplier();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SupplierDAO objsupplierDAO = new SupplierDAO();
            int result = 0;
            string supplierid = txtsupply_id.Text;
            DataTable dt = SupplierManager.GetAllSupplierInfoByID(supplierid);

            objsupplierDAO.supplier_id = txtsupply_id.Text;
            objsupplierDAO.name = txtname.Text;
            objsupplierDAO.phone = txtphone.Text;

            if (dt.Rows.Count == 1 && objsupplierDAO.supplier_id != "" && objsupplierDAO.name != "")
            {
                result = SupplierManager.UpdateSupplierInfo(objsupplierDAO);
                clear();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please Enter Supplier ID and Supplier Name Correctly');", true);
            }
            FillGridSupplier();
        }

        protected void gv_supplydetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_supplydetails.SelectedRow;

            txtsupply_id.Text = (row.FindControl("lblsupply_id") as System.Web.UI.WebControls.Label).Text;
            string product_id = txtsupply_id.Text;

            DataTable dt = SupplierManager.GetAllSupplierInfoByID(product_id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtsupply_id.Text = dt.Rows[i]["supplier_id"].ToString();
                txtname.Text = dt.Rows[i]["name"].ToString();
                txtphone.Text = dt.Rows[i]["phone"].ToString();
            }
        }

        private void clear()
        {
            txtname.Text = string.Empty;
            txtsupply_id.Text = string.Empty;
            txtphone.Text = string.Empty;
        }
    }
}