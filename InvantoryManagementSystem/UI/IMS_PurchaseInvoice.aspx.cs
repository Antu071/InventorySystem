using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using InvantoryManagementSystem.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvantoryManagementSystem.UI
{
    public partial class IMS_PurchaseInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PurchaseInvoice();
        }

        private void PurchaseInvoice()
        {
            DataTable dt = TEMP_ProductManager.MakeInvoice();

            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Server.MapPath("~/Report/PurchaseInvoice.rpt"));
            reportDocument.SetDataSource(dt);

            crviewer.ReportSource = reportDocument;
            reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Order Information");
            
        }
    }
}