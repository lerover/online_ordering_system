namespace Online_Order_System
{
    partial class customerHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShopping = new System.Windows.Forms.Button();
            this.btnYourOrder = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShopping
            // 
            this.btnShopping.Location = new System.Drawing.Point(199, 40);
            this.btnShopping.Name = "btnShopping";
            this.btnShopping.Size = new System.Drawing.Size(390, 86);
            this.btnShopping.TabIndex = 1;
            this.btnShopping.Text = "Shopping";
            this.btnShopping.UseVisualStyleBackColor = true;
            this.btnShopping.Click += new System.EventHandler(this.btnShopping_Click);
            // 
            // btnYourOrder
            // 
            this.btnYourOrder.Location = new System.Drawing.Point(199, 157);
            this.btnYourOrder.Name = "btnYourOrder";
            this.btnYourOrder.Size = new System.Drawing.Size(390, 86);
            this.btnYourOrder.TabIndex = 2;
            this.btnYourOrder.Text = "Your Orders";
            this.btnYourOrder.UseVisualStyleBackColor = true;
            this.btnYourOrder.Click += new System.EventHandler(this.btnYourOrder_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(199, 270);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(390, 86);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // customerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnYourOrder);
            this.Controls.Add(this.btnShopping);
            this.Name = "customerHome";
            this.Text = "customerHome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShopping;
        private System.Windows.Forms.Button btnYourOrder;
        private System.Windows.Forms.Button btnLogOut;
    }
}