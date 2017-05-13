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
    public partial class frmCustomerLedgerMasterAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private bool isInEditMode { get; set; }
        private int customerLedgerID { get; set; }

        public frmCustomerLedgerMasterAddUpdate(bool isInEditMode = false)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            ExtensionMethods.FormLoad(this, isInEditMode ? "Customer Ledger -Update" : "Customer Ledger - Add");
            this.isInEditMode = isInEditMode;
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            
            LoadCombo();
        }


        private void LoadCombo()
        {

            ////Fill ZSM options
            cbxZSM.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.ZSM);
            cbxZSM.DisplayMember = "PersonRouteName";
            cbxZSM.ValueMember = "PersonRouteCode";

            ////Fill RSM options
            cbxRSM.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.RSM);
            cbxRSM.DisplayMember = "PersonRouteName";
            cbxRSM.ValueMember = "PersonRouteCode";

            ////Fill ASM options
            cbxASM.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.ASM);
            cbxASM.DisplayMember = "PersonRouteName";
            cbxASM.ValueMember = "PersonRouteCode";

            ////Fill Area options
            cbxArea.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.AREA);
            cbxArea.DisplayMember = "PersonRouteName";
            cbxArea.ValueMember = "PersonRouteCode";

            ////Fill Salesman options
            cbxSalesman.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.SALESMAN);
            cbxSalesman.DisplayMember = "PersonRouteName";
            cbxSalesman.ValueMember = "PersonRouteCode";

            ////Fill Route options
            cbxRoute.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.ROUTE);
            cbxRoute.DisplayMember = "PersonRouteName";
            cbxRoute.ValueMember = "PersonRouteCode";

            ////Fill Costumer Type options
            cbxCustomerType.DataSource = applicationFacade.GetCustomerTypes();
            cbxCustomerType.DisplayMember = "CustomerTypeName";
            cbxCustomerType.ValueMember = "CustomerTypeId";

            ////Fill Rate Type options
            cbxRateType.DataSource = applicationFacade.GetInterestTypes();
            cbxRateType.DisplayMember = "InterestTypeName";
            cbxRateType.ValueMember = "InterestTypeId";

            ////Fill Less Excise options
            cbxLessExcise.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxLessExcise.SelectedItem = Choice.No;

            ////Fill Fixed Tax  options
            cbxFixedTax.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxFixedTax.SelectedItem = Choice.No;

            ////Fill Fixed SC options
            cbxFixedSC.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxFixedSC.SelectedItem = Choice.No;

            ////Fill Change SC/Tax while billing options
            cbxChangeSCTAXWhileBill.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxChangeSCTAXWhileBill.SelectedItem = Choice.No;

            ////Fill Follow condition strictly options
            cbxFollowConditionStrictly.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxFollowConditionStrictly.SelectedItem = Choice.No;

            ////Fill discount strictly options
            cbxLocaLCentral.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxLocaLCentral.SelectedItem = Choice.No;

            ///Fill Local/Central options
            ///
            cbxLocaLCentral.DataSource = Enum.GetValues(typeof(Enums.LocalCentral));
            cbxLocaLCentral.SelectedItem = LocalCentral.L;

            ///Fill User Control Controls-----------
            ///
            
        }

        private void frmCustomerLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
         
        }

      

        public void frmCustomerLedgerMasterAddUpdate_Fill_UsingExistingItem(CustomerLedgerMaster customerLedgerMaster)
        {
            if (customerLedgerMaster != null)
            {

                ///Set CustomerId
                ///
                this.customerLedgerID = customerLedgerMaster.CustomerLedgerId;

                ///Fill user control data
                ///
                ucSupplierCustomerInfo.Code = customerLedgerMaster.CustomerLedgerCode;
                ucSupplierCustomerInfo.Name=customerLedgerMaster.CustomerLedgerName ;
                ucSupplierCustomerInfo.ShortName=customerLedgerMaster.CustomerLedgerShortName ;
                ucSupplierCustomerInfo.Address=customerLedgerMaster.Address ;
                ucSupplierCustomerInfo.ContactPerson=customerLedgerMaster.ContactPerson ;
                ucSupplierCustomerInfo.Mobile=customerLedgerMaster.Mobile;
                ucSupplierCustomerInfo.Fax=customerLedgerMaster.Fax ;
                ucSupplierCustomerInfo.Pager=customerLedgerMaster.Pager ;
                ucSupplierCustomerInfo.OfficePhone=customerLedgerMaster.OfficePhone ;
                ucSupplierCustomerInfo.ResidentPhone=customerLedgerMaster.ResidentPhone ;
                ucSupplierCustomerInfo.EmailAddress= customerLedgerMaster.EmailAddress ;
                ucSupplierCustomerInfo.OpeningBal =Convert.ToString(customerLedgerMaster.OpeningBal);
                ucSupplierCustomerInfo.CreditDebit= customerLedgerMaster.CreditDebit == "C" ? Enums.TransType.C : Enums.TransType.D;
                ucSupplierCustomerInfo.TaxRetail = customerLedgerMaster.TaxRetail == "T" ? Enums.TaxRetail.T : Enums.TaxRetail.R;
                ucSupplierCustomerInfo.Status = customerLedgerMaster.Status ? Enums.Status.Active : Enums.Status.Inactive;

                ///Fill this form data
                ///
                if(customerLedgerMaster.ZSMId!=null)
                    cbxZSM.SelectedValue = customerLedgerMaster.ZSMId;

                if (customerLedgerMaster.RSMId != null)
                    cbxRSM.SelectedValue = customerLedgerMaster.RSMId;

                if (customerLedgerMaster.ASMId != null)
                    cbxASM.SelectedValue = customerLedgerMaster.ASMId;

                if (customerLedgerMaster.SalesManId != null)
                    cbxSalesman.SelectedValue = customerLedgerMaster.SalesManId;

                if (customerLedgerMaster.AreaId != null)
                    cbxArea.SelectedValue = customerLedgerMaster.AreaId;

                if (customerLedgerMaster.RouteId != null)
                    cbxRoute.SelectedValue = customerLedgerMaster.RouteId;

                tbxDL.Text= customerLedgerMaster.DLNo;
                tbxTIN.Text=customerLedgerMaster.TINNo;
                tbxCST.Text=customerLedgerMaster.CSTNo;
                tbxDay.Text=customerLedgerMaster.Day;
                tbxCredtLimit.Text=Convert.ToString(customerLedgerMaster.CreditLimit);
                tbxBankName.Text= customerLedgerMaster.BankName ;
                tbxBankArea.Text=customerLedgerMaster.BankArea;
                tbxCloseDay.Text=customerLedgerMaster.CloseDay;
                cbxCustomerType.SelectedValue =customerLedgerMaster.CustomerTypeID;
                cbxLessExcise.SelectedItem = customerLedgerMaster.IsLessExcise ? Choice.Yes : Choice.No;
                cbxRateType.SelectedValue = customerLedgerMaster.InterestTypeID;
                cbxFixedTax.SelectedItem=customerLedgerMaster.IsFixedTax ? Choice.Yes : Choice.No;
                cbxFixedTax.SelectedItem = customerLedgerMaster.IsFixedTax ? Choice.Yes : Choice.No;
                tbxTax.Text = Convert.ToString(customerLedgerMaster.Tax);
                cbxFixedSC.SelectedItem = customerLedgerMaster.IsFixedSC ? Choice.Yes : Choice.No;
                tbxSC.Text = Convert.ToString(customerLedgerMaster.SC);
                cbxChangeSCTAXWhileBill.SelectedItem = customerLedgerMaster.IsChangeSCWhileBill ? Choice.Yes : Choice.No;
                tbxSaleBillFormat.Text= customerLedgerMaster.SaleBillFormat;
                tbxMaxOSAmount.Text = Convert.ToString(customerLedgerMaster.MaxOSAmount);
                tbxMaxBillAmmount.Text = Convert.ToString(customerLedgerMaster.MaxBillAmount);
                tbxMaxNumberOfOSBill.Text = Convert.ToString(customerLedgerMaster.MaxNumOfOSBill);
                tbxMaxGracePeriod.Text = Convert.ToString(customerLedgerMaster.MaxGracePeriod);
                cbxFollowConditionStrictly.SelectedItem = customerLedgerMaster.IsFollowConditionStrictly ? Choice.Yes : Choice.No;
                tbxDiscount.Text = Convert.ToString(customerLedgerMaster.Discount);
                cbxLocaLCentral.SelectedItem = customerLedgerMaster.CentralLocal == "L" ? LocalCentral.L : LocalCentral.C;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Choice choice;
                LocalCentral localCentral;
                CustomerLedgerMaster customerLedgerMaster = new CustomerLedgerMaster();

                customerLedgerMaster.CustomerLedgerId = this.customerLedgerID;

                //values from User Control
                customerLedgerMaster.CustomerLedgerName = ucSupplierCustomerInfo.Name;
                customerLedgerMaster.CustomerLedgerShortName = ucSupplierCustomerInfo.ShortName;
                customerLedgerMaster.Address = ucSupplierCustomerInfo.Address;
                customerLedgerMaster.ContactPerson = ucSupplierCustomerInfo.ContactPerson;
                customerLedgerMaster.Mobile = ucSupplierCustomerInfo.Mobile;
                customerLedgerMaster.Fax = ucSupplierCustomerInfo.Fax;
                customerLedgerMaster.Pager = ucSupplierCustomerInfo.Pager;
                customerLedgerMaster.OfficePhone = ucSupplierCustomerInfo.OfficePhone;
                customerLedgerMaster.ResidentPhone = ucSupplierCustomerInfo.ResidentPhone;
                customerLedgerMaster.EmailAddress = ucSupplierCustomerInfo.EmailAddress;
                customerLedgerMaster.OpeningBal = ExtensionMethods.SafeConversionDecimal(ucSupplierCustomerInfo.OpeningBal);
                customerLedgerMaster.CreditDebit = ucSupplierCustomerInfo.CreditDebit == Enums.TransType.C ? "C" : "D";
                customerLedgerMaster.TaxRetail = ucSupplierCustomerInfo.TaxRetail == Enums.TaxRetail.T ? "T" : "R";
                customerLedgerMaster.Status = ucSupplierCustomerInfo.Status == Enums.Status.Active ? true : false;

                //values from User this form
                customerLedgerMaster.ZSMId = cbxZSM.SelectedItem != null ? (int?) (cbxZSM.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.RSMId = cbxRSM.SelectedItem != null ? (int?) (cbxRSM.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.ASMId = cbxASM.SelectedItem != null ? (int?) (cbxASM.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.AreaId = cbxArea.SelectedItem != null ? (int?)(cbxArea.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.SalesManId = cbxSalesman.SelectedItem != null ? (int?)(cbxSalesman.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.RouteId = cbxRoute.SelectedItem != null ? (int?)(cbxRoute.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.DLNo = tbxDL.Text;
                customerLedgerMaster.TINNo = tbxTIN.Text;
                customerLedgerMaster.CSTNo = tbxCST.Text;
                customerLedgerMaster.Day = tbxDay.Text;
                customerLedgerMaster.CreditLimit =ExtensionMethods.SafeConversionInt(tbxCredtLimit.Text)?? default(int);
                customerLedgerMaster.BankName = tbxBankName.Text;
                customerLedgerMaster.BankArea = tbxBankArea.Text;
                customerLedgerMaster.CloseDay = tbxCloseDay.Text;
                customerLedgerMaster.CustomerTypeID = (cbxCustomerType.SelectedItem as CustomerType).CustomerTypeId;

                Enum.TryParse<Choice>(cbxLessExcise.SelectedValue.ToString(), out choice);
                customerLedgerMaster.IsLessExcise = choice == Choice.Yes ;

                customerLedgerMaster.InterestTypeID = (cbxRateType.SelectedItem as InterestType).InterestTypeId;

                Enum.TryParse<Choice>(cbxFixedTax.SelectedValue.ToString(), out choice);
                customerLedgerMaster.IsFixedTax = choice == Choice.Yes;

                customerLedgerMaster.Tax = ExtensionMethods.SafeConversionDouble(tbxTax.Text);

                Enum.TryParse<Choice>(cbxFixedSC.SelectedValue.ToString(), out choice);
                customerLedgerMaster.IsFixedSC = choice == Choice.Yes;

                customerLedgerMaster.SC = ExtensionMethods.SafeConversionDouble(tbxSC.Text);

                Enum.TryParse<Choice>(cbxChangeSCTAXWhileBill.SelectedValue.ToString(), out choice);
                customerLedgerMaster.IsChangeSCWhileBill = choice == Choice.Yes;

                customerLedgerMaster.SaleBillFormat = tbxSaleBillFormat.Text;

                customerLedgerMaster.MaxOSAmount = ExtensionMethods.SafeConversionDouble(tbxMaxOSAmount.Text);
                customerLedgerMaster.MaxBillAmount = ExtensionMethods.SafeConversionDouble(tbxMaxBillAmmount.Text);
                customerLedgerMaster.MaxNumOfOSBill = ExtensionMethods.SafeConversionInt(tbxMaxNumberOfOSBill.Text);
                customerLedgerMaster.MaxGracePeriod = ExtensionMethods.SafeConversionInt(tbxMaxGracePeriod.Text);

                Enum.TryParse<Choice>(cbxFollowConditionStrictly.SelectedValue.ToString(), out choice);
                customerLedgerMaster.IsFollowConditionStrictly = choice == Choice.Yes;

                customerLedgerMaster.Discount = ExtensionMethods.SafeConversionDouble(tbxDiscount.Text);

                Enum.TryParse<LocalCentral>(cbxLocaLCentral.SelectedValue.ToString(), out localCentral);
                customerLedgerMaster.CentralLocal = localCentral == LocalCentral.L ? "L" : "C";

                int _result = 0;
                if (isInEditMode)
                {
                    _result= applicationFacade.UpdateCustomerLedger(customerLedgerMaster);
                }
                else
                {
                    _result= applicationFacade.AddCustomerLedger(customerLedgerMaster);
                }

                if (_result > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Constants.Messages.ErrorOccured);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            errorProviderCustomerLedger.Clear();
            this.Close();
        }
    }
}
