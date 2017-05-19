namespace PharmaUI
{
    partial class frmCustomerItemDiscountMaster
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedCompanyName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCustomerItemDiscount = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerItemDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company :";
            // 
            // lblSelectedCompanyName
            // 
            this.lblSelectedCompanyName.AutoSize = true;
            this.lblSelectedCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedCompanyName.Location = new System.Drawing.Point(107, 73);
            this.lblSelectedCompanyName.Name = "lblSelectedCompanyName";
            this.lblSelectedCompanyName.Size = new System.Drawing.Size(63, 17);
            this.lblSelectedCompanyName.TabIndex = 1;
            this.lblSelectedCompanyName.Text = "Ranbaxy";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(571, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvCustomerItemDiscount, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 359);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dgvCustomerItemDiscount
            // 
            this.dgvCustomerItemDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerItemDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerItemDiscount.Location = new System.Drawing.Point(3, 3);
            this.dgvCustomerItemDiscount.Name = "dgvCustomerItemDiscount";
            this.dgvCustomerItemDiscount.Size = new System.Drawing.Size(623, 353);
            this.dgvCustomerItemDiscount.TabIndex = 0;
            // 
            // frmCustomerItemDiscountMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 468);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSelectedCompanyName);
            this.Controls.Add(this.label1);
            this.Name = "frmCustomerItemDiscountMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustomerItemDiscountMaster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomerItemDiscountMaster_FormClosing);
            this.Load += new System.EventHandler(this.frmCustomerItemDiscountMaster_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerItemDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedCompanyName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvCustomerItemDiscount;
    }
}