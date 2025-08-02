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
            
            string db = "server=localhost; database=online_ordering_system; uid=root;password=";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db))
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
                                        `order` o
                                    JOIN 
                                        customer c ON o.customerID = c.customerID
                                    JOIN 
                                        `payment-methods` p ON o.paymentID = p.paymentID
                                    WHERE 
                                        o.customerID = @authID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@authID", customerID);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
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
            if(e.RowIndex >= 0 && dgvOrder.Columns[e.ColumnIndex].Name == "btnview")
            {
                var orderID = dgvOrder.Rows[e.RowIndex].Cells["orderID"].Value.ToString();

                orderDetailPage orderDetail = new orderDetailPage(orderID);
                orderDetail.Show();
                this.Hide();
            }
        }
    }
}
