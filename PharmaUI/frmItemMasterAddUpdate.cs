using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmaBusiness;
using PharmaBusinessObjects.Master;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI
{
    public partial class frmItemMasterAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private bool isInEditMode = false;

        public frmItemMasterAddUpdate(bool isInEditMode = false)
        {
            this.isInEditMode = isInEditMode;
            InitializeComponent();
            applicationFacade = new ApplicationFacade();

            LoadCombo();
        }

        private void LoadCombo()
        {
            cbxComanyCode.SelectedIndexChanged += CbxComanyCode_SelectedIndexChanged;
            cbxFixedDiscount.SelectedIndexChanged += CbxFixedDiscount_SelectedIndexChanged;

            //Fill half Scheme options
            cbxHalfScheme.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxHalfScheme.SelectedItem = Choice.No;

            //Fill qtr Scheme options
            cbxQtrScheme.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxQtrScheme.SelectedItem = Choice.No;

            //Fill fixed discount options
            cbxFixedDiscount.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxFixedDiscount.SelectedItem = Choice.No;

            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Status.Active;

            //Fill the company list
            cbxComanyCode.DataSource = applicationFacade.GetCompanies(String.Empty);
            cbxComanyCode.DisplayMember = "CompanyName";
            cbxComanyCode.ValueMember = "CompanyCode";

            //Fill sale type list
            cbxSaleType.DataSource = applicationFacade.GetAccountLedgerBySystemName("SaleLedger");
            cbxSaleType.DisplayMember = "AccountLedgerName";
            cbxSaleType.ValueMember = "AccountLedgerID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tbxItemName.Text))
                {
                    errorProviderItem.SetError(tbxItemName,"Item Name field is Required");
                    tbxItemName.Focus();
                    tbxItemName.SelectAll();
                    return;
                }

                Choice choice;
                Status status;

                Item item = new Item();
                item.ItemCode = tbxItemCode.Text;
                item.ItemName = tbxItemName.Text;
                item.CompanyCode = (cbxComanyCode.SelectedItem as Company).CompanyCode;
                item.ConversionRate = ExtensionMethods.SafeConversionDouble(tbxConvRate.Text);
                item.ShortName = tbxShortName.Text;
                item.Packing = tbxPacking.Text;
                item.PurchaseRate = ExtensionMethods.SafeConversionDouble(tbxPurchaseRate.Text);
                item.MRP = ExtensionMethods.SafeConversionDouble(tbxMRP.Text) ?? default(double);
                item.SaleRate = ExtensionMethods.SafeConversionDouble(tbxSaleRate.Text);
                item.SpecialRate = ExtensionMethods.SafeConversionDouble(tbxSpecialRate.Text);
                item.WholeSaleRate = ExtensionMethods.SafeConversionDouble(tbxWholeSaleRate.Text);
                item.SaleExcise = ExtensionMethods.SafeConversionDouble(tbxSaleExcise.Text);
                item.SurchargeOnSale = ExtensionMethods.SafeConversionDouble(tbxSCOnSale.Text);
                item.TaxOnSale = ExtensionMethods.SafeConversionDouble(tbxTaxOnSale.Text);
                item.Scheme1 = ExtensionMethods.SafeConversionDouble(tbxScheme1.Text);
                item.Scheme2 = ExtensionMethods.SafeConversionDouble(tbxScheme2.Text);
                item.PurchaseExcise = ExtensionMethods.SafeConversionDouble(tbxPurchaseExcise.Text);
                item.UPC = tbxUPC.Text;             
                Enum.TryParse<Choice>(cbxHalfScheme.SelectedValue.ToString(), out choice);               
                item.IsHalfScheme = choice == Choice.Yes;
                Enum.TryParse<Choice>(cbxQtrScheme.SelectedValue.ToString(), out choice);
                item.IsQTRScheme = choice == Choice.Yes;
                item.SpecialDiscount = ExtensionMethods.SafeConversionDouble(tbxSpecialDiscount.Text);
                item.SpecialDiscountOnQty = ExtensionMethods.SafeConversionDouble(tbxSpecialDiscountOnQty.Text);
                Enum.TryParse<Choice>(cbxFixedDiscount.SelectedValue.ToString(), out choice);
                item.IsFixedDiscount = choice == Choice.Yes;
                item.FixedDiscountRate = ExtensionMethods.SafeConversionDouble(tbxFixedDiscountRate.Text);
                item.MaximumQty = ExtensionMethods.SafeConversionDouble(tbxMaxQty.Text);
                item.MaximumDiscount = ExtensionMethods.SafeConversionDouble(tbxMaxDiscount.Text);
                item.SurchargeOnPurchase = ExtensionMethods.SafeConversionDouble(tbxSCOnPurchase.Text);
                item.TaxOnPurchase = ExtensionMethods.SafeConversionDouble(tbxTaxOnPurchase.Text);
                item.DiscountRecieved = ExtensionMethods.SafeConversionDouble(tbxDiscountRecieved.Text);
                item.SpecialDiscountRecieved = ExtensionMethods.SafeConversionDouble(tbxSpecialDiscountRecieved.Text);
                item.QtyPerCase = ExtensionMethods.SafeConversionDouble(tbxQtyPerCase.Text);
                item.Location = tbxLocation.Text;
                item.MinimumStock = ExtensionMethods.SafeConversionInt(tbxMinimumStock.Text);
                item.MaximumStock = ExtensionMethods.SafeConversionInt(tbxMaximumStock.Text);
                item.SaleTypeId =( cbxSaleType.SelectedItem as AccountLedgerMaster).AccountLedgerID;
                Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
                item.Status = status == Status.Active;

                bool actionResult = false;
                // if form is in Edit mode then udate item , else add item 
                if (!isInEditMode)
                {
                    actionResult= applicationFacade.AddNewItem(item);
                }
                else
                {
                    actionResult= applicationFacade.UpdateItem(item);
                }

                //Close this form if operation is successful
                if (actionResult)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void frmItemMasterAddUpdate_Load(object sender, EventArgs e)
        {
            List<Control> allControls = ExtensionMethods.GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize));

            this.Dock = DockStyle.Fill;
            panel1.Width = this.Width;

            Label lbl = new Label();
            lbl.Width = panel1.Width;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;

            if (isInEditMode)
            {
                lbl.Text = "Item Master - Update";
            }
            else
            {
                lbl.Text = "Item Master - Add";
            }
            
            panel1.Controls.Add(lbl);

            //Event to allow only decimal entry
            {
                tbxConvRate.KeyPress += TbxAllowDecimal_KeyPress;
                tbxPacking.KeyPress += TbxAllowDecimal_KeyPress;
                tbxPurchaseRate.KeyPress += TbxAllowDecimal_KeyPress;
                tbxMRP.KeyPress += TbxAllowDecimal_KeyPress;
                tbxSaleRate.KeyPress += TbxAllowDecimal_KeyPress;
                tbxSpecialRate.KeyPress += TbxAllowDecimal_KeyPress;
                tbxWholeSaleRate.KeyPress += TbxAllowDecimal_KeyPress;
                tbxSaleExcise.KeyPress += TbxAllowDecimal_KeyPress;
                tbxSCOnSale.KeyPress += TbxAllowDecimal_KeyPress;
                tbxScheme1.KeyPress += TbxAllowDecimal_KeyPress;
                tbxScheme2.KeyPress += TbxAllowDecimal_KeyPress;
                tbxPurchaseExcise.KeyPress += TbxAllowDecimal_KeyPress;
                tbxSpecialDiscount.KeyPress += TbxAllowDecimal_KeyPress;
                tbxSpecialDiscountOnQty.KeyPress += TbxAllowDecimal_KeyPress;
                tbxFixedDiscountRate.KeyPress += TbxAllowDecimal_KeyPress;
                tbxMaxQty.KeyPress += TbxAllowDecimal_KeyPress;
                tbxMaxDiscount.KeyPress += TbxAllowDecimal_KeyPress;
                tbxSCOnPurchase.KeyPress += TbxAllowDecimal_KeyPress;
                tbxTaxOnPurchase.KeyPress += TbxAllowDecimal_KeyPress;
                tbxDiscountRecieved.KeyPress += TbxAllowDecimal_KeyPress;
                tbxSpecialDiscountRecieved.KeyPress += TbxAllowDecimal_KeyPress;
                tbxQtyPerCase.KeyPress += TbxAllowDecimal_KeyPress;
                tbxMinimumStock.KeyPress += TbxAllowDecimal_KeyPress;
                tbxMaximumStock.KeyPress += TbxAllowDecimal_KeyPress;
            }
            
        }

        private void CbxFixedDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFixedDiscount.SelectedItem == null) return;

            Choice choice;
            Enum.TryParse<Choice>(cbxFixedDiscount.SelectedItem.ToString(), out choice);

            if (choice == Choice.Yes)
            {
                tbxFixedDiscountRate.ReadOnly = false;
            }
            else
            {
                tbxFixedDiscountRate.ReadOnly = true;
            }
        }

        private void CbxComanyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxComanyCode.SelectedItem == null) return;

            //Company selectedCompany = cbxComanyCode.SelectedItem as Company;

            //if (selectedCompany != null && !isInEditMode)
            //{
            //    tbxItemCode.Text = applicationFacade.GetNextItemCode(Convert.ToString(selectedCompany.CompanyCode));
            //}
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void frmItemMasterAddUpdate_Fill_UsingExistingItem(Item existingItem)
        {
            if (existingItem!=null)
            {
                tbxItemCode.Text = existingItem.ItemCode;
                tbxItemName.Text = existingItem.ItemName;
                cbxComanyCode.SelectedValue = existingItem.CompanyCode;
                tbxConvRate.Text =Convert.ToString(existingItem.ConversionRate);
                tbxShortName.Text = existingItem.ShortName;
                tbxPacking.Text = existingItem.Packing;
                tbxPurchaseRate.Text = Convert.ToString(existingItem.PurchaseRate);
                tbxMRP.Text = Convert.ToString(existingItem.MRP);
                tbxSaleRate.Text = Convert.ToString(existingItem.SaleRate);
                tbxSpecialRate.Text = Convert.ToString(existingItem.SpecialRate);
                tbxWholeSaleRate.Text = Convert.ToString(existingItem.WholeSaleRate);
                tbxSaleExcise.Text = Convert.ToString(existingItem.SaleExcise);
                tbxSCOnSale.Text = Convert.ToString(existingItem.SurchargeOnSale);
                tbxTaxOnSale.Text = Convert.ToString(existingItem.TaxOnSale);
                tbxScheme1.Text = Convert.ToString(existingItem.Scheme1);
                tbxScheme2.Text = Convert.ToString(existingItem.Scheme2);
                tbxPurchaseExcise.Text = Convert.ToString(existingItem.PurchaseExcise);
                tbxUPC.Text = existingItem.UPC;
                cbxHalfScheme.SelectedItem = existingItem.IsHalfScheme ? Choice.Yes : Choice.No;
                cbxQtrScheme.SelectedItem = existingItem.IsQTRScheme ? Choice.Yes : Choice.No;
                tbxSpecialDiscount.Text = Convert.ToString( existingItem.SpecialDiscount);
                tbxSpecialDiscountOnQty.Text =Convert.ToString( existingItem.SpecialDiscountOnQty);
                cbxFixedDiscount.SelectedItem = existingItem.IsFixedDiscount ? Choice.Yes : Choice.No;
                tbxFixedDiscountRate.Text = Convert.ToString(existingItem.FixedDiscountRate);
                tbxMaxQty.Text = Convert.ToString(existingItem.MaximumQty);
                tbxMaxDiscount.Text = Convert.ToString(existingItem.MaximumDiscount);
                tbxSCOnPurchase.Text = Convert.ToString(existingItem.SurchargeOnPurchase);
                tbxTaxOnPurchase.Text = Convert.ToString(existingItem.TaxOnPurchase);
                tbxDiscountRecieved.Text = Convert.ToString(existingItem.DiscountRecieved);
                tbxSpecialDiscountRecieved.Text = Convert.ToString(existingItem.SpecialDiscountRecieved);
                tbxQtyPerCase.Text = Convert.ToString(existingItem.QtyPerCase);
                tbxLocation.Text = Convert.ToString(existingItem.Location);
                tbxMinimumStock.Text = Convert.ToString(existingItem.MinimumStock);
                tbxMaximumStock.Text = Convert.ToString(existingItem.MaximumStock);
                cbxSaleType.SelectedValue = existingItem.SaleTypeId;
                cbxStatus.SelectedItem = existingItem.Status ? Status.Active : Status.Inactive;
            }
        }

        private void TbxAllowDecimal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbxItemName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxItemName.Text))
            {
                errorProviderItem.SetError(tbxItemName, "Item Name field is Required");
                tbxItemName.Focus();
                tbxItemName.SelectAll();
            }
            else
            {
                errorProviderItem.SetError(tbxItemName, String.Empty);
            }
        }

        private void tbxItemName_Validated(object sender, EventArgs e)
        {
            errorProviderItem.SetError(tbxItemName, String.Empty);
        }
    }
}
