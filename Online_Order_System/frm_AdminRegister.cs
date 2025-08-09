using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Changed from MySql.Data.MySqlClient

namespace Online_Order_System
{
    public partial class frm_AdminRegister : Form
    {
        // SQL Server connection string (Trusted Connection)
        string dbstring = "Server=localhost\\SQLEXPRESS;Database=online_ordering_system;Trusted_Connection=True;TrustServerCertificate=True;";

        public frm_AdminRegister()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void adminRegister_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtAdminName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdminName.Focus();
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

            // Database steps 
            string DBConnect = this.dbstring;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnect))
                {
                    conn.Open();

                    string validate = "SELECT COUNT(*) FROM admin WHERE adminName = @username";
                    SqlCommand cmd = new SqlCommand(validate, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Admin Name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string query = "INSERT INTO admin (adminName, password) VALUES (@username, @password)";
                        using (SqlCommand insertCmd = new SqlCommand(query, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@username", username);
                            insertCmd.Parameters.AddWithValue("@password", password);

                            int result = insertCmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                DialogResult success = MessageBox.Show("Account created Successfully!");
                                if (success == DialogResult.OK)
                                {
                                    frm_AdminLogin frm_AdminLogin = new frm_AdminLogin();
                                    frm_AdminLogin.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Failed to create account.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.Show();
            this.Hide();
        }
    }
}
