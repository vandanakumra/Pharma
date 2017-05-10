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
    public partial class frmPersonRouteMaster : Form
    {
        IApplicationFacade applicationFacade;

        public frmPersonRouteMaster()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmPersonRouteMaster_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Person Route Master");
            LoadCombo();
            LoadDataGrid(0);
            dgvPersonRoute.CellDoubleClick += DgvPersonRoute_CellDoubleClick;
            dgvPersonRoute.KeyDown += DgvPersonRoute_KeyDown;

            cbPersonRouteType.SelectedIndexChanged += CbPersonRouteType_SelectedIndexChanged;
        }

        private void CbPersonRouteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGrid((int)cbPersonRouteType.SelectedValue);
        }

        private void DgvPersonRoute_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void DgvPersonRoute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                PharmaBusinessObjects.Master.PersonRouteMaster model = (PharmaBusinessObjects.Master.PersonRouteMaster)dgvPersonRoute.Rows[e.RowIndex].DataBoundItem;

                frmPersonRouteMasterAddUpdate form = new frmPersonRouteMasterAddUpdate(model);
                form.FormClosed -= Form_FormClosed;
                form.FormClosed += Form_FormClosed;
                form.Show();
            }
        }

        private void LoadCombo()
        {
            cbPersonRouteType.DataSource = applicationFacade.GetRecordTypesWithAll();
            cbPersonRouteType.ValueMember = "RecordTypeId";
            cbPersonRouteType.DisplayMember = "RecordTypeName";
        }

        private void LoadDataGrid(int recordTypeId)
        {
            dgvPersonRoute.DataSource = applicationFacade.GetPersonRoutesByRecordTypeIdAndSearch(recordTypeId, txtSearch.Text);

            for (int i = 0; i < dgvPersonRoute.Columns.Count; i++)
            {
                dgvPersonRoute.Columns[i].Visible = false;
            }

            dgvPersonRoute.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonRoute.AllowUserToAddRows = false;
            dgvPersonRoute.AllowUserToDeleteRows = false;
            dgvPersonRoute.ReadOnly = true;

            dgvPersonRoute.Columns["PersonRouteCode"].Visible = true;
            dgvPersonRoute.Columns["PersonRouteCode"].HeaderText = "Account No";

            dgvPersonRoute.Columns["RecordTypeNme"].Visible = true;
            dgvPersonRoute.Columns["RecordTypeNme"].HeaderText = "Person/Route Type";

            dgvPersonRoute.Columns["PersonRouteName"].Visible = true;
            dgvPersonRoute.Columns["PersonRouteName"].HeaderText = "Person/Route Name";

            dgvPersonRoute.Columns["Status"].Visible = true;
           

        }

        private void btnAddPersonRoute_Click(object sender, EventArgs e)
        {
            frmPersonRouteMasterAddUpdate form = new frmPersonRouteMasterAddUpdate();
            form.FormClosed -= Form_FormClosed;
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDataGrid(0);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid((int)cbPersonRouteType.SelectedValue);
        }
    }
}
