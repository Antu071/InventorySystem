using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;
using InvantoryManagementSystem.Manager;

namespace InvantoryManagementSystem.UI
{
    public partial class IMS_Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("IMS_Login.aspx", true);
                }

                FillStockGridView();
            }
        }

        private void FillStockGridView()
        {
            DataTable dt = StockManager.GetAllStockInfo();
            gv_stockdetails.DataSource = dt;
            gv_stockdetails.DataBind();
        }     
    }
}