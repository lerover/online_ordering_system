using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // Changed to SqlClient for SQL Server

namespace Online_Order_System
{
    public partial class frm_CustomerHome : Form
    {
        private int orderTotal = 0;
        private decimal grandPrice = 0;
        private string dbstring = "Server=localhost;Database=online_ordering_system;Trusted_Connection=True;";
        private decimal selectedProductPrice;
        private List<shoppingItem> shoppingItems = new List<shoppingItem>();
        private List<orderDetail> orderDetail = new List<orderDetail>();

        public frm_CustomerHome()
        {
            InitializeComponent();
            data_reload();
            this.paymentTypeSelect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbGrandTotal_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void data_reload()
        {
            string db = this.dbstring;
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

                    cboCategoryName.DataSource = dt;
                    cboCategoryName.DisplayMember = "name";
                    cboCategoryName.ValueMember = "categoryID";

                }
                this.productSelect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void btnNowOrder_Click(object sender, EventArgs e)
        {
            if (orderDetail.Count == 0)
            {
                MessageBox.Show("No product is selected", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboPaymentType.SelectedIndex == 0)
            {
                MessageBox.Show("Payment Type is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerID = Session.CustomerID;
            int orderTotal = this.orderTotal;
            decimal grandTotal = this.grandPrice;
            int paymentID = Convert.ToInt32(comboPaymentType.SelectedValue);
            DateTime selectedDate = dateTimePicker1.Value;

            string db = this.dbstring;

            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();

                    // Insert order and get inserted ID using OUTPUT INSERTED.orderID
                    string query = @"
                        INSERT INTO [order] (customerID, orderTotal, grandtotal, STATUS, paymentID, orderDate, customerName) 
                        OUTPUT INSERTED.orderID
                        VALUES (@customerID, @orderTotal, @grandtotal, @status, @paymentID, @orderDate, @customerName)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerID", customerID);
                        cmd.Parameters.AddWithValue("@orderTotal", orderTotal);
                        cmd.Parameters.AddWithValue("@grandtotal", grandTotal);
                        cmd.Parameters.AddWithValue("@status", "pending");
                        cmd.Parameters.AddWithValue("@paymentID", paymentID);
                        cmd.Parameters.AddWithValue("@orderDate", selectedDate);
                        cmd.Parameters.AddWithValue("@customerName", txtName.Text);

                        long orderID = Convert.ToInt64(cmd.ExecuteScalar());

                        string detailQuery = "INSERT INTO order_details (productID, orderID, totalQty, totalPrice) VALUES (@productID, @orderID, @totalQty, @totalPrice)";

                        foreach (var detail in orderDetail)
                        {
                            using (SqlCommand detailcmd = new SqlCommand(detailQuery, conn))
                            {
                                detailcmd.Parameters.AddWithValue("@productID", detail.productID);
                                detailcmd.Parameters.AddWithValue("@orderID", orderID); // use the ID you just got
                                detailcmd.Parameters.AddWithValue("@totalQty", detail.totalQty);
                                detailcmd.Parameters.AddWithValue("@totalPrice", detail.TotalPrice);

                                detailcmd.ExecuteNonQuery();
                            }
                        }
                        DialogResult finalResult = MessageBox.Show("Your order has been placed successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (finalResult == DialogResult.OK)
                        {
                            // Clear both lists
                            orderDetail.Clear();
                            shoppingItems.Clear();

                            dgvShoppingList.DataSource = null;
                            dgvShoppingList.DataSource = shoppingItems;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.productSelect();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = cboCategoryName.SelectedValue.ToString();
            this.productSelect(id);
        }

        private void productSelect(string condition = null)
        {
            string db = this.dbstring;

            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    string query;

                    if (condition != null)
                    {
                        query = $"SELECT productID, NAME, price FROM product WHERE categoryID = {condition}";
                    }
                    else
                    {
                        query = "SELECT productID, NAME, price FROM product";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    DataRow placeholderRow = dt.NewRow();
                    placeholderRow["productID"] = 0;
                    placeholderRow["NAME"] = "Select Product";
                    dt.Rows.InsertAt(placeholderRow, 0);

                    cboProduct.DataSource = dt;
                    cboProduct.DisplayMember = "NAME";
                    cboProduct.ValueMember = "productID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void paymentTypeSelect()
        {
            string db = this.dbstring;

            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    string query = "SELECT paymentID, NAME FROM [payment-methods]";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    DataRow placeholderRow = dt.NewRow();
                    placeholderRow["paymentID"] = 0;
                    placeholderRow["NAME"] = "Select Payment Type";
                    dt.Rows.InsertAt(placeholderRow, 0);

                    comboPaymentType.DataSource = dt;
                    comboPaymentType.DisplayMember = "NAME";
                    comboPaymentType.ValueMember = "paymentID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void cboProductName(object sender, EventArgs e)
        {

        }

        private void lblOrderName_Click(object sender, EventArgs e)
        {

        }

        private void frm_CustomerHome_Load(object sender, EventArgs e)
        {

        }

        private void cboProduct_selectedIndexChange(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex > 0)
            {
                if (cboProduct.SelectedItem is DataRowView row)
                {
                    try
                    {
                        object priceValue = row["price"];
                        txtTotalPrice.Text = priceValue.ToString();
                        this.selectedProductPrice = Convert.ToDecimal(priceValue);

                        nudtotalQty.Value = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Price error: " + ex.Message);
                        txtTotalPrice.Text = "0";
                    }
                }
            }
        }

        private void nudtotalQty_ValueChanged(object sender, EventArgs e)
        {
            int quantity = (int)nudtotalQty.Value;

            if (quantity > 0)
            {
                decimal finalPrice = this.selectedProductPrice * quantity;

                txtTotalPrice.Text = finalPrice.ToString();
            }
            else
            {
                txtTotalPrice.Text = this.selectedProductPrice.ToString();
            }
        }

        private void btnShoppingList_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            if (!decimal.TryParse(txtTotalPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid Price.");
                return;
            }

            int qty = (int)nudtotalQty.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.");
                return;
            }

            var selectedRow = cboProduct.SelectedItem as DataRowView;
            string productName = Convert.ToString(selectedRow["NAME"]);
            int productID = Convert.ToInt32(selectedRow["productID"]);
            shoppingItem item = new shoppingItem
            {
                productName = productName,
                TotalQty = qty,
                TotalPrice = Convert.ToDecimal(txtTotalPrice.Text),
            };

            orderDetail order = new orderDetail
            {
                productID = productID,
                totalQty = qty,
                TotalPrice = Convert.ToDecimal(txtTotalPrice.Text)
            };

            this.grandPrice += Convert.ToDecimal(txtTotalPrice.Text);
            this.orderTotal += qty;
            txtGrandTotal.Text = Convert.ToString(this.grandPrice);

            shoppingItems.Add(item);
            orderDetail.Add(order);

            dgvShoppingList.DataSource = null;
            dgvShoppingList.DataSource = shoppingItems;
        }

        private void comboPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
            // Clear both lists
            orderDetail.Clear();
            shoppingItems.Clear();

            dgvShoppingList.DataSource = null;
            dgvShoppingList.DataSource = shoppingItems;

            // Optional: show a message or reset UI
            MessageBox.Show("Order cancelled. Shopping list has been cleared.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            customerHome customerHome = new customerHome();
            customerHome.Show();
            this.Hide();
        }

        private void dgvShoppingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class shoppingItem
    {
        public string productName { get; set; }
        public int TotalQty { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class orderDetail
    {
        public int productID { get; set; }
        public int totalQty { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
