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
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;

        public frmMain()
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            try
            {
                Form childForm = new Form();
                childForm.MdiParent = this;
                childForm.Text = "Window " + childFormNumber++;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LayoutMdi(MdiLayout.Cascade);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LayoutMdi(MdiLayout.TileVertical);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LayoutMdi(MdiLayout.TileHorizontal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LayoutMdi(MdiLayout.ArrangeIcons);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }           
        }

        private void personRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void companyMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsMdiContainer = true;
                frmCompany childForm = new frmCompany();
                childForm.MdiParent = this;
                childForm.Text = "Company Information";
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.ControlBox = false;
                childForm.MaximizeBox = false;
                childForm.MinimizeBox = false;
                childForm.ShowIcon = false;
                childForm.Dock = DockStyle.Fill;

                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsMdiContainer = true;
                frmItemMaster childForm = new frmItemMaster();
                childForm.MdiParent = this;
                childForm.Text = "Item Information";
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.ControlBox = false;
                childForm.MaximizeBox = false;
                childForm.MinimizeBox = false;
                childForm.ShowIcon = false;
                childForm.Dock = DockStyle.Fill;

                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountLedgerMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //frmAccountLedgerMaster childForm = new frmAccountLedgerMaster();
                //childForm.MdiParent = this;
                //childForm.Text = "Account Ledger Information";
                //childForm.Show();

                frmAccountLedgerMaster childForm = new frmAccountLedgerMaster();
                childForm.MdiParent = this;
                childForm.Text = "Account Ledger Information";
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.ControlBox = false;
                childForm.MaximizeBox = false;
                childForm.MinimizeBox = false;
                childForm.ShowIcon = false;
                childForm.Dock = DockStyle.Fill;

                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                List<Control> allControls = ExtensionMethods.GetAllControls(this);
                allControls.ForEach(k => k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void personLedgerMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPersonalLedgerMaster childForm = new frmPersonalLedgerMaster();
                childForm.MdiParent = this;
                childForm.Text = "Personal Diary";
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.ControlBox = false;
                childForm.MaximizeBox = false;
                childForm.MinimizeBox = false;
                childForm.ShowIcon = false;
                childForm.Dock = DockStyle.Fill;

                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
