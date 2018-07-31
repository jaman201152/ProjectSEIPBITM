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
using StockManagementSystemUI.BLL;
using StockManagementSystemUI.Model;

namespace StockManagementSystemUI.StockIn.UI
{
    public partial class StockInUi : Form
    {
        public StockInUi()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFormUI dashboard = new DashboardFormUI();
            dashboard.ShowDialog();

        }

        private void StockInUi_Load(object sender, EventArgs e)
        {


            // For Company Name Combo Box
            SqlConnection con = new SqlConnection(Common.ConnectionString());
            string query = "SELECT * FROM Companies";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            companyBindingSource.DataSource = dt;
            con.Close();

            // For Category Name Combo Box

            string queryCat = "SELECT * FROM Categories";
            SqlCommand comm = new SqlCommand(queryCat, con);
            con.Open();
            DataTable dtCat = new DataTable();
            SqlDataAdapter daCat = new SqlDataAdapter(comm);
            daCat.Fill(dtCat);
            categoryBindingSource.DataSource = dtCat;
            con.Close();

            // For Item Name Combo Box

            string queryItem = "SELECT * FROM Items";
            SqlCommand commItem = new SqlCommand(queryItem, con);
            con.Open();
            DataTable dtItem = new DataTable();
            SqlDataAdapter daItem = new SqlDataAdapter(commItem);
            daItem.Fill(dtItem);
            itemBindingSource.DataSource = dtItem;
            con.Close();

        }

        StockInManager _stockInManager = new StockInManager();
        private void SaveButton_Click(object sender, EventArgs e)
        {

            Model.StockIn stockIn = new Model.StockIn();

            stockIn.CampanyId = Convert.ToInt64(companyComboBox.SelectedValue);
            stockIn.CategoryId = Convert.ToInt64(categoryComboBox.SelectedValue);
            stockIn.ItemId = Convert.ToInt64(itemComboBox.SelectedValue);
            stockIn.AvailableQuantity = Convert.ToInt32(stokInTextBox.Text);
           bool isAdded = _stockInManager.Add(stockIn);

           if (isAdded)
           {
               MessageBox.Show("Successfully Added. ");
           }
           else
           {
               MessageBox.Show("Sry! Added Failed.");
           }

        }
    }
}
