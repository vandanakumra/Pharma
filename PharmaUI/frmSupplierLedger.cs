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

        public frmSupplierLedger()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmSupplierLedger_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Ledger Master");
            LoadDataGrid();
            dgvSupplier.CellDoubleClick += dgvSupplier_DoubleClick;
          
            //dgvSupplier.Click += DgvSupplier_Click;
           

        }
        


        private void dgvSupplier_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                PharmaBusinessObjects.Master.SupplierLedgerMaster model = (PharmaBusinessObjects.Master.SupplierLedgerMaster)dgvSupplier.Rows[e.RowIndex].DataBoundItem;

                AddEditSupplierLedger(model.SupplierLedgerId);
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            LoadDataGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
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

       

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddEditSupplierLedger(0);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditLedger();
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
                AddEditSupplierLedger(0);
                return true;
            }
            else if (keyData == Keys.F3)
            {
                EditLedger();
            }
            else if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void AddEditSupplierLedger(int supplierId)
        {
            frmSupplierLedgerAddUpdate form = new frmSupplierLedgerAddUpdate(supplierId,txtSearch.Text);
            form.FormClosed -= Form_FormClosed;
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();
        }

        private void frmSupplierLedger_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvSupplier.CurrentRow != null)
            {
                this.LastSelectedSupplier = dgvSupplier.CurrentRow.DataBoundItem as PharmaBusinessObjects.Master.SupplierLedgerMaster;
            }

        }

        private void frmSupplierLedger_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Escape)
           {
                    this.Close();
           }
           
        }
    }
}
