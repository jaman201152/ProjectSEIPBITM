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

namespace StockManagementSystemUI.StokOut.UI
{
    public partial class StockOutUi : Form
    {

        SqlConnection _con = new SqlConnection(Common.ConnectionString());

        public StockOutUi()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFormUI dashboard = new DashboardFormUI();
            dashboard.ShowDialog();
        }

        private void StockOutUi_Load(object sender, EventArgs e)
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

            // For Item Name Combo Box

            string queryItem = "SELECT * FROM Items";
            SqlCommand commItem = new SqlCommand(queryItem, _con);
            _con.Open();
            DataTable dtItem = new DataTable();
            SqlDataAdapter daItem = new SqlDataAdapter(commItem);
            daItem.Fill(dtItem);
            itemBindingSource.DataSource = dtItem;
            _con.Close();

        }
      

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            long itemId = Convert.ToInt64(itemComboBox.SelectedValue);

            // Show Reorder label
            string query = "SELECT * FROM Items WHERE Id='" + itemId + "'";
            SqlCommand command = new SqlCommand(query, _con);
            _con.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                // student.Name = dr.GetValue(2).ToString();
                reOrderLabel.Text = dr["ReorderLabel"].ToString();
            }

            _con.Close();

            // Show Item Available Quantity
            string queryItemAvailable = "SELECT * FROM ItemAvailableQuantity WHERE ItemId='" + itemId + "'";
            SqlCommand command_available = new SqlCommand(queryItemAvailable, _con);
            _con.Open();
            SqlDataReader drAvailable = command_available.ExecuteReader();
            if (drAvailable.Read())
            {
                // student.Name = dr.GetValue(2).ToString();
                availableQuantityLabel.Text = drAvailable["AvailableQuantity"].ToString();
            }
            else
            {
                availableQuantityLabel.Text = "0".ToString();
            }

            _con.Close();

        }

        List<StockOut> stockOutList = new List<StockOut>();
        StockOut stockOut = new StockOut();

        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (stockOutQuantityTextBox.Text.Length < 1)
            {
                MessageBox.Show("Enter StockOut Quantity.");
                return;
            }

            stockOut.CampanyId = Convert.ToInt64(companyComboBox.SelectedValue);
            stockOut.CategoryId = Convert.ToInt64(categoryComboBox.SelectedValue);
            stockOut.ItemId = Convert.ToInt64(itemComboBox.SelectedValue);
            stockOut.StockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);



            stockOutList.Add(stockOut);

            itemStockOutDataGridView.DataSource = stockOutList;

            stockOutQuantityTextBox.Clear();



        }
    }
}
