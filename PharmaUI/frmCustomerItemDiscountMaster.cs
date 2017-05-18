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
            dgvCustomerItemDiscount.DataSource = new List<CustomerCopanyDiscount>();

            for (int i = 0; i < dgvCustomerItemDiscount.Columns.Count; i++)
            {
                dgvCustomerItemDiscount.Columns[i].Visible = false;
            }

            dgvCustomerItemDiscount.Columns["ItemName"].Visible = true;
            dgvCustomerItemDiscount.Columns["ItemName"].HeaderText = "Item Name";
            dgvCustomerItemDiscount.Columns["ItemName"].ReadOnly = true;

            dgvCustomerItemDiscount.Columns["Normal"].Visible = true;
            dgvCustomerItemDiscount.Columns["Normal"].HeaderText = "Normal";

            dgvCustomerItemDiscount.Columns["Breakage"].Visible = true;
            dgvCustomerItemDiscount.Columns["Breakage"].HeaderText = "Breakage";

            dgvCustomerItemDiscount.Columns["Expired"].Visible = true;
            dgvCustomerItemDiscount.Columns["Expired"].HeaderText = "Expired";


            dgvCustomerItemDiscount.Columns["IsLessEcise"].Visible = true;
            dgvCustomerItemDiscount.Columns["IsLessEcise"].HeaderText = "LessEcise";

            dgvCustomerItemDiscount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerItemDiscount.AllowUserToAddRows = false;
            dgvCustomerItemDiscount.AllowUserToDeleteRows = false;
            dgvCustomerItemDiscount.ReadOnly = false;

        }
    }
}
