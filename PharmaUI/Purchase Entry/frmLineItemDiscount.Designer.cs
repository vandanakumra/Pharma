namespace PharmaUI
{
    partial class frmLineItemDiscount
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
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblDiscount = new System.Windows.Forms.TableLayoutPanel();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.txtVolDiscount = new System.Windows.Forms.TextBox();
            this.txtSpecialDiscount = new System.Windows.Forms.TextBox();
            this.lblSpecialDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblVolumeDiscount = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.dtExpiry = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtWholeSaleRate = new System.Windows.Forms.TextBox();
            this.txtSaleRate = new System.Windows.Forms.TextBox();
            this.txtExcise = new System.Windows.Forms.TextBox();
            this.lblLIExcise = new System.Windows.Forms.Label();
            this.lblLineItemDate = new System.Windows.Forms.Label();
            this.lblIsNewRate = new System.Windows.Forms.Label();
            this.lblSaleRate = new System.Windows.Forms.Label();
            this.lblWholeSaleRate = new System.Windows.Forms.Label();
            this.lblSpecialRate = new System.Windows.Forms.Label();
            this.chkIsNewRate = new System.Windows.Forms.CheckBox();
            this.txtSpecialRate = new System.Windows.Forms.TextBox();
            this.dtLIDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAppSaleRateValue = new System.Windows.Forms.Label();
            this.lblAppSaleExcise = new System.Windows.Forms.Label();
            this.lblAppExciseValue = new System.Windows.Forms.Label();
            this.lblNewRate = new System.Windows.Forms.Label();
            this.lblNewRateValue = new System.Windows.Forms.Label();
            this.lblAppSaleRate = new System.Windows.Forms.Label();
            this.tblMain.SuspendLayout();
            this.tblDiscount.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblMain.AutoSize = true;
            this.tblMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.tblDiscount, 0, 2);
            this.tblMain.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tblMain.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tblMain.Location = new System.Drawing.Point(0, 60);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblMain.Size = new System.Drawing.Size(730, 160);
            this.tblMain.TabIndex = 0;
            // 
            // tblDiscount
            // 
            this.tblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblDiscount.ColumnCount = 6;
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.Controls.Add(this.txtMRP, 1, 1);
            this.tblDiscount.Controls.Add(this.txtVolDiscount, 5, 0);
            this.tblDiscount.Controls.Add(this.txtSpecialDiscount, 3, 0);
            this.tblDiscount.Controls.Add(this.lblSpecialDiscount, 2, 0);
            this.tblDiscount.Controls.Add(this.txtDiscount, 1, 0);
            this.tblDiscount.Controls.Add(this.lblDiscount, 0, 0);
            this.tblDiscount.Controls.Add(this.lblVolumeDiscount, 4, 0);
            this.tblDiscount.Controls.Add(this.lblMRP, 0, 1);
            this.tblDiscount.Controls.Add(this.lblExpiry, 2, 1);
            this.tblDiscount.Controls.Add(this.dtExpiry, 3, 1);
            this.tblDiscount.Location = new System.Drawing.Point(3, 103);
            this.tblDiscount.Name = "tblDiscount";
            this.tblDiscount.RowCount = 2;
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDiscount.Size = new System.Drawing.Size(724, 54);
            this.tblDiscount.TabIndex = 1;
            // 
            // txtMRP
            // 
            this.txtMRP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRP.Location = new System.Drawing.Point(123, 30);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(114, 20);
            this.txtMRP.TabIndex = 20;
            // 
            // txtVolDiscount
            // 
            this.txtVolDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVolDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVolDiscount.Location = new System.Drawing.Point(605, 3);
            this.txtVolDiscount.Name = "txtVolDiscount";
            this.txtVolDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtVolDiscount.TabIndex = 19;
            // 
            // txtSpecialDiscount
            // 
            this.txtSpecialDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSpecialDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecialDiscount.Location = new System.Drawing.Point(363, 3);
            this.txtSpecialDiscount.Name = "txtSpecialDiscount";
            this.txtSpecialDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtSpecialDiscount.TabIndex = 18;
            // 
            // lblSpecialDiscount
            // 
            this.lblSpecialDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSpecialDiscount.AutoSize = true;
            this.lblSpecialDiscount.Location = new System.Drawing.Point(243, 7);
            this.lblSpecialDiscount.Name = "lblSpecialDiscount";
            this.lblSpecialDiscount.Size = new System.Drawing.Size(87, 13);
            this.lblSpecialDiscount.TabIndex = 5;
            this.lblSpecialDiscount.Text = "Special Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Location = new System.Drawing.Point(123, 3);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtDiscount.TabIndex = 17;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(3, 7);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(49, 13);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "Discount";
            // 
            // lblVolumeDiscount
            // 
            this.lblVolumeDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVolumeDiscount.AutoSize = true;
            this.lblVolumeDiscount.Location = new System.Drawing.Point(483, 7);
            this.lblVolumeDiscount.Name = "lblVolumeDiscount";
            this.lblVolumeDiscount.Size = new System.Drawing.Size(87, 13);
            this.lblVolumeDiscount.TabIndex = 6;
            this.lblVolumeDiscount.Text = "Volume Discount";
            // 
            // lblMRP
            // 
            this.lblMRP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMRP.AutoSize = true;
            this.lblMRP.Location = new System.Drawing.Point(3, 34);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(31, 13);
            this.lblMRP.TabIndex = 7;
            this.lblMRP.Text = "MRP";
            // 
            // lblExpiry
            // 
            this.lblExpiry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Location = new System.Drawing.Point(243, 34);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(35, 13);
            this.lblExpiry.TabIndex = 9;
            this.lblExpiry.Text = "Expiry";
            // 
            // dtExpiry
            // 
            this.dtExpiry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtExpiry.CustomFormat = "MM/yyyy";
            this.dtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpiry.Location = new System.Drawing.Point(363, 30);
            this.dtExpiry.Name = "dtExpiry";
            this.dtExpiry.Size = new System.Drawing.Size(114, 20);
            this.dtExpiry.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.txtWholeSaleRate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSaleRate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtExcise, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLIExcise, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLineItemDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIsNewRate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSaleRate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWholeSaleRate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSpecialRate, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkIsNewRate, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSpecialRate, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtLIDate, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 54);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txtWholeSaleRate
            // 
            this.txtWholeSaleRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWholeSaleRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWholeSaleRate.Location = new System.Drawing.Point(363, 30);
            this.txtWholeSaleRate.Name = "txtWholeSaleRate";
            this.txtWholeSaleRate.Size = new System.Drawing.Size(114, 20);
            this.txtWholeSaleRate.TabIndex = 15;
            // 
            // txtSaleRate
            // 
            this.txtSaleRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSaleRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaleRate.Location = new System.Drawing.Point(123, 30);
            this.txtSaleRate.Name = "txtSaleRate";
            this.txtSaleRate.Size = new System.Drawing.Size(114, 20);
            this.txtSaleRate.TabIndex = 14;
            // 
            // txtExcise
            // 
            this.txtExcise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtExcise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExcise.Location = new System.Drawing.Point(363, 3);
            this.txtExcise.Name = "txtExcise";
            this.txtExcise.Size = new System.Drawing.Size(114, 20);
            this.txtExcise.TabIndex = 12;
            // 
            // lblLIExcise
            // 
            this.lblLIExcise.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLIExcise.AutoSize = true;
            this.lblLIExcise.Location = new System.Drawing.Point(243, 7);
            this.lblLIExcise.Name = "lblLIExcise";
            this.lblLIExcise.Size = new System.Drawing.Size(38, 13);
            this.lblLIExcise.TabIndex = 5;
            this.lblLIExcise.Text = "Excise";
            // 
            // lblLineItemDate
            // 
            this.lblLineItemDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLineItemDate.AutoSize = true;
            this.lblLineItemDate.Location = new System.Drawing.Point(3, 7);
            this.lblLineItemDate.Name = "lblLineItemDate";
            this.lblLineItemDate.Size = new System.Drawing.Size(30, 13);
            this.lblLineItemDate.TabIndex = 1;
            this.lblLineItemDate.Text = "Date";
            // 
            // lblIsNewRate
            // 
            this.lblIsNewRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIsNewRate.AutoSize = true;
            this.lblIsNewRate.Location = new System.Drawing.Point(483, 7);
            this.lblIsNewRate.Name = "lblIsNewRate";
            this.lblIsNewRate.Size = new System.Drawing.Size(66, 13);
            this.lblIsNewRate.TabIndex = 6;
            this.lblIsNewRate.Text = "Is New Rate";
            // 
            // lblSaleRate
            // 
            this.lblSaleRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSaleRate.AutoSize = true;
            this.lblSaleRate.Location = new System.Drawing.Point(3, 34);
            this.lblSaleRate.Name = "lblSaleRate";
            this.lblSaleRate.Size = new System.Drawing.Size(54, 13);
            this.lblSaleRate.TabIndex = 7;
            this.lblSaleRate.Text = "Sale Rate";
            // 
            // lblWholeSaleRate
            // 
            this.lblWholeSaleRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWholeSaleRate.AutoSize = true;
            this.lblWholeSaleRate.Location = new System.Drawing.Point(243, 34);
            this.lblWholeSaleRate.Name = "lblWholeSaleRate";
            this.lblWholeSaleRate.Size = new System.Drawing.Size(88, 13);
            this.lblWholeSaleRate.TabIndex = 8;
            this.lblWholeSaleRate.Text = "Whole Sale Rate";
            // 
            // lblSpecialRate
            // 
            this.lblSpecialRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSpecialRate.AutoSize = true;
            this.lblSpecialRate.Location = new System.Drawing.Point(483, 34);
            this.lblSpecialRate.Name = "lblSpecialRate";
            this.lblSpecialRate.Size = new System.Drawing.Size(68, 13);
            this.lblSpecialRate.TabIndex = 9;
            this.lblSpecialRate.Text = "Special Rate";
            // 
            // chkIsNewRate
            // 
            this.chkIsNewRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIsNewRate.AutoSize = true;
            this.chkIsNewRate.Location = new System.Drawing.Point(603, 6);
            this.chkIsNewRate.Name = "chkIsNewRate";
            this.chkIsNewRate.Size = new System.Drawing.Size(15, 14);
            this.chkIsNewRate.TabIndex = 13;
            this.chkIsNewRate.UseVisualStyleBackColor = true;
            // 
            // txtSpecialRate
            // 
            this.txtSpecialRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSpecialRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecialRate.Location = new System.Drawing.Point(605, 30);
            this.txtSpecialRate.Name = "txtSpecialRate";
            this.txtSpecialRate.Size = new System.Drawing.Size(114, 20);
            this.txtSpecialRate.TabIndex = 16;
            // 
            // dtLIDate
            // 
            this.dtLIDate.CustomFormat = "MM/yyyy";
            this.dtLIDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLIDate.Location = new System.Drawing.Point(123, 3);
            this.dtLIDate.Name = "dtLIDate";
            this.dtLIDate.Size = new System.Drawing.Size(114, 20);
            this.dtLIDate.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.lblAppSaleRateValue, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblAppSaleExcise, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblAppExciseValue, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNewRate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNewRateValue, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblAppSaleRate, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(724, 34);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lblAppSaleRateValue
            // 
            this.lblAppSaleRateValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAppSaleRateValue.AutoSize = true;
            this.lblAppSaleRateValue.Location = new System.Drawing.Point(363, 10);
            this.lblAppSaleRateValue.Name = "lblAppSaleRateValue";
            this.lblAppSaleRateValue.Size = new System.Drawing.Size(0, 13);
            this.lblAppSaleRateValue.TabIndex = 7;
            // 
            // lblAppSaleExcise
            // 
            this.lblAppSaleExcise.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAppSaleExcise.AutoSize = true;
            this.lblAppSaleExcise.Location = new System.Drawing.Point(483, 10);
            this.lblAppSaleExcise.Name = "lblAppSaleExcise";
            this.lblAppSaleExcise.Size = new System.Drawing.Size(77, 13);
            this.lblAppSaleExcise.TabIndex = 6;
            this.lblAppSaleExcise.Text = "Approx. Excise";
            // 
            // lblAppExciseValue
            // 
            this.lblAppExciseValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAppExciseValue.AutoSize = true;
            this.lblAppExciseValue.Location = new System.Drawing.Point(603, 10);
            this.lblAppExciseValue.Name = "lblAppExciseValue";
            this.lblAppExciseValue.Size = new System.Drawing.Size(0, 13);
            this.lblAppExciseValue.TabIndex = 5;
            // 
            // lblNewRate
            // 
            this.lblNewRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNewRate.AutoSize = true;
            this.lblNewRate.Location = new System.Drawing.Point(3, 10);
            this.lblNewRate.Name = "lblNewRate";
            this.lblNewRate.Size = new System.Drawing.Size(55, 13);
            this.lblNewRate.TabIndex = 4;
            this.lblNewRate.Text = "New Rate";
            // 
            // lblNewRateValue
            // 
            this.lblNewRateValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNewRateValue.AutoSize = true;
            this.lblNewRateValue.Location = new System.Drawing.Point(123, 10);
            this.lblNewRateValue.Name = "lblNewRateValue";
            this.lblNewRateValue.Size = new System.Drawing.Size(0, 13);
            this.lblNewRateValue.TabIndex = 3;
            // 
            // lblAppSaleRate
            // 
            this.lblAppSaleRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAppSaleRate.AutoSize = true;
            this.lblAppSaleRate.Location = new System.Drawing.Point(243, 10);
            this.lblAppSaleRate.Name = "lblAppSaleRate";
            this.lblAppSaleRate.Size = new System.Drawing.Size(90, 13);
            this.lblAppSaleRate.TabIndex = 2;
            this.lblAppSaleRate.Text = "Approx Sale Rate";
            // 
            // frmLineItemDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(730, 233);
            this.Controls.Add(this.tblMain);
            this.Name = "frmLineItemDiscount";
            this.Text = "frmPurchaseBookLineItemUpdate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLineItemDiscount_FormClosing);
            this.Load += new System.EventHandler(this.frmLineItemDiscount_Load);
            this.tblMain.ResumeLayout(false);
            this.tblDiscount.ResumeLayout(false);
            this.tblDiscount.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TableLayoutPanel tblDiscount;
        private System.Windows.Forms.TextBox txtMRP;
        private System.Windows.Forms.TextBox txtVolDiscount;
        private System.Windows.Forms.TextBox txtSpecialDiscount;
        private System.Windows.Forms.Label lblSpecialDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblVolumeDiscount;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.DateTimePicker dtExpiry;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtWholeSaleRate;
        private System.Windows.Forms.TextBox txtSaleRate;
        private System.Windows.Forms.TextBox txtExcise;
        private System.Windows.Forms.Label lblLIExcise;
        private System.Windows.Forms.TextBox txtSpecialRate;
        private System.Windows.Forms.Label lblLineItemDate;
        private System.Windows.Forms.Label lblIsNewRate;
        private System.Windows.Forms.Label lblSaleRate;
        private System.Windows.Forms.Label lblWholeSaleRate;
        private System.Windows.Forms.Label lblSpecialRate;
        private System.Windows.Forms.DateTimePicker dtLIDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblAppSaleRateValue;
        private System.Windows.Forms.Label lblAppSaleExcise;
        private System.Windows.Forms.Label lblAppExciseValue;
        private System.Windows.Forms.Label lblNewRate;
        private System.Windows.Forms.Label lblNewRateValue;
        private System.Windows.Forms.Label lblAppSaleRate;
        private System.Windows.Forms.CheckBox chkIsNewRate;
    }
}