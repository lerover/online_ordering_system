using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // Changed to SQL Server

namespace Online_Order_System
{
    public partial class frm_payment : Form
    {
        public frm_payment()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPayment.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (txtPayment.Text.Length != 0)
            {
                DialogResult warning = MessageBox.Show(
                 "You have unsaved changes. Are you sure you want to leave without saving?",
                 "Unsaved Changes",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (warning == DialogResult.Yes)
                {
                    this.exit();
                }
            }
            else
            {
                this.exit();
            }
        }

        private void exit()
        {
            paymentMethod paymentMethod = new paymentMethod();
            paymentMethod.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string paymentMethod = txtPayment.Text;

            string db = "Server=localhost;Database=online_ordering_system;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(db))
                {
                    conn.Open();
                    string query = "INSERT INTO [payment-methods] (NAME) VALUES (@name)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", paymentMethod);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            DialogResult success = MessageBox.Show("Payment Methods created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (success == DialogResult.OK)
                            {
                                txtPayment.Clear();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Failed to create payment method.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtPayment_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
