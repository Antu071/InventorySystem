using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
namespace InvantoryManagementSystem.Gateway
{
	public class Product_ListGateway:DBConnector
	{

		internal DataTable GetAllProduct_ListInfo()
		{
			string query = "Select* From Product_List";
	 	 	return ExecuteQuery(query);
	 	}
		 internal int InsertProduct_ListInfo(Product_ListDAO objProduct_ListDAO)
		{
			string query = "Insert Into Product_List Values('" + objProduct_ListDAO.product_id +"','"+ objProduct_ListDAO.product_name+"')";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int UpdateProduct_ListInfo(Product_ListDAO objProduct_ListDAO)
		{ 
			string query = "Update Product_List Set product_name = '"+objProduct_ListDAO.product_name+ "' where product_id='"+objProduct_ListDAO.product_id+"'";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int DeleteProduct_ListInfo(Product_ListDAO objProduct_ListDAO)
		{ 
			string query = "DELETE from Product_List '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}

		internal DataTable GetAllProduct_ListInfoByID(string product_id)
		{
			string query = "Select product_name From Product_List where product_id='" + product_id + "'";
			return ExecuteQuery(query);
		}

		internal DataTable GetAllProduct_ListInfoByName(string product_name)
		{
			string query = "Select product_id From Product_List where product_name='" + product_name + "'";
			return ExecuteQuery(query);
		}

		internal void DeleteProductById(string product_id)
		{
			string query = "Delete From Product_List Where product_id='" + product_id + "'";
			ExecuteQuery(query);
		}
	}
}
