using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
namespace InvantoryManagementSystem.Manager
{
	public class ProductManager
	{
		 internal static DataTable GetAllProductInfo()
		 { 
			 return new ProductGateway().GetAllProductInfo();
 	 	 }

		internal static DataTable GetAllProductInfoBYSupplierID()
		{
			return new ProductGateway().GetAllProductInfoBYSupplierID();
		}
		internal static int InsertProductInfo(ProductDAO objProductDAO)
		 { 
			 return new ProductGateway().InsertProductInfo(objProductDAO);
 	 	 }
		 internal static int UpdateProductInfo(ProductDAO objProductDAO)
		 { 
			 return new ProductGateway().UpdateProductInfo(objProductDAO);
 	 	 }
		 internal static int DeleteProductInfo(ProductDAO objProductDAO)
		 { 
			 return new ProductGateway().DeleteProductInfo(objProductDAO);
 	 	 }

		internal static DataTable GetAllProductInfoByID(string productid)
		{
			return new ProductGateway().GetAllProductInfoByID(productid);
		}

		internal static void DeleteProductByProductId(string productid)
		{
			new ProductGateway().DeleteProductByProductId(productid);
		}

		internal static void DeleteProductByProductDate(DateTime purchasedate)
		{
			new ProductGateway().DeleteProductByProductDate(purchasedate);
		}

		internal static DataTable TotalPrice(decimal product_quantity, decimal product_unitprice,string product_name)
		{
			return new ProductGateway().TotalPrice(product_quantity, product_unitprice, product_name);
		}
	}
 }
