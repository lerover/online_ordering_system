namespace Online_Order_System
{
    partial class frm_CustomerHome
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
            this.cboCategoryName = new System.Windows.Forms.ComboBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOrderCancel = new System.Windows.Forms.Button();
            this.btnNowOrder = new System.Windows.Forms.Button();
            this.lblShoppingList = new System.Windows.Forms.Label();
            this.dgvShoppingList = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.nudtotalQty = new System.Windows.Forms.NumericUpDown();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.comboPaymentType = new System.Windows.Forms.ComboBox();
            this.btnShoppingList = new System.Windows.Forms.Button();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShoppingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudtotalQty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            // 
            // cboCategoryName
            // 
            this.cboCategoryName.FormattingEnabled = true;
            this.cboCategoryName.Location = new System.Drawing.Point(165, 102);
            this.cboCategoryName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCategoryName.Name = "cboCategoryName";
            this.cboCategoryName.Size = new System.Drawing.Size(211, 24);
            this.cboCategoryName.TabIndex = 1;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(165, 154);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(86, 38);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "&All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(290, 154);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 38);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Product Name";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Order Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(401, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Your Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Total Quantity";
            this.label8.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(404, 452);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Grand Total";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(408, 400);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Payment Type";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // btnOrderCancel
            // 
            this.btnOrderCancel.Location = new System.Drawing.Point(410, 545);
            this.btnOrderCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Size = new System.Drawing.Size(351, 38);
            this.btnOrderCancel.TabIndex = 26;
            this.btnOrderCancel.Text = "&Order Cancel";
            this.btnOrderCancel.UseVisualStyleBackColor = true;
            this.btnOrderCancel.Click += new System.EventHandler(this.btnOrderCancel_Click);
            // 
            // btnNowOrder
            // 
            this.btnNowOrder.Location = new System.Drawing.Point(410, 490);
            this.btnNowOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNowOrder.Name = "btnNowOrder";
            this.btnNowOrder.Size = new System.Drawing.Size(351, 38);
            this.btnNowOrder.TabIndex = 25;
            this.btnNowOrder.Text = "&Now Order";
            this.btnNowOrder.UseVisualStyleBackColor = true;
            this.btnNowOrder.Click += new System.EventHandler(this.btnNowOrder_Click);
            // 
            // lblShoppingList
            // 
            this.lblShoppingList.AutoSize = true;
            this.lblShoppingList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShoppingList.Location = new System.Drawing.Point(460, 42);
            this.lblShoppingList.Name = "lblShoppingList";
            this.lblShoppingList.Size = new System.Drawing.Size(144, 25);
            this.lblShoppingList.TabIndex = 31;
            this.lblShoppingList.Text = "Shopping List";
            // 
            // dgvShoppingList
            // 
            this.dgvShoppingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShoppingList.Location = new System.Drawing.Point(412, 104);
            this.dgvShoppingList.Name = "dgvShoppingList";
            this.dgvShoppingList.RowHeadersWidth = 51;
            this.dgvShoppingList.RowTemplate.Height = 24;
            this.dgvShoppingList.Size = new System.Drawing.Size(349, 172);
            this.dgvShoppingList.TabIndex = 33;
            this.dgvShoppingList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShoppingList_CellContentClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(514, 310);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(249, 22);
            this.dateTimePicker1.TabIndex = 42;
            // 
            // nudtotalQty
            // 
            this.nudtotalQty.Location = new System.Drawing.Point(156, 285);
            this.nudtotalQty.Name = "nudtotalQty";
            this.nudtotalQty.Size = new System.Drawing.Size(211, 22);
            this.nudtotalQty.TabIndex = 43;
            this.nudtotalQty.ValueChanged += new System.EventHandler(this.nudtotalQty_ValueChanged);
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(153, 233);
            this.cboProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(211, 24);
            this.cboProduct.TabIndex = 44;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_selectedIndexChange);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(526, 358);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(211, 22);
            this.txtName.TabIndex = 45;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Location = new System.Drawing.Point(526, 452);
            this.txtGrandTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(211, 22);
            this.txtGrandTotal.TabIndex = 46;
            this.txtGrandTotal.TextChanged += new System.EventHandler(this.txtTotalPrice_TextChanged);
            // 
            // comboPaymentType
            // 
            this.comboPaymentType.FormattingEnabled = true;
            this.comboPaymentType.Location = new System.Drawing.Point(526, 400);
            this.comboPaymentType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboPaymentType.Name = "comboPaymentType";
            this.comboPaymentType.Size = new System.Drawing.Size(211, 24);
            this.comboPaymentType.TabIndex = 49;
            this.comboPaymentType.SelectedIndexChanged += new System.EventHandler(this.comboPaymentType_SelectedIndexChanged);
            // 
            // btnShoppingList
            // 
            this.btnShoppingList.Location = new System.Drawing.Point(27, 436);
            this.btnShoppingList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShoppingList.Name = "btnShoppingList";
            this.btnShoppingList.Size = new System.Drawing.Size(339, 38);
            this.btnShoppingList.TabIndex = 50;
            this.btnShoppingList.Text = "&Add to shopping List";
            this.btnShoppingList.UseVisualStyleBackColor = true;
            this.btnShoppingList.Click += new System.EventHandler(this.btnShoppingList_Click);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Enabled = false;
            this.txtTotalPrice.Location = new System.Drawing.Point(153, 394);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(211, 22);
            this.txtTotalPrice.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 51;
            this.label3.Text = "Total Price";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(27, 27);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(167, 38);
            this.btnBack.TabIndex = 53;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Location = new System.Drawing.Point(155, 339);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(211, 22);
            this.txtDiscount.TabIndex = 55;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(34, 339);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(59, 16);
            this.lblDiscount.TabIndex = 54;
            this.lblDiscount.Text = "Discount";
            // 
            // frm_CustomerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 674);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShoppingList);
            this.Controls.Add(this.comboPaymentType);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.nudtotalQty);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dgvShoppingList);
            this.Controls.Add(this.lblShoppingList);
            this.Controls.Add(this.btnOrderCancel);
            this.Controls.Add(this.btnNowOrder);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.cboCategoryName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_CustomerHome";
            this.Text = "frm_CustomerHome";
            this.Load += new System.EventHandler(this.frm_CustomerHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShoppingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudtotalQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCategoryName;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOrderCancel;
        private System.Windows.Forms.Button btnNowOrder;
        private System.Windows.Forms.Label lblShoppingList;
        private System.Windows.Forms.DataGridView dgvShoppingList;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown nudtotalQty;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.ComboBox comboPaymentType;
        private System.Windows.Forms.Button btnShoppingList;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
    }
}