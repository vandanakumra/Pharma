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
        private string SupplierNameNew { get; set; }

        public frmSupplierLedgerAddUpdate(int supplierId,string supplierName)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            this.SupplierId = supplierId;
            SupplierNameNew = supplierName;
            
        }

        private void frmSupplierLedgerAddUpdate_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, (this.SupplierId > 0) ? "Supplier Ledger Master - Update" : "Supplier Ledger Master - Add");          
            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);
            FillCombo();

            if (this.SupplierId > 0)
            {
                FillFormForUpdate();
            }
            else
            {
                ucSupplierCustomerInfo.CustomerSupplierName = SupplierNameNew;
            }
        }

        public void GotFocusEventRaised(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    GotFocusEventRaised(c);
                }
                else
                {
                    if (c is TextBox)
                    {
                        TextBox tb1 = (TextBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }

                    else if (c is ComboBox)
                    {
                        ComboBox tb1 = (ComboBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }
                }
            }
        }


        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }

        private void FillFormForUpdate()
        {
            SupplierLedgerMaster supplier = applicationFacade.GetSupplierLedgerById(this.SupplierId);

            if (supplier != null)
            {
                this.ucSupplierCustomerInfo.Code = supplier.SupplierLedgerCode;
                this.ucSupplierCustomerInfo.CustomerSupplierName = supplier.SupplierLedgerName;
                this.ucSupplierCustomerInfo.ShortName = supplier.SupplierLedgerShortName;
                this.ucSupplierCustomerInfo.Address = supplier.Address;
                this.ucSupplierCustomerInfo.ContactPerson = supplier.ContactPerson;
                this.ucSupplierCustomerInfo.EmailAddress = supplier.EmailAddress;
                this.ucSupplierCustomerInfo.Mobile = supplier.Mobile;
                this.ucSupplierCustomerInfo.OfficePhone = supplier.OfficePhone;
                this.ucSupplierCustomerInfo.ResidentPhone = supplier.ResidentPhone;
                this.ucSupplierCustomerInfo.TaxRetail = supplier.TaxRetail =="R" ? Enums.TaxRetail.R : Enums.TaxRetail.T;
                this.ucSupplierCustomerInfo.Status = supplier.Status ? Enums.Status.Active : Enums.Status.Inactive;
                this.ucSupplierCustomerInfo.CreditDebit = supplier.CreditDebit =="C" ? Enums.TransType.C : Enums.TransType.D;
                this.ucSupplierCustomerInfo.OpeningBal = supplier.OpeningBal.ToString();
                txtDLNo.Text = supplier.DLNo;
                txtTin.Text = supplier.TINNo;
                cbxArea.SelectedValue = supplier.AreaId;
                
                //todo ADD SUPPLIER PURCHASE TYPE iD
                //cbxPurchaseType.SelectedValue = supplier.
            }
        }

        private void FillCombo()
        {
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
            if (string.IsNullOrEmpty(this.ucSupplierCustomerInfo.CustomerSupplierName))
            {
                throw new Exception("Supplier Name can not be blank");
            }

            Status status;
            int areaId = 0;
            decimal openingBal = 0.00M;
            
            SupplierLedgerMaster supplier = new SupplierLedgerMaster();
            supplier.SupplierLedgerCode = this.ucSupplierCustomerInfo.Code;
            supplier.SupplierLedgerName = this.ucSupplierCustomerInfo.CustomerSupplierName;
            supplier.SupplierLedgerShortName = this.ucSupplierCustomerInfo.ShortName;
            supplier.Address = this.ucSupplierCustomerInfo.Address;
            supplier.ContactPerson = this.ucSupplierCustomerInfo.ContactPerson;
            Enum.TryParse<Status>(this.ucSupplierCustomerInfo.Status.ToString(), out status);
            supplier.Status = status == Status.Active;
            supplier.CreditDebit = this.ucSupplierCustomerInfo.CreditDebit == Enums.TransType.C ? "C" : "D";
            Int32.TryParse(cbxArea.SelectedValue.ToString(), out areaId);
            supplier.AreaId = areaId;
            supplier.DLNo = txtDLNo.Text;
            supplier.EmailAddress = this.ucSupplierCustomerInfo.EmailAddress;
            supplier.Mobile = this.ucSupplierCustomerInfo.Mobile;
            supplier.OfficePhone = this.ucSupplierCustomerInfo.OfficePhone;

            decimal.TryParse(this.ucSupplierCustomerInfo.OpeningBal, out openingBal);
            supplier.OpeningBal = openingBal;
            supplier.ResidentPhone = this.ucSupplierCustomerInfo.ResidentPhone;
            supplier.TINNo = txtTin.Text;
            supplier.TaxRetail =this.ucSupplierCustomerInfo.TaxRetail  == TaxRetail.R ? "R" : "T";
            supplier.SupplierLedgerId = SupplierId;

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
