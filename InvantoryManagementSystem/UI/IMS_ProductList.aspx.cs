using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Label = System.Web.UI.WebControls.Label;

namespace InvantoryManagementSystem.UI
{
    public partial class IMS_ProductList : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("IMS_Login.aspx", true);
                }

                FillGridProductList();
                
                DataTable dt = Product_ListManager.GetAllProduct_ListInfo();
                if(dt.Rows.Count!=0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string p_id = dt.Rows[i]["product_id"].ToString();
                        int newid = Int32.Parse(p_id);
                        int id = newid + 1;
                        this.txtproduct_id.Text = id.ToString();
                    }
                }
                else
                {
                    string p_id = "1001";
                    this.txtproduct_id.Text = p_id;
                }
                               
                txtproduct_id.Enabled = false;
               
            }
        }

        private void FillGridProductList()
        {
            DataTable dt = Product_ListManager.GetAllProduct_ListInfo();
            gv_ProductList.DataSource = dt;
            gv_ProductList.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            
            Product_ListDAO objproduct_ListDAO = new Product_ListDAO();

            objproduct_ListDAO.product_id = txtproduct_id.Text;
            objproduct_ListDAO.product_name = txtproduct_name.Text;

            if(txtproduct_name.Text!="")
            {
                int list = Product_ListManager.InsertProduct_ListInfo(objproduct_ListDAO);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Insert Product Name');", true);

            }
            Response.Redirect(Request.RawUrl);
            FillGridProductList();
        }

        protected void gv_ProductList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_ProductList.Rows[e.RowIndex];

            string product_id = ((Label)gv_ProductList.Rows[e.RowIndex].FindControl("lbl_product_id")).Text;
            Product_ListManager.DeleteProductById(product_id);
            FillGridProductList();
        }
    }
}