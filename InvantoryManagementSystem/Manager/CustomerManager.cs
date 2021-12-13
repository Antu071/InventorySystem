using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
namespace InvantoryManagementSystem.Manager
{
	public class CustomerManager
	{
		 internal static DataTable GetAllCustomerInfo()
		 { 
			 return new CustomerGateway().GetAllCustomerInfo();
 	 	 }

		internal static DataTable GetAllCustomerInfoByName(decimal product_quantity,decimal product_unitprice, DateTime buy_date, decimal totalamount, string product_name)
		{
			return new CustomerGateway().GetAllCustomerInfoByName(product_quantity,product_unitprice,buy_date,totalamount,product_name);
		}
		internal static int InsertCustomerInfo(CustomerDAO objCustomerDAO)
		 { 
			 return new CustomerGateway().InsertCustomerInfo(objCustomerDAO);
 	 	 }
		 internal static int UpdateCustomerInfo(CustomerDAO objCustomerDAO)
		 { 
			 return new CustomerGateway().UpdateCustomerInfo(objCustomerDAO);
 	 	 }
		 internal static int DeleteCustomerInfo(CustomerDAO objCustomerDAO)
		 { 
			 return new CustomerGateway().DeleteCustomerInfo(objCustomerDAO);
 	 	 }
 	}
 }
