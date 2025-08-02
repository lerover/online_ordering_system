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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            CategoryHome categoryHome = new CategoryHome();
            categoryHome.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.Show();
            this.Hide();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            productHome product = new productHome();
            product.Show();
            this.Hide();
        }

        private void btnPaymentMethod_Click(object sender, EventArgs e)
        {
            paymentMethod paymentMethod = new paymentMethod();
            paymentMethod.Show();
            this.Hide();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adminRegToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productEditDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void orderListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCategory_Click_1(object sender, EventArgs e)
        {
            CategoryHome categoryHome = new CategoryHome();
            categoryHome.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            adminOrderPage adminOrderPage = new adminOrderPage();
            adminOrderPage.Show();
            this.Hide();
        }
    }
}
