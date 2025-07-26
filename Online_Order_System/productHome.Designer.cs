namespace Online_Order_System
{
    partial class productHome
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
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(0, 83);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.RowHeadersWidth = 62;
            this.dataGridViewProduct.RowTemplate.Height = 24;
            this.dataGridViewProduct.Size = new System.Drawing.Size(804, 370);
            this.dataGridViewProduct.TabIndex = 0;
            this.dataGridViewProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 79);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(28, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(145, 47);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(632, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(145, 47);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // productHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewProduct);
            this.Name = "productHome";
            this.Text = "productHome";
            this.Load += new System.EventHandler(this.productHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBack;
    }
}