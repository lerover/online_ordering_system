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
    }
}
