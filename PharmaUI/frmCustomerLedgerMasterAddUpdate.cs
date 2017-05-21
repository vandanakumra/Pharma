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
            LoadCombo();

            if (!isInEditMode)
                LoadCustomerCompanyDiscountGrid();

        }

        private void LoadCombo()
        {
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
            this.ucSupplierCustomerInfo.SetFocus();
            ExtensionMethods.EnterKeyDownForTabEvents(this);
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
                ucSupplierCustomerInfo.Telephone = customerLedgerMaster.Telephone;
                ucSupplierCustomerInfo.Mobile = customerLedgerMaster.Mobile;
                ucSupplierCustomerInfo.OfficePhone = customerLedgerMaster.OfficePhone;
                ucSupplierCustomerInfo.ResidentPhone = customerLedgerMaster.ResidentPhone;
                ucSupplierCustomerInfo.EmailAddress = customerLedgerMaster.EmailAddress;
                ucSupplierCustomerInfo.OpeningBal = Convert.ToString(customerLedgerMaster.OpeningBal);
                ucSupplierCustomerInfo.CreditDebit = customerLedgerMaster.CreditDebit == "C" ? Enums.TransType.C : Enums.TransType.D;
                ucSupplierCustomerInfo.TaxRetail = customerLedgerMaster.TaxRetail == "T" ? Enums.TaxRetail.T : Enums.TaxRetail.R;
                ucSupplierCustomerInfo.Status = customerLedgerMaster.Status ? Enums.Status.Active : Enums.Status.Inactive;

                tbxZSM.Text = customerLedgerMaster.ZSMName;
                tbxZSM.Tag = customerLedgerMaster.ZSMId;

                tbxRSM.Text = customerLedgerMaster.RSMName;
                tbxRSM.Tag = customerLedgerMaster.RSMId;

                tbxASM.Text = customerLedgerMaster.ASMName;
                tbxASM.Tag = customerLedgerMaster.ASMId;

                tbxSalesman.Text = customerLedgerMaster.SalesmanName;
                tbxSalesman.Tag = customerLedgerMaster.SalesManId;

                tbxArea.Text = customerLedgerMaster.AreaName;
                tbxArea.Tag = customerLedgerMaster.AreaId;

                tbxRoute.Text = customerLedgerMaster.RouteName;
                tbxRoute.Tag = customerLedgerMaster.RouteId;

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
                    MessageBox.Show("Customer Name " + Constants.Messages.RequiredField);
                    return;
                }

                customerLedgerMaster.CustomerLedgerId = this.customerLedgerID;

                //values from User Control
                customerLedgerMaster.CustomerLedgerName = ucSupplierCustomerInfo.CustomerSupplierName;
                customerLedgerMaster.CustomerLedgerShortName = ucSupplierCustomerInfo.ShortName;
                customerLedgerMaster.Address = ucSupplierCustomerInfo.Address;
                customerLedgerMaster.ContactPerson = ucSupplierCustomerInfo.ContactPerson;
                customerLedgerMaster.Telephone = ucSupplierCustomerInfo.Telephone;
                customerLedgerMaster.Mobile = ucSupplierCustomerInfo.Mobile;
                customerLedgerMaster.OfficePhone = ucSupplierCustomerInfo.OfficePhone;
                customerLedgerMaster.ResidentPhone = ucSupplierCustomerInfo.ResidentPhone;
                customerLedgerMaster.EmailAddress = ucSupplierCustomerInfo.EmailAddress;
                customerLedgerMaster.OpeningBal = ExtensionMethods.SafeConversionDecimal(ucSupplierCustomerInfo.OpeningBal);
                customerLedgerMaster.CreditDebit = ucSupplierCustomerInfo.CreditDebit == Enums.TransType.C ? "C" : "D";
                customerLedgerMaster.TaxRetail = ucSupplierCustomerInfo.TaxRetail == Enums.TaxRetail.T ? "T" : "R";
                customerLedgerMaster.Status = ucSupplierCustomerInfo.Status == Enums.Status.Active ? true : false;

                //values from User this form
                customerLedgerMaster.ZSMId = String.IsNullOrWhiteSpace(tbxZSM.Text) ?null : (int?)tbxZSM.Tag;
                customerLedgerMaster.RSMId = String.IsNullOrWhiteSpace(tbxRSM.Text) ? null : (int?)tbxRSM.Tag;
                customerLedgerMaster.ASMId = String.IsNullOrWhiteSpace(tbxASM.Text) ? null : (int?)tbxASM.Tag;
                customerLedgerMaster.AreaId = String.IsNullOrWhiteSpace(tbxSalesman.Text) ? null : (int?)tbxSalesman.Tag;
                customerLedgerMaster.SalesManId = String.IsNullOrWhiteSpace(tbxArea.Text) ? null : (int?)tbxArea.Tag;
                customerLedgerMaster.RouteId = String.IsNullOrWhiteSpace(tbxRoute.Text) ? null : (int?)tbxRoute.Tag;

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
                                                                                        CustomerItemDiscountMapping = (x.DataBoundItem as CustomerCopanyDiscount).CustomerItemDiscountMapping

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
       
        private void FrmPersonRouteMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            PersonRouteMaster lastSelectedPersonRoute= (sender as frmPersonRouteMaster).LastSelectedPersonRoute;
            if (lastSelectedPersonRoute != null)
            {
                switch (lastSelectedPersonRoute.RecordTypeNme)
                {
                    case Constants.RecordType.ZSMDISPLAYNAME:
                        {
                            tbxZSM.Text = lastSelectedPersonRoute.PersonRouteName;
                            tbxZSM.Tag = lastSelectedPersonRoute.PersonRouteID;
                        }
                        break;

                    case Constants.RecordType.RSMDISPLAYNAME:
                        {
                            tbxRSM.Text = lastSelectedPersonRoute.PersonRouteName;
                            tbxRSM.Tag = lastSelectedPersonRoute.PersonRouteID;
                        }
                        break;

                    case Constants.RecordType.ASMDISPLAYNAME:
                        {
                            tbxASM.Text = lastSelectedPersonRoute.PersonRouteName;
                            tbxASM.Tag = lastSelectedPersonRoute.PersonRouteID;
                        }
                        break;

                    case Constants.RecordType.SALESMANDISPLAYNAME:
                        {
                            tbxSalesman.Text = lastSelectedPersonRoute.PersonRouteName;
                            tbxSalesman.Tag = lastSelectedPersonRoute.PersonRouteID;
                        }
                        break;

                    case Constants.RecordType.AREADISPLAYNAME:
                        {
                            tbxArea.Text = lastSelectedPersonRoute.PersonRouteName;
                            tbxArea.Tag = lastSelectedPersonRoute.PersonRouteID;
                        }
                        break;

                    case Constants.RecordType.ROUTEDISPLAYNAME:
                        {
                            tbxRoute.Text = lastSelectedPersonRoute.PersonRouteName;
                            tbxRoute.Tag = lastSelectedPersonRoute.PersonRouteID;
                        }
                        break;
                }
               
            }

            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.F9))
            {

            }
            else if (keyData == (Keys.F3))
            {
                if (dgvCompanyDiscount.SelectedCells.Count > 0)
                {
                    CustomerCopanyDiscount existingItem = (CustomerCopanyDiscount)dgvCompanyDiscount.Rows[dgvCompanyDiscount.SelectedCells[0].RowIndex].DataBoundItem;
                    frmCustomerItemDiscountMaster form = new frmCustomerItemDiscountMaster(existingItem);
                    form.FormClosed += FormCustomerItemDiscount_FormClosed;
                    form.Show();
                }
            }
            else if (keyData == Keys.F1)
            {
                TextBox activePersonRouteType = new TextBox();
                string activePersonRouteTypeString = String.Empty;

                switch (this.ActiveControl.Name)
                {
                    case "tbxZSM":
                        {
                            activePersonRouteType = tbxZSM;
                            activePersonRouteTypeString = Constants.RecordType.ZSMDISPLAYNAME;
                        }
                        break;

                    case "tbxRSM":
                        {
                            activePersonRouteType = tbxRSM;
                            activePersonRouteTypeString = Constants.RecordType.RSMDISPLAYNAME;
                        }
                        break;

                    case "tbxASM":
                        {
                            activePersonRouteType = tbxASM;
                            activePersonRouteTypeString = Constants.RecordType.ASMDISPLAYNAME;
                        }
                        break;
                    case "tbxSalesman":
                        {
                            activePersonRouteType = tbxSalesman;
                            activePersonRouteTypeString = Constants.RecordType.SALESMANDISPLAYNAME;
                        }
                        break;
                    case "tbxArea":
                        {
                            activePersonRouteType = tbxArea;
                            activePersonRouteTypeString = Constants.RecordType.AREADISPLAYNAME;
                        }
                        break;
                    case "tbxRoute":
                        {
                            activePersonRouteType = tbxRoute;
                            activePersonRouteTypeString = Constants.RecordType.ROUTEDISPLAYNAME;
                        }
                        break;
                }

                if (!String.IsNullOrWhiteSpace(activePersonRouteTypeString))
                {
                    PersonRouteMaster personRouteMaster = new PersonRouteMaster()
                    {
                        RecordTypeNme = activePersonRouteTypeString,
                        PersonRouteID = ExtensionMethods.SafeConversionInt(Convert.ToString(activePersonRouteType.Tag)) ?? 0,
                        PersonRouteName = activePersonRouteType.Text
                    };

                    frmPersonRouteMaster frmPersonRouteMaster = new frmPersonRouteMaster();
                    //Set Child UI
                    ExtensionMethods.AddChildFormToPanel(this, frmPersonRouteMaster, ExtensionMethods.MainPanel);
                    frmPersonRouteMaster.WindowState = FormWindowState.Maximized;

                    frmPersonRouteMaster.FormClosed += FrmPersonRouteMaster_FormClosed;
                    frmPersonRouteMaster.Show();
                    frmPersonRouteMaster.ConfigurePersonRoute(personRouteMaster);
                }          
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FormCustomerItemDiscount_FormClosed(object sender, FormClosedEventArgs e)
        {
            CustomerCopanyDiscount updatedCustomerCopanyDiscount = (sender as frmCustomerItemDiscountMaster).retCustomerCopanyDiscount;
            (dgvCompanyDiscount.Rows[dgvCompanyDiscount.SelectedCells[0].RowIndex].DataBoundItem as CustomerCopanyDiscount).CustomerItemDiscountMapping = updatedCustomerCopanyDiscount.CustomerItemDiscountMapping;
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

       //Set focus for the controls

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

        private void dgvCompanyDiscount_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCompanyDiscount.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
            {
                SendKeys.Send("{tab}");
            }
        }
    }

}
