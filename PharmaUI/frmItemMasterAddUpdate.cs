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
        }

        private void cbxComanyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxComanyCode.SelectedItem == null) return;

            Company selectedCompany = cbxComanyCode.SelectedItem as Company;
            if(selectedCompany != null)
            tbxItemCode.Text=applicationFacade.GetNextItemCode(Convert.ToString(selectedCompany.CompanyCode));
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                Item item = new Item()
                {
                    ItemCode = tbxItemCode.Text,
                    ItemName = tbxItemName.Text,
                    CompanyCode = (cbxComanyCode.SelectedItem as Company).CompanyCode,
                    ConversionRate = Convert.ToDouble(tbxConvRate.Text),
                    ShortName = tbxShortName.Text,
                    Packing = tbxPacking.Text,
                    PurchaseRate = Convert.ToDouble(tbxPurchaseRate.Text),
                    MRP = Convert.ToDouble(tbxMRP.Text),
                    SaleRate = Convert.ToDouble(tbxSaleRate.Text),
                    SpecialRate = Convert.ToDouble(tbxSpecialRate.Text),
                    WholeSaleRate = Convert.ToDouble(tbxWholeSaleRate.Text),
                    SaleExcise = Convert.ToDouble(tbxSaleExcise.Text),
                    SurchargeOnSale = Convert.ToDouble(tbxSCOnSale.Text),
                    TaxOnSale = Convert.ToDouble(tbxTaxOnSale.Text),
                    Scheme1 = Convert.ToDouble(tbxScheme1.Text),
                    Scheme2 = Convert.ToDouble(tbxScheme2.Text),
                    PurchaseExcise = Convert.ToDouble(tbxPurchaseExcise.Text),
                    UPC = tbxUPC.Text,
                    IsHalfScheme = Convert.ToBoolean(chbxHalfScheme.Checked),
                    IsQTRScheme = Convert.ToBoolean(chbxQuarterScheme.Checked),
                    SpecialDiscount = Convert.ToDouble(tbxSpecialDiscount.Text),
                    SpecialDiscountOnQty = Convert.ToDouble(tbxSpecialDiscountOnQty.Text),
                    IsFixedDiscount = Convert.ToBoolean(chbxFixedDiscount.Checked),
                    FixedDiscountRate = Convert.ToDouble(tbxFixedDiscountRate.Text),
                    MaximumQty = Convert.ToDouble(tbxMaxQty.Text),
                    MaximumDiscount = Convert.ToDouble(tbxMaxDiscount),
                    SurchargeOnPurchase = Convert.ToDouble(tbxSCOnPurchase.Text),
                    TaxOnPurchase = Convert.ToDouble(tbxTaxOnPurchase.Text),
                    DiscountRecieved = Convert.ToDouble(tbxDiscountRecieved.Text),
                    SpecialDiscountRecieved = Convert.ToDouble(tbxSpecialDiscountRecieved.Text),
                    QtyPerCase = Convert.ToDouble(tbxQtyPerCase.Text),
                    Location = tbxLocation.Text,
                    MinimumStock = Convert.ToInt32(tbxMinimumStock.Text),
                    MaximumStock = Convert.ToInt32(tbxMaximumStock.Text),
                    SaleTypeId = default(int),
                    Status = Convert.ToBoolean(chbxStatus.Checked)
                };
            }
            catch (Exception ex)
            {
                throw;
            }
                    
        }
    }
}
