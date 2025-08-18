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
        private string name;
        private int? quantity;
        private decimal? price;
        private int? categoryID;
        private int? productID;
        private DateTime? updated_at;

        private string dbString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=online_ordering_system;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
        public frm_Product(string name = null, int? quantity = null, decimal? price = null, int? categoryID = null, int? productID = null, DateTime? updated_at = null)
        {
            InitializeComponent();

            comboCategory();
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.categoryID = categoryID;
            this.productID = productID;
            this.updated_at = updated_at;

            comboBoxCategory.SelectedValue = this.categoryID;

            MessageBox.Show($"{this.categoryID.GetType()}");
            txtProductName.Text = this.name;
            numericUpDownQty.Value = Convert.ToDecimal(this.quantity);
            txtPrice.Text = Convert.ToString(this.price);


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
            string db = this.dbString;

            //this.name = name;
            //this.quantity = quantity;
            //this.price = price;
            //this.categoryID = categoryID;
            //this.productID = productID;
            //this.updated_at = updated_at;

            if (condition())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(db))
                    {
                        conn.Open();
                        string query = $"UPDATE product SET name=@name, categoryID=@categoryID,quantity=@quantity,price=@price, updated_at = @update_at WHERE productID = {this.productID}";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", txtProductName.Text);
                            cmd.Parameters.AddWithValue("@categoryID",comboBoxCategory.SelectedValue);
                            cmd.Parameters.AddWithValue("@quantity",numericUpDownQty.Value);
                            cmd.Parameters.AddWithValue("@price",txtPrice.Text);
                            cmd.Parameters.AddWithValue("@update_at", DateTime.Now);

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Category updated successfully!");
                                CategoryHome home = new CategoryHome();
                                home.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }

                return;
            }


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
    
        private bool condition()
        {
            return this.name != null && this.quantity != null && this.price != null && this.categoryID != null && this.productID != null && this.updated_at != null;
        }
    }
}
