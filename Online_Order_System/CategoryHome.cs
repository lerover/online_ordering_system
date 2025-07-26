using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Online_Order_System
{
    public partial class CategoryHome : Form
    {
        public CategoryHome()
        {
            InitializeComponent();
            dataGridViewCategory.AutoGenerateColumns = true;
            dataGridViewCategory.Visible = true;
            LoadCategoryData();
            dataGridViewCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void LoadCategoryData()
        {
            string db = "server=localhost; database=online_ordering_system; uid=root; password=";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db))
                {
                    conn.Open();

                    string query = "SELECT categoryID,name,created_at AS created_at FROM category";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                
                    dataGridViewCategory.DataSource = dt;

                    dataGridViewCategory.Columns["CategoryID"].HeaderText = "ID";
                    dataGridViewCategory.Columns["name"].HeaderText = "Category Name";
                    dataGridViewCategory.Columns["created_at"].HeaderText = "Create Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }


            //update
            DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
            btnUpdate.HeaderText = "Update";
            btnUpdate.Text = "Update";
            btnUpdate.UseColumnTextForButtonValue = true;
            dataGridViewCategory.Columns.Add(btnUpdate);

            // Add Delete button
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Delete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            dataGridViewCategory.Columns.Add(btnDelete);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Frm_Category frm_category = new Frm_Category();
            frm_category.Show();
            this.Hide();    
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            adminHome.Show();
            this.Hide();
        }

        private void dataGridViewCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if (dataGridViewCategory.Columns[e.ColumnIndex].HeaderText == "Update")
                {
                    string id = dataGridViewCategory.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                    DialogResult result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show($"Deleted Name : {id}");
                    }
                }
        }

    }
}
