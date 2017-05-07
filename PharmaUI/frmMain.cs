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
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void personRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void companyMenuItem_Click(object sender, EventArgs e)
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

        private void itemMenuItem_Click(object sender, EventArgs e)
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
    }
}
