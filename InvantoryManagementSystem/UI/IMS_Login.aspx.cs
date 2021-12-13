using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Manager;

namespace InvantoryManagementSystem.UI
{
    public partial class IMS_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginInfoDAO objloginInfoDAO = new LoginInfoDAO();

            objloginInfoDAO.username = txtbox_username.Text;
            objloginInfoDAO.password = txtbox_password.Text;

            DataTable dt = LoginInfoManager.GetAllLoginInfoInfoByUsername(objloginInfoDAO);
            if (dt.Rows.Count != 0)
            {
                Session["username"] = txtbox_username.Text;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Login Successfull');", true);
                Response.Redirect("IMS_Homepage.aspx");
            }
            else
            {
                lbl_checkvalidation.Visible = true;
            }
        }
    }
}