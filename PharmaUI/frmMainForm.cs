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
            try
            {
                InitializeComponent();
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                ExtensionMethods.MainPanel = pnlMain;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }


        private void accountLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAccountLedgerMaster form = new frmAccountLedgerMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCompany form = new frmCompany();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemMaster form = new frmItemMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          

        }       

        private void personalDiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPersonalLedgerMaster form = new frmPersonalLedgerMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void supplierLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSupplierLedger form = new frmSupplierLedger();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void customerLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerLedgerMaster form = new frmCustomerLedgerMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void personRouteMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPersonRouteMaster form = new frmPersonRouteMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void userMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserMaster form = new frmUserMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Login();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void Login()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          

        }

        private void ToggleMenuItems(ToolStripItemCollection collection)
        {
            try
            {
                foreach (ToolStripMenuItem item in collection)
                {
                    if (item.Text.ToLower() == "exit" || ExtensionMethods.LoggedInUser.Privledges.Any(x => x.PrivledgeName.ToLower() == item.Text.ToLower()))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDefault form = new frmDefault();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    Login();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void purchaseTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPurchaseBookTransaction form = new frmPurchaseBookTransaction();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
    }
}
