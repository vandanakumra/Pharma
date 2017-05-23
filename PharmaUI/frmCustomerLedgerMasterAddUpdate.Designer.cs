namespace PharmaUI
{
    partial class frmCustomerLedgerMasterAddUpdate
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProviderCustomerLedger = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDiscountDetails = new System.Windows.Forms.GroupBox();
            this.dgvCompanyDiscount = new System.Windows.Forms.DataGridView();
            this.gbCustomerBillingDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxCustomerType = new System.Windows.Forms.ComboBox();
            this.cbxLessExcise = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxRateType = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbxSaleBillFormat = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbxDiscount = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxRoute = new System.Windows.Forms.TextBox();
            this.tbxArea = new System.Windows.Forms.TextBox();
            this.tbxSalesman = new System.Windows.Forms.TextBox();
            this.tbxASM = new System.Windows.Forms.TextBox();
            this.tbxRSM = new System.Windows.Forms.TextBox();
            this.tbxZSM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxCredtLimit = new System.Windows.Forms.TextBox();
            this.tbxMaxOSAmount = new System.Windows.Forms.TextBox();
            this.tbxMaxGracePeriod = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tbxMaxNumberOfOSBill = new System.Windows.Forms.TextBox();
            this.tbxMaxBillAmmount = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cbxLocaLCentral = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cbxFollowConditionStrictly = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxPAN = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxCIN = new System.Windows.Forms.TextBox();
            this.tbxGST = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxLIN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxServiceTax = new System.Windows.Forms.TextBox();
            this.tbxDL = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ucSupplierCustomerInfo = new PharmaUI.ucSupplierCustomerInfo();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCustomerLedger)).BeginInit();
            this.gbDiscountDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyDiscount)).BeginInit();
            this.gbCustomerBillingDetails.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(295, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 30);
            this.btnSave.TabIndex = 801;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(435, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 30);
            this.btnCancel.TabIndex = 802;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProviderCustomerLedger
            // 
            this.errorProviderCustomerLedger.ContainerControl = this;
            // 
            // gbDiscountDetails
            // 
            this.gbDiscountDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDiscountDetails.Controls.Add(this.dgvCompanyDiscount);
            this.gbDiscountDetails.Location = new System.Drawing.Point(649, 201);
            this.gbDiscountDetails.Name = "gbDiscountDetails";
            this.gbDiscountDetails.Size = new System.Drawing.Size(471, 286);
            this.gbDiscountDetails.TabIndex = 599;
            this.gbDiscountDetails.TabStop = false;
            this.gbDiscountDetails.Text = "Company Discount Details";
            // 
            // dgvCompanyDiscount
            // 
            this.dgvCompanyDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanyDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompanyDiscount.Location = new System.Drawing.Point(3, 16);
            this.dgvCompanyDiscount.MultiSelect = false;
            this.dgvCompanyDiscount.Name = "dgvCompanyDiscount";
            this.dgvCompanyDiscount.Size = new System.Drawing.Size(465, 267);
            this.dgvCompanyDiscount.TabIndex = 600;
            this.dgvCompanyDiscount.Tag = "";
            this.dgvCompanyDiscount.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanyDiscount_CellEnter);
            this.dgvCompanyDiscount.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvCompanyDiscount_EditingControlShowing);
            this.dgvCompanyDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCompanyDiscount_KeyDown);
            // 
            // gbCustomerBillingDetails
            // 
            this.gbCustomerBillingDetails.Controls.Add(this.tableLayoutPanel1);
            this.gbCustomerBillingDetails.Location = new System.Drawing.Point(15, 201);
            this.gbCustomerBillingDetails.Name = "gbCustomerBillingDetails";
            this.gbCustomerBillingDetails.Size = new System.Drawing.Size(271, 139);
            this.gbCustomerBillingDetails.TabIndex = 198;
            this.gbCustomerBillingDetails.TabStop = false;
            this.gbCustomerBillingDetails.Text = "Customer Billing Details";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxCustomerType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxLessExcise, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxRateType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbxSaleBillFormat, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label28, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxDiscount, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(265, 120);
            this.tableLayoutPanel1.TabIndex = 199;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 8);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 117;
            this.label12.Text = "Customer Type";
            // 
            // cbxCustomerType
            // 
            this.cbxCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCustomerType.FormattingEnabled = true;
            this.cbxCustomerType.Location = new System.Drawing.Point(135, 8);
            this.cbxCustomerType.Name = "cbxCustomerType";
            this.cbxCustomerType.Size = new System.Drawing.Size(122, 21);
            this.cbxCustomerType.TabIndex = 201;
            this.cbxCustomerType.Tag = "";
            // 
            // cbxLessExcise
            // 
            this.cbxLessExcise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLessExcise.FormattingEnabled = true;
            this.cbxLessExcise.Location = new System.Drawing.Point(135, 30);
            this.cbxLessExcise.Name = "cbxLessExcise";
            this.cbxLessExcise.Size = new System.Drawing.Size(122, 21);
            this.cbxLessExcise.TabIndex = 202;
            this.cbxLessExcise.Tag = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 30);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 119;
            this.label14.Text = "Less Excise";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 52);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 120;
            this.label15.Text = "Rate Type";
            // 
            // cbxRateType
            // 
            this.cbxRateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRateType.FormattingEnabled = true;
            this.cbxRateType.Location = new System.Drawing.Point(135, 52);
            this.cbxRateType.Name = "cbxRateType";
            this.cbxRateType.Size = new System.Drawing.Size(122, 21);
            this.cbxRateType.TabIndex = 203;
            this.cbxRateType.Tag = "";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 74);
            this.label21.Margin = new System.Windows.Forms.Padding(3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 125;
            this.label21.Text = "Sale Bill Format";
            // 
            // tbxSaleBillFormat
            // 
            this.tbxSaleBillFormat.Location = new System.Drawing.Point(135, 74);
            this.tbxSaleBillFormat.Name = "tbxSaleBillFormat";
            this.tbxSaleBillFormat.Size = new System.Drawing.Size(122, 20);
            this.tbxSaleBillFormat.TabIndex = 204;
            this.tbxSaleBillFormat.Tag = "";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 96);
            this.label28.Margin = new System.Windows.Forms.Padding(3);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 13);
            this.label28.TabIndex = 135;
            this.label28.Text = "Discount";
            // 
            // tbxDiscount
            // 
            this.tbxDiscount.Location = new System.Drawing.Point(135, 96);
            this.tbxDiscount.Name = "tbxDiscount";
            this.tbxDiscount.Size = new System.Drawing.Size(122, 20);
            this.tbxDiscount.TabIndex = 205;
            this.tbxDiscount.Tag = "";
            this.tbxDiscount.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(292, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 174);
            this.groupBox2.TabIndex = 298;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Person/Route Details";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tbxRoute, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.tbxArea, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.tbxSalesman, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbxASM, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbxRSM, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbxZSM, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblItemCode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblItemName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(345, 155);
            this.tableLayoutPanel2.TabIndex = 299;
            // 
            // tbxRoute
            // 
            this.tbxRoute.Location = new System.Drawing.Point(83, 123);
            this.tbxRoute.Name = "tbxRoute";
            this.tbxRoute.Size = new System.Drawing.Size(179, 20);
            this.tbxRoute.TabIndex = 306;
            this.tbxRoute.Tag = "";
            // 
            // tbxArea
            // 
            this.tbxArea.Location = new System.Drawing.Point(83, 101);
            this.tbxArea.Name = "tbxArea";
            this.tbxArea.Size = new System.Drawing.Size(179, 20);
            this.tbxArea.TabIndex = 305;
            this.tbxArea.Tag = "";
            // 
            // tbxSalesman
            // 
            this.tbxSalesman.Location = new System.Drawing.Point(83, 79);
            this.tbxSalesman.Name = "tbxSalesman";
            this.tbxSalesman.Size = new System.Drawing.Size(179, 20);
            this.tbxSalesman.TabIndex = 304;
            this.tbxSalesman.Tag = "";
            // 
            // tbxASM
            // 
            this.tbxASM.Location = new System.Drawing.Point(83, 57);
            this.tbxASM.Name = "tbxASM";
            this.tbxASM.Size = new System.Drawing.Size(179, 20);
            this.tbxASM.TabIndex = 303;
            this.tbxASM.Tag = "";
            // 
            // tbxRSM
            // 
            this.tbxRSM.Location = new System.Drawing.Point(83, 35);
            this.tbxRSM.Name = "tbxRSM";
            this.tbxRSM.Size = new System.Drawing.Size(179, 20);
            this.tbxRSM.TabIndex = 302;
            this.tbxRSM.Tag = "";
            // 
            // tbxZSM
            // 
            this.tbxZSM.Location = new System.Drawing.Point(83, 13);
            this.tbxZSM.Name = "tbxZSM";
            this.tbxZSM.Size = new System.Drawing.Size(179, 20);
            this.tbxZSM.TabIndex = 301;
            this.tbxZSM.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "Route";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Location = new System.Drawing.Point(13, 13);
            this.lblItemCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(36, 13);
            this.lblItemCode.TabIndex = 81;
            this.lblItemCode.Text = "Z.S.M";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(13, 35);
            this.lblItemName.Margin = new System.Windows.Forms.Padding(3);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(40, 13);
            this.lblItemName.TabIndex = 82;
            this.lblItemName.Text = "R.S.M.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "A.S.M";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Area";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Salesman";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Location = new System.Drawing.Point(15, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 195);
            this.groupBox1.TabIndex = 398;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bill Details";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tbxCredtLimit, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.tbxMaxOSAmount, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbxMaxGracePeriod, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label22, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label23, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label24, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label25, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tbxMaxNumberOfOSBill, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tbxMaxBillAmmount, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label27, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.cbxLocaLCentral, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.label26, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.cbxFollowConditionStrictly, 1, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(262, 176);
            this.tableLayoutPanel3.TabIndex = 399;
            // 
            // tbxCredtLimit
            // 
            this.tbxCredtLimit.Location = new System.Drawing.Point(134, 101);
            this.tbxCredtLimit.Name = "tbxCredtLimit";
            this.tbxCredtLimit.Size = new System.Drawing.Size(115, 20);
            this.tbxCredtLimit.TabIndex = 405;
            this.tbxCredtLimit.Tag = "";
            this.tbxCredtLimit.Text = "0";
            // 
            // tbxMaxOSAmount
            // 
            this.tbxMaxOSAmount.Location = new System.Drawing.Point(134, 13);
            this.tbxMaxOSAmount.Name = "tbxMaxOSAmount";
            this.tbxMaxOSAmount.Size = new System.Drawing.Size(115, 20);
            this.tbxMaxOSAmount.TabIndex = 401;
            this.tbxMaxOSAmount.Tag = "";
            this.tbxMaxOSAmount.Text = "0";
            // 
            // tbxMaxGracePeriod
            // 
            this.tbxMaxGracePeriod.Location = new System.Drawing.Point(134, 79);
            this.tbxMaxGracePeriod.Name = "tbxMaxGracePeriod";
            this.tbxMaxGracePeriod.Size = new System.Drawing.Size(115, 20);
            this.tbxMaxGracePeriod.TabIndex = 404;
            this.tbxMaxGracePeriod.Tag = "";
            this.tbxMaxGracePeriod.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 101);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 507;
            this.label11.Text = "Credit Limit";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(13, 13);
            this.label22.Margin = new System.Windows.Forms.Padding(3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 13);
            this.label22.TabIndex = 126;
            this.label22.Text = "Max O/S Ammount";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 35);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 13);
            this.label23.TabIndex = 127;
            this.label23.Text = "Max Bill Ammount";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(13, 57);
            this.label24.Margin = new System.Windows.Forms.Padding(3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 13);
            this.label24.TabIndex = 128;
            this.label24.Text = "Max No of O/S Bill";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 79);
            this.label25.Margin = new System.Windows.Forms.Padding(3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(89, 13);
            this.label25.TabIndex = 129;
            this.label25.Text = "Max grace period";
            // 
            // tbxMaxNumberOfOSBill
            // 
            this.tbxMaxNumberOfOSBill.Location = new System.Drawing.Point(134, 57);
            this.tbxMaxNumberOfOSBill.Name = "tbxMaxNumberOfOSBill";
            this.tbxMaxNumberOfOSBill.Size = new System.Drawing.Size(115, 20);
            this.tbxMaxNumberOfOSBill.TabIndex = 403;
            this.tbxMaxNumberOfOSBill.Tag = "";
            this.tbxMaxNumberOfOSBill.Text = "0";
            // 
            // tbxMaxBillAmmount
            // 
            this.tbxMaxBillAmmount.Location = new System.Drawing.Point(134, 35);
            this.tbxMaxBillAmmount.Name = "tbxMaxBillAmmount";
            this.tbxMaxBillAmmount.Size = new System.Drawing.Size(115, 20);
            this.tbxMaxBillAmmount.TabIndex = 402;
            this.tbxMaxBillAmmount.Tag = "";
            this.tbxMaxBillAmmount.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(13, 145);
            this.label27.Margin = new System.Windows.Forms.Padding(3);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(71, 13);
            this.label27.TabIndex = 131;
            this.label27.Text = "Local/Central";
            // 
            // cbxLocaLCentral
            // 
            this.cbxLocaLCentral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLocaLCentral.FormattingEnabled = true;
            this.cbxLocaLCentral.Location = new System.Drawing.Point(134, 145);
            this.cbxLocaLCentral.Name = "cbxLocaLCentral";
            this.cbxLocaLCentral.Size = new System.Drawing.Size(115, 21);
            this.cbxLocaLCentral.TabIndex = 407;
            this.cbxLocaLCentral.Tag = "";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 123);
            this.label26.Margin = new System.Windows.Forms.Padding(3);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(113, 13);
            this.label26.TabIndex = 130;
            this.label26.Text = "Follow condtion strictly";
            // 
            // cbxFollowConditionStrictly
            // 
            this.cbxFollowConditionStrictly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFollowConditionStrictly.FormattingEnabled = true;
            this.cbxFollowConditionStrictly.Location = new System.Drawing.Point(134, 123);
            this.cbxFollowConditionStrictly.Name = "cbxFollowConditionStrictly";
            this.cbxFollowConditionStrictly.Size = new System.Drawing.Size(115, 21);
            this.cbxFollowConditionStrictly.TabIndex = 406;
            this.cbxFollowConditionStrictly.Tag = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel5);
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Location = new System.Drawing.Point(295, 382);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 92);
            this.groupBox3.TabIndex = 499;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other Details";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.Controls.Add(this.tbxPAN, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.label10, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.tbxCIN, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.tbxGST, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tbxLIN, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.tbxServiceTax, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.tbxDL, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(339, 73);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // tbxPAN
            // 
            this.tbxPAN.Location = new System.Drawing.Point(222, 50);
            this.tbxPAN.Name = "tbxPAN";
            this.tbxPAN.Size = new System.Drawing.Size(112, 20);
            this.tbxPAN.TabIndex = 506;
            this.tbxPAN.Tag = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(172, 50);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 608;
            this.label10.Text = "PAN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 606;
            this.label9.Text = "S.Tax";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 115;
            this.label5.Text = "DL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 116;
            this.label6.Text = "GST";
            // 
            // tbxCIN
            // 
            this.tbxCIN.Location = new System.Drawing.Point(55, 27);
            this.tbxCIN.Name = "tbxCIN";
            this.tbxCIN.Size = new System.Drawing.Size(111, 20);
            this.tbxCIN.TabIndex = 503;
            this.tbxCIN.Tag = "";
            // 
            // tbxGST
            // 
            this.tbxGST.Location = new System.Drawing.Point(222, 5);
            this.tbxGST.Name = "tbxGST";
            this.tbxGST.Size = new System.Drawing.Size(112, 20);
            this.tbxGST.TabIndex = 502;
            this.tbxGST.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 117;
            this.label7.Text = "CIN";
            // 
            // tbxLIN
            // 
            this.tbxLIN.Location = new System.Drawing.Point(222, 27);
            this.tbxLIN.Name = "tbxLIN";
            this.tbxLIN.Size = new System.Drawing.Size(111, 20);
            this.tbxLIN.TabIndex = 504;
            this.tbxLIN.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 604;
            this.label8.Text = "LIN";
            // 
            // tbxServiceTax
            // 
            this.tbxServiceTax.Location = new System.Drawing.Point(55, 50);
            this.tbxServiceTax.Name = "tbxServiceTax";
            this.tbxServiceTax.Size = new System.Drawing.Size(111, 20);
            this.tbxServiceTax.TabIndex = 505;
            this.tbxServiceTax.Tag = "";
            // 
            // tbxDL
            // 
            this.tbxDL.Location = new System.Drawing.Point(55, 5);
            this.tbxDL.Name = "tbxDL";
            this.tbxDL.Size = new System.Drawing.Size(111, 20);
            this.tbxDL.TabIndex = 501;
            this.tbxDL.Tag = "";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(24, 82);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(141, 100);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // ucSupplierCustomerInfo
            // 
            this.ucSupplierCustomerInfo.Address = "";
            this.ucSupplierCustomerInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucSupplierCustomerInfo.Code = "";
            this.ucSupplierCustomerInfo.ContactPerson = "";
            this.ucSupplierCustomerInfo.CreditDebit = PharmaBusinessObjects.Common.Enums.TransType.C;
            this.ucSupplierCustomerInfo.CustomerSupplierName = "";
            this.ucSupplierCustomerInfo.EmailAddress = "";
            this.ucSupplierCustomerInfo.Location = new System.Drawing.Point(15, 56);
            this.ucSupplierCustomerInfo.Mobile = "";
            this.ucSupplierCustomerInfo.Name = "ucSupplierCustomerInfo";
            this.ucSupplierCustomerInfo.OfficePhone = "";
            this.ucSupplierCustomerInfo.OpeningBal = "";
            this.ucSupplierCustomerInfo.ResidentPhone = "";
            this.ucSupplierCustomerInfo.ShortName = "";
            this.ucSupplierCustomerInfo.Size = new System.Drawing.Size(1105, 140);
            this.ucSupplierCustomerInfo.Status = PharmaBusinessObjects.Common.Enums.Status.Active;
            this.ucSupplierCustomerInfo.TabIndex = 1;
            this.ucSupplierCustomerInfo.TaxRetail = PharmaBusinessObjects.Common.Enums.TaxRetail.R;
            this.ucSupplierCustomerInfo.Telephone = "";
            // 
            // frmCustomerLedgerMasterAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 553);
            this.Controls.Add(this.ucSupplierCustomerInfo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbCustomerBillingDetails);
            this.Controls.Add(this.gbDiscountDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmCustomerLedgerMasterAddUpdate";
            this.Text = "frmCustomerLedgerAddUpdate";
            this.Load += new System.EventHandler(this.frmCustomerLedgerMasterAddUpdate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCustomerLedgerMasterAddUpdate_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCustomerLedger)).EndInit();
            this.gbDiscountDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyDiscount)).EndInit();
            this.gbCustomerBillingDetails.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProviderCustomerLedger;
        private System.Windows.Forms.GroupBox gbDiscountDetails;
        private System.Windows.Forms.DataGridView dgvCompanyDiscount;
        private System.Windows.Forms.GroupBox gbCustomerBillingDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbxCustomerType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxLessExcise;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxRateType;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbxSaleBillFormat;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbxDiscount;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cbxLocaLCentral;
        private System.Windows.Forms.ComboBox cbxFollowConditionStrictly;
        private System.Windows.Forms.TextBox tbxMaxGracePeriod;
        private System.Windows.Forms.TextBox tbxMaxNumberOfOSBill;
        private System.Windows.Forms.TextBox tbxMaxBillAmmount;
        private System.Windows.Forms.TextBox tbxMaxOSAmount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox tbxDL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxGST;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxCIN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxLIN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxServiceTax;
        private System.Windows.Forms.TextBox tbxPAN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxCredtLimit;
        private ucSupplierCustomerInfo ucSupplierCustomerInfo;
        private System.Windows.Forms.TextBox tbxRoute;
        private System.Windows.Forms.TextBox tbxArea;
        private System.Windows.Forms.TextBox tbxSalesman;
        private System.Windows.Forms.TextBox tbxASM;
        private System.Windows.Forms.TextBox tbxRSM;
        private System.Windows.Forms.TextBox tbxZSM;
    }
}