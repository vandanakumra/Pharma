namespace PharmaUI
{
    partial class frmSupplierLedgerAddUpdate
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
            this.cbxArea = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbxPurchaseType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDLNo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTin = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucSupplierCustomerInfo = new PharmaUI.ucSupplierCustomerInfo();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxArea
            // 
            this.cbxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxArea.FormattingEnabled = true;
            this.cbxArea.Location = new System.Drawing.Point(102, 13);
            this.cbxArea.Name = "cbxArea";
            this.cbxArea.Size = new System.Drawing.Size(83, 21);
            this.cbxArea.TabIndex = 201;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 19);
            this.label16.TabIndex = 61;
            this.label16.Text = "Area";
            // 
            // cbxPurchaseType
            // 
            this.cbxPurchaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPurchaseType.FormattingEnabled = true;
            this.cbxPurchaseType.Location = new System.Drawing.Point(280, 13);
            this.cbxPurchaseType.Name = "cbxPurchaseType";
            this.cbxPurchaseType.Size = new System.Drawing.Size(83, 21);
            this.cbxPurchaseType.TabIndex = 202;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(191, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 27);
            this.label17.TabIndex = 63;
            this.label17.Text = "Purchase Type";
            // 
            // txtDLNo
            // 
            this.txtDLNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDLNo.Location = new System.Drawing.Point(636, 13);
            this.txtDLNo.Name = "txtDLNo";
            this.txtDLNo.Size = new System.Drawing.Size(90, 23);
            this.txtDLNo.TabIndex = 204;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(547, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 19);
            this.label19.TabIndex = 69;
            this.label19.Text = "DL No.";
            // 
            // txtTin
            // 
            this.txtTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTin.Location = new System.Drawing.Point(458, 13);
            this.txtTin.Name = "txtTin";
            this.txtTin.Size = new System.Drawing.Size(83, 23);
            this.txtTin.TabIndex = 203;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(369, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 19);
            this.label20.TabIndex = 67;
            this.label20.Text = "TIN No";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(403, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 48);
            this.btnCancel.TabIndex = 502;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(295, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 48);
            this.btnSave.TabIndex = 501;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 66);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxArea, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxPurchaseType, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label20, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTin, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label19, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDLNo, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(739, 47);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ucSupplierCustomerInfo
            // 
            this.ucSupplierCustomerInfo.Address = "";
            this.ucSupplierCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSupplierCustomerInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucSupplierCustomerInfo.Code = "";
            this.ucSupplierCustomerInfo.ContactPerson = "";
            this.ucSupplierCustomerInfo.CreditDebit = PharmaBusinessObjects.Common.Enums.TransType.C;
            this.ucSupplierCustomerInfo.CustomerSupplierName = "";
            this.ucSupplierCustomerInfo.EmailAddress = "";
            this.ucSupplierCustomerInfo.Fax = "";
            this.ucSupplierCustomerInfo.Location = new System.Drawing.Point(11, 61);
            this.ucSupplierCustomerInfo.Mobile = "";
            this.ucSupplierCustomerInfo.Name = "ucSupplierCustomerInfo";
            this.ucSupplierCustomerInfo.OfficePhone = "";
            this.ucSupplierCustomerInfo.OpeningBal = "";
            this.ucSupplierCustomerInfo.Pager = "";
            this.ucSupplierCustomerInfo.ResidentPhone = "";
            this.ucSupplierCustomerInfo.ShortName = "";
            this.ucSupplierCustomerInfo.Size = new System.Drawing.Size(747, 130);
            this.ucSupplierCustomerInfo.Status = PharmaBusinessObjects.Common.Enums.Status.Active;
            this.ucSupplierCustomerInfo.TabIndex = 72;
            this.ucSupplierCustomerInfo.TaxRetail = PharmaBusinessObjects.Common.Enums.TaxRetail.R;
            // 
            // frmSupplierLedgerAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 357);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucSupplierCustomerInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmSupplierLedgerAddUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSupplierLedgerAddUpdate";
            this.Load += new System.EventHandler(this.frmSupplierLedgerAddUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxArea;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbxPurchaseType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDLNo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTin;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private ucSupplierCustomerInfo ucSupplierCustomerInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}