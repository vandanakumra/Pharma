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
            this.tblScheme = new System.Windows.Forms.TableLayoutPanel();
            this.txtScheme2 = new System.Windows.Forms.TextBox();
            this.lblScheme = new System.Windows.Forms.Label();
            this.lblSchemeSign = new System.Windows.Forms.Label();
            this.lblHalfScheme = new System.Windows.Forms.Label();
            this.txtScheme1 = new System.Windows.Forms.TextBox();
            this.chkIsHalfScheme = new System.Windows.Forms.CheckBox();
            this.tblDiscount = new System.Windows.Forms.TableLayoutPanel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblSpecialDiscount = new System.Windows.Forms.Label();
            this.lblVolumeDiscount = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.lblExcise = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtSpecialDiscount = new System.Windows.Forms.TextBox();
            this.txtVolDiscount = new System.Windows.Forms.TextBox();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.txtExcise = new System.Windows.Forms.TextBox();
            this.dtExpiry = new System.Windows.Forms.DateTimePicker();
            this.dgvBatchList = new System.Windows.Forms.DataGridView();
            this.tblMain.SuspendLayout();
            this.tblScheme.SuspendLayout();
            this.tblDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchList)).BeginInit();
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
            this.tblMain.Controls.Add(this.tblScheme, 0, 0);
            this.tblMain.Controls.Add(this.tblDiscount, 0, 1);
            this.tblMain.Controls.Add(this.dgvBatchList, 0, 2);
            this.tblMain.Location = new System.Drawing.Point(0, 60);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMain.Size = new System.Drawing.Size(730, 134);
            this.tblMain.TabIndex = 0;
            // 
            // tblScheme
            // 
            this.tblScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblScheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblScheme.ColumnCount = 6;
            this.tblScheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblScheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblScheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblScheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblScheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblScheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblScheme.Controls.Add(this.txtScheme2, 3, 0);
            this.tblScheme.Controls.Add(this.lblScheme, 0, 0);
            this.tblScheme.Controls.Add(this.lblSchemeSign, 2, 0);
            this.tblScheme.Controls.Add(this.lblHalfScheme, 4, 0);
            this.tblScheme.Controls.Add(this.txtScheme1, 1, 0);
            this.tblScheme.Controls.Add(this.chkIsHalfScheme, 5, 0);
            this.tblScheme.Location = new System.Drawing.Point(3, 3);
            this.tblScheme.Name = "tblScheme";
            this.tblScheme.RowCount = 1;
            this.tblScheme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblScheme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblScheme.Size = new System.Drawing.Size(724, 38);
            this.tblScheme.TabIndex = 0;
            // 
            // txtScheme2
            // 
            this.txtScheme2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtScheme2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScheme2.Location = new System.Drawing.Point(292, 9);
            this.txtScheme2.Name = "txtScheme2";
            this.txtScheme2.Size = new System.Drawing.Size(161, 20);
            this.txtScheme2.TabIndex = 4;
            // 
            // lblScheme
            // 
            this.lblScheme.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblScheme.AutoSize = true;
            this.lblScheme.Location = new System.Drawing.Point(3, 12);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(46, 13);
            this.lblScheme.TabIndex = 0;
            this.lblScheme.Text = "Scheme";
            // 
            // lblSchemeSign
            // 
            this.lblSchemeSign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSchemeSign.AutoSize = true;
            this.lblSchemeSign.Location = new System.Drawing.Point(271, 12);
            this.lblSchemeSign.Name = "lblSchemeSign";
            this.lblSchemeSign.Size = new System.Drawing.Size(13, 13);
            this.lblSchemeSign.TabIndex = 1;
            this.lblSchemeSign.Text = "+";
            // 
            // lblHalfScheme
            // 
            this.lblHalfScheme.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHalfScheme.AutoSize = true;
            this.lblHalfScheme.Location = new System.Drawing.Point(459, 12);
            this.lblHalfScheme.Name = "lblHalfScheme";
            this.lblHalfScheme.Size = new System.Drawing.Size(68, 13);
            this.lblHalfScheme.TabIndex = 2;
            this.lblHalfScheme.Text = "Half Scheme";
            // 
            // txtScheme1
            // 
            this.txtScheme1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtScheme1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScheme1.Location = new System.Drawing.Point(103, 9);
            this.txtScheme1.Name = "txtScheme1";
            this.txtScheme1.Size = new System.Drawing.Size(161, 20);
            this.txtScheme1.TabIndex = 3;
            // 
            // chkIsHalfScheme
            // 
            this.chkIsHalfScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsHalfScheme.AutoSize = true;
            this.chkIsHalfScheme.Location = new System.Drawing.Point(559, 3);
            this.chkIsHalfScheme.Name = "chkIsHalfScheme";
            this.chkIsHalfScheme.Size = new System.Drawing.Size(162, 32);
            this.chkIsHalfScheme.TabIndex = 5;
            this.chkIsHalfScheme.UseVisualStyleBackColor = true;
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
            this.tblDiscount.Location = new System.Drawing.Point(3, 47);
            this.tblDiscount.Name = "tblDiscount";
            this.tblDiscount.RowCount = 2;
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDiscount.Size = new System.Drawing.Size(724, 38);
            this.tblDiscount.TabIndex = 1;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(3, 3);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(49, 13);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Location = new System.Drawing.Point(123, 3);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtDiscount.TabIndex = 6;
            // 
            // lblSpecialDiscount
            // 
            this.lblSpecialDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSpecialDiscount.AutoSize = true;
            this.lblSpecialDiscount.Location = new System.Drawing.Point(243, 3);
            this.lblSpecialDiscount.Name = "lblSpecialDiscount";
            this.lblSpecialDiscount.Size = new System.Drawing.Size(87, 13);
            this.lblSpecialDiscount.TabIndex = 5;
            this.lblSpecialDiscount.Text = "Special Discount";
            // 
            // lblVolumeDiscount
            // 
            this.lblVolumeDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVolumeDiscount.AutoSize = true;
            this.lblVolumeDiscount.Location = new System.Drawing.Point(483, 3);
            this.lblVolumeDiscount.Name = "lblVolumeDiscount";
            this.lblVolumeDiscount.Size = new System.Drawing.Size(87, 13);
            this.lblVolumeDiscount.TabIndex = 6;
            this.lblVolumeDiscount.Text = "Volume Discount";
            // 
            // lblMRP
            // 
            this.lblMRP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMRP.AutoSize = true;
            this.lblMRP.Location = new System.Drawing.Point(3, 22);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(31, 13);
            this.lblMRP.TabIndex = 7;
            this.lblMRP.Text = "MRP";
            // 
            // lblExcise
            // 
            this.lblExcise.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExcise.AutoSize = true;
            this.lblExcise.Location = new System.Drawing.Point(243, 22);
            this.lblExcise.Name = "lblExcise";
            this.lblExcise.Size = new System.Drawing.Size(38, 13);
            this.lblExcise.TabIndex = 8;
            this.lblExcise.Text = "Excise";
            // 
            // lblExpiry
            // 
            this.lblExpiry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Location = new System.Drawing.Point(483, 22);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(35, 13);
            this.lblExpiry.TabIndex = 9;
            this.lblExpiry.Text = "Expiry";
            // 
            // txtSpecialDiscount
            // 
            this.txtSpecialDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSpecialDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecialDiscount.Location = new System.Drawing.Point(363, 3);
            this.txtSpecialDiscount.Name = "txtSpecialDiscount";
            this.txtSpecialDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtSpecialDiscount.TabIndex = 7;
            // 
            // txtVolDiscount
            // 
            this.txtVolDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVolDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVolDiscount.Location = new System.Drawing.Point(605, 3);
            this.txtVolDiscount.Name = "txtVolDiscount";
            this.txtVolDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtVolDiscount.TabIndex = 8;
            // 
            // txtMRP
            // 
            this.txtMRP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRP.Location = new System.Drawing.Point(123, 22);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(114, 20);
            this.txtMRP.TabIndex = 9;
            // 
            // txtExcise
            // 
            this.txtExcise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtExcise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExcise.Location = new System.Drawing.Point(363, 22);
            this.txtExcise.Name = "txtExcise";
            this.txtExcise.Size = new System.Drawing.Size(114, 20);
            this.txtExcise.TabIndex = 10;
            // 
            // dtExpiry
            // 
            this.dtExpiry.CustomFormat = "MM/yyyy";
            this.dtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpiry.Location = new System.Drawing.Point(603, 22);
            this.dtExpiry.Name = "dtExpiry";
            this.dtExpiry.Size = new System.Drawing.Size(118, 20);
            this.dtExpiry.TabIndex = 11;
            // 
            // dgvBatchList
            // 
            this.dgvBatchList.AllowUserToAddRows = false;
            this.dgvBatchList.AllowUserToDeleteRows = false;
            this.dgvBatchList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBatchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatchList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBatchList.Location = new System.Drawing.Point(3, 91);
            this.dgvBatchList.Name = "dgvBatchList";
            this.dgvBatchList.Size = new System.Drawing.Size(724, 40);
            this.dgvBatchList.TabIndex = 2;
            // 
            // frmPurchaseBookLineItemUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(730, 250);
            this.Controls.Add(this.tblMain);
            this.Name = "frmPurchaseBookLineItemUpdate";
            this.Text = "frmPurchaseBookLineItemUpdate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPurchaseBookLineItemUpdate_FormClosing);
            this.Load += new System.EventHandler(this.frmPurchaseBookLineItemUpdate_Load);
            this.tblMain.ResumeLayout(false);
            this.tblScheme.ResumeLayout(false);
            this.tblScheme.PerformLayout();
            this.tblDiscount.ResumeLayout(false);
            this.tblDiscount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TableLayoutPanel tblScheme;
        private System.Windows.Forms.Label lblScheme;
        private System.Windows.Forms.Label lblSchemeSign;
        private System.Windows.Forms.Label lblHalfScheme;
        private System.Windows.Forms.TextBox txtScheme1;
        private System.Windows.Forms.TextBox txtScheme2;
        private System.Windows.Forms.CheckBox chkIsHalfScheme;
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
        private System.Windows.Forms.DataGridView dgvBatchList;
    }
}