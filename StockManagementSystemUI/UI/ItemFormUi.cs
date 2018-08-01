﻿using System;
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

namespace StockManagementSystemUI.Item.UI
{
    public partial class ItemFormUi : Form
    {

        SqlConnection _con = new SqlConnection(Common.ConnectionString());
        public ItemFormUi()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFormUI dashboard = new DashboardFormUI();
            dashboard.ShowDialog();

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void ItemFormUi_Load(object sender, EventArgs e)
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
        ItemManager _itemManager = new ItemManager();
        private void SaveButton_Click(object sender, EventArgs e)
        {

            Model.Item item = new Model.Item();
            item.CategoryId = Convert.ToInt64(categoryComboBox.SelectedValue);
            item.CompanyId = Convert.ToInt64(companyComboBox.SelectedValue);
            item.Name = itemNameTextBox.Text;
            item.ReorderLabel = Convert.ToInt32(recorderTextBox.Text);

            string QueryDuplicate = @"SELECT COUNT(*) FROM Items where Name='" + item.Name
                                    + "' and CategoryId='" + item.CategoryId + "' and CompanyId='" + item.CompanyId + "' ";

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
                bool isAdded = _itemManager.Add(item);
                if (isAdded)
                {
                    MessageBox.Show("Successfully Added. ");
                    itemNameTextBox.Clear();
                    recorderTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Sorry! Added Failed.");
                }
            }

       


        }
    }
}
