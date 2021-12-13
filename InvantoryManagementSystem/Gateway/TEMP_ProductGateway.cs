using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
namespace InvantoryManagementSystem.Gateway
{
	public class TEMP_ProductGateway:DBConnector
	{

		internal DataTable GetAllTEMP_ProductInfo()
		{
			string query = "Select* From TEMP_Product";
	 	 	return ExecuteQuery(query);
	 	}
		 internal int InsertTEMP_ProductInfo(TEMP_ProductDAO objTEMP_ProductDAO)
		{
			string query = "Insert Into TEMP_Product Values('" + objTEMP_ProductDAO.product_id +"','"+ objTEMP_ProductDAO.product_name +"','"+ objTEMP_ProductDAO.product_unitprice +"','"+ objTEMP_ProductDAO.product_quantity +"','"+ objTEMP_ProductDAO.supplier_id + "','" + objTEMP_ProductDAO.purchasedate + "','" + objTEMP_ProductDAO.totalamount + "')";
			return ExecuteNonQuery(query);
	 	}
		 internal int UpdateTEMP_ProductInfo(TEMP_ProductDAO objTEMP_ProductDAO)
		{ 
			string query = "Update TEMP_Product Set ColumnName = '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal DataTable DeleteTEMP_ProductInfo()
		{
			string query = "DELETE from TEMP_Product";
			return ExecuteQuery(query);
		}

		internal DataTable DeleteTEMP_ProductInfoByID(int id)
		{
			string query = "DELETE from TEMP_Product where id='" + id + "' ";
			return ExecuteQuery(query);
		}

		internal DataTable MakeInvoice()
        {
			string query = "select TEMP_Product.id,Supplier.supplier_id,name,phone,email,purchasedate,product_id,product_name,product_quantity,product_unitprice,totalamount from Supplier inner join TEMP_Product on Supplier.supplier_id = TEMP_Product.supplier_id";
			return ExecuteQuery(query);
		}
	}
}
