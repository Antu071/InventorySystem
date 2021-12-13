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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Manager;

namespace InvantoryManagementSystem.UI
{
    public partial class IMS_Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Invoice();
        }

        private void Invoice()
        {
            DataTable dt = TEMP_CustomerOrderManager.MakeInvoice();

            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Server.MapPath("~/Report/Invoice.rpt"));
            reportDocument.SetDataSource(dt);

            crviewer.ReportSource = reportDocument;
            reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Order Information");           
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
            message.Subject = "Subject";
            message.Body = "Body";
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