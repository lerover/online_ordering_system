using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Order_System
{
    public partial class paymentMethod : Form
    {
        public paymentMethod()
        {
            InitializeComponent();
            showData();
            datagridPaymentMethod.AutoGenerateColumns = true;
            datagridPaymentMethod.Visible = true;
            datagridPaymentMethod.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frm_payment frm_Payment = new frm_payment();
            frm_Payment.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            adminHome.Show();
            this.Hide();
        }

        private void showData()
        {
            string db = "server=localhost; database=online_ordering_system; uid=root; password=";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db))
                {
                    conn.Open();

                    string query = "SELECT NAME,created_at AS created_at FROM `payment-methods`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    datagridPaymentMethod.DataSource = dt;

                    datagridPaymentMethod.Columns["NAME"].HeaderText = "Payment Methods";
                    datagridPaymentMethod.Columns["created_at"].HeaderText = "Create Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
    }
}
