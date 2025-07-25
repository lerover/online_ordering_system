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
    public partial class frm_Customerlogin : Form
    {
        public frm_Customerlogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            frm_CustomerRegister frm_CustomerRegister = new frm_CustomerRegister();
            frm_CustomerRegister.Show();

            this.Hide();
        }

        private void gb1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.Show();

            this.Hide();
        }

        private void frm_Customerlogin_Load(object sender, EventArgs e)
        {

        }
    }
}
