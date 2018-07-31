using StockManagementSystemUI.Category.BLL;
using StockManagementSystemUI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemUI.Category.DAL
{
    public class CategoryRepository
    {
        string connectionString = @"server=DESKTOP-BBIGD1E; database=StockManagementSystemBatch50; integrated security = true ";
        public bool Add(Model.Category category)
        {

            SqlConnection con = new SqlConnection(connectionString);

            string query = @"INSERT INTO Categorys VALUES('" + category.Name + "')";

            SqlCommand command = new SqlCommand(query, con);
            con.Open();

            bool isRowAffectred = command.ExecuteNonQuery() > 0;

            con.Close();

            return isRowAffectred;
        }

        internal DataTable CategoryLode(CategoryManager categoryManager)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM Categorys ORDER BY Id  DESC";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
