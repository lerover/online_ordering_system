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
    public partial class frm_CustomerRegister : Form
    {
        public frm_CustomerRegister()
        {
            InitializeComponent();
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
    }
}
