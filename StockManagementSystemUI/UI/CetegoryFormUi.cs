using StockManagementSystemUI.Category.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Model.Category category = new Model.Category();
            category.Name = nameTextBox.Text;
            bool isAdded = _CategoryManager.Add(category: category);
            if (isAdded)
            {
                MessageBox.Show("added");
                CategoryLode();
                return;

            }
            MessageBox.Show("failed");



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
