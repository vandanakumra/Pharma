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
    public partial class frmPersonRouteMaster : Form
    {
        IApplicationFacade applicationFacade;
        public PersonRouteMaster LastSelectedPersonRoute { get; set; }

        public frmPersonRouteMaster()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
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
            if (e.KeyCode==Keys.Enter)
            {
                this.Close();
            }
        }

        private void DgvPersonRoute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                PharmaBusinessObjects.Master.PersonRouteMaster model = (PharmaBusinessObjects.Master.PersonRouteMaster)dgvPersonRoute.Rows[e.RowIndex].DataBoundItem;

                AddEditPersonRoute(model);
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

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            LoadDataGrid(0);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid((int)cbPersonRouteType.SelectedValue);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddEditPersonRoute(null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPersonRoute();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        void AddEditPersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster model)
        {
            frmPersonRouteMasterAddUpdate form = new frmPersonRouteMasterAddUpdate(model);
            form.FormClosed -= Form_FormClosed;
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();
        }

        private void EditPersonRoute()
        {
            if (dgvPersonRoute.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");

            PharmaBusinessObjects.Master.PersonRouteMaster model = (PharmaBusinessObjects.Master.PersonRouteMaster)dgvPersonRoute.SelectedRows[0].DataBoundItem;
                        
            AddEditPersonRoute(model);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.F9))
            {
                AddEditPersonRoute(null);
            }
            else if (keyData == Keys.F3)
            {
                EditPersonRoute();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void ConfigurePersonRoute(PersonRouteMaster model)
        {
            if(model != null)
            {
                this.cbPersonRouteType.Text = model.RecordTypeNme;
                this.cbPersonRouteType.Enabled = false;
               

                List<DataGridViewRow> filteredRow = dgvPersonRoute.Rows.OfType<DataGridViewRow>().Where(x => (int)x.Cells["PersonRouteID"].Value == model.PersonRouteID).ToList();
                if(filteredRow.Count > 0)
                {
                    dgvPersonRoute.ClearSelection();
                    filteredRow.First().Selected = true;
                } 
            }

        }

        private void frmPersonRouteMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(dgvPersonRoute.SelectedRows != null)
            {
                this.LastSelectedPersonRoute = dgvPersonRoute.SelectedRows[0].DataBoundItem as PersonRouteMaster;
            }
            
        }
    }
}
