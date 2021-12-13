using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
namespace InvantoryManagementSystem.Manager
{
	public class Product_ListManager
	{
		 internal static DataTable GetAllProduct_ListInfo()
		 { 
			 return new Product_ListGateway().GetAllProduct_ListInfo();
 	 	 }
		 internal static int InsertProduct_ListInfo(Product_ListDAO objProduct_ListDAO)
		 { 
			 return new Product_ListGateway().InsertProduct_ListInfo(objProduct_ListDAO);
 	 	 }
		 internal static int UpdateProduct_ListInfo(Product_ListDAO objProduct_ListDAO)
		 { 
			 return new Product_ListGateway().UpdateProduct_ListInfo(objProduct_ListDAO);
 	 	 }
		 internal static int DeleteProduct_ListInfo(Product_ListDAO objProduct_ListDAO)
		 { 
			 return new Product_ListGateway().DeleteProduct_ListInfo(objProduct_ListDAO);
 	 	 }

		internal static DataTable GetAllProduct_ListInfoByID(string product_id)
		{
			return new Product_ListGateway().GetAllProduct_ListInfoByID(product_id);
		}

		internal static DataTable GetAllProduct_ListInfoByName(string product_name)
		{
			return new Product_ListGateway().GetAllProduct_ListInfoByName(product_name);
		}

        internal static void DeleteProductById(string product_id)
        {
			new Product_ListGateway().DeleteProductById(product_id);
		}
    }
 }
