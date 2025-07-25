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
    public partial class Frm_Category : Form
    {
        public Frm_Category()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string db = "server=localhost; database=online_ordering_system; uid=root;password=";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(db))
                {
                    conn.Open();

                    string query = "INSERT INTO category (name) VALUES (@name)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                           DialogResult success =  MessageBox.Show("Category successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if(success == DialogResult.OK)
                            {
                                txtCategoryName.Clear();
                                txtCategoryName.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Category create Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    ;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CategoryHome categoryHome = new CategoryHome();
            categoryHome.Show();
            this.Hide();
        }
    }
}
