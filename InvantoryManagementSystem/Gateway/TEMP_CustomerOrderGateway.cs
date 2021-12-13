using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
namespace InvantoryManagementSystem.Gateway
{
	public class TEMP_CustomerOrderGateway:DBConnector
	{

		internal DataTable GetAllTEMP_CustomerOrderInfo()
		{
			string query = "Select* From TEMP_CustomerOrder";
	 	 	return ExecuteQuery(query);
	 	}
		 internal int InsertTEMP_CustomerOrderInfo(TEMP_CustomerOrderDAO objTEMP_CustomerOrderDAO)
		{
			string query = "Insert Into TEMP_CustomerOrder Values('" + objTEMP_CustomerOrderDAO.product_name +"','"+ objTEMP_CustomerOrderDAO.buy_date +"','"+ objTEMP_CustomerOrderDAO.product_quantity +"','"+ objTEMP_CustomerOrderDAO.product_unitprice +"','"+ objTEMP_CustomerOrderDAO.totalamount+ "','" + objTEMP_CustomerOrderDAO.customerid + "')";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int UpdateTEMP_CustomerOrderInfo(TEMP_CustomerOrderDAO objTEMP_CustomerOrderDAO)
		{ 
			string query = "Update TEMP_CustomerOrder Set ColumnName = '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}

        internal DataTable MakeInvoice()
        {
			string query = "select TEMP_CustomerOrder.id,TEMP_CustomerOrder.customerid,Customer_INFO.Name,Mail,Phone,Address,product_name,buy_date,product_quantity,product_unitprice,totalamount from TEMP_CustomerOrder inner join Customer_INFO on TEMP_CustomerOrder.customerid = Customer_INFO.CustomerID";
			return ExecuteQuery(query);
        }

        internal int DeleteTEMP_CustomerOrderInfo()
		{ 
			string query = "DELETE from TEMP_CustomerOrder";
	 	 	return ExecuteNonQuery(query);
	 	}

		internal DataTable DeleteTEMP_CustomerOrderInfoByID(int id)
		{
			string query = "DELETE from TEMP_CustomerOrder where id='" + id + "' ";
			return ExecuteQuery(query);
		}
	}
}
