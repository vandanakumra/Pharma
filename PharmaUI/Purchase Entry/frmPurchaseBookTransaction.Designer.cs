namespace PharmaUI
{
    partial class frmPurchaseBookTransaction
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPurchaseType = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.cbxPurchaseType = new System.Windows.Forms.ComboBox();
            this.lblPurchaseTypeName = new System.Windows.Forms.Label();
            this.cbxPurchaseFormType = new System.Windows.Forms.ComboBox();
            this.errFrmPurchaseBookHeader = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmPurchaseBookHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.lblPurchaseType, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblInvoiceNumber, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtInvoiceNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSupplierName, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPurchaseDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtPurchaseDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSupplierCode, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvLineItem, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxPurchaseType, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPurchaseTypeName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxPurchaseFormType, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(909, 239);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblPurchaseType
            // 
            this.lblPurchaseType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPurchaseType.AutoSize = true;
            this.lblPurchaseType.Location = new System.Drawing.Point(339, 68);
            this.lblPurchaseType.Name = "lblPurchaseType";
            this.lblPurchaseType.Size = new System.Drawing.Size(79, 13);
            this.lblPurchaseType.TabIndex = 8;
            this.lblPurchaseType.Text = "Purchase Type";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(3, 68);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(82, 13);
            this.lblInvoiceNumber.TabIndex = 6;
            this.lblInvoiceNumber.Text = "Invoice Number";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtInvoiceNumber.Location = new System.Drawing.Point(103, 65);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(146, 20);
            this.txtInvoiceNumber.TabIndex = 7;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(675, 18);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(0, 13);
            this.lblSupplierName.TabIndex = 5;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(3, 18);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(78, 13);
            this.lblPurchaseDate.TabIndex = 0;
            this.lblPurchaseDate.Text = "Purchase Date";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier";
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPurchaseDate.Location = new System.Drawing.Point(103, 15);
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.Size = new System.Drawing.Size(200, 20);
            this.dtPurchaseDate.TabIndex = 3;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSupplierCode.Location = new System.Drawing.Point(439, 15);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(146, 20);
            this.txtSupplierCode.TabIndex = 4;
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvLineItem, 5);
            this.dgvLineItem.Location = new System.Drawing.Point(3, 103);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(903, 113);
            this.dgvLineItem.TabIndex = 11;
            this.dgvLineItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLineItem_KeyDown);
            // 
            // cbxPurchaseType
            // 
            this.cbxPurchaseType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPurchaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPurchaseType.FormattingEnabled = true;
            this.cbxPurchaseType.Location = new System.Drawing.Point(439, 64);
            this.cbxPurchaseType.Name = "cbxPurchaseType";
            this.cbxPurchaseType.Size = new System.Drawing.Size(230, 21);
            this.cbxPurchaseType.TabIndex = 8;
            // 
            // lblPurchaseTypeName
            // 
            this.lblPurchaseTypeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPurchaseTypeName.AutoSize = true;
            this.lblPurchaseTypeName.Location = new System.Drawing.Point(3, 222);
            this.lblPurchaseTypeName.Name = "lblPurchaseTypeName";
            this.lblPurchaseTypeName.Size = new System.Drawing.Size(0, 13);
            this.lblPurchaseTypeName.TabIndex = 10;
            // 
            // cbxPurchaseFormType
            // 
            this.cbxPurchaseFormType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPurchaseFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPurchaseFormType.FormattingEnabled = true;
            this.cbxPurchaseFormType.Location = new System.Drawing.Point(675, 64);
            this.cbxPurchaseFormType.Name = "cbxPurchaseFormType";
            this.cbxPurchaseFormType.Size = new System.Drawing.Size(231, 21);
            this.cbxPurchaseFormType.TabIndex = 9;
            this.cbxPurchaseFormType.Visible = false;
            this.cbxPurchaseFormType.SelectedIndexChanged += new System.EventHandler(this.cbxPurchaseFormType_SelectedIndexChanged);
            // 
            // errFrmPurchaseBookHeader
            // 
            this.errFrmPurchaseBookHeader.ContainerControl = this;
            // 
            // frmPurchaseBookTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 301);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchaseBookTransaction";
            this.Text = "frmPurchaseBookTransaction";
            this.Load += new System.EventHandler(this.frmPurchaseBookTransaction_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPurchaseBookTransaction_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmPurchaseBookHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPurchaseDate;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label lblPurchaseType;
        private System.Windows.Forms.Label lblPurchaseTypeName;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.ErrorProvider errFrmPurchaseBookHeader;
        private System.Windows.Forms.ComboBox cbxPurchaseType;
        private System.Windows.Forms.ComboBox cbxPurchaseFormType;
    }
}