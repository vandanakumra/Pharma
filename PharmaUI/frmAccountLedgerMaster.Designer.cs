namespace PharmaUI
{
    partial class frmAccountLedgerMaster
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
            this.dgvAccountLedger = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAccountLedger
            // 
            this.dgvAccountLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountLedger.Location = new System.Drawing.Point(12, 49);
            this.dgvAccountLedger.Name = "dgvAccountLedger";
            this.dgvAccountLedger.Size = new System.Drawing.Size(1114, 150);
            this.dgvAccountLedger.TabIndex = 0;
            // 
            // frmAccountLedgerMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 322);
            this.Controls.Add(this.dgvAccountLedger);
            this.Name = "frmAccountLedgerMaster";
            this.Text = "Account Ledger Master";
            this.Load += new System.EventHandler(this.frmAccountLedgerMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountLedger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccountLedger;
    }
}