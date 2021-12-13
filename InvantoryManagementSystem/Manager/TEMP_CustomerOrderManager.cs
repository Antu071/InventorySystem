using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
namespace InvantoryManagementSystem.Manager
{
	public class TEMP_CustomerOrderManager
	{
		 internal static DataTable GetAllTEMP_CustomerOrderInfo()
		 { 
			 return new TEMP_CustomerOrderGateway().GetAllTEMP_CustomerOrderInfo();
 	 	 }
		 internal static int InsertTEMP_CustomerOrderInfo(TEMP_CustomerOrderDAO objTEMP_CustomerOrderDAO)
		 { 
			 return new TEMP_CustomerOrderGateway().InsertTEMP_CustomerOrderInfo(objTEMP_CustomerOrderDAO);
 	 	 }
		 internal static int UpdateTEMP_CustomerOrderInfo(TEMP_CustomerOrderDAO objTEMP_CustomerOrderDAO)
		 { 
			 return new TEMP_CustomerOrderGateway().UpdateTEMP_CustomerOrderInfo(objTEMP_CustomerOrderDAO);
 	 	 }

        internal static DataTable MakeInvoice()
        {
			return new TEMP_CustomerOrderGateway().MakeInvoice();
		}

        internal static int DeleteTEMP_CustomerOrderInfo()
		 { 
			 return new TEMP_CustomerOrderGateway().DeleteTEMP_CustomerOrderInfo();
 	 	 }

		internal static DataTable DeleteTEMP_CustomerOrderInfoByID(int id)
		{
			return new TEMP_CustomerOrderGateway().DeleteTEMP_CustomerOrderInfoByID(id);
		}
	}
 }
