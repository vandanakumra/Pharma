using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
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
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void frmCustomerLedgerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Customer Ledger Master");
                GotFocusEventRaised(this);
                ExtensionMethods.EnterKeyDownForTabEvents(this);
                LoadDataGrid();
                dgvCustomerLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCustomerLedger.AllowUserToAddRows = false;
                dgvCustomerLedger.AllowUserToDeleteRows = false;
                dgvCustomerLedger.ReadOnly = true;
                dgvCustomerLedger.CellDoubleClick += dgvCustomerLedger_CellDoubleClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomerLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex != -1)
                {
                    frmCustomerLedgerMasterAddUpdate form = new frmCustomerLedgerMasterAddUpdate(true);
                    ExtensionMethods.AddChildFormToPanel(this, form, ExtensionMethods.MainPanel);
                    CustomerLedgerMaster existingItem = (CustomerLedgerMaster)dgvCustomerLedger.CurrentRow.DataBoundItem;
                    form.frmCustomerLedgerMasterAddUpdate_Fill_UsingExistingItem(existingItem);
                    form.LoadCustomerCompanyDiscountGrid();
                    form.FormClosed += Form_FormClosed;
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (frmCustomerLedgerMasterAddUpdate)sender, ExtensionMethods.MainPanel);
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataGrid()
        {
            dgvCustomerLedger.DataSource = applicationFacade.GetCustomerLedgers(txtSearch.Text);

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

            dgvCustomerLedger.Columns["Status"].Visible = true;
            dgvCustomerLedger.Columns["Status"].HeaderText = "Status";

            //Change order
            dgvCustomerLedger.Columns["Status"].DisplayIndex = dgvCustomerLedger.ColumnCount - 1;

        }

        //Search Functionality

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ADD/UPDATE/DELETE Functionality

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new frmCustomerLedgerMasterAddUpdate();
                ExtensionMethods.AddChildFormToPanel(this, form, ExtensionMethods.MainPanel);
                form.WindowState = FormWindowState.Maximized;
                form.FormClosed += Form_FormClosed;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvCustomerLedger.SelectedRows.Count == 0)
                    MessageBox.Show("Please select atleast one row to edit");

                if (dgvCustomerLedger.SelectedRows[0] != null)
                {
                    frmCustomerLedgerMasterAddUpdate form = new frmCustomerLedgerMasterAddUpdate(true);

                    ExtensionMethods.AddChildFormToPanel(this, form, ExtensionMethods.MainPanel);
                    form.WindowState = FormWindowState.Maximized;

                    CustomerLedgerMaster existingItem = (CustomerLedgerMaster)dgvCustomerLedger.SelectedRows[0].DataBoundItem;
                    form.frmCustomerLedgerMasterAddUpdate_Fill_UsingExistingItem(existingItem);
                    form.LoadCustomerCompanyDiscountGrid();

                    form.FormClosed += Form_FormClosed;
                    form.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(Constants.Messages.DeletePrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (dgvCustomerLedger.SelectedRows.Count == 0)
                        MessageBox.Show("Please select atleast one row to delete");

                    if (dgvCustomerLedger.SelectedRows[0] != null)
                    {
                        CustomerLedgerMaster existingItem = (CustomerLedgerMaster)dgvCustomerLedger.SelectedRows[0].DataBoundItem;
                        deleteCustomerLedger(existingItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.F9))
            {
                OpenCustomerLedgerddUpdateForm(false);
                return true;
            }
            else if (keyData == Keys.F3)
            {
                if (dgvCustomerLedger.SelectedRows.Count == 0)
                    MessageBox.Show("Please select atleast one row to edit");

                OpenCustomerLedgerddUpdateForm(true);
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                DialogResult result = MessageBox.Show(Constants.Messages.DeletePrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                    if (dgvCustomerLedger.SelectedRows.Count == 0)
                        MessageBox.Show("Please select atleast one row to delete");

                    CustomerLedgerMaster existingItem = (CustomerLedgerMaster)dgvCustomerLedger.SelectedRows[0].DataBoundItem;
                    deleteCustomerLedger(existingItem);

                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OpenCustomerLedgerddUpdateForm(bool isEdit)
        {
            try
            {
                frmCustomerLedgerMasterAddUpdate form = new frmCustomerLedgerMasterAddUpdate(isEdit);
                ExtensionMethods.AddChildFormToPanel(this, form, ExtensionMethods.MainPanel);
                form.WindowState = FormWindowState.Maximized;

                if (isEdit && dgvCustomerLedger.SelectedRows[0] != null)
                {
                    CustomerLedgerMaster existingItem = (CustomerLedgerMaster)dgvCustomerLedger.SelectedRows[0].DataBoundItem;
                    form.frmCustomerLedgerMasterAddUpdate_Fill_UsingExistingItem(existingItem);
                    form.LoadCustomerCompanyDiscountGrid();
                }
                form.FormClosed += Form_FormClosed;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void deleteCustomerLedger(CustomerLedgerMaster customerLedger)
        {
            if (customerLedger != null)
            {
                applicationFacade.DeleteCustomerLedger(customerLedger.CustomerLedgerId);
                LoadDataGrid();
            }
        }

        //Disable row change on Enter
        private void dgvCustomerLedger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                }
                else
                    base.OnKeyDown(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
