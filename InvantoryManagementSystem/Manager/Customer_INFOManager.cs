using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
namespace InvantoryManagementSystem.Manager
{
	public class Customer_INFOManager
	{
		 internal static DataTable GetAllCustomer_INFOInfo()
		 { 
			 return new Customer_INFOGateway().GetAllCustomer_INFOInfo();
 	 	 }
		 internal static int InsertCustomer_INFOInfo(Customer_INFODAO objCustomer_INFODAO)
		 { 
			 return new Customer_INFOGateway().InsertCustomer_INFOInfo(objCustomer_INFODAO);
 	 	 }
		 internal static int UpdateCustomer_INFOInfo(Customer_INFODAO objCustomer_INFODAO)
		 { 
			 return new Customer_INFOGateway().UpdateCustomer_INFOInfo(objCustomer_INFODAO);
 	 	 }
		 internal static int DeleteCustomer_INFOInfo(Customer_INFODAO objCustomer_INFODAO)
		 { 
			 return new Customer_INFOGateway().DeleteCustomer_INFOInfo(objCustomer_INFODAO);
 	 	 }
 	}
 }
