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
    public partial class frmAccountLedgerMaster : Form
    {
        IApplicationFacade applicationFacade;

        public frmAccountLedgerMaster()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }

        private void frmAccountLedgerMaster_Load(object sender, EventArgs e)
        {
            dgvAccountLedger.DataSource = applicationFacade.GetAccountLedgers();
        }
    }
}
