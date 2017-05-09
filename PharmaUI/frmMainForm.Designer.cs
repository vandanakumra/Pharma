namespace PharmaUI
{
    partial class frmMainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accoutMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalDiaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personRouteMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterMaintenanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterMaintenanceToolStripMenuItem
            // 
            this.masterMaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accoutMasterToolStripMenuItem,
            this.companyMasterToolStripMenuItem,
            this.itemMasterToolStripMenuItem,
            this.personRouteMasterToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.masterMaintenanceToolStripMenuItem.Name = "masterMaintenanceToolStripMenuItem";
            this.masterMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.masterMaintenanceToolStripMenuItem.Text = "Master Maintenance";
            // 
            // accoutMasterToolStripMenuItem
            // 
            this.accoutMasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountLedgerToolStripMenuItem,
            this.personalDiaryToolStripMenuItem,
            this.customerLedgerToolStripMenuItem,
            this.supplierLedgerToolStripMenuItem});
            this.accoutMasterToolStripMenuItem.Name = "accoutMasterToolStripMenuItem";
            this.accoutMasterToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.accoutMasterToolStripMenuItem.Text = "Accout Master";
            // 
            // accountLedgerToolStripMenuItem
            // 
            this.accountLedgerToolStripMenuItem.Name = "accountLedgerToolStripMenuItem";
            this.accountLedgerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.accountLedgerToolStripMenuItem.Text = "Account Ledger";
            this.accountLedgerToolStripMenuItem.Click += new System.EventHandler(this.accountLedgerToolStripMenuItem_Click);
            // 
            // personalDiaryToolStripMenuItem
            // 
            this.personalDiaryToolStripMenuItem.Name = "personalDiaryToolStripMenuItem";
            this.personalDiaryToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.personalDiaryToolStripMenuItem.Text = "Personal Diary";
            this.personalDiaryToolStripMenuItem.Click += new System.EventHandler(this.personalDiaryToolStripMenuItem_Click);
            // 
            // customerLedgerToolStripMenuItem
            // 
            this.customerLedgerToolStripMenuItem.Name = "customerLedgerToolStripMenuItem";
            this.customerLedgerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.customerLedgerToolStripMenuItem.Text = "Customer Ledger";
            this.customerLedgerToolStripMenuItem.Click += new System.EventHandler(this.customerLedgerToolStripMenuItem_Click);
            // 
            // supplierLedgerToolStripMenuItem
            // 
            this.supplierLedgerToolStripMenuItem.Name = "supplierLedgerToolStripMenuItem";
            this.supplierLedgerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.supplierLedgerToolStripMenuItem.Text = "Supplier Ledger";
            this.supplierLedgerToolStripMenuItem.Click += new System.EventHandler(this.supplierLedgerToolStripMenuItem_Click);
            // 
            // companyMasterToolStripMenuItem
            // 
            this.companyMasterToolStripMenuItem.Name = "companyMasterToolStripMenuItem";
            this.companyMasterToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.companyMasterToolStripMenuItem.Text = "Company Master";
            this.companyMasterToolStripMenuItem.Click += new System.EventHandler(this.companyMasterToolStripMenuItem_Click);
            // 
            // itemMasterToolStripMenuItem
            // 
            this.itemMasterToolStripMenuItem.Name = "itemMasterToolStripMenuItem";
            this.itemMasterToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.itemMasterToolStripMenuItem.Text = "Item Master";
            this.itemMasterToolStripMenuItem.Click += new System.EventHandler(this.itemMasterToolStripMenuItem_Click);
            // 
            // personRouteMasterToolStripMenuItem
            // 
            this.personRouteMasterToolStripMenuItem.Name = "personRouteMasterToolStripMenuItem";
            this.personRouteMasterToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.personRouteMasterToolStripMenuItem.Text = "Person Route Master";
            this.personRouteMasterToolStripMenuItem.Click += new System.EventHandler(this.personRouteMasterToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(0, 27);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(756, 100);
            this.pnlMain.TabIndex = 1;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 477);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainForm";
            this.Text = "Pharma Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accoutMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalDiaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personRouteMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
    }
}