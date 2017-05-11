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
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI
{
    public partial class frmSupplierLedgerAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private int SupplierId { get; set; }

        public frmSupplierLedgerAddUpdate()
        {
            InitializeComponent();            
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        public frmSupplierLedgerAddUpdate(int supplierId)
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
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
            SupplierLedgerMaster supplier = applicationFacade.GetSupplierLedgerById(this.SupplierId);

            if (supplier != null)
            {
                txtSupplierCode.Text = supplier.SupplierLedgerCode;
                txtSupplierName.Text = supplier.SupplierLedgerName;
                txtSupplierShortName.Text = supplier.SupplierLedgerShortName;
                txtAddress.Text = supplier.Address;
                txtContactPerson.Text = supplier.ContactPerson;
                txtEmailAddress.Text = supplier.EmailAddress;
                txtFax.Text = supplier.Fax;
                txtMobile.Text = supplier.Mobile;
                txtPager.Text = supplier.Pager;
                txtPhoneO.Text = supplier.OfficePhone;
                txtPhoneR.Text = supplier.ResidentPhone;
                txtDLNo.Text = supplier.DLNo;
                txtOpeningBal.Text = supplier.OpeningBal.ToString();
                txtTin.Text = supplier.TINNo;
                cbxTextRetail.SelectedItem = supplier.TaxRetail;
                cbxStatus.SelectedItem = supplier.Status ? Enums.Status.Active : Enums.Status.Inactive;
                cbxCreditDebit.SelectedItem = supplier.CreditDebit;
                cbxArea.SelectedValue = supplier.AreaId;
                
                //todo ADD SUPPLIER PURCHASE TYPE iD
                //cbxPurchaseType.SelectedValue = supplier.
            }
        }

        private void FillCombo()
        {
            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

            //Fill Tax/Retail option
            cbxTextRetail.SelectedItem = "R";
            cbxCreditDebit.SelectedItem = "C";
    
            //Fill Purchase type option
            cbxPurchaseType.DataSource = applicationFacade.GetAccountLedgerBySystemName("PurchaseLedger");
            cbxPurchaseType.DisplayMember = "AccountLedgerName";
            cbxPurchaseType.ValueMember = "AccountLedgerID";

            //Fill area option
            cbxArea.DataSource = applicationFacade.GetPersonRoutesBySystemName("AREA");
            cbxArea.DisplayMember = "PersonRouteName";
            cbxArea.ValueMember = "PersonRouteID";
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSupplierName.Text))
            {
                throw new Exception("Supplier Name can not be blank");
            }
            Status status;
            int areaId = 0;
            decimal openingBal = 0.00M;
            
            SupplierLedgerMaster supplier = new SupplierLedgerMaster();
            supplier.SupplierLedgerCode = txtSupplierCode.Text;
            supplier.SupplierLedgerName = txtSupplierName.Text;
            supplier.SupplierLedgerShortName = txtSupplierShortName.Text;
            supplier.Address = txtAddress.Text;
            supplier.ContactPerson = txtContactPerson.Text;
            Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
            supplier.Status = status == Status.Active;
            supplier.CreditDebit = cbxCreditDebit.SelectedItem.ToString();
            Int32.TryParse(cbxArea.SelectedValue.ToString(), out areaId);
            supplier.AreaId = areaId;
            supplier.DLNo = txtDLNo.Text;
            supplier.EmailAddress = txtEmailAddress.Text;
            supplier.Fax = txtFax.Text;
            supplier.Mobile = txtMobile.Text;
            supplier.OfficePhone = txtPhoneO.Text;

            decimal.TryParse(txtOpeningBal.Text, out openingBal);
            supplier.OpeningBal = openingBal;
            supplier.Pager = txtPager.Text;
            supplier.ResidentPhone = txtPhoneR.Text;
            supplier.TINNo = txtTin.Text;

            int result = SupplierId > 0 ? applicationFacade.UpdateSupplierLedger(supplier) : applicationFacade.AddSupplierLedger(supplier);

            //Close this form if operation is successful
            if (result > 0)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOpeningBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
