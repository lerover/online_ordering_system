using Microsoft.Data.SqlClient;  // changed to SQL Server namespace
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Order_System
{
    public partial class productHome : Form
    {
        private string dbString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=online_ordering_system;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"; 
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
            this.productData();
        }

        private void productData()
        {
            string db = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=online_ordering_system;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"; ;
            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    string query =
                        @"SELECT p.productID AS product_id, p.NAME AS product_name, c.name AS category_name, p.quantity, p.price, p.created_at, p.updated_at 
                          FROM product p 
                          JOIN category c ON p.categoryID = c.categoryID";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewProduct.DataSource = dt;

                        dataGridViewProduct.Columns["product_id"].HeaderText = "ID";
                        dataGridViewProduct.Columns["product_name"].HeaderText = "Name";
                        dataGridViewProduct.Columns["category_name"].HeaderText = "Category Name";
                        dataGridViewProduct.Columns["quantity"].HeaderText = "Quantity";
                        dataGridViewProduct.Columns["price"].HeaderText = "Price";
                        dataGridViewProduct.Columns["created_at"].HeaderText = "Created At";
                        dataGridViewProduct.Columns["updated_at"].HeaderText = "Updated At";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

            if (!dataGridViewProduct.Columns.Contains("btnUpdate"))
            {
                DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn
                {
                    HeaderText = "Update",
                    Name = "btnUpdate",
                    Text = "Update",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewProduct.Columns.Add(btnUpdate);
            }

            if (!dataGridViewProduct.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "Delete",
                    Name = "btnDelete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };

                dataGridViewProduct.Columns.Add(btnDelete);
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
            // Optional paint event handler
        }

       

        private void dataGridViewProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dataGridViewProduct.Rows[e.RowIndex].Cells["product_id"].Value.ToString();
                string db = this.dbString;

                if (dataGridViewProduct.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlConnection conn = new SqlConnection(db))
                            {
                                conn.Open();
                                string query = "DELETE FROM product WHERE productID = @id";

                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", id);
                                    int rows = cmd.ExecuteNonQuery();

                                    if (rows > 0)
                                    {
                                        MessageBox.Show("Deleted successfully!");
                                        this.productData();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Delete failed or record not found.");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
                else if (dataGridViewProduct.Columns[e.ColumnIndex].Name == "btnUpdate")
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(db))
                        {
                            conn.Open();
                            string query = "SELECT * FROM product WHERE productID = @id";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int productID = reader.GetInt32(reader.GetOrdinal("productID"));
                                        int categoryID = reader.GetInt32(reader.GetOrdinal("categoryID"));
                                        decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                                        int quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                                        string name = reader.GetString(reader.GetOrdinal("name"));
                                        DateTime updated_at = reader.GetDateTime(reader.GetOrdinal("updated_at"));

                                        frm_Product frm_product = new frm_Product(name, quantity, price,categoryID,productID, updated_at);
                                        frm_product.Show();
                                        this.Hide();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
