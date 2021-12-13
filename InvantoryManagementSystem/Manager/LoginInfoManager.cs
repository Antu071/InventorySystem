using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using InvantoryManagementSystem.DAO;
using InvantoryManagementSystem.Gateway;
namespace InvantoryManagementSystem.Manager
{
	public class LoginInfoManager
	{
		 internal static DataTable GetAllLoginInfoInfo()
		 { 
			 return new LoginInfoGateway().GetAllLoginInfoInfo();
 	 	 }
		 internal static int InsertLoginInfoInfo(LoginInfoDAO objLoginInfoDAO)
		 { 
			 return new LoginInfoGateway().InsertLoginInfoInfo(objLoginInfoDAO);
 	 	 }
		 internal static int UpdateLoginInfoInfo(LoginInfoDAO objLoginInfoDAO)
		 { 
			 return new LoginInfoGateway().UpdateLoginInfoInfo(objLoginInfoDAO);
 	 	 }

        internal static DataTable GetAllLoginInfoInfoByUsername(LoginInfoDAO objloginInfoDAO)
        {
			return new LoginInfoGateway().GetAllLoginInfoInfoByUsername(objloginInfoDAO);
		}

        internal static int DeleteLoginInfoInfo(LoginInfoDAO objLoginInfoDAO)
		 { 
			 return new LoginInfoGateway().DeleteLoginInfoInfo(objLoginInfoDAO);
 	 	 }
 	}
 }
