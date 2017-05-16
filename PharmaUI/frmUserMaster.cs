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

            LoadUserGrid();
            dgvUser.DoubleClick += DgvUser_DoubleClick;
            dgvUser.KeyDown += DgvUser_KeyDown; 


        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmUserMasterAddUpdate frm = new frmUserMasterAddUpdate();
            frm.ShowDialog();

        }

        private void DgvUser_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.F9)
            {
                List<UserMaster> users = new List<UserMaster>();

                if(dgvUser.Rows.Count > 0)
                {
                    users = (List<UserMaster>)dgvUser.DataSource;
                }

                users.Add(new UserMaster() {UserId=0, FirstName=string.Empty, Password=string.Empty, LastName =string.Empty, Status=true, Username=string.Empty });
                dgvUser.DataSource = users;
                dgvUser.Refresh();

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LoadUserGrid()
        {
            dgvUser.DataSource = applicationFacade.GetUsers(txtSearch.Text);
        }

        private void buttonAddNewUser_Click(object sender, EventArgs e)
        {
            frmUserMasterAddUpdate form = new frmUserMasterAddUpdate();
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadUserGrid();
        }

        private void DgvUser_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUser.SelectedRows[0];

                if (row != null)
                {
                    int userId = 0;

                    Int32.TryParse(Convert.ToString(row.Cells["UserId"].Value), out userId);
                    frmUserMasterAddUpdate form = new frmUserMasterAddUpdate(userId);
                    form.FormClosed -= Form_FormClosed;
                    form.FormClosed += Form_FormClosed;
                    form.ShowDialog();

                }
            }
        }
    }
}
