namespace PharmaUI
{
    partial class frmMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.masterMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountLedgerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personLedgerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personRouteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterMaintenanceToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // masterMaintenanceToolStripMenuItem
            // 
            this.masterMaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountMenuItem,
            this.companyMenuItem,
            this.itemMenuItem,
            this.personRouteMenuItem,
            this.exitToolStripMenuItem});
            this.masterMaintenanceToolStripMenuItem.Name = "masterMaintenanceToolStripMenuItem";
            this.masterMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.masterMaintenanceToolStripMenuItem.Text = "Master Maintenance";
            // 
            // accountMenuItem
            // 
            this.accountMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountLedgerMenuItem,
            this.personLedgerMenuItem});
            this.accountMenuItem.Name = "accountMenuItem";
            this.accountMenuItem.Size = new System.Drawing.Size(147, 22);
            this.accountMenuItem.Text = "Account";
            // 
            // accountLedgerMenuItem
            // 
            this.accountLedgerMenuItem.Name = "accountLedgerMenuItem";
            this.accountLedgerMenuItem.Size = new System.Drawing.Size(158, 22);
            this.accountLedgerMenuItem.Text = "Account Ledger";
            // 
            // personLedgerMenuItem
            // 
            this.personLedgerMenuItem.Name = "personLedgerMenuItem";
            this.personLedgerMenuItem.Size = new System.Drawing.Size(158, 22);
            this.personLedgerMenuItem.Text = "Person Ledger";
            // 
            // companyMenuItem
            // 
            this.companyMenuItem.Name = "companyMenuItem";
            this.companyMenuItem.Size = new System.Drawing.Size(147, 22);
            this.companyMenuItem.Text = "Company";
            this.companyMenuItem.Click += new System.EventHandler(this.companyMenuItem_Click);
            // 
            // itemMenuItem
            // 
            this.itemMenuItem.Name = "itemMenuItem";
            this.itemMenuItem.Size = new System.Drawing.Size(147, 22);
            this.itemMenuItem.Text = "Item";
            // 
            // personRouteMenuItem
            // 
            this.personRouteMenuItem.Name = "personRouteMenuItem";
            this.personRouteMenuItem.Size = new System.Drawing.Size(147, 22);
            this.personRouteMenuItem.Text = "Person & Route";
            this.personRouteMenuItem.Click += new System.EventHandler(this.personRouteToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(23, 23);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem masterMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountLedgerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personLedgerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personRouteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}



