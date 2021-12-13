using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvantoryManagementSystem
{
    public partial class SiteMaster : MasterPage
    {
        string urlPath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                urlPath = HttpContext.Current.Request.Url.AbsolutePath;
                
            }
            
        }
    }
}