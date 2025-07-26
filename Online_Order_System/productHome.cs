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
    public partial class productHome : Form
    {
        public productHome()
        {
            InitializeComponent();
            dataGridViewProduct.ColumnHeadersVisible = true;
            dataGridViewProduct.AutoSize = true;
            dataGridViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frm_Product frm_Product = new frm_Product();
            frm_Product.Show();
            this.Hide();
        }

        private void productHome_Load(object sender, EventArgs e)
        {
            string db = "server=localhost; database=online_ordering_system; uid=root; password=";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db))
                {
                    conn.Open();
                    string query =
                        "Select p.NAME AS product_name,c.name AS category_name, p.quantity, p.price, p.created_at, p.updated_at From product p JOIN category c ON p.categoryID = c.categoryID";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewProduct.DataSource = dt;

                        dataGridViewProduct.Columns["product_name"].HeaderText = "Name";
                        dataGridViewProduct.Columns["category_name"].HeaderText = "Category Name";
                        dataGridViewProduct.Columns["quantity"].HeaderText = "Quantity";
                        dataGridViewProduct.Columns["price"].HeaderText = "Price";
                        dataGridViewProduct.Columns["created_at"].HeaderText = "Created At";
                        dataGridViewProduct.Columns["updated_at"].HeaderText = "Updated At";

                    }


                    //string query = "SELECT categoryID,name,created_at AS created_at FROM category";
                    //MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    //DataTable dt = new DataTable();
                    //adapter.Fill(dt);

                    //dataGridViewCategory.DataSource = dt;

                    //dataGridViewCategory.Columns["CategoryID"].HeaderText = "ID";
                    //dataGridViewCategory.Columns["name"].HeaderText = "Category Name";
                    //dataGridViewCategory.Columns["created_at"].HeaderText = "Create Date";
                }
            } catch (Exception ex) {
                MessageBox.Show("Error :" + ex.Message);
               }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            adminHome.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
