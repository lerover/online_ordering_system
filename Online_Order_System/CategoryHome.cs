using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Online_Order_System
{
    public partial class CategoryHome : Form
    {
        // SQL Server connection string
        private string dbstring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=online_ordering_system;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

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
            try
            {
                using (SqlConnection conn = new SqlConnection(dbstring))
                {
                    conn.Open();

                    string query = "SELECT categoryID, name, created_at FROM category";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewCategory.DataSource = dt;

                    dataGridViewCategory.Columns["categoryID"].HeaderText = "ID";
                    dataGridViewCategory.Columns["name"].HeaderText = "Category Name";
                    dataGridViewCategory.Columns["created_at"].HeaderText = "Create Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

            // Update button
            if (!dataGridViewCategory.Columns.Contains("btnUpdate"))
            {
                DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn
                {
                    HeaderText = "Update",
                    Name = "btnUpdate",
                    Text = "Update",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewCategory.Columns.Add(btnUpdate);
            }

            // Delete button
            if (!dataGridViewCategory.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "Delete",
                    Name = "btnDelete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewCategory.Columns.Add(btnDelete);
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

        private void dataGridViewCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dataGridViewCategory.Rows[e.RowIndex].Cells["categoryID"].Value.ToString();

                if (dataGridViewCategory.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlConnection conn = new SqlConnection(dbstring))
                            {
                                conn.Open();
                                string query = "DELETE FROM category WHERE categoryID = @id";

                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", id);
                                    int rows = cmd.ExecuteNonQuery();

                                    if (rows > 0)
                                    {
                                        MessageBox.Show("Deleted successfully!");
                                        LoadCategoryData();
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
                else if (dataGridViewCategory.Columns[e.ColumnIndex].Name == "btnUpdate")
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(dbstring))
                        {
                            conn.Open();
                            string query = "SELECT * FROM category WHERE categoryID = @id";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int categoryID = reader.GetInt32(reader.GetOrdinal("categoryID"));
                                        string name = reader.GetString(reader.GetOrdinal("name"));
                                        DateTime updated_at = reader.GetDateTime(reader.GetOrdinal("updated_at"));

                                        Frm_Category frm_category = new Frm_Category(categoryID, name, updated_at);
                                        frm_category.Show();
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
