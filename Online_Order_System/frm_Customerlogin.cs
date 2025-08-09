using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // Changed from MySql.Data.MySqlClient
// Removed MySqlX.XDevAPI as it's MySQL-specific

namespace Online_Order_System
{
    public partial class frm_Customerlogin : Form
    {
        public frm_Customerlogin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password) || password.Length <= 5)
            {
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                if (password.Length <= 5)
                {
                    MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
            }

            string dbConnection = "Server=localhost;Database=online_ordering_system;Trusted_Connection=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(dbConnection))
                {
                    conn.Open();
                    string query = "SELECT * FROM customer WHERE customerName = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    int customerID = reader.GetInt32(reader.GetOrdinal("customerID"));
                                    Session.CustomerID = customerID;
                                }
                                DialogResult result = MessageBox.Show("Successfully Login", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (result == DialogResult.OK)
                                {
                                    customerHome customerHome = new customerHome();
                                    customerHome.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            frm_CustomerRegister frm_CustomerRegister = new frm_CustomerRegister();
            frm_CustomerRegister.Show();
            this.Hide();
        }

        private void gb1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.Show();
            this.Hide();
        }

        private void frm_Customerlogin_Load(object sender, EventArgs e)
        {

        }
    }

    public static class Session
    {
        public static int CustomerID { get; set; }
    }
}
