namespace Online_Order_System
{
    partial class frm_OrderList
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnOrderConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(450, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Order Listing";
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(401, 107);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.RowTemplate.Height = 24;
            this.dgvOrder.Size = new System.Drawing.Size(409, 194);
            this.dgvOrder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(450, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 44);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product Detail List";
            // 
            // dgvDetail
            // 
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(35, 427);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 24;
            this.dgvDetail.Size = new System.Drawing.Size(775, 209);
            this.dgvDetail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search Date";
            // 
            // dtpdate
            // 
            this.dtpdate.Location = new System.Drawing.Point(81, 143);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(200, 22);
            this.dtpdate.TabIndex = 5;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnAll.Location = new System.Drawing.Point(127, 207);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(105, 37);
            this.btnAll.TabIndex = 6;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = false;
            // 
            // btnOrderConfirm
            // 
            this.btnOrderConfirm.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOrderConfirm.Location = new System.Drawing.Point(127, 288);
            this.btnOrderConfirm.Name = "btnOrderConfirm";
            this.btnOrderConfirm.Size = new System.Drawing.Size(105, 37);
            this.btnOrderConfirm.TabIndex = 7;
            this.btnOrderConfirm.Text = "&Order Confirm";
            this.btnOrderConfirm.UseVisualStyleBackColor = false;
            // 
            // frm_OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 663);
            this.Controls.Add(this.btnOrderConfirm);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.label1);
            this.Name = "frm_OrderList";
            this.Text = "frm_OrderList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnOrderConfirm;
    }
}