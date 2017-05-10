using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
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
    public partial class frmSupplierLedgerAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private int SupplierId { get; set; }

        public frmSupplierLedgerAddUpdate()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
        }

        public frmSupplierLedgerAddUpdate(int supplierId)
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();
            this.SupplierId = supplierId;
            ExtensionMethods.FormLoad(this, (this.SupplierId > 0) ? "Supplier Ledger Master - Update" : "Supplier Ledger Master - Add");
        }

        private void frmSupplierLedgerAddUpdate_Load(object sender, EventArgs e)
        {
            FillCombo();

            if (this.SupplierId > 0)
            {
                FillFormForUpdate();
            }

        }

        private void FillFormForUpdate()
        {
            //SupplierLedgerMaster supplier = applicationFacade.GetSupplierById(this.SupplierId);

            //if (supplier != null)
            //{
                //txtCompanyCode.Text = supplier.CompanyCode;
                //txtCompanyName.Text = supplier.CompanyName;
                //txtBillingPrefRating.Text = supplier.BillingPreferenceRating.ToString();
                //txtOrderPrefRating.Text = supplier.OrderPreferenceRating.ToString();
                //cbxDI.SelectedItem = supplier.IsDirect ? Enums.DI.Direct : Enums.DI.Indirect;////
                //cbxSSRequired.SelectedItem = supplier.StockSummaryRequired ? Enums.Choice.Yes : Enums.Choice.No;
                //cbxStatus.SelectedItem = supplier.Status ? Enums.Status.Active : Enums.Status.Inactive;

            //}
        }

        private void FillCombo()
        {
            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

            //Fill Tax/Retail option
            cbxTextRetail.DataSource = Enum.GetValues(typeof(Enums.TaxRetail));
            cbxTextRetail.SelectedItem = Enums.Choice.Yes;

            //Fill Purchase type option
            cbxPurchaseType.DataSource = applicationFacade.GetAccountLedgerBySystemName("PurchaseLedger");
            cbxPurchaseType.DisplayMember = "AccountLedgerName";
            cbxPurchaseType.ValueMember = "AccountLedgerID";

            //Fill area option
            //cbxArea.DataSource = applicationFacade.GetAre("PurchaseLedger");
            //cbxPurchaseType.DisplayMember = "AccountLedgerName";
            //cbxPurchaseType.ValueMember = "AccountLedgerID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
