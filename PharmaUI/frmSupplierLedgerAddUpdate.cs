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
                this.ucSupplierCustomerInfo1.Code = supplier.SupplierLedgerCode;
                this.ucSupplierCustomerInfo1.Name = supplier.SupplierLedgerName;
                this.ucSupplierCustomerInfo1.ShortName = supplier.SupplierLedgerShortName;
                this.ucSupplierCustomerInfo1.Address = supplier.Address;
                this.ucSupplierCustomerInfo1.ContactPerson = supplier.ContactPerson;
                this.ucSupplierCustomerInfo1.EmailAddress = supplier.EmailAddress;
                this.ucSupplierCustomerInfo1.Fax = supplier.Fax;
                this.ucSupplierCustomerInfo1.Mobile = supplier.Mobile;
                this.ucSupplierCustomerInfo1.Pager = supplier.Pager;
                this.ucSupplierCustomerInfo1.OfficePhone = supplier.OfficePhone;
                this.ucSupplierCustomerInfo1.ResidentPhone = supplier.ResidentPhone;
                this.ucSupplierCustomerInfo1.TaxRetail = supplier.TaxRetail;
                this.ucSupplierCustomerInfo1.Status = supplier.Status ? Enums.Status.Active : Enums.Status.Inactive;
                this.ucSupplierCustomerInfo1.CreditDebit = supplier.CreditDebit;
                this.ucSupplierCustomerInfo1.OpeningBal = supplier.OpeningBal.ToString();
                txtDLNo.Text = supplier.DLNo;
                txtTin.Text = supplier.TINNo;
                cbxArea.SelectedValue = supplier.AreaId;
                
                //todo ADD SUPPLIER PURCHASE TYPE iD
                //cbxPurchaseType.SelectedValue = supplier.
            }
        }

        private void FillCombo()
        {
            //Fill status options
            this.ucSupplierCustomerInfo1.StatusDataSource = Enum.GetValues(typeof(Enums.Status));
            this.ucSupplierCustomerInfo1.Status = Enums.Status.Active;

            //Fill Tax/Retail option
            this.ucSupplierCustomerInfo1.TaxRetail= "R";
            this.ucSupplierCustomerInfo1.CreditDebit = "C";

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
            if (string.IsNullOrEmpty(this.ucSupplierCustomerInfo1.Name))
            {
                throw new Exception("Supplier Name can not be blank");
            }
            Status status;
            int areaId = 0;
            decimal openingBal = 0.00M;
            
            SupplierLedgerMaster supplier = new SupplierLedgerMaster();
            supplier.SupplierLedgerCode = this.ucSupplierCustomerInfo1.Code;
            supplier.SupplierLedgerName = this.ucSupplierCustomerInfo1.Name;
            supplier.SupplierLedgerShortName = this.ucSupplierCustomerInfo1.ShortName;
            supplier.Address = this.ucSupplierCustomerInfo1.Address;
            supplier.ContactPerson = this.ucSupplierCustomerInfo1.ContactPerson;
            Enum.TryParse<Status>(this.ucSupplierCustomerInfo1.Status.ToString(), out status);
            supplier.Status = status == Status.Active;
            supplier.CreditDebit = this.ucSupplierCustomerInfo1.CreditDebit;
            Int32.TryParse(cbxArea.SelectedValue.ToString(), out areaId);
            supplier.AreaId = areaId;
            supplier.DLNo = txtDLNo.Text;
            supplier.EmailAddress = this.ucSupplierCustomerInfo1.EmailAddress;
            supplier.Fax = this.ucSupplierCustomerInfo1.Fax;
            supplier.Mobile = this.ucSupplierCustomerInfo1.Mobile;
            supplier.OfficePhone = this.ucSupplierCustomerInfo1.OfficePhone;

            decimal.TryParse(this.ucSupplierCustomerInfo1.OpeningBal, out openingBal);
            supplier.OpeningBal = openingBal;
            supplier.Pager = this.ucSupplierCustomerInfo1.Pager;
            supplier.ResidentPhone = this.ucSupplierCustomerInfo1.ResidentPhone;
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
