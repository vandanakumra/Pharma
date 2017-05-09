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
    public partial class frmCompany : Form
    {
        IApplicationFacade applicationFacade;
        public frmCompany()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Company Master");

            LoadDataGrid();

            dgvCompanyList.DoubleClick += DgvCompanyList_DoubleClick;
            dgvCompanyList.KeyDown += DgvCompanyList_KeyDown; ;
            dgvCompanyList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void DgvCompanyList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete && dgvCompanyList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCompanyList.SelectedRows[0];

                if (row != null)
                {
                    if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        int companyId = 0;
                        Int32.TryParse(Convert.ToString(row.Cells["CompanyId"].Value), out companyId);
                        applicationFacade.DeleteCompany(companyId);
                        LoadDataGrid();
                    }
                }
            }
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
                    frmCompanyAddUpdate form = new frmCompanyAddUpdate(companyId);
                    form.FormClosed += Form_FormClosed;
                    form.ShowDialog();

                }
            }
        }

        
        private void btnAddNewCompany_Click(object sender, EventArgs e)
        {
            frmCompanyAddUpdate form = new frmCompanyAddUpdate();
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();

        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDataGrid();
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

            dgvCompanyList.Columns["Status"].Visible = false;
            //dgvCompanyList.Columns["Status"].HeaderText = "Company Code";

            dgvCompanyList.Columns["DirectIndirect"].Visible = true;
            dgvCompanyList.Columns["DirectIndirect"].HeaderText = "Direct/Indirect";

            dgvCompanyList.Columns["OrderPreferenceRating"].Visible = true;
            dgvCompanyList.Columns["OrderPreferenceRating"].HeaderText = "Order Preference Rating";

            dgvCompanyList.Columns["BillingPreferenceRating"].Visible = true;
            dgvCompanyList.Columns["BillingPreferenceRating"].HeaderText = "Billing Preference Rating";

            dgvCompanyList.Columns["StockSummaryRequirement"].Visible = true;
            dgvCompanyList.Columns["StockSummaryRequirement"].HeaderText = "Stock Summary Required";
            //dgvAccountLedger.Columns["AccountLedgerCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;       



        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
        }
    }
}
