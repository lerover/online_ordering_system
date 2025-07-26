namespace Online_Order_System
{
    partial class AdminHome
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
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(211, 134);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(299, 57);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "Product";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Location = new System.Drawing.Point(211, 52);
            this.btnCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(299, 57);
            this.btnCategory.TabIndex = 2;
            this.btnCategory.Text = "Category ";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(211, 222);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(299, 57);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnProduct);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminHome";
            this.Text = "AdminHome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnLogout;
    }
}