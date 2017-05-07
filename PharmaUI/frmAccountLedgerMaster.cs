using PharmaBusiness;
using PharmaBusinessObjects;
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
    public partial class frmAccountLedgerMaster : Form
    {
        IApplicationFacade applicationFacade;

        public frmAccountLedgerMaster()
        {
           
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }

        private void frmAccountLedgerMaster_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            panel1.Width = this.Width;

            Label lbl = new Label();
            lbl.Width = panel1.Width;
            lbl.Dock = DockStyle.Fill;           
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;          
            lbl.Text = "Account Ledger Master";
            panel1.Controls.Add(lbl);


            LoadCombo();
            LoadDataGrid(0); 
        }

        private void LoadCombo()
        {
            cbLedgerType.SelectedIndexChanged -= CbLedgerType_SelectedIndexChanged;

            cbLedgerType.DataSource = applicationFacade.GetAccountLedgerTypesWithAll();
            cbLedgerType.DisplayMember = "AccountLedgerTypeName";
            cbLedgerType.ValueMember = "AccountLedgerTypeID";
            cbLedgerType.SelectedIndex = 0;

            cbLedgerType.SelectedIndexChanged += CbLedgerType_SelectedIndexChanged;


        }

        private void CbLedgerType_SelectedIndexChanged(object sender, EventArgs e)
        {          
            LoadDataGrid(cbLedgerType.SelectedIndex);
        }

        private void LoadDataGrid(int ledgerTypeID)
        {
            dgvAccountLedger.DataSource = applicationFacade.GetAccountLedgerByLedgerTypeIdAndSearch (ledgerTypeID,txtSearch.Text);

            for (int i = 0; i < dgvAccountLedger.Columns.Count; i++)
            {
                dgvAccountLedger.Columns[i].Visible = false;
            }

            dgvAccountLedger.Columns["AccountLedgerCode"].Visible = true;
            dgvAccountLedger.Columns["AccountLedgerCode"].HeaderText = "Account No";

            dgvAccountLedger.Columns["AccountLedgerType"].Visible = true;
            dgvAccountLedger.Columns["AccountLedgerType"].HeaderText = "Ledger Type";

            dgvAccountLedger.Columns["AccountLedgerName"].Visible = true;
            dgvAccountLedger.Columns["AccountLedgerName"].HeaderText = "Account Name";

            dgvAccountLedger.Columns["AccountType"].Visible = true;
            dgvAccountLedger.Columns["AccountType"].HeaderText = "Account Type";

            dgvAccountLedger.Columns["OpeningBalance"].Visible = true;
            dgvAccountLedger.Columns["OpeningBalance"].HeaderText = "Opening Balance";

            dgvAccountLedger.Columns["DebitControlCode"].Visible = true;
            dgvAccountLedger.Columns["DebitControlCode"].HeaderText = "Debit";

            dgvAccountLedger.Columns["CreditControlCode"].Visible = true;
            dgvAccountLedger.Columns["CreditControlCode"].HeaderText = "Credit";

        }

        private void btnAddNewLedger_Click(object sender, EventArgs e)
        {
            frmAccountLedgerMasterAddUpdate form = new frmAccountLedgerMasterAddUpdate();
            form.ShowDialog();

        }
    }
}
