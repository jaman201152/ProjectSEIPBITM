﻿using StockManagementSystemUI.Company.BLL;
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

            SqlConnection _con = new SqlConnection(Model.Common.ConnectionString());
            string QueryDuplicate = @"SELECT COUNT(*) FROM Companies where Name='" + company.Name + "' ";

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
                bool isAdded = _companyManager.Add(company: company);
                if (isAdded)
                {
                    MessageBox.Show("Successfully Saved.");
                    nameTextBox.Clear();
                    CompanyLode();
                    return;

                }
                MessageBox.Show("Sory! Saved failed");
            }
           
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFormUI dashboard = new DashboardFormUI();
            dashboard.ShowDialog();
        }
    }
}
