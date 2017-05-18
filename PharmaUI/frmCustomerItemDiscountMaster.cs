using PharmaBusiness;
using PharmaBusinessObjects;
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
        private CustomerCopanyDiscount CustomerCopanyDiscount { get; set; }
        IApplicationFacade applicationFacade;

        public frmCustomerItemDiscountMaster(CustomerCopanyDiscount CustomerCopanyDiscount)
        {
            InitializeComponent();
            //ExtensionMethods.SetFormProperties(this);

            this.CustomerCopanyDiscount = CustomerCopanyDiscount;
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);

           
        }

        private void frmCustomerItemDiscountMaster_Load(object sender, EventArgs e)
        {
            ///Display Company name
            ///
            this.lblSelectedCompanyName.Text = CustomerCopanyDiscount.CompanyName;

           
        }

        private void LoadGrid()
        {
            dgvCustomerItemDiscount.DataSource = applicationFacade.GetAllCompanyItemDiscountByCompanyID(CustomerCopanyDiscount.CompanyID);

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

        //private List<CustomerCopanyDiscount> GetMergedItemDiscountList()
        //{

        //}
    }
}
