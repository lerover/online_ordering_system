using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Online_Order_System
{
    public partial class adminOrderDetail : Form
    {
        private int orderID;

        public adminOrderDetail(string id)
        {
            InitializeComponent();
            this.orderID = Convert.ToInt32(id);
            this.loadData(this.orderID);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            adminOrderPage adminOrder = new adminOrderPage();
            adminOrder.Show();
            this.Hide();
        }

        private void loadData(int id)
        {
            // SQL Server connection string (change Data Source and credentials accordingly)
            string db = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=online_ordering_system;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"; ;

            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            p.NAME AS name,
                            od.totalQty,
                            od.totalPrice
                        FROM 
                            order_details od
                        JOIN 
                            [order] o ON o.orderID = od.orderID
                        JOIN 
                            product p ON p.productID = od.productID
                        WHERE 
                            od.orderID = @orderID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderID", id);

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
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
