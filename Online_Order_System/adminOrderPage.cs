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

            string db = "server=localhost; database=online_ordering_system; uid=root;password=";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db))
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
                                        `order` o
                                    JOIN 
                                        customer c ON o.customerID = c.customerID
                                    JOIN 
                                        `payment-methods` p ON o.paymentID = p.paymentID
                                   ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
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
                MessageBox.Show("Error :" + ex.Message);
            }
            if (!dataGridView1.Columns.Contains("btnview"))
            {
                DataGridViewButtonColumn btnview = new DataGridViewButtonColumn();
                btnview.Name = "btnview";
                btnview.HeaderText = "Action";
                btnview.Text = "Detail";
                btnview.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(btnview);
            }
            if (!dataGridView1.Columns.Contains("btnAccept"))
            {
                DataGridViewButtonColumn btnAccept = new DataGridViewButtonColumn();
                btnAccept.Name = "btnAccept";
                btnAccept.HeaderText = "Action";
                btnAccept.Text = "Accept";
                btnAccept.UseColumnTextForButtonValue = true;

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

                string db = "server=localhost;database=online_ordering_system;uid=root;password=";

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(db))
                    {
                        conn.Open();
                        string query = "UPDATE `order` SET STATUS = @status WHERE orderID = @orderID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@status", "accept"); // or "active" for consistency
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

            //private void DataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
            //{
            //    if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnview")
            //    {
            //        var orderID = dataGridView1.Rows[e.RowIndex].Cells["orderID"].Value.ToString();

            //        orderDetailPage orderDetail = new orderDetailPage(orderID);
            //        orderDetail.Show();
            //        this.Hide();
            //    }
            //    throw new System.NotImplementedException();
            //}
        }
    }
}
