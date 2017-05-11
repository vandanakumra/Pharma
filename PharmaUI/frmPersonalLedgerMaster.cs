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
    public partial class frmPersonalLedgerMaster : Form
    {
        IApplicationFacade applicationFacade;

        public frmPersonalLedgerMaster()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }


        private void frmPersonalLedgerMaster_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Personal Diary");
            FillGrid();

            dgvPersonalLedger.CellDoubleClick += dgvPersonalLedger_CellDoubleClick;
            dgvPersonalLedger.KeyDown += DgvPersonalLedger_KeyDown;
        }

        private void DgvPersonalLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvPersonalLedger.SelectedRows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show(Constants.Messages.DeletePrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    PersonalLedgerMaster itemToBeRemoved = (PersonalLedgerMaster)dgvPersonalLedger.SelectedRows[0].DataBoundItem;
                    applicationFacade.DeletePersonalLedger(itemToBeRemoved);
                    FillGrid();
                }
            }
        }

        private void FillGrid()
        {
            dgvPersonalLedger.DataSource = applicationFacade.GetPersonalLedgers(txtSearch.Text);

            for (int i = 0; i < dgvPersonalLedger.Columns.Count; i++)
            {
                dgvPersonalLedger.Columns[i].Visible = false;
            }

            dgvPersonalLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonalLedger.AllowUserToAddRows = false;
            dgvPersonalLedger.AllowUserToDeleteRows = false;
            dgvPersonalLedger.ReadOnly = true;

            dgvPersonalLedger.Columns["PersonalLedgerCode"].Visible = true;
            dgvPersonalLedger.Columns["PersonalLedgerCode"].HeaderText = "Account No";            
                        
            dgvPersonalLedger.Columns["PersonalLedgerName"].Visible = true;
            dgvPersonalLedger.Columns["PersonalLedgerName"].HeaderText = "Account Name";
            
            dgvPersonalLedger.Columns["Address"].Visible = true;
            dgvPersonalLedger.Columns["Address"].HeaderText = "Address";
            
            dgvPersonalLedger.Columns["ContactPerson"].Visible = true;
            dgvPersonalLedger.Columns["ContactPerson"].HeaderText = "Contact Person";
            
            dgvPersonalLedger.Columns["EmailAddress"].Visible = true;
            dgvPersonalLedger.Columns["EmailAddress"].HeaderText = "Email";
            
                     
        }

        private void btnAddNewLedger_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new frmPersonalLedgerMasterAddUpdate();
                form.FormClosed += Form_FormClosed;
                form.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGrid();
        }



        private void dgvPersonalLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                frmPersonalLedgerMasterAddUpdate form = new frmPersonalLedgerMasterAddUpdate(true);
                PersonalLedgerMaster existingItem = (PersonalLedgerMaster)dgvPersonalLedger.CurrentRow.DataBoundItem;
                form.frmPersonalLedgerMasterAddUpdate_Fill_UsingExistingItem(existingItem);
                form.FormClosed += Form_FormClosed;
                form.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
