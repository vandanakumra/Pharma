namespace PharmaUI
{
    partial class frmPurchaseBookLineItemUpdate
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
            this.txtExcise = new System.Windows.Forms.TextBox();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.txtVolDiscount = new System.Windows.Forms.TextBox();
            this.txtSpecialDiscount = new System.Windows.Forms.TextBox();
            this.lblSpecialDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblVolumeDiscount = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.lblExcise = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.dtExpiry = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblLIExcise = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblLineItemDate = new System.Windows.Forms.Label();
            this.lblVolRate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAppSaleRate = new System.Windows.Forms.Label();
            this.lblNewRateValue = new System.Windows.Forms.Label();
            this.lblNewRate = new System.Windows.Forms.Label();
            this.lblAppExciseValue = new System.Windows.Forms.Label();
            this.lblAppSaleExcise = new System.Windows.Forms.Label();
            this.lblAppSaleRateValue = new System.Windows.Forms.Label();
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
            this.tblMain.Size = new System.Drawing.Size(730, 164);
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
            this.tblDiscount.Controls.Add(this.txtExcise, 3, 1);
            this.tblDiscount.Controls.Add(this.txtMRP, 1, 1);
            this.tblDiscount.Controls.Add(this.txtVolDiscount, 5, 0);
            this.tblDiscount.Controls.Add(this.txtSpecialDiscount, 3, 0);
            this.tblDiscount.Controls.Add(this.lblSpecialDiscount, 2, 0);
            this.tblDiscount.Controls.Add(this.txtDiscount, 1, 0);
            this.tblDiscount.Controls.Add(this.lblDiscount, 0, 0);
            this.tblDiscount.Controls.Add(this.lblVolumeDiscount, 4, 0);
            this.tblDiscount.Controls.Add(this.lblMRP, 0, 1);
            this.tblDiscount.Controls.Add(this.lblExcise, 2, 1);
            this.tblDiscount.Controls.Add(this.lblExpiry, 4, 1);
            this.tblDiscount.Controls.Add(this.dtExpiry, 5, 1);
            this.tblDiscount.Location = new System.Drawing.Point(3, 103);
            this.tblDiscount.Name = "tblDiscount";
            this.tblDiscount.RowCount = 2;
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDiscount.Size = new System.Drawing.Size(724, 58);
            this.tblDiscount.TabIndex = 1;
            // 
            // txtExcise
            // 
            this.txtExcise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtExcise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExcise.Location = new System.Drawing.Point(363, 33);
            this.txtExcise.Name = "txtExcise";
            this.txtExcise.Size = new System.Drawing.Size(114, 20);
            this.txtExcise.TabIndex = 10;
            // 
            // txtMRP
            // 
            this.txtMRP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRP.Location = new System.Drawing.Point(123, 33);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(114, 20);
            this.txtMRP.TabIndex = 9;
            // 
            // txtVolDiscount
            // 
            this.txtVolDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVolDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVolDiscount.Location = new System.Drawing.Point(605, 4);
            this.txtVolDiscount.Name = "txtVolDiscount";
            this.txtVolDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtVolDiscount.TabIndex = 8;
            // 
            // txtSpecialDiscount
            // 
            this.txtSpecialDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSpecialDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecialDiscount.Location = new System.Drawing.Point(363, 4);
            this.txtSpecialDiscount.Name = "txtSpecialDiscount";
            this.txtSpecialDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtSpecialDiscount.TabIndex = 7;
            // 
            // lblSpecialDiscount
            // 
            this.lblSpecialDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSpecialDiscount.AutoSize = true;
            this.lblSpecialDiscount.Location = new System.Drawing.Point(243, 8);
            this.lblSpecialDiscount.Name = "lblSpecialDiscount";
            this.lblSpecialDiscount.Size = new System.Drawing.Size(87, 13);
            this.lblSpecialDiscount.TabIndex = 5;
            this.lblSpecialDiscount.Text = "Special Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Location = new System.Drawing.Point(123, 4);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtDiscount.TabIndex = 6;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(3, 8);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(49, 13);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "Discount";
            // 
            // lblVolumeDiscount
            // 
            this.lblVolumeDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVolumeDiscount.AutoSize = true;
            this.lblVolumeDiscount.Location = new System.Drawing.Point(483, 8);
            this.lblVolumeDiscount.Name = "lblVolumeDiscount";
            this.lblVolumeDiscount.Size = new System.Drawing.Size(87, 13);
            this.lblVolumeDiscount.TabIndex = 6;
            this.lblVolumeDiscount.Text = "Volume Discount";
            // 
            // lblMRP
            // 
            this.lblMRP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMRP.AutoSize = true;
            this.lblMRP.Location = new System.Drawing.Point(3, 37);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(31, 13);
            this.lblMRP.TabIndex = 7;
            this.lblMRP.Text = "MRP";
            // 
            // lblExcise
            // 
            this.lblExcise.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExcise.AutoSize = true;
            this.lblExcise.Location = new System.Drawing.Point(243, 37);
            this.lblExcise.Name = "lblExcise";
            this.lblExcise.Size = new System.Drawing.Size(38, 13);
            this.lblExcise.TabIndex = 8;
            this.lblExcise.Text = "Excise";
            // 
            // lblExpiry
            // 
            this.lblExpiry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Location = new System.Drawing.Point(483, 37);
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
            this.dtExpiry.Location = new System.Drawing.Point(603, 33);
            this.dtExpiry.Name = "dtExpiry";
            this.dtExpiry.Size = new System.Drawing.Size(118, 20);
            this.dtExpiry.TabIndex = 11;
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
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLIExcise, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLineItemDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblVolRate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 5, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 54);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(363, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 20);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(123, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 20);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(605, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(114, 20);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(363, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(114, 20);
            this.textBox4.TabIndex = 7;
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
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Location = new System.Drawing.Point(123, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(114, 20);
            this.textBox5.TabIndex = 6;
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
            // lblVolRate
            // 
            this.lblVolRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVolRate.AutoSize = true;
            this.lblVolRate.Location = new System.Drawing.Point(483, 7);
            this.lblVolRate.Name = "lblVolRate";
            this.lblVolRate.Size = new System.Drawing.Size(87, 13);
            this.lblVolRate.TabIndex = 6;
            this.lblVolRate.Text = "Volume Discount";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "MRP";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Excise";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Expiry";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(603, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(118, 20);
            this.dateTimePicker1.TabIndex = 11;
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
            // lblNewRateValue
            // 
            this.lblNewRateValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNewRateValue.AutoSize = true;
            this.lblNewRateValue.Location = new System.Drawing.Point(123, 10);
            this.lblNewRateValue.Name = "lblNewRateValue";
            this.lblNewRateValue.Size = new System.Drawing.Size(0, 13);
            this.lblNewRateValue.TabIndex = 3;
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
            // lblAppExciseValue
            // 
            this.lblAppExciseValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAppExciseValue.AutoSize = true;
            this.lblAppExciseValue.Location = new System.Drawing.Point(603, 10);
            this.lblAppExciseValue.Name = "lblAppExciseValue";
            this.lblAppExciseValue.Size = new System.Drawing.Size(0, 13);
            this.lblAppExciseValue.TabIndex = 5;
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
            // lblAppSaleRateValue
            // 
            this.lblAppSaleRateValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAppSaleRateValue.AutoSize = true;
            this.lblAppSaleRateValue.Location = new System.Drawing.Point(363, 10);
            this.lblAppSaleRateValue.Name = "lblAppSaleRateValue";
            this.lblAppSaleRateValue.Size = new System.Drawing.Size(0, 13);
            this.lblAppSaleRateValue.TabIndex = 7;
            // 
            // frmPurchaseBookLineItemUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(730, 317);
            this.Controls.Add(this.tblMain);
            this.Name = "frmPurchaseBookLineItemUpdate";
            this.Text = "frmPurchaseBookLineItemUpdate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPurchaseBookLineItemUpdate_FormClosing);
            this.Load += new System.EventHandler(this.frmPurchaseBookLineItemUpdate_Load);
            this.tblMain.ResumeLayout(false);
            this.tblDiscount.ResumeLayout(false);
            this.tblDiscount.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TableLayoutPanel tblDiscount;
        private System.Windows.Forms.TextBox txtExcise;
        private System.Windows.Forms.TextBox txtMRP;
        private System.Windows.Forms.TextBox txtVolDiscount;
        private System.Windows.Forms.TextBox txtSpecialDiscount;
        private System.Windows.Forms.Label lblSpecialDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblVolumeDiscount;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblExcise;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.DateTimePicker dtExpiry;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblLIExcise;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblLineItemDate;
        private System.Windows.Forms.Label lblVolRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblAppSaleRateValue;
        private System.Windows.Forms.Label lblAppSaleExcise;
        private System.Windows.Forms.Label lblAppExciseValue;
        private System.Windows.Forms.Label lblNewRate;
        private System.Windows.Forms.Label lblNewRateValue;
        private System.Windows.Forms.Label lblAppSaleRate;
    }
}