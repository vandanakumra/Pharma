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
                form.ShowDialog();
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            dgvCustomerLedger.DataSource = applicationFacade.GetCustomerLedgers();

            //for (int i = 0; i < dgvCustomerLedger.Columns.Count; i++)
            //{
            //    dgvCustomerLedger.Columns[i].Visible = false;
            //}

            dgvCustomerLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerLedger.AllowUserToAddRows = false;
            dgvCustomerLedger.AllowUserToDeleteRows = false;
            dgvCustomerLedger.ReadOnly = true;

        }

        private void btnAddNewLedger_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new frmCustomerLedgerMasterAddUpdate();
                form.ShowDialog();
            }
            catch (Exception)
            {

            }
        }
    }
}
