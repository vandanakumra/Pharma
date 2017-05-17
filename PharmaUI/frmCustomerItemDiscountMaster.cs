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
    public partial class frmCustomerItemDiscountMaster : Form
    {
        private int CompanyID { get; set; }

        public frmCustomerItemDiscountMaster(int CompanyID)
        {
            InitializeComponent();
            this.CompanyID = CompanyID;
        }

        private void frmCustomerItemDiscountMaster_Load(object sender, EventArgs e)
        {

        }
    }
}
