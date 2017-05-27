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
    public partial class frmSupplierLedger : Form
    {
        public PharmaBusinessObjects.Master.SupplierLedgerMaster LastSelectedSupplier { get; set; }
        IApplicationFacade applicationFacade;
        private bool isOpenAsChild;

        public frmSupplierLedger(bool _isOpenAsChild = false)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                isOpenAsChild = _isOpenAsChild;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void frmSupplierLedger_Load(object sender, EventArgs e)
        {
            try
            {

                ExtensionMethods.FormLoad(this, "Supplier Ledger Master");
                GotFocusEventRaised(this);
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                LoadDataGrid();
                dgvSupplier.CellDoubleClick += dgvSupplier_DoubleClick;
                dgvSupplier.KeyDown += DgvSupplier_KeyDown;

                if(isOpenAsChild && dgvSupplier.Rows.Count > 0)
                {
                    dgvSupplier.CurrentCell = dgvSupplier.Rows[0].Cells[1];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
        }

        private void DgvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.End && isOpenAsChild)
                {
                    this.Close();
                }
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

        private void dgvSupplier_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    PharmaBusinessObjects.Master.SupplierLedgerMaster model = (PharmaBusinessObjects.Master.SupplierLedgerMaster)dgvSupplier.Rows[e.RowIndex].DataBoundItem;

                    AddEditSupplierLedger(model.SupplierLedgerId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
        }

        private void FormSupplierLedgerAddUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                LoadDataGrid();

                frmSupplierLedgerAddUpdate frm = (frmSupplierLedgerAddUpdate)sender;

                if (dgvSupplier.Rows.Count > 0)
                {
                    int id = frm.SupplierId;

                    foreach (DataGridViewRow row in dgvSupplier.Rows)
                    {
                        if (row.Cells["SupplierLedgerId"].Value.ToString().Equals(frm.SupplierId.ToString()))
                        {
                            dgvSupplier.Rows[row.Index].Selected = true;

                            if (row.Index != 0)
                            {
                                dgvSupplier.Rows[0].Selected = false;
                            }

                            break;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void LoadDataGrid()
        {
            dgvSupplier.DataSource = applicationFacade.GetSupplierLedgers(txtSearch.Text);

            for (int i = 0; i < dgvSupplier.Columns.Count; i++)
            {
                dgvSupplier.Columns[i].Visible = false;
            }

            dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSupplier.AllowUserToAddRows = false;
            dgvSupplier.AllowUserToDeleteRows = false;
            dgvSupplier.ReadOnly = true;
          

            dgvSupplier.Columns["SupplierLedgerCode"].Visible = true;
            dgvSupplier.Columns["SupplierLedgerCode"].HeaderText = "Supplier Code";
            dgvSupplier.Columns["SupplierLedgerCode"].FillWeight = 1;

            dgvSupplier.Columns["SupplierLedgerName"].Visible = true;
            dgvSupplier.Columns["SupplierLedgerName"].HeaderText = "Supplier Name";
            dgvSupplier.Columns["SupplierLedgerName"].FillWeight = 1.5F;

            dgvSupplier.Columns["Status"].Visible = false;
            //dgvCompanyList.Columns["Status"].HeaderText = "Company Code";

            dgvSupplier.Columns["SupplierLedgerShortName"].Visible = true;
            dgvSupplier.Columns["SupplierLedgerShortName"].HeaderText = "Supplier Short Name";
            dgvSupplier.Columns["SupplierLedgerShortName"].FillWeight = 1.3F;

            dgvSupplier.Columns["Address"].Visible = true;
            dgvSupplier.Columns["Address"].HeaderText = "Address";
            dgvSupplier.Columns["Address"].FillWeight = 2;

            dgvSupplier.Columns["ContactPerson"].Visible = true;
            dgvSupplier.Columns["ContactPerson"].HeaderText = "Contact Person";
            dgvSupplier.Columns["ContactPerson"].FillWeight = 1.5F;

            dgvSupplier.Columns["AreaName"].Visible = true;
            dgvSupplier.Columns["AreaName"].HeaderText = "Area Name";
            dgvSupplier.Columns["AreaName"].FillWeight = 1.5F;

            dgvSupplier.Columns["OfficePhone"].Visible = true;
            dgvSupplier.Columns["OfficePhone"].HeaderText = "Office Phone";
            dgvSupplier.Columns["OfficePhone"].FillWeight = 1.5F;
            //dgvAccountLedger.Columns["AccountLedgerCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;       
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.F9))
            {
                AddEditSupplierLedger(0);
                return true;
            }
            else if (keyData == Keys.F3)
            {
                EditLedger();
            }
            else if (keyData == Keys.Escape || keyData == Keys.End)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void AddEditSupplierLedger(int supplierId)
        {
            frmSupplierLedgerAddUpdate form = new frmSupplierLedgerAddUpdate(supplierId,txtSearch.Text);
            form.FormClosed -= FormSupplierLedgerAddUpdate_FormClosed;
            form.FormClosed += FormSupplierLedgerAddUpdate_FormClosed;
            form.ShowDialog();
        }

        private void frmSupplierLedger_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (dgvSupplier.CurrentRow != null)
                {
                    this.LastSelectedSupplier = dgvSupplier.CurrentRow.DataBoundItem as PharmaBusinessObjects.Master.SupplierLedgerMaster;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }

        private void frmSupplierLedger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }


        //Action buttons 
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                AddEditSupplierLedger(0);
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
                EditLedger();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void EditLedger()
        {
            if (dgvSupplier.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");

            PharmaBusinessObjects.Master.SupplierLedgerMaster model = (PharmaBusinessObjects.Master.SupplierLedgerMaster)dgvSupplier.SelectedRows[0].DataBoundItem;

            AddEditSupplierLedger(model.SupplierLedgerId);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    //PharmaBusinessObjects.Master.AccountLedgerMaster itemToBeRemoved = (PharmaBusinessObjects.Master.AccountLedgerMaster)dgvAccountLedger.SelectedRows[0].DataBoundItem;
                    //applicationFacade.DeleteItem(itemToBeRemoved);
                    //LoadDataGrid(0);
                }
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

        private void dgvSupplier_KeyDown(object sender, KeyEventArgs e)
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
    }
}
