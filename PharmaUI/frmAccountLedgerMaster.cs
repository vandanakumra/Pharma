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
            ExtensionMethods.FormLoad(this, "Account Ledger Master");

            LoadCombo();
            LoadDataGrid(0);
            dgvAccountLedger.CellDoubleClick += DgvAccountLedger_CellDoubleClick;
            dgvAccountLedger.KeyDown += DgvAccountLedger_KeyDown;
        }

        private void DgvAccountLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvAccountLedger.SelectedRows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    //PharmaBusinessObjects.Master.AccountLedgerMaster itemToBeRemoved = (PharmaBusinessObjects.Master.AccountLedgerMaster)dgvAccountLedger.SelectedRows[0].DataBoundItem;
                    //applicationFacade.DeleteItem(itemToBeRemoved);
                    //LoadDataGrid(0);
                }
            }
        }

        private void DgvAccountLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                PharmaBusinessObjects.Master.AccountLedgerMaster model = (PharmaBusinessObjects.Master.AccountLedgerMaster)dgvAccountLedger.Rows[e.RowIndex].DataBoundItem;

                frmAccountLedgerMasterAddUpdate form = new frmAccountLedgerMasterAddUpdate(model.AccountLedgerID);
                form.FormClosed -= Form_FormClosed;
                form.FormClosed += Form_FormClosed;
                form.Show();
            }
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

            dgvAccountLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccountLedger.AllowUserToAddRows = false;
            dgvAccountLedger.AllowUserToDeleteRows = false;
            dgvAccountLedger.ReadOnly = true;
           
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

            dgvAccountLedger.Columns["Status"].Visible = true;            
        }

        private void btnAddNewLedger_Click(object sender, EventArgs e)
        {
            frmAccountLedgerMasterAddUpdate form = new frmAccountLedgerMasterAddUpdate();
            form.FormClosed -= Form_FormClosed;
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();

        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCombo();
            LoadDataGrid(0);

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid((int)cbLedgerType.SelectedValue);
        }

        //private void dgvAccountLedger_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    PharmaBusinessObjects.Master.AccountLedgerMaster model = (PharmaBusinessObjects.Master.AccountLedgerMaster)dgvAccountLedger.Rows[e.RowIndex].DataBoundItem;

        //    frmAccountLedgerMasterAddUpdate form = new frmAccountLedgerMasterAddUpdate(model.AccountLedgerID);
        //    form.FormClosed += Form_FormClosed1;
        //    form.FormClosed += Form_FormClosed1;
        //    form.Show();
        //}

        //private void Form_FormClosed1(object sender, FormClosedEventArgs e)
        //{
        //    LoadDataGrid((int)cbLedgerType.SelectedValue);
        //}
    }
}
