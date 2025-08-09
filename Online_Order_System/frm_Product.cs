using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // Changed to SQL Server

namespace Online_Order_System
{
    public partial class frm_Product : Form
    {
        private string dbString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=online_ordering_system;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
        public frm_Product()
        {
            InitializeComponent();

            comboCategory();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frm_Product_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.Insert(0, "Select Category");

            string db = this.dbString;
            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    string query = "SELECT categoryID, name FROM category";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    DataRow placeholderRow = dt.NewRow();
                    placeholderRow["categoryID"] = 0;
                    placeholderRow["name"] = "Select Category";
                    dt.Rows.InsertAt(placeholderRow, 0);

                    comboBoxCategory.DataSource = dt;
                    comboBoxCategory.DisplayMember = "name";
                    comboBoxCategory.ValueMember = "categoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            numericUpDownQty.Minimum = 0;
            numericUpDownQty.Maximum = 100000;

            comboBoxCategory.SelectedIndex = 0;
        }

        private void comboCategory()
        {
            comboBoxCategory.Items.Insert(0, "Select Category");
            comboBoxCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int categoryID;
            int quantity;
            decimal price;

            if (comboBoxCategory.SelectedValue == null ||
                !int.TryParse(comboBoxCategory.SelectedValue.ToString(), out categoryID)
                || categoryID == 0)
            {
                MessageBox.Show("Please select a valid category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCategory.Focus();
                return;
            }

            string name = txtProductName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return;
            }

            quantity = (int)numericUpDownQty.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Please enter a valid, non-negative quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownQty.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("Please enter a valid, non-negative price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            string db = this.dbString;
            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    string query = "INSERT INTO product(NAME, categoryID, quantity, price) VALUES(@name, @categoryID, @quantity, @price)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@categoryID", categoryID);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@price", price);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            DialogResult success = MessageBox.Show("Product created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (success == DialogResult.OK)
                            {
                                numericUpDownQty.Value = 0;
                                txtProductName.Clear();
                                txtPrice.Clear();
                                comboBoxCategory.SelectedIndex = -1;
                                comboBoxCategory.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Product created failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            numericUpDownQty.Value = 0;
            txtProductName.Clear();
            txtPrice.Clear();
            comboBoxCategory.SelectedIndex = -1;
            comboBoxCategory.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProductName.Text) ||
                !string.IsNullOrWhiteSpace(txtPrice.Text) ||
                numericUpDownQty.Value != 0)
            {
                DialogResult warning = MessageBox.Show(
                    "You have unsaved changes. Are you sure you want to leave without saving?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (warning == DialogResult.Yes)
                {
                    this.exit();
                }
            }
            else
            {
                this.exit();
            }
        }

        private void exit()
        {
            productHome product = new productHome();
            product.Show();
            this.Hide();
        }
    }
}
