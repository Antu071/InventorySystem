using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace InvantoryManagementSystem.DAO
{
	public class TEMP_CustomerOrderDAO
	{	 	
	 	 public int id { get; set; }
	 	 public string product_name { get; set; }
	 	 public DateTime buy_date { get; set; }
	 	 public decimal product_quantity { get; set; }
	 	 public decimal product_unitprice { get; set; }
	 	 public decimal totalamount { get; set; }
		 public string customerid { get; set; }
	}
}
