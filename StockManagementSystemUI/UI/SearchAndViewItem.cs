using StockManagementSystemUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystemUI.UI
{
    public partial class SearchAndViewItem : Form
    {

        SqlConnection _con = new SqlConnection(Common.ConnectionString());
        public SearchAndViewItem()
        {
            InitializeComponent();
        }

        private void SearchAndViewItem_Load(object sender, EventArgs e)
        {
            // For Company Name Combo Box
            string query = "SELECT * FROM Companies";
            SqlCommand command = new SqlCommand(query, _con);
            _con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            companyBindingSource.DataSource = dt;
            _con.Close();

            // For Category Name Combo Box

            string queryCat = "SELECT * FROM Categories";
            SqlCommand comm = new SqlCommand(queryCat, _con);
            _con.Open();
            DataTable dtCat = new DataTable();
            SqlDataAdapter daCat = new SqlDataAdapter(comm);
            daCat.Fill(dtCat);
            categoryBindingSource.DataSource = dtCat;
            _con.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            long comId = Convert.ToInt64(companyComboBox.SelectedValue);
            long catId = Convert.ToInt64(categoryComboBox.SelectedValue);

            string queryCat = "SELECT i.Name ItemName,comp.Name CompanyName,cat.Name CategoryName,"
                +" iabl.AvailableQuantity AvailableQuantity,i.ReorderLabel ReorderLabel FROM Items i "
            +" INNER jOIN ItemAvailableQuantity iabl on i.Id=iabl.ItemId "
            +" INNER jOIN Companies comp on i.CompanyId=comp.Id "
            +" INNER jOIN Categories cat on i.CategoryId=cat.Id "
            + " WHERE comp.Id='" + comId + "' and cat.Id='" + catId + "'";
            SqlCommand comm = new SqlCommand(queryCat, _con);
            _con.Open();
            DataTable dtCat = new DataTable();
            SqlDataAdapter daCat = new SqlDataAdapter(comm);
            daCat.Fill(dtCat);
            ItemDataGridView.DataSource = dtCat;
            _con.Close();


        }
    }
}
