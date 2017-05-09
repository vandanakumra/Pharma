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
    public partial class frmPersonalLedgerMaster : Form
    {
        IApplicationFacade applicationFacade;

        public frmPersonalLedgerMaster()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }


        private void frmPersonalLedgerMaster_Load(object sender, EventArgs e)
        {
            List<Control> allControls = ExtensionMethods.GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize));

            this.Dock = DockStyle.Fill;
            panel1.Width = this.Width;

            Label lbl = new Label();
            lbl.Width = panel1.Width;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, 14, FontStyle.Bold);
            lbl.Text = "Personal Diary";
            panel1.Controls.Add(lbl);


            FillGrid();

        }

        private void FillGrid()
        {
            dgvPersonalLedger.DataSource = applicationFacade.GetPersonalLedgers();

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

        }
    }
}
