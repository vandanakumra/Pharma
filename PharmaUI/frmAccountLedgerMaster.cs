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

        private int selectedRowIndex = 0;    

        public frmAccountLedgerMaster()
        {           
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
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

                OpenAddEdit(model.AccountLedgerID);
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


        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            //LoadCombo();
            LoadDataGrid((int)cbLedgerType.SelectedValue);           

            if (dgvAccountLedger.Rows.Count > 0)
            {
                dgvAccountLedger.Rows[0].Selected = true;
            }

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid((int)cbLedgerType.SelectedValue);
        }

        private void OpenAddEdit(int accountLedgerId)
        {
            frmAccountLedgerMasterAddUpdate form = new frmAccountLedgerMasterAddUpdate(accountLedgerId,txtSearch.Text);
            form.FormClosed -= Form_FormClosed;
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenAddEdit(0);           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditLedger();
        }

        private void EditLedger()
        {
            if (dgvAccountLedger.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");          

            PharmaBusinessObjects.Master.AccountLedgerMaster model = (PharmaBusinessObjects.Master.AccountLedgerMaster)dgvAccountLedger.SelectedRows[0].DataBoundItem;

            selectedRowIndex = model.AccountLedgerID;           

            OpenAddEdit(model.AccountLedgerID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                //PharmaBusinessObjects.Master.AccountLedgerMaster itemToBeRemoved = (PharmaBusinessObjects.Master.AccountLedgerMaster)dgvAccountLedger.SelectedRows[0].DataBoundItem;
                //applicationFacade.DeleteItem(itemToBeRemoved);
                //LoadDataGrid(0);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.F9))
            {
                OpenAddEdit(0);
                return true;
            }
            else if (keyData == Keys.F3)
            {
                EditLedger();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
