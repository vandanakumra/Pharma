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
            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);

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
                    //PersonalLedgerMaster itemToBeRemoved = (PersonalLedgerMaster)dgvPersonalLedger.SelectedRows[0].DataBoundItem;
                    //applicationFacade.DeletePersonalLedger(itemToBeRemoved);
                    //FillGrid();
                }
            }
            else if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            else
                base.OnKeyDown(e);
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

      
        void OpenAddEdit(int personLedgerId)
        {
            var form = new frmPersonalLedgerMasterAddUpdate(personLedgerId,txtSearch.Text);
            form.FormClosed -= Form_FormClosed;
            form.FormClosed += Form_FormClosed;

            if (personLedgerId > 0 && dgvPersonalLedger.SelectedRows[0] != null)
            {
                PersonalLedgerMaster existingItem = (PersonalLedgerMaster)dgvPersonalLedger.SelectedRows[0].DataBoundItem;
                form.frmPersonalLedgerMasterAddUpdate_Fill_UsingExistingItem(existingItem);
            }

            form.ShowDialog();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            FillGrid();
        }



        private void dgvPersonalLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditPersonLedger();
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
                EditPersonLedger();

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void EditPersonLedger()
        {
            if (dgvPersonalLedger.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");

            PharmaBusinessObjects.Master.PersonalLedgerMaster model = (PharmaBusinessObjects.Master.PersonalLedgerMaster)dgvPersonalLedger.SelectedRows[0].DataBoundItem;

            OpenAddEdit(model.PersonalLedgerId);
        }


        ///Action button
        ///

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            OpenAddEdit(0);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPersonLedger();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

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
