using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;

namespace InvantoryManagementSystem.Gateway
{
	public class ProductGateway:DBConnector
	{

		internal DataTable GetAllProductInfo()
		{
			string query = "Select* From Product";
	 	 	return ExecuteQuery(query);
		}
		internal DataTable GetAllProductInfoBYSupplierID()
		{
			string query = "Select DISTINCT supplier_id From Product Where supplier_id IS NOT NULL ORDER BY supplier_id";
			return ExecuteQuery(query);
		}
		internal int InsertProductInfo(ProductDAO objProductDAO)
		{
			string query = "Insert Into Product Values('" + objProductDAO.product_id +"','"+ objProductDAO.product_name +"','"+ objProductDAO.product_unitprice +"','"+ objProductDAO.purchasedate +"','"+ objProductDAO.product_quantity+"','"+objProductDAO.supplier_id + "' ,'" + objProductDAO.invoice_no + "')";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int UpdateProductInfo(ProductDAO objProductDAO)
		{ 
			string query = "Update Product Set product_id='" + objProductDAO.product_id + "',product_name='" + objProductDAO.product_name + "',product_quantity='" + objProductDAO.product_quantity + "',product_unitprice='" + objProductDAO.product_unitprice + "',purchasedate='" + objProductDAO.purchasedate + "',supplier_id='" + objProductDAO.supplier_id + "' ,invoice_no='" + objProductDAO.invoice_no + "' where product_id='" + objProductDAO.product_id + "'";
			return ExecuteNonQuery(query);
	 	}
		 internal int DeleteProductInfo(ProductDAO objProductDAO)
		{ 
			string query = "DELETE from Product '' WHERE product_id= ''";
	 	 	return ExecuteNonQuery(query);
	 	}

		internal DataTable GetAllProductInfoByID(string productid)
		{
			string query = "Select * From Product Where product_id='" + productid + "'";
			return ExecuteQuery(query);
		}

		internal void DeleteProductByProductId(string productid)
		{
			string query = "Delete From Product Where product_id='" + productid + "'";
			ExecuteQuery(query);
		}

		internal void DeleteProductByProductDate(DateTime purchasedate)
		{
			string query = "Delete From Product Where purchasedate='" + purchasedate + "'";
			ExecuteQuery(query);
		}

		internal DataTable TotalPrice(decimal product_quantity, decimal product_unitprice,string product_name)
		{
			string query = "SELECT product_name,'"+ product_quantity + "' * '" + product_unitprice + "' AS Total_Price FROM Product where product_name='"+ product_name +"'";
			return ExecuteQuery(query);
		}
	}
}
