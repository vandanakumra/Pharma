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
    public partial class frmAccountLedgerMasterAddUpdate : Form
    {
       
        IApplicationFacade applicationFacade;

        public frmAccountLedgerMasterAddUpdate()
        {

            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }


        private void frmAccountLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
            panel1.Width = this.Width;

            Label lbl = new Label();
            lbl.Width = panel1.Width;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Text = "Account Ledger Master - ADD";
            panel1.Controls.Add(lbl);

            FillCombo();

        }

        private void FillCombo()
        {
           
                 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
