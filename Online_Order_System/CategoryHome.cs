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
        private string dbstring = "server=localhost; database=online_ordering_system; uid=root; password=";

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
            string db = this.dbstring;
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
            if (!dataGridViewCategory.Columns.Contains("btnUpdate"))
            {
                DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
                btnUpdate.HeaderText = "Update";
                btnUpdate.Name = "btnUpdate";
                btnUpdate.Text = "Update";
                btnUpdate.UseColumnTextForButtonValue = true;
                dataGridViewCategory.Columns.Add(btnUpdate);
            }


            // Add Delete button
            if (!dataGridViewCategory.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.HeaderText = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
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
            if (e.RowIndex >= 0) // fix: include first row (index 0)
            {
                if (dataGridViewCategory.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    string id = dataGridViewCategory.Rows[e.RowIndex].Cells["categoryID"].Value.ToString();

                    DialogResult result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        string db = this.dbstring;
                        try
                        {
                            using (MySqlConnection conn = new MySqlConnection(db))
                            {
                                conn.Open();
                                string query = "DELETE FROM category WHERE categoryID = @id";

                                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", id);
                                    int rows = cmd.ExecuteNonQuery();

                                    if (rows > 0)
                                    {
                                        MessageBox.Show("Deleted successfully!");
                                        // Optionally, refresh your DataGridView here
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
                            MessageBox.Show("Error : " + ex.Message);
                        }
                    }
                }
                else // Assume this is Edit or other column click
                {
                    string id = dataGridViewCategory.Rows[e.RowIndex].Cells["categoryID"].Value.ToString();

                    string db = this.dbstring;
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(db))
                        {
                            conn.Open();
                            string query = "SELECT * FROM category WHERE categoryID = @id";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);

                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int categoryID = reader.GetInt32("categoryID");
                                        string name = reader.GetString("name");
                                        DateTime updated_at = reader.GetDateTime("updated_at");

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
                        MessageBox.Show("Error : " + ex.Message);
                    }
                }
            }
        }

    }
}
