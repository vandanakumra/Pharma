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
        }

       
        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
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
            this.Dock = DockStyle.Fill;
            panel1.Width = this.Width;

            Label lbl = new Label();
            lbl.Width = panel1.Width;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Text = "Item Master - Add";
            panel1.Controls.Add(lbl);

            cbxComanyCode.SelectedIndexChanged += CbxComanyCode_SelectedIndexChanged;
            cbxFixedDiscount.SelectedIndexChanged += CbxFixedDiscount_SelectedIndexChanged;

            //Fill half Scheme options
            cbxHalfScheme.DataSource = Enum.GetValues(typeof(Enums.Choice));

            //Fill qtr Scheme options
            cbxQtrScheme.DataSource = Enum.GetValues(typeof(Enums.Choice));

            //Fill fixed discount options
            cbxFixedDiscount.DataSource = Enum.GetValues(typeof(Enums.Choice));

            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));

            //Fill the company list
            cbxComanyCode.DataSource = applicationFacade.GetCompanies();
            cbxComanyCode.DisplayMember = "CompanyName";
            cbxComanyCode.ValueMember = "CompanyCode";

            //Fill sale type list
            cbxSaleType.DataSource = applicationFacade.GetAccountLedgerBySystemName("SaleLedger");
            cbxSaleType.DisplayMember = "AccountLedgerName";
            cbxSaleType.ValueMember = "AccountLedgerID";

        }

        private void CbxFixedDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFixedDiscount.SelectedItem == null) return;

            Choice choice;
            Enum.TryParse<Choice>(cbxHalfScheme.SelectedValue.ToString(), out choice);

            if (choice == Choice.Yes)
            {
                tbxFixedDiscountRate.ReadOnly = false;
            }
        }

        private void CbxComanyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxComanyCode.SelectedItem == null) return;

            Company selectedCompany = cbxComanyCode.SelectedItem as Company;

            if (selectedCompany != null)
            {
                tbxItemCode.Text = applicationFacade.GetNextItemCode(Convert.ToString(selectedCompany.CompanyCode));
            }
                
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
