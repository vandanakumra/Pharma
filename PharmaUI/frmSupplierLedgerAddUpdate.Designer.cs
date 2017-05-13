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
            this.label18 = new System.Windows.Forms.Label();
            this.txtDLNo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTin = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ucSupplierCustomerInfo = new PharmaUI.ucSupplierCustomerInfo();
            this.SuspendLayout();
            // 
            // cbxArea
            // 
            this.cbxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxArea.FormattingEnabled = true;
            this.cbxArea.Location = new System.Drawing.Point(170, 390);
            this.cbxArea.Name = "cbxArea";
            this.cbxArea.Size = new System.Drawing.Size(121, 21);
            this.cbxArea.TabIndex = 62;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(25, 390);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 19);
            this.label16.TabIndex = 61;
            this.label16.Text = "Area";
            // 
            // cbxPurchaseType
            // 
            this.cbxPurchaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPurchaseType.FormattingEnabled = true;
            this.cbxPurchaseType.Location = new System.Drawing.Point(551, 392);
            this.cbxPurchaseType.Name = "cbxPurchaseType";
            this.cbxPurchaseType.Size = new System.Drawing.Size(121, 21);
            this.cbxPurchaseType.TabIndex = 64;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(436, 392);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 19);
            this.label17.TabIndex = 63;
            this.label17.Text = "Purchase Type";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(444, 416);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 65;
            this.label18.Text = "Area";
            // 
            // txtDLNo
            // 
            this.txtDLNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDLNo.Location = new System.Drawing.Point(551, 449);
            this.txtDLNo.Name = "txtDLNo";
            this.txtDLNo.Size = new System.Drawing.Size(204, 23);
            this.txtDLNo.TabIndex = 68;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(436, 449);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 19);
            this.label19.TabIndex = 69;
            this.label19.Text = "DL No.";
            // 
            // txtTin
            // 
            this.txtTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTin.Location = new System.Drawing.Point(170, 449);
            this.txtTin.Name = "txtTin";
            this.txtTin.Size = new System.Drawing.Size(216, 23);
            this.txtTin.TabIndex = 66;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(25, 451);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 19);
            this.label20.TabIndex = 67;
            this.label20.Text = "TIN No";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(397, 491);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 48);
            this.btnCancel.TabIndex = 71;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(289, 491);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 48);
            this.btnSave.TabIndex = 70;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucSupplierCustomerInfo
            // 
            this.ucSupplierCustomerInfo.Address = "";
            this.ucSupplierCustomerInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucSupplierCustomerInfo.Code = "";
            this.ucSupplierCustomerInfo.ContactPerson = "";
            this.ucSupplierCustomerInfo.EmailAddress = "";
            this.ucSupplierCustomerInfo.Fax = "";
            this.ucSupplierCustomerInfo.Location = new System.Drawing.Point(11, 39);
            this.ucSupplierCustomerInfo.Mobile = "";
            this.ucSupplierCustomerInfo.CustomerSupplierName = "ucSupplierCustomerInfo";
            this.ucSupplierCustomerInfo.OfficePhone = "";
            this.ucSupplierCustomerInfo.OpeningBal = "";
            this.ucSupplierCustomerInfo.Pager = "";
            this.ucSupplierCustomerInfo.ResidentPhone = "";
            this.ucSupplierCustomerInfo.ShortName = "";
            this.ucSupplierCustomerInfo.Size = new System.Drawing.Size(747, 345);
            this.ucSupplierCustomerInfo.TabIndex = 72;
            // 
            // frmSupplierLedgerAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 536);
            this.Controls.Add(this.ucSupplierCustomerInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDLNo);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtTin);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cbxPurchaseType);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbxArea);
            this.Controls.Add(this.label16);
            this.Name = "frmSupplierLedgerAddUpdate";
            this.Text = "frmSupplierLedgerAddUpdate";
            this.Load += new System.EventHandler(this.frmSupplierLedgerAddUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxArea;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbxPurchaseType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDLNo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTin;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private ucSupplierCustomerInfo ucSupplierCustomerInfo;
    }
}