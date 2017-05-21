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
    public partial class frmMainForm : Form
    {
        IApplicationFacade applicationFacade;

        public frmMainForm()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            ExtensionMethods.MainPanel = pnlMain;
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;

            pnlLogin.Location = new Point(
            this.ClientSize.Width / 2 - pnlLogin.Size.Width / 2,
            this.ClientSize.Height / 2 - pnlLogin.Size.Height / 2);
            pnlLogin.Anchor = AnchorStyles.None;


            pnlMain.Dock = DockStyle.Fill;

            List<Control> allControls = ExtensionMethods.GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void accountLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountLedgerMaster form = new frmAccountLedgerMaster();
            ExtensionMethods.AddFormToPanel(form, pnlMain);           
            form.Show();
        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompany form = new frmCompany();
            ExtensionMethods.AddFormToPanel(form, pnlMain);
            form.Show();
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemMaster form = new frmItemMaster();
            ExtensionMethods.AddFormToPanel(form, pnlMain);
            form.Show();

        }       

        private void personalDiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonalLedgerMaster form = new frmPersonalLedgerMaster();
            ExtensionMethods.AddFormToPanel(form, pnlMain);
            form.Show();
        }

        private void supplierLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierLedger form = new frmSupplierLedger();
            ExtensionMethods.AddFormToPanel(form, pnlMain);
            form.Show();
        }

        private void customerLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerLedgerMaster form = new frmCustomerLedgerMaster();
            ExtensionMethods.AddFormToPanel(form, pnlMain);
            form.Show();
        }

        private void personRouteMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonRouteMaster form = new frmPersonRouteMaster();
            ExtensionMethods.AddFormToPanel(form, pnlMain);
            form.Show();
        }

        private void userMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserMaster form = new frmUserMaster();
            ExtensionMethods.AddFormToPanel(form, pnlMain);
            form.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            PharmaBusinessObjects.Master.UserMaster loginUser = applicationFacade.GetUserByUserName(tbUserName.Text);

            if (loginUser != null)
            {
                pnlLogin.Visible = false;
                menuStrip1.Visible = true;
                ExtensionMethods.LoggedInUser = loginUser;

               // ToggleMenuItems(menuStrip1.Items);
                frmDefault form = new frmDefault();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();

            }

        }

        private void ToggleMenuItems(ToolStripItemCollection collection)
        {
            foreach (ToolStripMenuItem item in collection)
            {
                if(item.Text.ToLower() == "exit" || ExtensionMethods.LoggedInUser.Privledges.Any(x=>x.PrivledgeName.ToLower() == item.Text.ToLower()))
                {
                    continue;
                }
                else
                {
                    item.Visible = false;
                    item.ShortcutKeys = Keys.None;

                    if (item.HasDropDownItems) // if subMenu has children
                    {
                        ToggleMenuItems(item.DropDownItems); // Call recursive Method.
                    }

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDefault form = new frmDefault();
            ExtensionMethods.AddFormToPanel(form, pnlMain);
            form.Show();
        }

        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void purchaseTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseBookTransaction form = new frmPurchaseBookTransaction();
            ExtensionMethods.AddFormToPanel(form, pnlMain);
            form.Show();
        }
    }
}
