using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Online_Order_System
{
    public partial class adminOrderPage : Form
    {
        public adminOrderPage()
        {
            InitializeComponent();
            dataLoad();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            adminHome.Show();
            this.Hide();
        }

        private void dataLoad()
        {
            string db = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=online_ordering_system;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"; // Change as needed

            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            o.orderID,
                            c.customerName AS name,
                            o.orderTotal,
                            o.discount,
                            o.grandtotal,
                            o.STATUS,
                            p.NAME AS paymentName,
                            o.orderDate
                        FROM 
                            [order] o
                        JOIN 
                            customer c ON o.customerID = c.customerID
                        JOIN 
                            [payment-methods] p ON o.paymentID = p.paymentID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Me " + ex.Message);
            }

            if (!dataGridView1.Columns.Contains("btnview"))
            {
                DataGridViewButtonColumn btnview = new DataGridViewButtonColumn
                {
                    Name = "btnview",
                    HeaderText = "Action",
                    Text = "Detail",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(btnview);
            }

            if (!dataGridView1.Columns.Contains("btnAccept"))
            {
                DataGridViewButtonColumn btnAccept = new DataGridViewButtonColumn
                {
                    Name = "btnAccept",
                    HeaderText = "Action",
                    Text = "Accept",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(btnAccept);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnview")
            {
                var orderID = dataGridView1.Rows[e.RowIndex].Cells["orderID"].Value.ToString();

                adminOrderDetail orderDetail = new adminOrderDetail(orderID);
                orderDetail.Show();
                this.Hide();
            }

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnAccept")
            {
                var orderID = dataGridView1.Rows[e.RowIndex].Cells["orderID"].Value.ToString();

                string db = "Data Source=localhost;Initial Catalog=online_ordering_system;Integrated Security=True";

                try
                {
                    using (SqlConnection conn = new SqlConnection(db))
                    {
                        conn.Open();
                        string query = "UPDATE [order] SET STATUS = @status WHERE orderID = @orderID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@status", "accept");
                            cmd.Parameters.AddWithValue("@orderID", orderID);

                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Order status has been accepted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dataLoad();
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
