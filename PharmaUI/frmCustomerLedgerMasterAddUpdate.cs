using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
            ExtensionMethods.SetFormProperties(this);
            ExtensionMethods.FormLoad(this, isInEditMode ? "Customer Ledger -Update" : "Customer Ledger - Add");
            this.isInEditMode = isInEditMode;
            this.customerLedgerID = 0;
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);

            {
                cbxZSM.KeyDown += cbxPersonRouteType_KeyDown;
                cbxRSM.KeyDown += cbxPersonRouteType_KeyDown;
                cbxASM.KeyDown += cbxPersonRouteType_KeyDown;
                cbxSalesman.KeyDown += cbxPersonRouteType_KeyDown;
                cbxArea.KeyDown += cbxPersonRouteType_KeyDown;
                cbxRoute.KeyDown += cbxPersonRouteType_KeyDown;
            }

            LoadCombo();

            if(!isInEditMode)
                LoadCustomerCompanyDiscountGrid();

        }

        private void LoadCombo()
        {

            ////Fill ZSM options
            cbxZSM.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.ZSM);
            cbxZSM.DisplayMember = "PersonRouteName";
            cbxZSM.ValueMember = "PersonRouteID";

            cbxZSM.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxZSM.AutoCompleteMode = AutoCompleteMode.Suggest;

            ////Fill RSM options
            cbxRSM.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.RSM);
            cbxRSM.DisplayMember = "PersonRouteName";
            cbxRSM.ValueMember = "PersonRouteID";

            cbxRSM.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxRSM.AutoCompleteMode = AutoCompleteMode.Suggest;

            ////Fill ASM options
            cbxASM.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.ASM);
            cbxASM.DisplayMember = "PersonRouteName";
            cbxASM.ValueMember = "PersonRouteID";

            cbxASM.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxASM.AutoCompleteMode = AutoCompleteMode.Suggest;

            ////Fill Area options
            cbxArea.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.AREA);
            cbxArea.DisplayMember = "PersonRouteName";
            cbxArea.ValueMember = "PersonRouteID";

            cbxArea.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxArea.AutoCompleteMode = AutoCompleteMode.Suggest;

            ////Fill Salesman options
            cbxSalesman.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.SALESMAN);
            cbxSalesman.DisplayMember = "PersonRouteName";
            cbxSalesman.ValueMember = "PersonRouteID";

            cbxSalesman.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxSalesman.AutoCompleteMode = AutoCompleteMode.Suggest;

            ////Fill Route options
            cbxRoute.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.ROUTE);
            cbxRoute.DisplayMember = "PersonRouteName";
            cbxRoute.ValueMember = "PersonRouteID";

            ////Fill Costumer Type options
            cbxCustomerType.DataSource = applicationFacade.GetCustomerTypes();
            cbxCustomerType.DisplayMember = "CustomerTypeName";
            cbxCustomerType.ValueMember = "CustomerTypeId";

            cbxCustomerType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxCustomerType.AutoCompleteMode = AutoCompleteMode.Suggest;

            ////Fill Rate Type options
            cbxRateType.DataSource = applicationFacade.GetInterestTypes();
            cbxRateType.DisplayMember = "InterestTypeName";
            cbxRateType.ValueMember = "InterestTypeId";

            ////Fill Less Excise options
            cbxLessExcise.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxLessExcise.SelectedItem = Choice.No;


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

        public void LoadCustomerCompanyDiscountGrid()
        {

            List<CustomerCopanyDiscount> customerCopanyDiscountList = applicationFacade.GetCompleteCompanyDiscountList(customerLedgerID);
            dgvCompanyDiscount.DataSource = customerCopanyDiscountList;

            for (int i = 0; i < dgvCompanyDiscount.Columns.Count; i++)
            {
                dgvCompanyDiscount.Columns[i].Visible = false;
            }

            dgvCompanyDiscount.Columns["CompanyName"].Visible = true;
            dgvCompanyDiscount.Columns["CompanyName"].HeaderText = "Company Name";
            dgvCompanyDiscount.Columns["CompanyName"].ReadOnly = true;

            dgvCompanyDiscount.Columns["Normal"].Visible = true;
            dgvCompanyDiscount.Columns["Normal"].HeaderText = "Normal";

            dgvCompanyDiscount.Columns["Breakage"].Visible = true;
            dgvCompanyDiscount.Columns["Breakage"].HeaderText = "Breakage";

            dgvCompanyDiscount.Columns["Expired"].Visible = true;
            dgvCompanyDiscount.Columns["Expired"].HeaderText = "Expired";

           
            dgvCompanyDiscount.Columns["IsLessEcise"].Visible = true;
            dgvCompanyDiscount.Columns["IsLessEcise"].HeaderText = "LessEcise";

            dgvCompanyDiscount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompanyDiscount.AllowUserToAddRows = false;
            dgvCompanyDiscount.AllowUserToDeleteRows = false;
            dgvCompanyDiscount.ReadOnly = false;
        }

        private void frmCustomerLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
            GotFocusEventRaised(this);
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
                ucSupplierCustomerInfo.CustomerSupplierName = customerLedgerMaster.CustomerLedgerName;
                ucSupplierCustomerInfo.ShortName = customerLedgerMaster.CustomerLedgerShortName;
                ucSupplierCustomerInfo.Address = customerLedgerMaster.Address;
                ucSupplierCustomerInfo.ContactPerson = customerLedgerMaster.ContactPerson;
                ucSupplierCustomerInfo.Mobile = customerLedgerMaster.Mobile;
                ucSupplierCustomerInfo.OfficePhone = customerLedgerMaster.OfficePhone;
                ucSupplierCustomerInfo.ResidentPhone = customerLedgerMaster.ResidentPhone;
                ucSupplierCustomerInfo.EmailAddress = customerLedgerMaster.EmailAddress;
                ucSupplierCustomerInfo.OpeningBal = Convert.ToString(customerLedgerMaster.OpeningBal);
                ucSupplierCustomerInfo.CreditDebit = customerLedgerMaster.CreditDebit == "C" ? Enums.TransType.C : Enums.TransType.D;
                ucSupplierCustomerInfo.TaxRetail = customerLedgerMaster.TaxRetail == "T" ? Enums.TaxRetail.T : Enums.TaxRetail.R;
                ucSupplierCustomerInfo.Status = customerLedgerMaster.Status ? Enums.Status.Active : Enums.Status.Inactive;

                ///Fill this form data
                ///
                if (customerLedgerMaster.ZSMId != null)
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

                tbxDL.Text = customerLedgerMaster.DLNo;
                tbxGST.Text = customerLedgerMaster.GSTNo;
                tbxCIN.Text = customerLedgerMaster.CINNo;
                tbxLIN.Text = customerLedgerMaster.LINNo;
                tbxServiceTax.Text = customerLedgerMaster.ServiceTaxNo;
                tbxPAN.Text = customerLedgerMaster.PANNo;

                tbxCredtLimit.Text = Convert.ToString(customerLedgerMaster.CreditLimit);
                cbxCustomerType.SelectedValue = customerLedgerMaster.CustomerTypeID;
                cbxLessExcise.SelectedItem = customerLedgerMaster.IsLessExcise ? Choice.Yes : Choice.No;
                cbxRateType.SelectedValue = customerLedgerMaster.InterestTypeID;
                tbxSaleBillFormat.Text = customerLedgerMaster.SaleBillFormat;
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

                if (String.IsNullOrWhiteSpace(ucSupplierCustomerInfo.CustomerSupplierName))
                {
                    MessageBox.Show("Customer Name "+ Constants.Messages.RequiredField);
                    return;
                }

                customerLedgerMaster.CustomerLedgerId = this.customerLedgerID;

                //values from User Control
                customerLedgerMaster.CustomerLedgerName = ucSupplierCustomerInfo.CustomerSupplierName;
                customerLedgerMaster.CustomerLedgerShortName = ucSupplierCustomerInfo.ShortName;
                customerLedgerMaster.Address = ucSupplierCustomerInfo.Address;
                customerLedgerMaster.ContactPerson = ucSupplierCustomerInfo.ContactPerson;
                customerLedgerMaster.Mobile = ucSupplierCustomerInfo.Mobile;
                customerLedgerMaster.OfficePhone = ucSupplierCustomerInfo.OfficePhone;
                customerLedgerMaster.ResidentPhone = ucSupplierCustomerInfo.ResidentPhone;
                customerLedgerMaster.EmailAddress = ucSupplierCustomerInfo.EmailAddress;
                customerLedgerMaster.OpeningBal = ExtensionMethods.SafeConversionDecimal(ucSupplierCustomerInfo.OpeningBal);
                customerLedgerMaster.CreditDebit = ucSupplierCustomerInfo.CreditDebit == Enums.TransType.C ? "C" : "D";
                customerLedgerMaster.TaxRetail = ucSupplierCustomerInfo.TaxRetail == Enums.TaxRetail.T ? "T" : "R";
                customerLedgerMaster.Status = ucSupplierCustomerInfo.Status == Enums.Status.Active ? true : false;

                //values from User this form
                customerLedgerMaster.ZSMId = cbxZSM.SelectedItem != null ? (int?)(cbxZSM.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.RSMId = cbxRSM.SelectedItem != null ? (int?)(cbxRSM.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.ASMId = cbxASM.SelectedItem != null ? (int?)(cbxASM.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.AreaId = cbxArea.SelectedItem != null ? (int?)(cbxArea.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.SalesManId = cbxSalesman.SelectedItem != null ? (int?)(cbxSalesman.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.RouteId = cbxRoute.SelectedItem != null ? (int?)(cbxRoute.SelectedItem as PersonRouteMaster).PersonRouteID : null;
                customerLedgerMaster.DLNo = tbxDL.Text;
                customerLedgerMaster.GSTNo = tbxGST.Text;
                customerLedgerMaster.CINNo = tbxCIN.Text;
                customerLedgerMaster.LINNo = tbxLIN.Text;
                customerLedgerMaster.ServiceTaxNo = tbxServiceTax.Text;
                customerLedgerMaster.PANNo = tbxPAN.Text;
                customerLedgerMaster.CreditLimit = ExtensionMethods.SafeConversionInt(tbxCredtLimit.Text) ?? default(int);
                customerLedgerMaster.CustomerTypeID = (cbxCustomerType.SelectedItem as CustomerType).CustomerTypeId;

                Enum.TryParse<Choice>(cbxLessExcise.SelectedValue.ToString(), out choice);
                customerLedgerMaster.IsLessExcise = choice == Choice.Yes;

                customerLedgerMaster.InterestTypeID = (cbxRateType.SelectedItem as InterestType).InterestTypeId;

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

                ///Get All the mapping for Company discount 
                ///
                customerLedgerMaster.CustomerCopanyDiscountList = dgvCompanyDiscount.Rows
                                                                                    .Cast<DataGridViewRow>()
                                                                                    .Where(r => !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Normal"].Value))
                                                                                                || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Breakage"].Value))
                                                                                                || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Expired"].Value))
                                                                                    ).Select(x => new CustomerCopanyDiscount()
                                                                                    {
                                                                                        CompanyID = (x.DataBoundItem as CustomerCopanyDiscount).CompanyID,
                                                                                        Normal = (x.DataBoundItem as CustomerCopanyDiscount).Normal,
                                                                                        Breakage = (x.DataBoundItem as CustomerCopanyDiscount).Breakage,
                                                                                        Expired = (x.DataBoundItem as CustomerCopanyDiscount).Expired,
                                                                                        IsLessEcise = (x.DataBoundItem as CustomerCopanyDiscount).IsLessEcise,
                                                                                        CustomerItemDiscountMapping= (x.DataBoundItem as CustomerCopanyDiscount).CustomerItemDiscountMapping

                                                                                    }).ToList();               

                int _result = 0;
                if (isInEditMode)
                {
                    _result = applicationFacade.UpdateCustomerLedger(customerLedgerMaster);
                }
                else
                {
                    _result = applicationFacade.AddCustomerLedger(customerLedgerMaster);
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
                throw ex;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            errorProviderCustomerLedger.Clear();
            this.Close();
        }
      
        private void frmCustomerLedgerMasterAddUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cbxPersonRouteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox activePersonRouteType =new ComboBox();
                Label activePersonRouteTypeMessageLbl = new Label();
                string activePersonRouteTypeString = String.Empty;

                switch ((sender as ComboBox).Name)
                {
                    case "cbxZSM":
                        {
                            activePersonRouteType = cbxZSM;
                            activePersonRouteTypeMessageLbl = lblZSMsg;
                            activePersonRouteTypeString = Constants.RecordType.ZSMDISPLAYNAME;
                        }
                        break;

                    case "cbxRSM":
                        {
                            activePersonRouteType = cbxRSM;
                            activePersonRouteTypeMessageLbl = lblRSMMsg;
                            activePersonRouteTypeString = Constants.RecordType.RSMDISPLAYNAME;
                        }
                        break;

                    case "cbxASM":
                        {
                            activePersonRouteType = cbxASM;
                            activePersonRouteTypeMessageLbl = lblASMMsg;
                            activePersonRouteTypeString = Constants.RecordType.ASMDISPLAYNAME;
                        }
                        break;
                    case "cbxSalesman":
                        {
                            activePersonRouteType = cbxSalesman;
                            activePersonRouteTypeMessageLbl = lblSalesmanMsg;
                            activePersonRouteTypeString = Constants.RecordType.SALESMANDISPLAYNAME;
                        }
                        break;
                    case "cbxArea":
                        {
                            activePersonRouteType = cbxArea;
                            activePersonRouteTypeMessageLbl = lblAreaMsg;
                            activePersonRouteTypeString = Constants.RecordType.AREADISPLAYNAME;
                        }
                        break;
                    case "cbxRoute":
                        {
                            activePersonRouteType = cbxRoute;
                            activePersonRouteTypeMessageLbl = lblRouteMsg;
                            activePersonRouteTypeString = Constants.RecordType.ROUTEDISPLAYNAME;
                        }
                        break;
                }


                int index = activePersonRouteType.FindString(activePersonRouteType.Text);
                if (index < 0)
                {

                    activePersonRouteTypeMessageLbl.Text=Constants.Messages.NotFound;

                    // DialogResult result = MessageBox.Show(String.Format(Constants.Messages.PersonRouteCreate,activePersonRouteTypeString), Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    //if (result == DialogResult.Yes)
                    //{
                    //    PersonRouteMaster newPersonRouteMaster = new PersonRouteMaster()
                    //    {
                    //        RecordTypeNme=activePersonRouteTypeString,
                    //        PersonRouteName= activePersonRouteType.Text
                    //    };
                    //    frmPersonRouteMasterAddUpdate form = new frmPersonRouteMasterAddUpdate(newPersonRouteMaster);
                    //    form.Tag = (sender as ComboBox).Name;
                    //    form.FormClosing += Form_FormClosing;
                    //    form.ShowDialog();             
                    //}
                    //else
                    //{
                    //    activePersonRouteType.SelectedIndex = 0;
                    //    return;
                    //}
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.F9))
            {
                ComboBox activePersonRouteType = new ComboBox();
                Label activePersonRouteTypeMessageLbl = new Label();
                string activePersonRouteTypeString = String.Empty;

                switch ((this.ActiveControl).Name)
                {
                    case "cbxZSM":
                        {
                            activePersonRouteType = cbxZSM;
                            activePersonRouteTypeMessageLbl = lblZSMsg;
                            activePersonRouteTypeString = Constants.RecordType.ZSMDISPLAYNAME;
                        }
                        break;

                    case "cbxRSM":
                        {
                            activePersonRouteType = cbxRSM;
                            activePersonRouteTypeMessageLbl = lblRSMMsg;
                            activePersonRouteTypeString = Constants.RecordType.RSMDISPLAYNAME;
                        }
                        break;

                    case "cbxASM":
                        {
                            activePersonRouteType = cbxASM;
                            activePersonRouteTypeMessageLbl = lblASMMsg;
                            activePersonRouteTypeString = Constants.RecordType.ASMDISPLAYNAME;
                        }
                        break;
                    case "cbxSalesman":
                        {
                            activePersonRouteType = cbxSalesman;
                            activePersonRouteTypeMessageLbl = lblSalesmanMsg;
                            activePersonRouteTypeString = Constants.RecordType.SALESMANDISPLAYNAME;
                        }
                        break;
                    case "cbxArea":
                        {
                            activePersonRouteType = cbxArea;
                            activePersonRouteTypeMessageLbl = lblAreaMsg;
                            activePersonRouteTypeString = Constants.RecordType.AREADISPLAYNAME;
                        }
                        break;
                    case "cbxRoute":
                        {
                            activePersonRouteType = cbxRoute;
                            activePersonRouteTypeMessageLbl = lblRouteMsg;
                            activePersonRouteTypeString = Constants.RecordType.ROUTEDISPLAYNAME;
                        }
                        break;
                }


                int index = activePersonRouteType.FindString(activePersonRouteType.Text);
                if (index < 0 && activePersonRouteTypeString != String.Empty)
                {
                    PersonRouteMaster newPersonRouteMaster = new PersonRouteMaster()
                    {
                        RecordTypeNme = activePersonRouteTypeString,
                        PersonRouteName = activePersonRouteType.Text
                    };
                    frmPersonRouteMasterAddUpdate form = new frmPersonRouteMasterAddUpdate(newPersonRouteMaster);
                    form.Tag = (this.ActiveControl).Name;
                    form.FormClosing += FormPersonRouteMaster_FormClosing;
                    form.ShowDialog();
                }

                activePersonRouteTypeMessageLbl.Text = String.Empty;
            }
            else if(keyData == (Keys.F3))
            {
                if (dgvCompanyDiscount.SelectedCells.Count > 0 )
                {                   
                    CustomerCopanyDiscount existingItem = (CustomerCopanyDiscount)dgvCompanyDiscount.Rows[dgvCompanyDiscount.SelectedCells[0].RowIndex].DataBoundItem;
                    frmCustomerItemDiscountMaster form = new frmCustomerItemDiscountMaster(existingItem);
                    form.FormClosed += FormCustomerItemDiscount_FormClosed;
                    form.Show();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FormCustomerItemDiscount_FormClosed(object sender, FormClosedEventArgs e)
        {
            CustomerCopanyDiscount updatedCustomerCopanyDiscount = (sender as frmCustomerItemDiscountMaster).CustomerCopanyDiscount;
            (dgvCompanyDiscount.Rows[dgvCompanyDiscount.SelectedCells[0].RowIndex].DataBoundItem as CustomerCopanyDiscount).CustomerItemDiscountMapping = updatedCustomerCopanyDiscount.CustomerItemDiscountMapping;
        }

        private void FormPersonRouteMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            int personRouteID = ((frmPersonRouteMasterAddUpdate)sender).PersonRouteID;

            switch ((sender as frmPersonRouteMasterAddUpdate).Tag.ToString())
            {
                case "cbxZSM":
                    {
                        ////Fill ZSM options
                        cbxZSM.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.ZSM);
                        cbxZSM.DisplayMember = "PersonRouteName";
                        cbxZSM.ValueMember = "PersonRouteID";
                        ///set newly added item
                        ///
                        if (personRouteID == 0 && cbxZSM.Items.Count >0 )
                        {
                            cbxZSM.SelectedIndex = 0;
                        }
                        else
                        {
                            cbxZSM.SelectedValue = personRouteID ;
                        }
                        
                    }
                    break;

                case "cbxRSM":
                    {
                        ////Fill RSM options
                        cbxRSM.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.RSM);
                        cbxRSM.DisplayMember = "PersonRouteName";
                        cbxRSM.ValueMember = "PersonRouteID";
                        ///set newly added item
                        ///

                        if (personRouteID == 0 && cbxRSM.Items.Count > 0)
                        {
                            cbxRSM.SelectedIndex = 0;
                        }
                        else
                        {
                            cbxRSM.SelectedValue = personRouteID;
                        }

                        
                    }
                    break;

                case "cbxASM":
                    {
                        ////Fill ASM options
                        cbxASM.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.ASM);
                        cbxASM.DisplayMember = "PersonRouteName";
                        cbxASM.ValueMember = "PersonRouteID";
                        ///set newly added item
                        ///
                        if (personRouteID == 0 && cbxASM.Items.Count > 0)
                        {
                            cbxASM.SelectedIndex = 0;
                        }
                        else
                        {
                            cbxASM.SelectedValue = personRouteID;
                        }
                        

                    }
                    break;
                case "cbxSalesman":
                    {
                        ////Fill Salesman options
                        cbxSalesman.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.SALESMAN);
                        cbxSalesman.DisplayMember = "PersonRouteName";
                        cbxSalesman.ValueMember = "PersonRouteID";
                        ///set newly added item
                        ///
                        if (personRouteID == 0 && cbxSalesman.Items.Count > 0)
                        {
                            cbxSalesman.SelectedIndex = 0;
                        }
                        else
                        {
                            cbxSalesman.SelectedValue = personRouteID;
                        }
                        
                    }
                    break;
                case "cbxArea":
                    {
                        ////Fill Area options
                        cbxArea.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.AREA);
                        cbxArea.DisplayMember = "PersonRouteName";
                        cbxArea.ValueMember = "PersonRouteID";
                        ///set newly added item
                        ///
                        if (personRouteID == 0 && cbxArea.Items.Count > 0)
                        {
                            cbxArea.SelectedIndex = 0;
                        }
                        else
                        {
                            cbxArea.SelectedValue = personRouteID;
                        }
                        
                    }
                    break;
                case "cbxRoute":
                    {
                        ////Fill Route options
                        cbxRoute.DataSource = applicationFacade.GetPersonRoutesBySystemName(Constants.RecordType.ROUTE);
                        cbxRoute.DisplayMember = "PersonRouteName";
                        cbxRoute.ValueMember = "PersonRouteID";
                        ///set newly added item
                        ///
                        if (personRouteID == 0 && cbxRoute.Items.Count > 0)
                        {
                            cbxRoute.SelectedIndex = 0;
                        }
                        else
                        {
                            cbxRoute.SelectedValue = personRouteID;
                        }
                    }
                    break;
            }

        }
  
        private void dgvCompanyDiscount_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string columnName = dgvCompanyDiscount.Columns[dgvCompanyDiscount.CurrentCell.ColumnIndex].Name;

            if (columnName.Equals("CompanyName") || columnName.Equals("IsLessEcise")) return;

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
