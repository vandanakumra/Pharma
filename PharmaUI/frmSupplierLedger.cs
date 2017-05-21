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
        private string supplierCode = string.Empty;
        private string supplierName = string.Empty;

        public string SupplierCode { get { return supplierCode; } }
        public string SupplierName { get { return supplierName; } }

        IApplicationFacade applicationFacade;

        public frmSupplierLedger()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        public frmSupplierLedger(bool isDialog)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            this.WindowState = FormWindowState.Normal;
            btnClose.Visible = true;
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmSupplierLedger_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Ledger Master");
            LoadDataGrid();
            dgvSupplier.CellDoubleClick += dgvSupplier_DoubleClick;
            dgvSupplier.KeyDown += dgvSupplier_KeyDown; ;
            dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvSupplier.Click += DgvSupplier_Click;
            dgvSupplier.SelectionChanged += DgvSupplier_SelectionChanged;

        }

        private void DgvSupplier_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows != null && dgvSupplier.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvSupplier.SelectedRows[0];

                if (row != null)
                {
                    supplierCode = Convert.ToString(row.Cells["SupplierLedgerCode"].Value);
                    supplierName = Convert.ToString(row.Cells["SupplierLedgerName"].Value);
                }
            }
        }

        //private void DgvSupplier_Click(object sender, EventArgs e)
        //{
        //    DataGridViewRow row = dgvSupplier.SelectedRows[0];

        //    if (row != null)
        //    {
        //        supplierCode = Convert.ToString(row.Cells["SupplierCode"]);
        //        supplierName = Convert.ToString(row.Cells["SupplierName"]);
        //    }
        //}

        private void dgvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvSupplier.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvSupplier.SelectedRows[0];

                if (row != null)
                {
                    if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        int supplierId = 0;
                        Int32.TryParse(Convert.ToString(row.Cells["SupplierId"].Value), out supplierId);
                        //applicationFacade.DeleteSupplier(supplierId);
                        LoadDataGrid();
                    }
                }
            }
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

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void AddEditSupplierLedger(int supplierId)
        {
            frmSupplierLedgerAddUpdate form = new frmSupplierLedgerAddUpdate(supplierId,txtSearch.Text);
            form.FormClosed -= Form_FormClosed;
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
