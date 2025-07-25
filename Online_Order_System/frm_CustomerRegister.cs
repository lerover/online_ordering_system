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
using MySqlX.XDevAPI.Common;

namespace Online_Order_System
{
    public partial class frm_CustomerRegister : Form
    {
        public frm_CustomerRegister()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frm_Customerlogin frm_Customerlogin = new frm_Customerlogin();
            frm_Customerlogin.Show();
            this.Close();
        }

        private void frm_CustomerRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtCustomerNm.Text;
            string address = txtAddress.Text;
            string contact = txtContact.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Customer Name is required!","Validation Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string dbConnection = "server=localhost; database=online_ordering_system; uid=root;password=";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(dbConnection))
                {
                    conn.Open();

                    string checkQuery = "Select COUNT(*) FROM customer WHERE customerName Like @username";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Customer Name already exists!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    //string query = $"INSERT INTO admin (adminName,password) VALUES (@username,@password) ";

                    string query = "INSERT INTO customer (customerName,address,contact,password) VALUES (@username,@address,@contact,@password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@address",address);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@password", password);

                        int result = cmd.ExecuteNonQuery();
                        if(result > 0)
                        {
                           DialogResult success = MessageBox.Show("Account created Successfully!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            if (success == DialogResult.OK)
                            {
                                frm_Customerlogin frm_Customerlogin = new frm_Customerlogin();
                                frm_Customerlogin.Show();
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
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
