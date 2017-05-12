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
            cbxDiscount.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxDiscount.SelectedItem = Choice.No;
    
            ///Fill User Control Controls-----------
            ///
            
        }

        private void frmCustomerLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
         
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            errorProviderCustomerLedger.Clear();
            this.Close();
        }

        public void frmItemMasterAddUpdate_Fill_UsingExistingItem(CustomerLedgerMaster existingItem)
        {
            if (existingItem != null)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                CustomerLedgerMaster customerLedgerMaster = new CustomerLedgerMaster();

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
                customerLedgerMaster.ZSMId = (cbxZSM.SelectedItem as PersonRouteMaster).PersonRouteID;
                customerLedgerMaster.RSMId = (cbxRSM.SelectedItem as PersonRouteMaster).PersonRouteID;
                customerLedgerMaster.ASMId = (cbxASM.SelectedItem as PersonRouteMaster).PersonRouteID;
                customerLedgerMaster.AreaId = (cbxArea.SelectedItem as PersonRouteMaster).PersonRouteID;
                customerLedgerMaster.SalesManId = (cbxSalesman.SelectedItem as PersonRouteMaster).PersonRouteID;
                customerLedgerMaster.RouteId = (cbxRoute.SelectedItem as PersonRouteMaster).PersonRouteID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
