using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // Changed to SQL Server namespace

namespace Online_Order_System
{
    public partial class orderPage : Form
    {
        public orderPage()
        {
            InitializeComponent();
            dataLoad();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            customerHome customer = new customerHome();
            customer.Show();
            this.Hide();
        }

        private void dataLoad()
        {
            string db = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=online_ordering_system;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"; ;
            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    int customerID = Session.CustomerID;
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
                                        [payment-methods] p ON o.paymentID = p.paymentID
                                    WHERE 
                                        o.customerID = @authID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@authID", customerID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvOrder.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            if (!dgvOrder.Columns.Contains("btnDetail"))
            {
                DataGridViewButtonColumn btnview = new DataGridViewButtonColumn();
                btnview.Name = "btnview";
                btnview.HeaderText = "Action";
                btnview.Text = "Detail";
                btnview.UseColumnTextForButtonValue = true;

                dgvOrder.Columns.Add(btnview);
            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrder.Columns[e.ColumnIndex].Name == "btnview")
            {
                var orderID = dgvOrder.Rows[e.RowIndex].Cells["orderID"].Value.ToString();

                orderDetailPage orderDetail = new orderDetailPage(orderID);
                orderDetail.Show();
                this.Hide();
            }
        }
    }
}
