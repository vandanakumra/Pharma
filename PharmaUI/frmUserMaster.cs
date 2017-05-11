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
    public partial class frmUserMaster : Form
    {
        IApplicationFacade applicationFacade;

        public frmUserMaster()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);

        }

        private void frmUserMaster_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "User Master");

            dgvUser.DataSource = applicationFacade.GetUsers();
            dgvUser.CellDoubleClick += DgvUser_CellDoubleClick;
            dgvUser.KeyDown += DgvUser_KeyDown;

        }

        private void DgvUser_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmUserMasterAddUpdate frm = new frmUserMasterAddUpdate();
            frm.ShowDialog();

        }
    }
}
