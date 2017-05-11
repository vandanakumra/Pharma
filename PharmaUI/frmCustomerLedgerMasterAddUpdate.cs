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
    public partial class frmCustomerLedgerMasterAddUpdate : Form
    {
        public frmCustomerLedgerMasterAddUpdate()
        {
            InitializeComponent();
            LoadCombo();
        }


        private void LoadCombo()
        {
           
            ////Fill ZSM options
            //cbxHalfScheme.DataSource = Enum.GetValues(typeof(Enums.Choice));
            //cbxHalfScheme.SelectedItem = Choice.No;

            ////Fill RSM options
            //cbxQtrScheme.DataSource = Enum.GetValues(typeof(Enums.Choice));
            //cbxQtrScheme.SelectedItem = Choice.No;

            ////Fill ASM options
            //cbxFixedDiscount.DataSource = Enum.GetValues(typeof(Enums.Choice));
            //cbxFixedDiscount.SelectedItem = Choice.No;

            ////Fill status options
            //cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            //cbxStatus.SelectedItem = Status.Active;

            ////Fill the company list
            //cbxComanyCode.DataSource = applicationFacade.GetCompanies(String.Empty);
            //cbxComanyCode.DisplayMember = "CompanyName";
            //cbxComanyCode.ValueMember = "CompanyCode";

            ////Fill sale type list
            //cbxSaleType.DataSource = applicationFacade.GetAccountLedgerBySystemName("SaleLedger");
            //cbxSaleType.DisplayMember = "AccountLedgerName";
            //cbxSaleType.ValueMember = "AccountLedgerID";
        }
    }
}
