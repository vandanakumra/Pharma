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
using PharmaBusinessObjects.Common;

namespace PharmaUI
{
    public partial class frmCompany : Form
    {
        IApplicationFacade applicationFacade;

        public frmCompany()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Company Master");
            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);

            LoadDataGrid();

            dgvCompanyList.CellDoubleClick += DgvCompanyList_DoubleClick;
            dgvCompanyList.KeyDown += DgvCompanyList_KeyDown; ;

        }

        private void LoadDataGrid()
        {
            dgvCompanyList.DataSource = applicationFacade.GetCompanies(txtSearch.Text);

            for (int i = 0; i < dgvCompanyList.Columns.Count; i++)
            {
                dgvCompanyList.Columns[i].Visible = false;
            }

            dgvCompanyList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompanyList.AllowUserToAddRows = false;
            dgvCompanyList.AllowUserToDeleteRows = false;
            dgvCompanyList.ReadOnly = true;

            dgvCompanyList.Columns["CompanyCode"].Visible = true;
            dgvCompanyList.Columns["CompanyCode"].HeaderText = "Company Code";

            dgvCompanyList.Columns["CompanyName"].Visible = true;
            dgvCompanyList.Columns["CompanyName"].HeaderText = "Company Name";

            dgvCompanyList.Columns["DirectIndirect"].Visible = true;
            dgvCompanyList.Columns["DirectIndirect"].HeaderText = "Direct/Indirect";

            dgvCompanyList.Columns["OrderPreferenceRating"].Visible = true;
            dgvCompanyList.Columns["OrderPreferenceRating"].HeaderText = "Order Preference Rating";

            dgvCompanyList.Columns["BillingPreferenceRating"].Visible = true;
            dgvCompanyList.Columns["BillingPreferenceRating"].HeaderText = "Billing Preference Rating";

            dgvCompanyList.Columns["StockSummaryRequirement"].Visible = true;
            dgvCompanyList.Columns["StockSummaryRequirement"].HeaderText = "Stock Summary Required";

            dgvCompanyList.Columns["Status"].Visible = true;
            dgvCompanyList.Columns["Status"].HeaderText = "Status";
        }

        private void DgvCompanyList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete && dgvCompanyList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCompanyList.SelectedRows[0];

                if (row != null)
                {
                    if (DialogResult.Yes == MessageBox.Show(Constants.Messages.DeletePrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        int companyId = 0;
                        Int32.TryParse(Convert.ToString(row.Cells["CompanyId"].Value), out companyId);
                        applicationFacade.DeleteCompany(companyId);
                        LoadDataGrid();
                    }
                }
            }
            else if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            else
                base.OnKeyDown(e);
        }
        
        private void DgvCompanyList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCompanyList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCompanyList.SelectedRows[0];

                if (row != null)
                {
                    int companyId = 0;
                    Int32.TryParse(Convert.ToString(row.Cells["CompanyId"].Value), out companyId);
                    OpenAddEdit(companyId);

                }
            }
        }

        private void OpenAddEdit(int companyId)
        {            
            frmCompanyAddUpdate frmCompanyAddUpdate = new frmCompanyAddUpdate(companyId,txtSearch.Text);
            frmCompanyAddUpdate.FormClosed -= frmCompanyAddUpdate_FormClosed;
            frmCompanyAddUpdate.FormClosed += frmCompanyAddUpdate_FormClosed;
            frmCompanyAddUpdate.ShowDialog();
        }

        private void EditCompany()
        {
            if (dgvCompanyList.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");

            PharmaBusinessObjects.Master.CompanyMaster model = (PharmaBusinessObjects.Master.CompanyMaster)dgvCompanyList.SelectedRows[0].DataBoundItem;
            OpenAddEdit(model.CompanyId);
        }

        private void frmCompanyAddUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            LoadDataGrid();
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
                EditCompany();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }       

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid();

            if (dgvCompanyList.Rows.Count == 0)
            {
                if (DialogResult.Yes == MessageBox.Show(Constants.Messages.NotExists, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    frmCompanyAddUpdate form = new frmCompanyAddUpdate(0, txtSearch.Text);
                    form.FormClosed += frmCompanyAddUpdate_FormClosed;
                    form.ShowDialog();
                }
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            OpenAddEdit(0);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditCompany();
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
