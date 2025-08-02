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
        private int? categoryID;
        private string name;
        private DateTime? updated_at;

        private string dbstring = "server=localhost; database=online_ordering_system; uid=root;password=";
        public Frm_Category(int? categoryID = null, string name = null, DateTime? updated_at = null)
        {
            InitializeComponent();
            this.categoryID = categoryID;
            this.name = name;
            this.updated_at = updated_at;
            txtCategoryName.Text = this.name;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string db = this.dbstring;
            if(this.categoryID != null && this.name != null && this.updated_at != null)
            {
                try
                {
                    using(MySqlConnection conn = new MySqlConnection(db))
                    {
                        conn.Open();
                        string query = $"UPDATE category SET name=@name, updated_at = @update_at WHERE categoryID = {this.categoryID}";
                        using(MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                            cmd.Parameters.AddWithValue("@update_at", DateTime.Now);

                            int result = cmd.ExecuteNonQuery();

                            if(result > 0)
                            {
                                MessageBox.Show("Category updated successfully!");
                                CategoryHome home = new CategoryHome();
                                home.Show();
                                this.Hide();
                            }
                        }
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }

                return;
            }
            string name = txtCategoryName.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (!string.IsNullOrWhiteSpace(txtCategoryName.Text))
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
            CategoryHome categoryHome = new CategoryHome();
            categoryHome.Show();
            this.Hide();
        }
    }
}
