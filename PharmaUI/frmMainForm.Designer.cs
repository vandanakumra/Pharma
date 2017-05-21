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
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accoutMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalDiaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personRouteMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inventoryMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionCtrlPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.masterMaintenanceToolStripMenuItem,
            this.inventoryMaintenanceToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // masterMaintenanceToolStripMenuItem
            // 
            this.masterMaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accoutMasterToolStripMenuItem,
            this.companyMasterToolStripMenuItem,
            this.itemMasterToolStripMenuItem,
            this.personRouteMasterToolStripMenuItem,
            this.userMasterToolStripMenuItem});
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
            this.accoutMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.accoutMasterToolStripMenuItem.Text = "Accout Master";
            // 
            // accountLedgerToolStripMenuItem
            // 
            this.accountLedgerToolStripMenuItem.Name = "accountLedgerToolStripMenuItem";
            this.accountLedgerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.accountLedgerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.accountLedgerToolStripMenuItem.Text = "Account Ledger";
            this.accountLedgerToolStripMenuItem.Click += new System.EventHandler(this.accountLedgerToolStripMenuItem_Click);
            // 
            // personalDiaryToolStripMenuItem
            // 
            this.personalDiaryToolStripMenuItem.Name = "personalDiaryToolStripMenuItem";
            this.personalDiaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.personalDiaryToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.personalDiaryToolStripMenuItem.Text = "Personal Diary";
            this.personalDiaryToolStripMenuItem.Click += new System.EventHandler(this.personalDiaryToolStripMenuItem_Click);
            // 
            // customerLedgerToolStripMenuItem
            // 
            this.customerLedgerToolStripMenuItem.Name = "customerLedgerToolStripMenuItem";
            this.customerLedgerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.customerLedgerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.customerLedgerToolStripMenuItem.Text = "Customer Ledger";
            this.customerLedgerToolStripMenuItem.Click += new System.EventHandler(this.customerLedgerToolStripMenuItem_Click);
            // 
            // supplierLedgerToolStripMenuItem
            // 
            this.supplierLedgerToolStripMenuItem.Name = "supplierLedgerToolStripMenuItem";
            this.supplierLedgerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.supplierLedgerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.supplierLedgerToolStripMenuItem.Text = "Supplier Ledger";
            this.supplierLedgerToolStripMenuItem.Click += new System.EventHandler(this.supplierLedgerToolStripMenuItem_Click);
            // 
            // companyMasterToolStripMenuItem
            // 
            this.companyMasterToolStripMenuItem.Name = "companyMasterToolStripMenuItem";
            this.companyMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.companyMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.companyMasterToolStripMenuItem.Text = "Company Master";
            this.companyMasterToolStripMenuItem.Click += new System.EventHandler(this.companyMasterToolStripMenuItem_Click);
            // 
            // itemMasterToolStripMenuItem
            // 
            this.itemMasterToolStripMenuItem.Name = "itemMasterToolStripMenuItem";
            this.itemMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.itemMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.itemMasterToolStripMenuItem.Text = "Item Master";
            this.itemMasterToolStripMenuItem.Click += new System.EventHandler(this.itemMasterToolStripMenuItem_Click);
            // 
            // personRouteMasterToolStripMenuItem
            // 
            this.personRouteMasterToolStripMenuItem.Name = "personRouteMasterToolStripMenuItem";
            this.personRouteMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.personRouteMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.personRouteMasterToolStripMenuItem.Text = "Person Route Master";
            this.personRouteMasterToolStripMenuItem.Click += new System.EventHandler(this.personRouteMasterToolStripMenuItem_Click);
            // 
            // userMasterToolStripMenuItem
            // 
            this.userMasterToolStripMenuItem.Name = "userMasterToolStripMenuItem";
            this.userMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.userMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.userMasterToolStripMenuItem.Text = "User Master";
            this.userMasterToolStripMenuItem.Click += new System.EventHandler(this.userMasterToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(0, 27);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(756, 31);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.Controls.Add(this.btnCancel);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.tbPassword);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.tbUserName);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Location = new System.Drawing.Point(197, 141);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(388, 181);
            this.pnlLogin.TabIndex = 2;
            this.pnlLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(263, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(145, 130);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(93, 35);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(145, 79);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(211, 20);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(145, 46);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(211, 20);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUserName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // inventoryMaintenanceToolStripMenuItem
            // 
            this.inventoryMaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseBookToolStripMenuItem});
            this.inventoryMaintenanceToolStripMenuItem.Name = "inventoryMaintenanceToolStripMenuItem";
            this.inventoryMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.inventoryMaintenanceToolStripMenuItem.Text = "Inventory Maintenance";
            // 
            // purchaseBookToolStripMenuItem
            // 
            this.purchaseBookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionCtrlPToolStripMenuItem});
            this.purchaseBookToolStripMenuItem.Name = "purchaseBookToolStripMenuItem";
            this.purchaseBookToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.purchaseBookToolStripMenuItem.Text = "Purchase Book";
            // 
            // transactionCtrlPToolStripMenuItem
            // 
            this.transactionCtrlPToolStripMenuItem.Name = "transactionCtrlPToolStripMenuItem";
            this.transactionCtrlPToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.transactionCtrlPToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.transactionCtrlPToolStripMenuItem.Text = "Transaction";
            this.transactionCtrlPToolStripMenuItem.Click += new System.EventHandler(this.purchaseTransactionToolStripMenuItem_Click);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 477);
            this.ControlBox = false;
            this.Controls.Add(this.pnlLogin);
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
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
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
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem userMasterToolStripMenuItem;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionCtrlPToolStripMenuItem;
    }
}