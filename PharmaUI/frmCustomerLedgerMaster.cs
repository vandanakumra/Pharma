using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Master;
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
        IApplicationFacade applicationFacade;

        public frmCustomerLedgerMaster()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmCustomerLedgerMaster_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Customer Ledger Master");

            LoadDataGrid();

            dgvCustomerLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerLedger.AllowUserToAddRows = false;
            dgvCustomerLedger.AllowUserToDeleteRows = false;
            dgvCustomerLedger.ReadOnly = true;

            dgvCustomerLedger.CellDoubleClick += dgvCustomerLedger_CellDoubleClick;
        }

        private void dgvCustomerLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                frmCustomerLedgerMasterAddUpdate form = new frmCustomerLedgerMasterAddUpdate(true);
                CustomerLedgerMaster existingItem = (CustomerLedgerMaster)dgvCustomerLedger.CurrentRow.DataBoundItem;
                form.frmCustomerLedgerMasterAddUpdate_Fill_UsingExistingItem(existingItem);
                form.FormClosed += Form_FormClosed;
                form.Show();
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            dgvCustomerLedger.DataSource = applicationFacade.GetCustomerLedgers();

            for (int i = 0; i < dgvCustomerLedger.Columns.Count; i++)
            {
                dgvCustomerLedger.Columns[i].Visible = false;
            }

            dgvCustomerLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerLedger.AllowUserToAddRows = false;
            dgvCustomerLedger.AllowUserToDeleteRows = false;
            dgvCustomerLedger.ReadOnly = true;


            dgvCustomerLedger.Columns["CustomerLedgerCode"].Visible = true;
            dgvCustomerLedger.Columns["CustomerLedgerCode"].HeaderText = "Ledger Code";

            dgvCustomerLedger.Columns["CustomerLedgerName"].Visible = true;
            dgvCustomerLedger.Columns["CustomerLedgerName"].HeaderText = "Ledger Name";

            dgvCustomerLedger.Columns["CustomerLedgerShortName"].Visible = true;
            dgvCustomerLedger.Columns["CustomerLedgerShortName"].HeaderText = "Ledger ShortName";

            dgvCustomerLedger.Columns["Address"].Visible = true;
            dgvCustomerLedger.Columns["Address"].HeaderText = "Address";

            dgvCustomerLedger.Columns["Mobile"].Visible = true;
            dgvCustomerLedger.Columns["Mobile"].HeaderText = "Mobile";

            dgvCustomerLedger.Columns["EmailAddress"].Visible = true;
            dgvCustomerLedger.Columns["EmailAddress"].HeaderText = "Email Address";

            dgvCustomerLedger.Columns["OpeningBal"].Visible = true;
            dgvCustomerLedger.Columns["OpeningBal"].HeaderText = "Opening Bal";

            dgvCustomerLedger.Columns["CreditDebit"].Visible = true;
            dgvCustomerLedger.Columns["CreditDebit"].HeaderText = "CreditDebit";

            dgvCustomerLedger.Columns["BankName"].Visible = true;
            dgvCustomerLedger.Columns["BankName"].HeaderText = "Bank Name";

            dgvCustomerLedger.Columns["Status"].Visible = true;
            dgvCustomerLedger.Columns["Status"].HeaderText = "Status";

            //Change order
            dgvCustomerLedger.Columns["Status"].DisplayIndex = dgvCustomerLedger.ColumnCount-1;

        }

        private void btnAddNewLedger_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new frmCustomerLedgerMasterAddUpdate();
                ExtensionMethods.AddChildFormToPanel(this, form, ExtensionMethods.MainPanel);
                form.FormClosed += Form_FormClosed;
                form.Show();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
