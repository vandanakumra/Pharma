namespace PharmaUI.Sale_Entry
{
    partial class frmSaleEntry
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
            this.components = new System.ComponentModel.Container();
            this.dtSaleDate = new System.Windows.Forms.MaskedTextBox();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.txtSalesManCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSaleManName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDueBills = new System.Windows.Forms.Label();
            this.lblFRate = new System.Windows.Forms.Label();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lblTotalSchemeAmt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalDiscountAmt = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalTaxAmount = new System.Windows.Forms.Label();
            this.lblTotalNetAmount = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPacking = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblCaseQuantity = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblItemAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSurharge = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblSaleTypeCode = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIsHalf = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lblTaxRate = new System.Windows.Forms.Label();
            this.lblVolumeDiscountAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblVolumeDis = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblScheme = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblHalf = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.errFrmSaleEntry = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmSaleEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // dtSaleDate
            // 
            this.dtSaleDate.Location = new System.Drawing.Point(97, 57);
            this.dtSaleDate.Mask = "00/00/0000";
            this.dtSaleDate.Name = "dtSaleDate";
            this.dtSaleDate.Size = new System.Drawing.Size(100, 20);
            this.dtSaleDate.TabIndex = 7;
            this.dtSaleDate.ValidatingType = typeof(System.DateTime);
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(13, 60);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(30, 13);
            this.lblPurchaseDate.TabIndex = 5;
            this.lblPurchaseDate.Text = "Date";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(349, 57);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(146, 20);
            this.txtCustomerCode.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Customer";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(510, 60);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(0, 13);
            this.lblCustomerName.TabIndex = 13;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(9, 86);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(82, 13);
            this.lblInvoiceNumber.TabIndex = 14;
            this.lblInvoiceNumber.Text = "Invoice Number";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(97, 83);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(146, 20);
            this.txtInvoiceNumber.TabIndex = 15;
            // 
            // txtSalesManCode
            // 
            this.txtSalesManCode.Location = new System.Drawing.Point(349, 83);
            this.txtSalesManCode.Name = "txtSalesManCode";
            this.txtSalesManCode.Size = new System.Drawing.Size(146, 20);
            this.txtSalesManCode.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Sales Man";
            // 
            // lblSaleManName
            // 
            this.lblSaleManName.AutoSize = true;
            this.lblSaleManName.Location = new System.Drawing.Point(505, 98);
            this.lblSaleManName.Name = "lblSaleManName";
            this.lblSaleManName.Size = new System.Drawing.Size(0, 13);
            this.lblSaleManName.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(815, 63);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 48);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Due Bills";
            // 
            // lblDueBills
            // 
            this.lblDueBills.AutoSize = true;
            this.lblDueBills.Location = new System.Drawing.Point(594, 86);
            this.lblDueBills.Name = "lblDueBills";
            this.lblDueBills.Size = new System.Drawing.Size(48, 13);
            this.lblDueBills.TabIndex = 26;
            this.lblDueBills.Text = "Due Bills";
            // 
            // lblFRate
            // 
            this.lblFRate.AutoSize = true;
            this.lblFRate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblFRate.Location = new System.Drawing.Point(531, 60);
            this.lblFRate.Name = "lblFRate";
            this.lblFRate.Size = new System.Drawing.Size(39, 13);
            this.lblFRate.TabIndex = 27;
            this.lblFRate.Text = "F.Rate";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.AllowUserToOrderColumns = true;
            this.dgvLineItem.AllowUserToResizeColumns = false;
            this.dgvLineItem.AllowUserToResizeRows = false;
            this.dgvLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvLineItem.Location = new System.Drawing.Point(8, 116);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(894, 202);
            this.dgvLineItem.TabIndex = 28;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label42, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalSchemeAmt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalDiscountAmt, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalAmount, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalTaxAmount, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalNetAmount, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 321);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(894, 30);
            this.tableLayoutPanel1.TabIndex = 130;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 28);
            this.label5.TabIndex = 124;
            this.label5.Text = "Scheme Amount";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(716, 4);
            this.label42.Margin = new System.Windows.Forms.Padding(3);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(66, 28);
            this.label42.TabIndex = 128;
            this.label42.Text = "Total Amount";
            // 
            // lblTotalSchemeAmt
            // 
            this.lblTotalSchemeAmt.AutoSize = true;
            this.lblTotalSchemeAmt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSchemeAmt.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalSchemeAmt.Location = new System.Drawing.Point(93, 4);
            this.lblTotalSchemeAmt.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalSchemeAmt.Name = "lblTotalSchemeAmt";
            this.lblTotalSchemeAmt.Size = new System.Drawing.Size(32, 19);
            this.lblTotalSchemeAmt.TabIndex = 116;
            this.lblTotalSchemeAmt.Text = "0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(182, 4);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 28);
            this.label6.TabIndex = 125;
            this.label6.Text = "Discount Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(538, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 28);
            this.label8.TabIndex = 127;
            this.label8.Text = "Invoice Amount";
            // 
            // lblTotalDiscountAmt
            // 
            this.lblTotalDiscountAmt.AutoSize = true;
            this.lblTotalDiscountAmt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiscountAmt.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalDiscountAmt.Location = new System.Drawing.Point(271, 4);
            this.lblTotalDiscountAmt.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalDiscountAmt.Name = "lblTotalDiscountAmt";
            this.lblTotalDiscountAmt.Size = new System.Drawing.Size(32, 19);
            this.lblTotalDiscountAmt.TabIndex = 117;
            this.lblTotalDiscountAmt.Text = "0.0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalAmount.Location = new System.Drawing.Point(805, 4);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(32, 19);
            this.lblTotalAmount.TabIndex = 123;
            this.lblTotalAmount.Text = "0.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 4);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 28);
            this.label7.TabIndex = 126;
            this.label7.Text = "Tax Amount";
            // 
            // lblTotalTaxAmount
            // 
            this.lblTotalTaxAmount.AutoSize = true;
            this.lblTotalTaxAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTaxAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalTaxAmount.Location = new System.Drawing.Point(449, 4);
            this.lblTotalTaxAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalTaxAmount.Name = "lblTotalTaxAmount";
            this.lblTotalTaxAmount.Size = new System.Drawing.Size(32, 19);
            this.lblTotalTaxAmount.TabIndex = 119;
            this.lblTotalTaxAmount.Text = "0.0";
            // 
            // lblTotalNetAmount
            // 
            this.lblTotalNetAmount.AutoSize = true;
            this.lblTotalNetAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNetAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalNetAmount.Location = new System.Drawing.Point(627, 4);
            this.lblTotalNetAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalNetAmount.Name = "lblTotalNetAmount";
            this.lblTotalNetAmount.Size = new System.Drawing.Size(32, 19);
            this.lblTotalNetAmount.TabIndex = 121;
            this.lblTotalNetAmount.Text = "0.0";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBalance, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label19, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPacking, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label25, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblCaseQuantity, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label15, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblItemAmount, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSurharge, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label23, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSaleTypeCode, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblIsHalf, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label37, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTaxRate, 7, 2);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblDiscount, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label14, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label33, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblScheme, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label13, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblHalf, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.label18, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblVolumeDiscountAmount, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.label20, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblVolumeDis, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 352);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(894, 96);
            this.tableLayoutPanel2.TabIndex = 131;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 4);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 16);
            this.label17.TabIndex = 150;
            this.label17.Text = "Balance";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Blue;
            this.lblBalance.Location = new System.Drawing.Point(155, 4);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(3);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(18, 16);
            this.lblBalance.TabIndex = 124;
            this.lblBalance.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(227, 4);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 16);
            this.label19.TabIndex = 151;
            this.label19.Text = "Packing";
            // 
            // lblPacking
            // 
            this.lblPacking.AutoSize = true;
            this.lblPacking.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacking.ForeColor = System.Drawing.Color.Blue;
            this.lblPacking.Location = new System.Drawing.Point(378, 4);
            this.lblPacking.Margin = new System.Windows.Forms.Padding(3);
            this.lblPacking.Name = "lblPacking";
            this.lblPacking.Size = new System.Drawing.Size(32, 16);
            this.lblPacking.TabIndex = 126;
            this.lblPacking.Text = "0.0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(4, 27);
            this.label25.Margin = new System.Windows.Forms.Padding(3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 16);
            this.label25.TabIndex = 154;
            this.label25.Text = "Case Quantity";
            // 
            // lblCaseQuantity
            // 
            this.lblCaseQuantity.AutoSize = true;
            this.lblCaseQuantity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaseQuantity.ForeColor = System.Drawing.Color.Blue;
            this.lblCaseQuantity.Location = new System.Drawing.Point(155, 27);
            this.lblCaseQuantity.Margin = new System.Windows.Forms.Padding(3);
            this.lblCaseQuantity.Name = "lblCaseQuantity";
            this.lblCaseQuantity.Size = new System.Drawing.Size(18, 16);
            this.lblCaseQuantity.TabIndex = 132;
            this.lblCaseQuantity.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(673, 4);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 16);
            this.label15.TabIndex = 149;
            this.label15.Text = "Item Amount";
            // 
            // lblItemAmount
            // 
            this.lblItemAmount.AutoSize = true;
            this.lblItemAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblItemAmount.Location = new System.Drawing.Point(824, 4);
            this.lblItemAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblItemAmount.Name = "lblItemAmount";
            this.lblItemAmount.Size = new System.Drawing.Size(32, 16);
            this.lblItemAmount.TabIndex = 122;
            this.lblItemAmount.Text = "0.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(227, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 16);
            this.label9.TabIndex = 163;
            this.label9.Text = "SC (%)";
            // 
            // lblSurharge
            // 
            this.lblSurharge.AutoSize = true;
            this.lblSurharge.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurharge.ForeColor = System.Drawing.Color.Blue;
            this.lblSurharge.Location = new System.Drawing.Point(378, 50);
            this.lblSurharge.Margin = new System.Windows.Forms.Padding(3);
            this.lblSurharge.Name = "lblSurharge";
            this.lblSurharge.Size = new System.Drawing.Size(32, 16);
            this.lblSurharge.TabIndex = 164;
            this.lblSurharge.Text = "0.0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(450, 4);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 16);
            this.label23.TabIndex = 153;
            this.label23.Text = "Sale Type";
            // 
            // lblSaleTypeCode
            // 
            this.lblSaleTypeCode.AutoSize = true;
            this.lblSaleTypeCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleTypeCode.ForeColor = System.Drawing.Color.Blue;
            this.lblSaleTypeCode.Location = new System.Drawing.Point(601, 4);
            this.lblSaleTypeCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblSaleTypeCode.Name = "lblSaleTypeCode";
            this.lblSaleTypeCode.Size = new System.Drawing.Size(61, 16);
            this.lblSaleTypeCode.TabIndex = 130;
            this.lblSaleTypeCode.Text = "Sale 01";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(450, 27);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 16);
            this.label10.TabIndex = 165;
            this.label10.Text = "Half";
            // 
            // lblIsHalf
            // 
            this.lblIsHalf.AutoSize = true;
            this.lblIsHalf.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsHalf.ForeColor = System.Drawing.Color.Blue;
            this.lblIsHalf.Location = new System.Drawing.Point(601, 27);
            this.lblIsHalf.Margin = new System.Windows.Forms.Padding(3);
            this.lblIsHalf.Name = "lblIsHalf";
            this.lblIsHalf.Size = new System.Drawing.Size(32, 16);
            this.lblIsHalf.TabIndex = 166;
            this.lblIsHalf.Text = "0.0";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(673, 50);
            this.label37.Margin = new System.Windows.Forms.Padding(3);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(68, 16);
            this.label37.TabIndex = 160;
            this.label37.Text = "Tax (%)";
            // 
            // lblTaxRate
            // 
            this.lblTaxRate.AutoSize = true;
            this.lblTaxRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxRate.ForeColor = System.Drawing.Color.Blue;
            this.lblTaxRate.Location = new System.Drawing.Point(824, 50);
            this.lblTaxRate.Margin = new System.Windows.Forms.Padding(3);
            this.lblTaxRate.Name = "lblTaxRate";
            this.lblTaxRate.Size = new System.Drawing.Size(32, 16);
            this.lblTaxRate.TabIndex = 144;
            this.lblTaxRate.Text = "0.0";
            // 
            // lblVolumeDiscountAmount
            // 
            this.lblVolumeDiscountAmount.AutoSize = true;
            this.lblVolumeDiscountAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumeDiscountAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblVolumeDiscountAmount.Location = new System.Drawing.Point(601, 73);
            this.lblVolumeDiscountAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblVolumeDiscountAmount.Name = "lblVolumeDiscountAmount";
            this.lblVolumeDiscountAmount.Size = new System.Drawing.Size(32, 19);
            this.lblVolumeDiscountAmount.TabIndex = 170;
            this.lblVolumeDiscountAmount.Text = "0.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 50);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 16);
            this.label11.TabIndex = 161;
            this.label11.Text = "Discount (%)";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.Blue;
            this.lblDiscount.Location = new System.Drawing.Point(155, 50);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(3);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(32, 16);
            this.lblDiscount.TabIndex = 162;
            this.lblDiscount.Text = "0.0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(227, 73);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 19);
            this.label14.TabIndex = 169;
            this.label14.Text = "Amt";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 73);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 19);
            this.label12.TabIndex = 167;
            this.label12.Text = "Last Bill";
            // 
            // lblVolumeDis
            // 
            this.lblVolumeDis.AutoSize = true;
            this.lblVolumeDis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumeDis.ForeColor = System.Drawing.Color.Blue;
            this.lblVolumeDis.Location = new System.Drawing.Point(155, 73);
            this.lblVolumeDis.Margin = new System.Windows.Forms.Padding(3);
            this.lblVolumeDis.Name = "lblVolumeDis";
            this.lblVolumeDis.Size = new System.Drawing.Size(32, 19);
            this.lblVolumeDis.TabIndex = 168;
            this.lblVolumeDis.Text = "0.0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(227, 27);
            this.label33.Margin = new System.Windows.Forms.Padding(3);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 16);
            this.label33.TabIndex = 158;
            this.label33.Text = "Scheme";
            // 
            // lblScheme
            // 
            this.lblScheme.AutoSize = true;
            this.lblScheme.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheme.ForeColor = System.Drawing.Color.Blue;
            this.lblScheme.Location = new System.Drawing.Point(378, 27);
            this.lblScheme.Margin = new System.Windows.Forms.Padding(3);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(32, 16);
            this.lblScheme.TabIndex = 140;
            this.lblScheme.Text = "0.0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(450, 50);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 16);
            this.label13.TabIndex = 171;
            this.label13.Text = "Half (%)";
            // 
            // lblHalf
            // 
            this.lblHalf.AutoSize = true;
            this.lblHalf.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalf.ForeColor = System.Drawing.Color.Blue;
            this.lblHalf.Location = new System.Drawing.Point(601, 50);
            this.lblHalf.Margin = new System.Windows.Forms.Padding(3);
            this.lblHalf.Name = "lblHalf";
            this.lblHalf.Size = new System.Drawing.Size(32, 16);
            this.lblHalf.TabIndex = 172;
            this.lblHalf.Text = "0.0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(450, 73);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 19);
            this.label18.TabIndex = 173;
            this.label18.Text = "Amt";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(378, 73);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 19);
            this.label20.TabIndex = 174;
            this.label20.Text = "0.0";
            // 
            // errFrmSaleEntry
            // 
            this.errFrmSaleEntry.ContainerControl = this;
            // 
            // frmSaleEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 449);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.lblFRate);
            this.Controls.Add(this.lblDueBills);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSaleManName);
            this.Controls.Add(this.txtSalesManCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.dtSaleDate);
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaleEntry";
            this.Text = "frmSaleEntry";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmSaleEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox dtSaleDate;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.TextBox txtSalesManCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSaleManName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDueBills;
        private System.Windows.Forms.Label lblFRate;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label lblTotalSchemeAmt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalDiscountAmt;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalTaxAmount;
        private System.Windows.Forms.Label lblTotalNetAmount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPacking;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblCaseQuantity;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblItemAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSurharge;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblSaleTypeCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblIsHalf;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lblTaxRate;
        private System.Windows.Forms.Label lblVolumeDiscountAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblVolumeDis;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblScheme;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblHalf;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ErrorProvider errFrmSaleEntry;
    }
}