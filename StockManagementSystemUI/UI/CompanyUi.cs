using StockManagementSystemUI.Company.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystemUI.Company.UI
{
    public partial class CompanyUi : Form
    {
        CompanyManager _companyManager = new CompanyManager();

        public CompanyUi()
        {
            InitializeComponent();
            CompanyLode();
        }


        private void CompanyLode()
        {
            DataTable getTable = _companyManager.CategoryLode(_companyManager);
            companyBindingSource.DataSource = getTable;
            companyDataGridView1.DataSource = companyBindingSource;


        }



        private void SaveButton_Click(object sender, EventArgs e)
        {
            Model.Company company = new Model.Company();
            company.Name = nameTextBox.Text;
            bool isAdded = _companyManager.Add(company: company);
            if (isAdded)
            {
                MessageBox.Show("added");
                CompanyLode();
                return;

            }
            MessageBox.Show("failed");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFormUI dashboard = new DashboardFormUI();
            dashboard.ShowDialog();
        }
    }
}
