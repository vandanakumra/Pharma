using PharmaBusiness;
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
    public partial class frmDefault : Form
    {
        ApplicationFacade applicationFacade;

        public frmDefault()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            this.Dock = DockStyle.Fill;

        }

        private void frmDefault_Load(object sender, EventArgs e)
        {
            ExtensionMethods.HomeFormLoad(this, "Pharma Sol");
        }

    }
}
