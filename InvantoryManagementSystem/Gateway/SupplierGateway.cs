using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
namespace InvantoryManagementSystem.Gateway
{
	public class SupplierGateway:DBConnector
	{

		internal DataTable GetAllSupplierInfo()
		{
			string query = "Select* From Supplier";
	 	 	return ExecuteQuery(query);
	 	}
		 internal int InsertSupplierInfo(SupplierDAO objSupplierDAO)
		{
			string query = "Insert Into Supplier Values('" + objSupplierDAO.supplier_id +"','"+ objSupplierDAO.name +"','"+ objSupplierDAO.phone+ "','" + objSupplierDAO.mail + "')";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int UpdateSupplierInfo(SupplierDAO objSupplierDAO)
		{ 
			string query = "Update Supplier Set supplier_id='" + objSupplierDAO.supplier_id + "',name='" + objSupplierDAO.name + "',phone='" + objSupplierDAO.phone + "'where supplier_id='" + objSupplierDAO.supplier_id + "'";
			return ExecuteNonQuery(query);
	 	}
		 internal int DeleteSupplierInfo(SupplierDAO objSupplierDAO)
		{ 
			string query = "DELETE from Supplier '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}

		internal void DeleteSupplierById(string supplierid)
		{
			string query = "Delete From Supplier Where supplier_id='" + supplierid + "'";
			ExecuteQuery(query);
		}

		internal DataTable GetAllSupplierInfoByID(string supplier_id)
		{
			string query = "Select * From Supplier Where supplier_id='" + supplier_id + "'";
			return ExecuteQuery(query);
		}
	}
}
