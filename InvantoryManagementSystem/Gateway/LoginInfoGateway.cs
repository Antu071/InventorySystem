using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
namespace InvantoryManagementSystem.Gateway
{
	public class LoginInfoGateway:DBConnector
	{

		internal DataTable GetAllLoginInfoInfo()
		{
			string query = "Select* From LoginInfo";
	 	 	return ExecuteQuery(query);
	 	}
		 internal int InsertLoginInfoInfo(LoginInfoDAO objLoginInfoDAO)
		{
			string query = "Insert Into LoginInfo Values('" + objLoginInfoDAO.username +"','"+ objLoginInfoDAO.password+"')";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int UpdateLoginInfoInfo(LoginInfoDAO objLoginInfoDAO)
		{ 
			string query = "Update LoginInfo Set ColumnName = '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}
		 internal int DeleteLoginInfoInfo(LoginInfoDAO objLoginInfoDAO)
		{ 
			string query = "DELETE from LoginInfo '' WHERE employeeid= ''";
	 	 	return ExecuteNonQuery(query);
	 	}

        internal DataTable GetAllLoginInfoInfoByUsername(LoginInfoDAO objloginInfoDAO)
        {
			string query = "Select * From LoginInfo Where username = '" + objloginInfoDAO.username + "' and password = '" + objloginInfoDAO.password + "'";
			return ExecuteQuery(query);
		}
    }
}
