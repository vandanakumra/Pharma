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
            this.lblScheme = new System.Windows.Forms.Label();
            this.lblSchemeSign = new System.Windows.Forms.Label();
            this.lblHalfScheme = new System.Windows.Forms.Label();
            this.txtScheme1 = new System.Windows.Forms.TextBox();
            this.txtScheme2 = new System.Windows.Forms.TextBox();
            this.chkIsHalfScheme = new System.Windows.Forms.CheckBox();
            this.tblMain.SuspendLayout();
            this.tblScheme.SuspendLayout();
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
            this.tblMain.Location = new System.Drawing.Point(0, 60);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMain.Size = new System.Drawing.Size(730, 100);
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
            this.tblScheme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblScheme.Size = new System.Drawing.Size(724, 27);
            this.tblScheme.TabIndex = 0;
            // 
            // lblScheme
            // 
            this.lblScheme.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblScheme.AutoSize = true;
            this.lblScheme.Location = new System.Drawing.Point(3, 7);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(46, 13);
            this.lblScheme.TabIndex = 0;
            this.lblScheme.Text = "Scheme";
            // 
            // lblSchemeSign
            // 
            this.lblSchemeSign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSchemeSign.AutoSize = true;
            this.lblSchemeSign.Location = new System.Drawing.Point(270, 7);
            this.lblSchemeSign.Name = "lblSchemeSign";
            this.lblSchemeSign.Size = new System.Drawing.Size(13, 13);
            this.lblSchemeSign.TabIndex = 1;
            this.lblSchemeSign.Text = "+";
            // 
            // lblHalfScheme
            // 
            this.lblHalfScheme.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHalfScheme.AutoSize = true;
            this.lblHalfScheme.Location = new System.Drawing.Point(457, 7);
            this.lblHalfScheme.Name = "lblHalfScheme";
            this.lblHalfScheme.Size = new System.Drawing.Size(68, 13);
            this.lblHalfScheme.TabIndex = 2;
            this.lblHalfScheme.Text = "Half Scheme";
            // 
            // txtScheme1
            // 
            this.txtScheme1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScheme1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScheme1.Location = new System.Drawing.Point(103, 3);
            this.txtScheme1.Name = "txtScheme1";
            this.txtScheme1.Size = new System.Drawing.Size(161, 20);
            this.txtScheme1.TabIndex = 3;
            // 
            // txtScheme2
            // 
            this.txtScheme2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScheme2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScheme2.Location = new System.Drawing.Point(290, 3);
            this.txtScheme2.Name = "txtScheme2";
            this.txtScheme2.Size = new System.Drawing.Size(161, 20);
            this.txtScheme2.TabIndex = 4;
            // 
            // chkIsHalfScheme
            // 
            this.chkIsHalfScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsHalfScheme.AutoSize = true;
            this.chkIsHalfScheme.Location = new System.Drawing.Point(557, 3);
            this.chkIsHalfScheme.Name = "chkIsHalfScheme";
            this.chkIsHalfScheme.Size = new System.Drawing.Size(164, 21);
            this.chkIsHalfScheme.TabIndex = 5;
            this.chkIsHalfScheme.UseVisualStyleBackColor = true;
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
            this.Load += new System.EventHandler(this.frmPurchaseBookLineItemUpdate_Load);
            this.tblMain.ResumeLayout(false);
            this.tblScheme.ResumeLayout(false);
            this.tblScheme.PerformLayout();
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
    }
}