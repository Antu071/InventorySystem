using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
namespace InvantoryManagementSystem.Gateway
{
	public class Customer_INFOGateway:DBConnector
	{

		internal DataTable GetAllCustomer_INFOInfo()
		{
			string query = "Select* From Customer_INFO";
	 	 	return ExecuteQuery(query);
	 	}
		 internal int InsertCustomer_INFOInfo(Customer_INFODAO objCustomer_INFODAO)
		{
			string query = "Insert Into Customer_INFO Values('" + objCustomer_INFODAO.customerid +"','"+ objCustomer_INFODAO.name +"','"+ objCustomer_INFODAO.phone +"','"+ objCustomer_INFODAO.mail +"','"+ objCustomer_INFODAO.address+"')";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int UpdateCustomer_INFOInfo(Customer_INFODAO objCustomer_INFODAO)
		{ 
			string query = "Update Customer_INFO Set ColumnName = '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int DeleteCustomer_INFOInfo(Customer_INFODAO objCustomer_INFODAO)
		{ 
			string query = "DELETE from Customer_INFO '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}
	}
}
