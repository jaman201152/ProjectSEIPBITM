using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemUI.Model;

namespace StockManagementSystemUI.DAL
{
   public class StockInRepository
    {
       public bool Add(Model.StockIn stockIn)
       {
           SqlConnection con = new SqlConnection(Common.ConnectionString());

           string query = @"INSERT INTO StockIn VALUES('" + stockIn.CampanyId + "','"
                               + stockIn.CategoryId + "','" + stockIn.ItemId + "','"
                               + stockIn.AvailableQuantity + "')";

           SqlCommand command = new SqlCommand(query, con);
           con.Open();

           bool isRowAffectred = command.ExecuteNonQuery() > 0;

           con.Close();

           return isRowAffectred;
       }
    }
}
