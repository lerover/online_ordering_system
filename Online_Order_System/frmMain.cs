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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            //create an instance to admin login form
            frm_AdminLogin frm_AdminLogin = new frm_AdminLogin();

            //show the next form
            frm_AdminLogin.Show();

            this.Hide();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void lblorder_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerlogin_Click(object sender, EventArgs e)
        {
            frm_Customerlogin frm_Customerlogin = new frm_Customerlogin();
            frm_Customerlogin.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
