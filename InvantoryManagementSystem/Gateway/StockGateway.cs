using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
namespace InvantoryManagementSystem.Gateway
{
	public class StockGateway:DBConnector
	{

		internal DataTable GetAllStockInfo()
		{
			string query = "Select* From Stock";
	 	 	return ExecuteQuery(query);
	 	}
		 internal int InsertStockInfo(StockDAO objStockDAO)
		{
			string query = "Insert Into Stock Values('" + objStockDAO.product_id +"','"+ objStockDAO.product_name +"','"+ objStockDAO.product_quantity +"','"+ objStockDAO.product_unitprice +"','"+ objStockDAO.purchasedate+"')";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int UpdateStockInfoByQuantity(decimal newQuantity, string product_name)
		{ 
			string query = "Update Stock Set product_quantity = '"+newQuantity+"' WHERE product_name= '"+ product_name + "'";
	 	 	return ExecuteNonQuery(query);
	 	}

		internal int UpdateStockInfo(StockDAO objStockDAO)
        {
			string query = "Update Stock Set product_name = '" + objStockDAO.product_name + "',product_quantity='"+objStockDAO.product_quantity+ "',product_unitprice='"+objStockDAO.product_unitprice+ "',purchasedate='"+objStockDAO.purchasedate+ "' WHERE product_id= '" + objStockDAO.product_id + "'";
			return ExecuteNonQuery(query);
		}
		 internal int DeleteStockInfo(StockDAO objStockDAO)
		{ 
			string query = "DELETE from Stock '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}

		internal int DeleteProductFromStockById(string product_id)
		{
			string query = "Delete From Stock Where product_id='" + product_id + "'";
			return ExecuteNonQuery(query);
		}

		internal DataTable GetAllStockInfoByProductName(string name)
        {
			string query = "Select product_quantity from Stock where product_name='"+name+"'";
			return ExecuteQuery(query);
		}
		internal DataTable GetUnitPriceByProduct_Name(string product_name)
        {
			string query = "select product_unitprice,product_quantity from Stock where product_name='" + product_name + "'";
			return ExecuteQuery(query);
		}

		internal DataTable GetProduct_NameByID(string product_id)
		{
			string query = "select product_name from Stock where product_id='" + product_id + "'";
			return ExecuteQuery(query);
		}


		internal DataTable GetProductDetailsID(string product_id)
		{
			string query = "select * from Stock where product_id='" + product_id + "'";
			return ExecuteQuery(query);
		}

	}
}
