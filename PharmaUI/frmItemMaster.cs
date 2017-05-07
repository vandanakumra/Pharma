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
        ApplicationFacade applicationFacade;
        public frmItemMaster()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            dgvItemList.DataSource = applicationFacade.GetAllItems();


            for (int i = 0; i < dgvItemList.Columns.Count; i++)
            {
                dgvItemList.Columns[i].Visible = false;
            }

            dgvItemList.Columns["ItemCode"].Visible = true;
            dgvItemList.Columns["ItemName"].Visible = true;
            dgvItemList.Columns["CompanyCode"].Visible = true;
            dgvItemList.Columns["ShortName"].Visible = true;
            dgvItemList.Columns["MRP"].Visible = true;

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
