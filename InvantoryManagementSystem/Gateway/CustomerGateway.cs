using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
namespace InvantoryManagementSystem.Gateway
{
	public class CustomerGateway:DBConnector
	{

		internal DataTable GetAllCustomerInfo()
		{
			string query = "Select* From Customer";
	 	 	return ExecuteQuery(query);
	 	}

		internal DataTable GetAllCustomerInfoById(int id)
		{
			string query = "select product_quantity,buy_date from Customer where id='"+id+"'";
			return ExecuteQuery(query);
		}

		internal DataTable GetAllCustomerInfoByName(decimal product_quantity,decimal product_unitprice, DateTime buy_date, decimal totalamount,string product_name)
		{
			string query = "select '"+product_quantity+ "','" + product_unitprice + "','" + buy_date+"','"+ totalamount + "' from Customer where product_name='"+product_name+"'";
			return ExecuteQuery(query);
		}
		internal int InsertCustomerInfo(CustomerDAO objCustomerDAO)
		{
			string query = "Insert Into Customer Values('" + objCustomerDAO.product_name +"','"+ objCustomerDAO.product_quantity + "','" + objCustomerDAO.buy_date + "','" + objCustomerDAO.totalamount + "','"+ objCustomerDAO.product_unitprice+ "','" + objCustomerDAO.customerid + "')";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int UpdateCustomerInfo(CustomerDAO objCustomerDAO)
		{ 
			string query = "Update Customer Set ColumnName = '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int DeleteCustomerInfo(CustomerDAO objCustomerDAO)
		{ 
			string query = "DELETE from Customer '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}
	}
}
