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
    public partial class frmSupplierLedgerMaster : Form
    {
        public frmSupplierLedgerMaster()
        {
            InitializeComponent();
        }

        private void frmSupplierLedgerMaster_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Supplier Ledger Master");


            dgvSupplierLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSupplierLedger.AllowUserToAddRows = false;
            dgvSupplierLedger.AllowUserToDeleteRows = false;
            dgvSupplierLedger.ReadOnly = true;
        }
    }
}
