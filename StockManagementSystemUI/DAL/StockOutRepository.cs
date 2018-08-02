using StockManagementSystemUI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemUI.DAL
{
   public class StockOutRepository
    {
       SqlConnection _con = new SqlConnection(Common.ConnectionString());

       public bool Add(Model.StockIn stockIn)
       {


           string query = @"INSERT INTO StockIn VALUES('" + stockIn.CampanyId + "','"
                               + stockIn.CategoryId + "','" + stockIn.ItemId + "','"
                               + stockIn.AvailableQuantity + "')";

           SqlCommand command = new SqlCommand(query, _con);
           _con.Open();

           bool isRowAffectred = command.ExecuteNonQuery() > 0;

           _con.Close();
           /// *************************** //

           string query_check_item = @"SELECT COUNT(*) FROM StockIn WHERE ItemId='" + stockIn.ItemId + "' ";

           SqlCommand command_check_item = new SqlCommand(query_check_item, _con);
           _con.Open();
           SqlDataAdapter dr = new SqlDataAdapter(command_check_item);
           DataTable dt = new DataTable();

           dr.Fill(dt);
           if (Convert.ToInt32(dt.Rows[0][0]) > 1)
           {
               // ************************

               _con.Close();

               // Show Item Available Quantity
               string queryItemAvailable = "SELECT * FROM ItemAvailableQuantity WHERE ItemId='" + stockIn.ItemId + "'";
               SqlCommand command_available = new SqlCommand(queryItemAvailable, _con);
               _con.Open();
               SqlDataReader drAvailable = command_available.ExecuteReader();
               if (drAvailable.Read())
               {
                   // student.Name = dr.GetValue(2).ToString();
                   int stockInUpdate = Convert.ToInt32(drAvailable["AvailableQuantity"]);
                   stockIn.AvailableQuantity = stockInUpdate + stockIn.AvailableQuantity;
               }
               _con.Close();
               // ****************** 
               string query_update = @"UPDATE ItemAvailableQuantity SET AvailableQuantity='" + stockIn.AvailableQuantity + "' WHERE ItemId='" + stockIn.ItemId + "' ";

               SqlCommand command_update = new SqlCommand(query_update, _con);
               _con.Open();

               bool isRowAffectred1 = command_update.ExecuteNonQuery() > 0;

               _con.Close();

               // ************************ //
           }
           else
           {
               // ************************
               _con.Close();
               string query1 = @"INSERT INTO ItemAvailableQuantity VALUES('" + stockIn.ItemId + "','"
                                  + stockIn.AvailableQuantity + "')";

               SqlCommand command1 = new SqlCommand(query1, _con);
               _con.Open();

               bool isRowAffectred1 = command1.ExecuteNonQuery() > 0;

               _con.Close();

               // ************************ //
           }


           return isRowAffectred;
       }


    }
}
