using PharmaBusinessObjects.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class ItemMaster : BaseBusinessObjects
    {
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public double? ConversionRate { get; set; }
        public string ShortName { get; set; }
        public string Packing { get; set; }
        public double? PurchaseRate { get; set; }
        public double MRP { get; set; }
        public double? SaleRate { get; set; }
        public double? SpecialRate { get; set; }
        public double? WholeSaleRate { get; set; }
        public double? SaleExcise { get; set; }
        public double? SurchargeOnSale { get; set; }
        public double? TaxOnSale { get; set; }
        public double? Scheme1 { get; set; }
        public double? Scheme2 { get; set; }
        public double? PurchaseExcise { get; set; }
        public string UPC { get; set; }
        public bool IsHalfScheme { get; set; }
        public bool IsQTRScheme { get; set; }
        public double? SpecialDiscount { get; set; }
        public double? SpecialDiscountOnQty { get; set; }
        public bool IsFixedDiscount { get; set; }
        public double? FixedDiscountRate { get; set; }
        public double? MaximumQty { get; set; }
        public double? MaximumDiscount { get; set; }
        public double? SurchargeOnPurchase { get; set; }
        public double? TaxOnPurchase { get; set; }
        public double? DiscountRecieved { get; set; }
        public double? SpecialDiscountRecieved { get; set; }
        public double? QtyPerCase { get; set; }
        public string Location { get; set; }
        public int? MinimumStock { get; set; }
        public int? MaximumStock { get; set; }
        public int SaleTypeId { get; set; }
        public bool Status { get; set; }
        public int PurchaseTypeId { get; set; }
        public string PurchaseTypeCode { get; set; }
        public string PurchaseTypeName { get; set; }
        public decimal? PurchaseTypeRate { get; set; }

        public PurchaseSaleBookLineItem ToPurchaseBookLineItem()
        {
            PurchaseSaleBookLineItem lineItem = new PurchaseSaleBookLineItem();
            lineItem.ItemCode = this.ItemCode;
            lineItem.ItemName = this.ItemName;
            lineItem.Quantity = this.QtyPerCase == null ? 0 : Convert.ToInt32(this.QtyPerCase);
            lineItem.IsHalfScheme = this.IsHalfScheme;
            lineItem.MRP = this.MRP;
            lineItem.Scheme1 = this.Scheme1 == null ? 0 : Convert.ToInt32(this.Scheme1);
            lineItem.Scheme2 = this.Scheme2 == null ? 0 : Convert.ToInt32(this.Scheme2);
            lineItem.Discount = this.DiscountRecieved ?? 0L;
            lineItem.SpecialDiscount = this.SpecialDiscountRecieved ?? 0L;
            lineItem.VolumeDiscount = 0L;
            lineItem.MRP = this.MRP;
           // lineItem.Excise = this.PurchaseExcise ?? 0L;
            lineItem.FreeQuantity = 0;
            lineItem.SpecialRate = this.SpecialRate ?? 0L;
            lineItem.WholeSaleRate = this.WholeSaleRate ?? 0L;
            lineItem.SaleRate = this.SaleRate ?? 0L;
            lineItem.PurchaseSaleTypeCode = this.PurchaseTypeCode;
            double val = 0L;
            double.TryParse(Convert.ToString(this.PurchaseTypeRate), out val);
            lineItem.PurchaseSaleTax = val;
            lineItem.PurchaseSaleRate = (double)this.PurchaseRate;
            return lineItem;
        }
    }
    
}
