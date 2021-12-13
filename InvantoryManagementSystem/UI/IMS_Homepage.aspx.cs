using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvantoryManagementSystem.UI
{
    public partial class IMS_Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("IMS_Login.aspx", true);                    
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Log In Successfull');", true);
            }
        }
    }
}