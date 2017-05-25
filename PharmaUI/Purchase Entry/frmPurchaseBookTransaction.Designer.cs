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
            this.lblPurchaseType = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.cbxPurchaseType = new System.Windows.Forms.ComboBox();
            this.cbxPurchaseFormType = new System.Windows.Forms.ComboBox();
            this.errFrmPurchaseBookHeader = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSupplierName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmPurchaseBookHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPurchaseType
            // 
            this.lblPurchaseType.AutoSize = true;
            this.lblPurchaseType.Location = new System.Drawing.Point(287, 90);
            this.lblPurchaseType.Name = "lblPurchaseType";
            this.lblPurchaseType.Size = new System.Drawing.Size(79, 13);
            this.lblPurchaseType.TabIndex = 8;
            this.lblPurchaseType.Text = "Purchase Type";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(9, 90);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(82, 13);
            this.lblInvoiceNumber.TabIndex = 6;
            this.lblInvoiceNumber.Text = "Invoice Number";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(97, 87);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(146, 20);
            this.txtInvoiceNumber.TabIndex = 7;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(13, 60);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(78, 13);
            this.lblPurchaseDate.TabIndex = 0;
            this.lblPurchaseDate.Text = "Purchase Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier";
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPurchaseDate.Location = new System.Drawing.Point(97, 57);
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.Size = new System.Drawing.Size(146, 20);
            this.dtPurchaseDate.TabIndex = 3;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(373, 57);
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
            this.dgvLineItem.Location = new System.Drawing.Point(6, 115);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(900, 174);
            this.dgvLineItem.TabIndex = 11;
            this.dgvLineItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLineItem_KeyDown);
            // 
            // cbxPurchaseType
            // 
            this.cbxPurchaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPurchaseType.FormattingEnabled = true;
            this.cbxPurchaseType.Location = new System.Drawing.Point(373, 86);
            this.cbxPurchaseType.Name = "cbxPurchaseType";
            this.cbxPurchaseType.Size = new System.Drawing.Size(146, 21);
            this.cbxPurchaseType.TabIndex = 8;
            // 
            // cbxPurchaseFormType
            // 
            this.cbxPurchaseFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPurchaseFormType.FormattingEnabled = true;
            this.cbxPurchaseFormType.Location = new System.Drawing.Point(525, 86);
            this.cbxPurchaseFormType.Name = "cbxPurchaseFormType";
            this.cbxPurchaseFormType.Size = new System.Drawing.Size(132, 21);
            this.cbxPurchaseFormType.TabIndex = 9;
            this.cbxPurchaseFormType.Visible = false;
            this.cbxPurchaseFormType.SelectedIndexChanged += new System.EventHandler(this.cbxPurchaseFormType_SelectedIndexChanged);
            // 
            // errFrmPurchaseBookHeader
            // 
            this.errFrmPurchaseBookHeader.ContainerControl = this;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(525, 60);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(0, 13);
            this.lblSupplierName.TabIndex = 12;
            // 
            // frmPurchaseBookTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 301);
            this.ControlBox = false;
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.lblPurchaseType);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.dtPurchaseDate);
            this.Controls.Add(this.cbxPurchaseType);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.cbxPurchaseFormType);
            this.Controls.Add(this.txtSupplierCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchaseBookTransaction";
            this.Text = "frmPurchaseBookTransaction";
            this.Load += new System.EventHandler(this.frmPurchaseBookTransaction_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPurchaseBookTransaction_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmPurchaseBookHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPurchaseDate;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label lblPurchaseType;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.ErrorProvider errFrmPurchaseBookHeader;
        private System.Windows.Forms.ComboBox cbxPurchaseType;
        private System.Windows.Forms.ComboBox cbxPurchaseFormType;
        private System.Windows.Forms.Label lblSupplierName;
    }
}