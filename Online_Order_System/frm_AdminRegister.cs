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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Online_Order_System
{
    public partial class frm_AdminRegister : Form
    {
        public frm_AdminRegister()
        {
            InitializeComponent();
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
                    txtAdminName.Focus();
                    return;
                }

                if (password.Length <= 5)
                {
                    MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdminName.Focus();
                    return;
                }
            }



            //Database steps 
            string DBConnect = "server=localhost; database=online_ordering_system; uid=root; password=";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnect))
                {
                    conn.Open();
                    string validate = "SELECT COUNT(*) FROM admin WHERE adminName=@username";
                    MySqlCommand cmd = new MySqlCommand(validate, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if(count > 0)
                    {
                        MessageBox.Show("Admin Name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string query = $"INSERT INTO admin (adminName,password) VALUES (@username,@password) ";
                        using (MySqlCommand insertCmd = new MySqlCommand(query, conn))
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
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
