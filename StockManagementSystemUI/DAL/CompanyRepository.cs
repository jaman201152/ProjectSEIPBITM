using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemUI.Company.BLL;
using StockManagementSystemUI.Model;

namespace StockManagementSystemUI.Company.DAL
{
    public class CompanyRepository
    {
        string connectionString = @"server=DESKTOP-BBIGD1E; database=StockManagementSystemBatch50; integrated security = true ";
        public bool Add(Model.Company company)
        {

            SqlConnection con = new SqlConnection(connectionString);

            string query = @"INSERT INTO Companys VALUES('" + company.Name + "')";

            SqlCommand command = new SqlCommand(query, con);
            con.Open();

            bool isRowAffectred = command.ExecuteNonQuery() > 0;

            con.Close();

            return isRowAffectred;
        }

        internal DataTable CategoryLode(CompanyManager companyManager)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM Companys ORDER BY Id  DESC";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //internal bool Add(Model.Company company)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
