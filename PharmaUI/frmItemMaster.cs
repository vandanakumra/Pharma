using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmaBusiness;
using PharmaBusinessObjects;

namespace PharmaUI
{
    public partial class frmItemMaster : Form
    {
        IApplicationFacade applicationFacade;
        public frmItemMaster()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            panel1.Width = this.Width;

            Label lbl = new Label();
            lbl.Width = panel1.Width;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Text = "Item Master";
            panel1.Controls.Add(lbl);

            dgvItemList.DataSource = applicationFacade.GetAllItems();
            for (int i = 0; i < dgvItemList.Columns.Count; i++)
            {
                dgvItemList.Columns[i].Visible = false;
            }

            dgvItemList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItemList.AllowUserToAddRows = false;
            dgvItemList.AllowUserToDeleteRows = false;
            dgvItemList.ReadOnly = true;

            dgvItemList.Columns["ItemCode"].Visible = true;
            dgvItemList.Columns["ItemName"].Visible = true;
            dgvItemList.Columns["CompanyCode"].Visible = true;
            dgvItemList.Columns["ShortName"].Visible = true;
            dgvItemList.Columns["MRP"].Visible = true;

            dgvItemList.DoubleClick += DgvItemList_DoubleClick;

        }

        private void DgvItemList_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new frmItemMasterAddUpdate();
                form.Show(this);
            }
            catch (Exception)
            {

            }
        }
    }
}
