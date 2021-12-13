using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
namespace InvantoryManagementSystem.Manager
{
	public class StockManager
	{
		 internal static DataTable GetAllStockInfo()
		 { 
			 return new StockGateway().GetAllStockInfo();
 	 	 }
		 internal static int InsertStockInfo(StockDAO objStockDAO)
		 { 
			 return new StockGateway().InsertStockInfo(objStockDAO);
 	 	 }
		 internal static int UpdateStockInfoByQuantity(decimal newQuantity, string product_name)
		 { 
			 return new StockGateway().UpdateStockInfoByQuantity(newQuantity, product_name);
 	 	 }
		internal static int UpdateStockInfo(StockDAO objStockDAO)
		{
			return new StockGateway().UpdateStockInfo(objStockDAO);
		}
		internal static int DeleteStockInfo(StockDAO objStockDAO)
		 { 
			 return new StockGateway().DeleteStockInfo(objStockDAO);
 	 	 }

		internal static int DeleteProductFromStockById(string product_id)
		{
			return new StockGateway().DeleteProductFromStockById(product_id);
		}

		internal static DataTable GetAllStockInfoByProductName(string name)
        {
			return new StockGateway().GetAllStockInfoByProductName(name);
		}

		internal static DataTable GetUnitPriceByProduct_Name(string product_name)
		{
			return new StockGateway().GetUnitPriceByProduct_Name(product_name);
		}

		internal static DataTable GetProduct_NameByID(string product_id)
		{
			return new StockGateway().GetProduct_NameByID(product_id);
		}

		internal static DataTable GetProductDetailsID(string product_id)
		{
			return new StockGateway().GetProductDetailsID(product_id);
		}


	}
 }
