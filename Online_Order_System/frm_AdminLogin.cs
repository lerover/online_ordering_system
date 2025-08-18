using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Online_Order_System
{
    public partial class frm_AdminLogin : Form
    {
        int attemptFailed = 0;
        int countdownSeconds = 0;
        public frm_AdminLogin()
        {
            InitializeComponent();
            txtAdminPw.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtAdminName.Text;
            string password = txtAdminPw.Text;

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
                    txtAdminPw.Focus();
                    return;
                }

                if (password.Length <= 5)
                {
                    MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdminPw.Focus();
                    return;
                }
            }

            // Update this connection string with your actual SQL Server details
            string DBConnect = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=online_ordering_system;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
            // If you're using SQL Server Authentication, use:
            // string DBConnect = "Data Source=localhost;Initial Catalog=online_ordering_system;User ID=your_username;Password=your_password";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnect))
                {
                    conn.Open();

                    string query = "SELECT * FROM admin WHERE adminName = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            DialogResult success = MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (success == DialogResult.OK)
                            {
                                attemptFailed = 0;
                                AdminHome adminHome = new AdminHome();
                                adminHome.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            attemptFailed++;
                            if(attemptFailed >= 3)
                            {
                                MessageBox.Show("You've tried 3 times wrongly, try again in 2 minutes");
                                lockLogin();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void lockLogin()
        {
            countdownSeconds = 120;
            lblCountDown.Text = $"Try again in {countdownSeconds} seconds";
            btnLogin.Enabled = false;
            lockTimer.Start();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frm_AdminRegister frm_AdminRegister = new frm_AdminRegister();
            frm_AdminRegister.Show();
            this.Hide();
        }

        private void frm_AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lockTimer_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;
            lblCountDown.Text = $"Try again in {countdownSeconds} seconds";
            if (countdownSeconds <= 0)
            {
                lockTimer.Stop();
                lblCountDown.Text = "";
                btnLogin.Enabled = true;
                attemptFailed = 0;
            }
        }
    }
}
