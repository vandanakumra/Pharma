namespace PharmaUI
{
    partial class frmReceiptFromCustomer
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
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblAmtOS = new System.Windows.Forms.Label();
            this.lblAmtOSVal = new System.Windows.Forms.Label();
            this.lblAmtAdjVal = new System.Windows.Forms.Label();
            this.lblAmtAdj = new System.Windows.Forms.Label();
            this.lblTotalCash = new System.Windows.Forms.Label();
            this.lblCashVal = new System.Windows.Forms.Label();
            this.lblTotalCQ = new System.Windows.Forms.Label();
            this.lblCQVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItemList
            // 
            this.dgvItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Location = new System.Drawing.Point(16, 89);
            this.dgvItemList.MultiSelect = false;
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemList.Size = new System.Drawing.Size(1024, 188);
            this.dgvItemList.TabIndex = 105;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(62, 57);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(145, 26);
            this.txtDate.TabIndex = 106;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(12, 60);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 19);
            this.lblSearch.TabIndex = 107;
            this.lblSearch.Text = "Date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblCQVal, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCQ, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCashVal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCash, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAmtAdjVal, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAmtAdj, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAmtOSVal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAmtOS, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 277);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 248);
            this.tableLayoutPanel1.TabIndex = 108;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Location = new System.Drawing.Point(6, 62);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(508, 180);
            this.dataGridView1.TabIndex = 109;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView2, 2);
            this.dataGridView2.Location = new System.Drawing.Point(523, 62);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(499, 180);
            this.dataGridView2.TabIndex = 110;
            // 
            // lblAmtOS
            // 
            this.lblAmtOS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAmtOS.AutoSize = true;
            this.lblAmtOS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtOS.Location = new System.Drawing.Point(6, 34);
            this.lblAmtOS.Margin = new System.Windows.Forms.Padding(3);
            this.lblAmtOS.Name = "lblAmtOS";
            this.lblAmtOS.Size = new System.Drawing.Size(162, 19);
            this.lblAmtOS.TabIndex = 111;
            this.lblAmtOS.Text = "Amount Outstanding ";
            this.lblAmtOS.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblAmtOSVal
            // 
            this.lblAmtOSVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAmtOSVal.AutoSize = true;
            this.lblAmtOSVal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtOSVal.ForeColor = System.Drawing.Color.Blue;
            this.lblAmtOSVal.Location = new System.Drawing.Point(184, 34);
            this.lblAmtOSVal.Margin = new System.Windows.Forms.Padding(3);
            this.lblAmtOSVal.Name = "lblAmtOSVal";
            this.lblAmtOSVal.Size = new System.Drawing.Size(45, 19);
            this.lblAmtOSVal.TabIndex = 112;
            this.lblAmtOSVal.Text = "3500";
            this.lblAmtOSVal.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblAmtAdjVal
            // 
            this.lblAmtAdjVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAmtAdjVal.AutoSize = true;
            this.lblAmtAdjVal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtAdjVal.ForeColor = System.Drawing.Color.Blue;
            this.lblAmtAdjVal.Location = new System.Drawing.Point(691, 34);
            this.lblAmtAdjVal.Margin = new System.Windows.Forms.Padding(3);
            this.lblAmtAdjVal.Name = "lblAmtAdjVal";
            this.lblAmtAdjVal.Size = new System.Drawing.Size(45, 19);
            this.lblAmtAdjVal.TabIndex = 114;
            this.lblAmtAdjVal.Text = "4500";
            this.lblAmtAdjVal.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblAmtAdj
            // 
            this.lblAmtAdj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAmtAdj.AutoSize = true;
            this.lblAmtAdj.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtAdj.Location = new System.Drawing.Point(523, 34);
            this.lblAmtAdj.Margin = new System.Windows.Forms.Padding(3);
            this.lblAmtAdj.Name = "lblAmtAdj";
            this.lblAmtAdj.Size = new System.Drawing.Size(139, 19);
            this.lblAmtAdj.TabIndex = 113;
            this.lblAmtAdj.Text = "Amount Adjusted ";
            this.lblAmtAdj.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTotalCash
            // 
            this.lblTotalCash.AutoSize = true;
            this.lblTotalCash.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCash.Location = new System.Drawing.Point(6, 6);
            this.lblTotalCash.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalCash.Name = "lblTotalCash";
            this.lblTotalCash.Size = new System.Drawing.Size(106, 19);
            this.lblTotalCash.TabIndex = 112;
            this.lblTotalCash.Text = "TOTAL CASH";
            // 
            // lblCashVal
            // 
            this.lblCashVal.AutoSize = true;
            this.lblCashVal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashVal.ForeColor = System.Drawing.Color.Blue;
            this.lblCashVal.Location = new System.Drawing.Point(184, 6);
            this.lblCashVal.Margin = new System.Windows.Forms.Padding(3);
            this.lblCashVal.Name = "lblCashVal";
            this.lblCashVal.Size = new System.Drawing.Size(45, 19);
            this.lblCashVal.TabIndex = 113;
            this.lblCashVal.Text = "3500";
            // 
            // lblTotalCQ
            // 
            this.lblTotalCQ.AutoSize = true;
            this.lblTotalCQ.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCQ.Location = new System.Drawing.Point(523, 6);
            this.lblTotalCQ.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalCQ.Name = "lblTotalCQ";
            this.lblTotalCQ.Size = new System.Drawing.Size(127, 19);
            this.lblTotalCQ.TabIndex = 115;
            this.lblTotalCQ.Text = "TOTAL CHEQUE";
            // 
            // lblCQVal
            // 
            this.lblCQVal.AutoSize = true;
            this.lblCQVal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCQVal.ForeColor = System.Drawing.Color.Blue;
            this.lblCQVal.Location = new System.Drawing.Point(691, 6);
            this.lblCQVal.Margin = new System.Windows.Forms.Padding(3);
            this.lblCQVal.Name = "lblCQVal";
            this.lblCQVal.Size = new System.Drawing.Size(45, 19);
            this.lblCQVal.TabIndex = 115;
            this.lblCQVal.Text = "4500";
            // 
            // frmReceiptFromCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 537);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dgvItemList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReceiptFromCustomer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReceiptFromCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAmtOS;
        private System.Windows.Forms.Label lblAmtOSVal;
        private System.Windows.Forms.Label lblAmtAdjVal;
        private System.Windows.Forms.Label lblAmtAdj;
        private System.Windows.Forms.Label lblCQVal;
        private System.Windows.Forms.Label lblTotalCQ;
        private System.Windows.Forms.Label lblCashVal;
        private System.Windows.Forms.Label lblTotalCash;
    }
}