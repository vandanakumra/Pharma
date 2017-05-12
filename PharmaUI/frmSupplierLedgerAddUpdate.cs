﻿using PharmaBusiness;
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
                this.ucSupplierCustomerInfo.Code = supplier.SupplierLedgerCode;
                this.ucSupplierCustomerInfo.Name = supplier.SupplierLedgerName;
                this.ucSupplierCustomerInfo.ShortName = supplier.SupplierLedgerShortName;
                this.ucSupplierCustomerInfo.Address = supplier.Address;
                this.ucSupplierCustomerInfo.ContactPerson = supplier.ContactPerson;
                this.ucSupplierCustomerInfo.EmailAddress = supplier.EmailAddress;
                this.ucSupplierCustomerInfo.Fax = supplier.Fax;
                this.ucSupplierCustomerInfo.Mobile = supplier.Mobile;
                this.ucSupplierCustomerInfo.Pager = supplier.Pager;
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
            if (string.IsNullOrEmpty(this.ucSupplierCustomerInfo.Name))
            {
                throw new Exception("Supplier Name can not be blank");
            }
            Status status;
            int areaId = 0;
            decimal openingBal = 0.00M;
            
            SupplierLedgerMaster supplier = new SupplierLedgerMaster();
            supplier.SupplierLedgerCode = this.ucSupplierCustomerInfo.Code;
            supplier.SupplierLedgerName = this.ucSupplierCustomerInfo.Name;
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
            supplier.Fax = this.ucSupplierCustomerInfo.Fax;
            supplier.Mobile = this.ucSupplierCustomerInfo.Mobile;
            supplier.OfficePhone = this.ucSupplierCustomerInfo.OfficePhone;

            decimal.TryParse(this.ucSupplierCustomerInfo.OpeningBal, out openingBal);
            supplier.OpeningBal = openingBal;
            supplier.Pager = this.ucSupplierCustomerInfo.Pager;
            supplier.ResidentPhone = this.ucSupplierCustomerInfo.ResidentPhone;
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
