using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace InvantoryManagementSystem.DAO
{
	public class TEMP_ProductDAO
	{	 	
	 	 public int id { get; set; }
	 	 public string product_id { get; set; }
	 	 public string product_name { get; set; }
	 	 public decimal product_unitprice { get; set; }
	 	 public decimal product_quantity { get; set; }
	 	 public string supplier_id { get; set; }
		 public DateTime purchasedate { get; set; }
		 public decimal totalamount { get; set; }

	}
}
