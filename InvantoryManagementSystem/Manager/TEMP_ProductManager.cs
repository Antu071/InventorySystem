using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
namespace InvantoryManagementSystem.Manager
{
	public class TEMP_ProductManager
	{
		 internal static DataTable GetAllTEMP_ProductInfo()
		 { 
			 return new TEMP_ProductGateway().GetAllTEMP_ProductInfo();
 	 	 }
		 internal static int InsertTEMP_ProductInfo(TEMP_ProductDAO objTEMP_ProductDAO)
		 { 
			 return new TEMP_ProductGateway().InsertTEMP_ProductInfo(objTEMP_ProductDAO);
 	 	 }
		 internal static int UpdateTEMP_ProductInfo(TEMP_ProductDAO objTEMP_ProductDAO)
		 { 
			 return new TEMP_ProductGateway().UpdateTEMP_ProductInfo(objTEMP_ProductDAO);
 	 	 }
		 internal static DataTable DeleteTEMP_ProductInfo()
		 { 
			 return new TEMP_ProductGateway().DeleteTEMP_ProductInfo();
 	 	 }

		internal static DataTable DeleteTEMP_ProductInfoByID(int id)
		{
			return new TEMP_ProductGateway().DeleteTEMP_ProductInfoByID(id);
		}

		internal static DataTable MakeInvoice()
		{
			return new TEMP_ProductGateway().MakeInvoice();
		}
	}
 }
