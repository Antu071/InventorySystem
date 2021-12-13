using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using PrimeApps.DAO;
//using PrimeApps.Manager;
namespace InvantoryManagementSystem.UI
{
	public partial class PR_PIInfo : System.Web.UI.Page
	{
		string companyName = "";
		string getUserName = "";
		string companyAccessType = "";
		string companyBusinessType = "";
 
		//PR_PIInfoDAO objPR_PIInfoDAO = new PR_PIInfoDAO();

	 	protected void Page_Load(object sender, EventArgs e)
	 	 { 
			if (Session["UserName"] != null) 
 			{ 
 				getUserName = Session["UserName"].ToString(); 
 			} 
 			else 
 			{ 
				Response.Redirect("../Pages/PR_Login.aspx"); 
			} 
 			if (Session["CompanyCode"] != null) 
 			{ 
				companyName = Session["CompanyCode"].ToString(); 
			} 
 
			//companyAccessType = CompanyAccessDefination.GetAccessDefination(getUserName, companyName);
			//companyBusinessType = CompanyAccessDefination.GetBusinessTypeDefination(getUserName, companyName);

			if (!IsPostBack)
			{
 			}
	 	 }

		//private void GetAllObjProperties()
		//{
		//	objPR_PIInfoDAO.pino="";
		//	objPR_PIInfoDAO.pidate="";
		//	objPR_PIInfoDAO.buyername="";
		//	objPR_PIInfoDAO.buyercode="";
		//	objPR_PIInfoDAO.yarncount="";
		//	objPR_PIInfoDAO.yarncode="";
		//	objPR_PIInfoDAO.rate="";
		//	objPR_PIInfoDAO.piquantity="";
		//	objPR_PIInfoDAO.pivalue="";
		//	objPR_PIInfoDAO.ref="";
		//	objPR_PIInfoDAO.companyid="";
		//	objPR_PIInfoDAO.lcstatus="";
		//	objPR_PIInfoDAO.lotno="";
		//	objPR_PIInfoDAO.deliveryplace="";
		//	objPR_PIInfoDAO.tbdfrom="";
		//	objPR_PIInfoDAO.spcomment="";
		//	objPR_PIInfoDAO.prodrefno="";
		//	objPR_PIInfoDAO.activemode="";
		//	objPR_PIInfoDAO.tenor="";
		//	objPR_PIInfoDAO.expirydate="";
		//	objPR_PIInfoDAO.inquiryno="";
		//	objPR_PIInfoDAO.discount="";
		//	objPR_PIInfoDAO.commission="";
		//	objPR_PIInfoDAO.brokercode="";
		//	objPR_PIInfoDAO.appstatus="";
		//}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			//objPR_PIInfoDAO.pino = "";
			//objPR_PIInfoDAO.pidate = "";
			//objPR_PIInfoDAO.buyername = "";
			//objPR_PIInfoDAO.buyercode = "";
			//objPR_PIInfoDAO.yarncount = "";
			//objPR_PIInfoDAO.yarncode = "";
			//objPR_PIInfoDAO.rate = "";
			//objPR_PIInfoDAO.piquantity = "";
			//objPR_PIInfoDAO.pivalue = "";
			//objPR_PIInfoDAO.ref= "";
			//objPR_PIInfoDAO.companyid = "";
			//objPR_PIInfoDAO.lcstatus = "";
			//objPR_PIInfoDAO.lotno = "";
			//objPR_PIInfoDAO.deliveryplace = "";
			//objPR_PIInfoDAO.tbdfrom = "";
			//objPR_PIInfoDAO.spcomment = "";
			//objPR_PIInfoDAO.prodrefno = "";
			//objPR_PIInfoDAO.activemode = "";
			//objPR_PIInfoDAO.tenor = "";
			//objPR_PIInfoDAO.expirydate = "";
			//objPR_PIInfoDAO.inquiryno = "";
			//objPR_PIInfoDAO.discount = "";
			//objPR_PIInfoDAO.commission = "";
			//objPR_PIInfoDAO.brokercode = "";
			//objPR_PIInfoDAO.appstatus = "";
		}
		protected void btnSave_Click(object sender, EventArgs e)
        {

        }
	} 
}
