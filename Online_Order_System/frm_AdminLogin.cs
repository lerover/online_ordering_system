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
    public partial class frm_AdminLogin : Form
    {
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

                if(password.Length <= 5)
                {
                    MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdminPw.Focus();
                    return;
                }
            }


            string DBConnect = "server=localhost; database=online_ordering_system; uid=root; password=";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnect))
                {
                    conn.Open();

                    string query = $"SELECT * FROM admin WHERE adminName=@username AND password=@password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        MySqlDataReader reader = cmd.ExecuteReader();

                        if(reader.HasRows)
                        {
                            DialogResult success = MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if(success == DialogResult.OK)
                            {
                                AdminHome adminHome = new AdminHome();
                                adminHome.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

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
    }
}
