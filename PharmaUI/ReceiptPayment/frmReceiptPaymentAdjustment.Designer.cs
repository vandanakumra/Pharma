namespace PharmaUI.ReceiptPayment
{
    partial class frmReceiptPaymentAdjustment
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
            this.dgvReceiptPaymentAdjustment = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPartyName = new System.Windows.Forms.Label();
            this.lblPartyNameVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptPaymentAdjustment)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReceiptPaymentAdjustment
            // 
            this.dgvReceiptPaymentAdjustment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReceiptPaymentAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptPaymentAdjustment.Location = new System.Drawing.Point(12, 93);
            this.dgvReceiptPaymentAdjustment.MultiSelect = false;
            this.dgvReceiptPaymentAdjustment.Name = "dgvReceiptPaymentAdjustment";
            this.dgvReceiptPaymentAdjustment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptPaymentAdjustment.Size = new System.Drawing.Size(882, 327);
            this.dgvReceiptPaymentAdjustment.TabIndex = 201;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(331, 429);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 33);
            this.btnSave.TabIndex = 1001;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(446, 429);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 33);
            this.btnCancel.TabIndex = 1002;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPartyName
            // 
            this.lblPartyName.AutoSize = true;
            this.lblPartyName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyName.Location = new System.Drawing.Point(12, 71);
            this.lblPartyName.Name = "lblPartyName";
            this.lblPartyName.Size = new System.Drawing.Size(102, 19);
            this.lblPartyName.TabIndex = 100;
            this.lblPartyName.Text = "Party Name :";
            // 
            // lblPartyNameVal
            // 
            this.lblPartyNameVal.AutoSize = true;
            this.lblPartyNameVal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyNameVal.Location = new System.Drawing.Point(110, 71);
            this.lblPartyNameVal.Name = "lblPartyNameVal";
            this.lblPartyNameVal.Size = new System.Drawing.Size(93, 19);
            this.lblPartyNameVal.TabIndex = 101;
            this.lblPartyNameVal.Text = "A.K Pharma";
            // 
            // frmReceiptPaymentAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 470);
            this.ControlBox = false;
            this.Controls.Add(this.lblPartyNameVal);
            this.Controls.Add(this.lblPartyName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvReceiptPaymentAdjustment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReceiptPaymentAdjustment";
            this.Load += new System.EventHandler(this.frmReceiptPaymentAdjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptPaymentAdjustment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReceiptPaymentAdjustment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPartyName;
        private System.Windows.Forms.Label lblPartyNameVal;
    }
}