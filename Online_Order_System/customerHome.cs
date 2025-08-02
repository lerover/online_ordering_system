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
    public partial class customerHome : Form
    {
        public customerHome()
        {
            InitializeComponent();
        }

        private void btnShopping_Click(object sender, EventArgs e)
        {
            frm_CustomerHome frm_CustomerHome = new frm_CustomerHome();
            frm_CustomerHome.Show();
            this.Hide();
        }

        private void btnYourOrder_Click(object sender, EventArgs e)
        {
            orderPage orderPage = new orderPage();
            orderPage.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frm_Customerlogin frm_Customerlogin = new frm_Customerlogin();
            frm_Customerlogin.Show();
            this.Hide();
        }
    }
}
