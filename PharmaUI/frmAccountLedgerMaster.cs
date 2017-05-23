using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
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
        private string accountLedgerCode = string.Empty;
        private string accountLedgerName = string.Empty;
        private bool isOpenAsDialog = false;
        private string ledgerType = string.Empty;

        public string AccountLedgerID { get { return accountLedgerCode; } }
        public string AccountLedgerName { get { return accountLedgerName; } }

        IApplicationFacade applicationFacade;

        private int selectedRowIndex = 0;    

        public frmAccountLedgerMaster()
        {           
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        public frmAccountLedgerMaster(bool isDialog, string ledgerTypeName)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);

            List<Control> allControls = ExtensionMethods.GetAllControls(this);
            allControls.ForEach(k => k.Visible = false);

            this.WindowState = FormWindowState.Normal;
          //  btnClose.Visible = true;
            dgvAccountLedger.Visible = true;
            ledgerType = ledgerTypeName;
            isOpenAsDialog = isDialog;

            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        //Set focus for the controls
        public void GotFocusEventRaised(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    GotFocusEventRaised(c);
                }
                else
                {
                    if (c is TextBox)
                    {
                        TextBox tb1 = (TextBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }

                    else if (c is ComboBox)
                    {
                        ComboBox tb1 = (ComboBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }
                }
            }
        }

        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }

        private void frmAccountLedgerMaster_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Account Ledger Master");
            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);

            LoadCombo();
            

            if (isOpenAsDialog)
            {
                dgvAccountLedger.SelectionChanged += DgvAccountLedger_SelectionChanged;
                AccountLedgerType master = applicationFacade.GetAccountLedgerTypeByName(ledgerType);
                LoadDataGrid(master != null ? master.AccountLedgerTypeID : 0);
            }
            else
            {
                LoadDataGrid(0);
                dgvAccountLedger.CellContentDoubleClick += DgvAccountLedger_CellDoubleClick;
                dgvAccountLedger.KeyDown += DgvAccountLedger_KeyDown;
            }
            dgvAccountLedger.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtSearch.Focus();
        }

        private void DgvAccountLedger_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccountLedger.SelectedRows != null && dgvAccountLedger.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAccountLedger.SelectedRows[0];

                if (row != null)
                {
                    accountLedgerCode = Convert.ToString(row.Cells["AccountLedgerCode"].Value);
                    accountLedgerName = Convert.ToString(row.Cells["AccountLedgerName"].Value);
                }
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
