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
    public partial class frmCompany : Form
    {
        private IApplicationFacade applicationFacade;
        public frmCompany()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
           dgvCompanyList.DataSource = applicationFacade.GetCompanies();
           
        }
    }
}
