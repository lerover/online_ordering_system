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
    public partial class orderDetailPage : Form
    {
        private int orderID;
        public orderDetailPage(string id)
        {
            InitializeComponent();
            this.orderID = Convert.ToInt32(id);
            this.loadData(this.orderID);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            orderPage orderPage = new orderPage();
            orderPage.Show();
            this.Hide();
        }

        private void loadData(int id)
        {
            string db = "Server=localhost;Database=online_ordering_system;Trusted_Connection=True;";

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
