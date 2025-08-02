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
            string db = "server=localhost; database=online_ordering_system; uid=root; password=";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(db))
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
                    `order` o ON o.orderID = od.orderID
                JOIN 
                    product p ON p.productID = od.productID
                WHERE 
                    od.orderID = @orderID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderID", id);

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
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
