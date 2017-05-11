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
    public partial class frmCustomerLedgerMaster : Form
    {
        public frmCustomerLedgerMaster()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
        }

        private void frmCustomerLedgerMaster_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Customer Ledger Master");

            dgvCustomerLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerLedger.AllowUserToAddRows = false;
            dgvCustomerLedger.AllowUserToDeleteRows = false;
            dgvCustomerLedger.ReadOnly = true;
        }
    }
}
