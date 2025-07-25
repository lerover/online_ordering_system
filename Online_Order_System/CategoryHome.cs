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
    }
}
