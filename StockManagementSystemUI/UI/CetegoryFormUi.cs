using StockManagementSystemUI.Category.BLL;
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
using StockManagementSystemUI.Model;

namespace StockManagementSystemUI.Category.UI
{
    public partial class CetegoryFormUi : Form
    {
        CategoryManager _CategoryManager = new CategoryManager();

        public CetegoryFormUi()
        {
            InitializeComponent() ;
             CategoryLode();
        }
        private void CategoryLode()
        {
            DataTable getTable = _CategoryManager.CategoryLode(_CategoryManager);
             categoryBindingSource.DataSource = getTable;
            categoryDataGridView1.DataSource = categoryBindingSource;


        }
        SqlConnection _con = new SqlConnection(Model.Common.ConnectionString());
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Model.Category category = new Model.Category();
            category.Name = nameTextBox.Text;


            string QueryDuplicate = @"SELECT COUNT(*) FROM Categories where Name='" + category.Name + "' ";

            SqlCommand commandDuplicateCheck = new SqlCommand(QueryDuplicate, _con);
            DataTable ds = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(commandDuplicateCheck);
            da.Fill(ds);
            if (ds.Rows[0][0].ToString() == "1")
            {
                string msg = "Duplicate Entry not Allowed.";
                MessageBox.Show(msg);
            }
            else
            {
                bool isAdded = _CategoryManager.Add(category: category);
                if (isAdded)
                {
                    MessageBox.Show("Successfuly Saved.");
                    nameTextBox.Clear();
                    CategoryLode();
                    return;

                }
                MessageBox.Show("Sorry! failed.");
            }

           



        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFormUI dashboard = new DashboardFormUI();
            dashboard.ShowDialog();

        }
    }
}
