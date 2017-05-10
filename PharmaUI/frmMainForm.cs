using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            pnlMain.Dock = DockStyle.Fill;

            List<Control> allControls = ExtensionMethods.GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void accountLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountLedgerMaster form = new frmAccountLedgerMaster();
            ExtensionMethods.SetFormProperties(form, pnlMain);           
            form.Show();
        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompany form = new frmCompany();
            ExtensionMethods.SetFormProperties(form, pnlMain);
            form.Show();
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemMaster form = new frmItemMaster();
            ExtensionMethods.SetFormProperties(form, pnlMain);
            form.Show();

        }       

        private void personalDiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonalLedgerMaster form = new frmPersonalLedgerMaster();
            ExtensionMethods.SetFormProperties(form, pnlMain);
            form.Show();
        }

        private void supplierLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierLedger form = new frmSupplierLedger();
            ExtensionMethods.SetFormProperties(form, pnlMain);
            form.Show();
        }

        private void customerLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerLedgerMaster form = new frmCustomerLedgerMaster();
            ExtensionMethods.SetFormProperties(form, pnlMain);
            form.Show();
        }

        private void personRouteMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonRouteMaster form = new frmPersonRouteMaster();
            ExtensionMethods.SetFormProperties(form, pnlMain);
            form.Show();
        }
    }
}
