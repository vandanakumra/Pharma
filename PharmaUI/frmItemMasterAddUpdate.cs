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

namespace PharmaUI
{
    public partial class frmItemMasterAddUpdate : Form
    {
        ApplicationFacade applicationFacade;
        public frmItemMasterAddUpdate()
        {
            InitializeComponent();
            applicationFacade = new ApplicationFacade();

            //Fill the company list
            cbxComanyCode.DataSource = applicationFacade.GetCompanies();
            cbxComanyCode.DisplayMember = "CompanyName";
            cbxComanyCode.ValueMember = "CompanyCode";

            //Fill sale type list
            cbxSaleType.DataSource = applicationFacade.GetAccountLedgerBySystemName("SaleLedger");
            cbxSaleType.DisplayMember = "AccountLedgerType";
            cbxSaleType.ValueMember = "AccountLedgerTypeId";
        }

        private void cbxComanyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxComanyCode.SelectedItem == null) return;

            Company selectedCompany = cbxComanyCode.SelectedItem as Company;
            if (selectedCompany != null)
                tbxItemCode.Text = applicationFacade.GetNextItemCode(Convert.ToString(selectedCompany.CompanyCode));
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
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
                item.IsHalfScheme = Convert.ToBoolean(chbxHalfScheme.Checked);
                item.IsQTRScheme = Convert.ToBoolean(chbxQuarterScheme.Checked);
                item.SpecialDiscount = ExtensionMethods.SafeConversionDouble(tbxSpecialDiscount.Text);
                item.SpecialDiscountOnQty = ExtensionMethods.SafeConversionDouble(tbxSpecialDiscountOnQty.Text);
                item.IsFixedDiscount = Convert.ToBoolean(chbxFixedDiscount.Checked);
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
                item.SaleTypeId = 1;
                item.Status = Convert.ToBoolean(chbxStatus.Checked);

                applicationFacade.AddNewItem(item);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
