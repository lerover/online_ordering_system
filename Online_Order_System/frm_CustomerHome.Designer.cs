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
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rdoCash = new System.Windows.Forms.RadioButton();
            this.rdoBank = new System.Windows.Forms.RadioButton();
            this.btnOrderCancel = new System.Windows.Forms.Button();
            this.btnNowOrder = new System.Windows.Forms.Button();
            this.lblChoosePN = new System.Windows.Forms.Label();
            this.lblShoppingList = new System.Windows.Forms.Label();
            this.dgvChoosePN = new System.Windows.Forms.DataGridView();
            this.dgvShoppingList = new System.Windows.Forms.DataGridView();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderName = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoosePN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShoppingList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            // 
            // cboCategoryName
            // 
            this.cboCategoryName.FormattingEnabled = true;
            this.cboCategoryName.Location = new System.Drawing.Point(151, 24);
            this.cboCategoryName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCategoryName.Name = "cboCategoryName";
            this.cboCategoryName.Size = new System.Drawing.Size(211, 24);
            this.cboCategoryName.TabIndex = 1;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(151, 77);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(86, 38);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "&All";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(276, 77);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 38);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // cboProductName
            // 
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.Location = new System.Drawing.Point(151, 149);
            this.cboProductName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(211, 24);
            this.cboProductName.TabIndex = 5;
            this.cboProductName.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Product Name";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Order ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Order Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Order Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Total Quantity";
            this.label8.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 382);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Total Price";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 431);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Discount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 481);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Total Amount";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 534);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Grand Total";
            this.label12.Click += new System.EventHandler(this.lbGrandTotal_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 572);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Payment Type";
            // 
            // rdoCash
            // 
            this.rdoCash.AutoSize = true;
            this.rdoCash.Location = new System.Drawing.Point(148, 570);
            this.rdoCash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoCash.Name = "rdoCash";
            this.rdoCash.Size = new System.Drawing.Size(59, 20);
            this.rdoCash.TabIndex = 23;
            this.rdoCash.TabStop = true;
            this.rdoCash.Text = "Cash";
            this.rdoCash.UseVisualStyleBackColor = true;
            // 
            // rdoBank
            // 
            this.rdoBank.AutoSize = true;
            this.rdoBank.Location = new System.Drawing.Point(265, 569);
            this.rdoBank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoBank.Name = "rdoBank";
            this.rdoBank.Size = new System.Drawing.Size(59, 20);
            this.rdoBank.TabIndex = 24;
            this.rdoBank.TabStop = true;
            this.rdoBank.Text = "Bank";
            this.rdoBank.UseVisualStyleBackColor = true;
            // 
            // btnOrderCancel
            // 
            this.btnOrderCancel.Location = new System.Drawing.Point(265, 617);
            this.btnOrderCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Size = new System.Drawing.Size(123, 38);
            this.btnOrderCancel.TabIndex = 26;
            this.btnOrderCancel.Text = "&Order Cancel";
            this.btnOrderCancel.UseVisualStyleBackColor = true;
            // 
            // btnNowOrder
            // 
            this.btnNowOrder.Location = new System.Drawing.Point(140, 617);
            this.btnNowOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNowOrder.Name = "btnNowOrder";
            this.btnNowOrder.Size = new System.Drawing.Size(86, 38);
            this.btnNowOrder.TabIndex = 25;
            this.btnNowOrder.Text = "&Now Order";
            this.btnNowOrder.UseVisualStyleBackColor = true;
            // 
            // lblChoosePN
            // 
            this.lblChoosePN.AutoSize = true;
            this.lblChoosePN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoosePN.Location = new System.Drawing.Point(460, 30);
            this.lblChoosePN.Name = "lblChoosePN";
            this.lblChoosePN.Size = new System.Drawing.Size(229, 25);
            this.lblChoosePN.TabIndex = 29;
            this.lblChoosePN.Text = "Choose Product Name";
            this.lblChoosePN.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // lblShoppingList
            // 
            this.lblShoppingList.AutoSize = true;
            this.lblShoppingList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShoppingList.Location = new System.Drawing.Point(460, 316);
            this.lblShoppingList.Name = "lblShoppingList";
            this.lblShoppingList.Size = new System.Drawing.Size(144, 25);
            this.lblShoppingList.TabIndex = 31;
            this.lblShoppingList.Text = "Shopping List";
            // 
            // dgvChoosePN
            // 
            this.dgvChoosePN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoosePN.Location = new System.Drawing.Point(426, 103);
            this.dgvChoosePN.Name = "dgvChoosePN";
            this.dgvChoosePN.RowHeadersWidth = 51;
            this.dgvChoosePN.RowTemplate.Height = 24;
            this.dgvChoosePN.Size = new System.Drawing.Size(325, 150);
            this.dgvChoosePN.TabIndex = 32;
            // 
            // dgvShoppingList
            // 
            this.dgvShoppingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShoppingList.Location = new System.Drawing.Point(412, 378);
            this.dgvShoppingList.Name = "dgvShoppingList";
            this.dgvShoppingList.RowHeadersWidth = 51;
            this.dgvShoppingList.RowTemplate.Height = 24;
            this.dgvShoppingList.Size = new System.Drawing.Size(349, 172);
            this.dgvShoppingList.TabIndex = 33;
            // 
            // lblOrderID
            // 
            this.lblOrderID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderID.Location = new System.Drawing.Point(151, 196);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(211, 23);
            this.lblOrderID.TabIndex = 34;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderDate.Location = new System.Drawing.Point(151, 236);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(211, 23);
            this.lblOrderDate.TabIndex = 35;
            // 
            // lblOrderName
            // 
            this.lblOrderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderName.Location = new System.Drawing.Point(151, 283);
            this.lblOrderName.Name = "lblOrderName";
            this.lblOrderName.Size = new System.Drawing.Size(211, 23);
            this.lblOrderName.TabIndex = 36;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalQty.Location = new System.Drawing.Point(151, 334);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(211, 23);
            this.lblTotalQty.TabIndex = 37;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalPrice.Location = new System.Drawing.Point(151, 378);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(211, 23);
            this.lblTotalPrice.TabIndex = 38;
            // 
            // lblDiscount
            // 
            this.lblDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiscount.Location = new System.Drawing.Point(151, 430);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(211, 23);
            this.lblDiscount.TabIndex = 39;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Location = new System.Drawing.Point(151, 481);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(211, 23);
            this.lblTotalAmount.TabIndex = 40;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrandTotal.Location = new System.Drawing.Point(148, 533);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(211, 23);
            this.lblGrandTotal.TabIndex = 41;
            // 
            // frm_CustomerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 674);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.lblOrderName);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.dgvShoppingList);
            this.Controls.Add(this.dgvChoosePN);
            this.Controls.Add(this.lblShoppingList);
            this.Controls.Add(this.lblChoosePN);
            this.Controls.Add(this.btnOrderCancel);
            this.Controls.Add(this.btnNowOrder);
            this.Controls.Add(this.rdoBank);
            this.Controls.Add(this.rdoCash);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboProductName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.cboCategoryName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_CustomerHome";
            this.Text = "frm_CustomerHome";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoosePN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShoppingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCategoryName;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rdoCash;
        private System.Windows.Forms.RadioButton rdoBank;
        private System.Windows.Forms.Button btnOrderCancel;
        private System.Windows.Forms.Button btnNowOrder;
        private System.Windows.Forms.Label lblChoosePN;
        private System.Windows.Forms.Label lblShoppingList;
        private System.Windows.Forms.DataGridView dgvChoosePN;
        private System.Windows.Forms.DataGridView dgvShoppingList;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderName;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblGrandTotal;
    }
}