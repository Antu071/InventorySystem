using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
namespace InvantoryManagementSystem.Manager
{
	public class SupplierManager
	{
		 internal static DataTable GetAllSupplierInfo()
		 { 
			 return new SupplierGateway().GetAllSupplierInfo();
 	 	 }
		 internal static int InsertSupplierInfo(SupplierDAO objSupplierDAO)
		 { 
			 return new SupplierGateway().InsertSupplierInfo(objSupplierDAO);
 	 	 }
		 internal static int UpdateSupplierInfo(SupplierDAO objSupplierDAO)
		 { 
			 return new SupplierGateway().UpdateSupplierInfo(objSupplierDAO);
 	 	 }
		 internal static int DeleteSupplierInfo(SupplierDAO objSupplierDAO)
		 { 
			 return new SupplierGateway().DeleteSupplierInfo(objSupplierDAO);
 	 	 }

		internal static void DeleteSupplierById(string supplierid)
		{
			 new SupplierGateway().DeleteSupplierById(supplierid);
		}

		internal static DataTable GetAllSupplierInfoByID(string supplier_id)
		{
			return new SupplierGateway().GetAllSupplierInfoByID(supplier_id);
		}
	}
 }
