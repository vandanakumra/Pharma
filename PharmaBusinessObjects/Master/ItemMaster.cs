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
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public double ? ConversionRate { get; set; }
        public string ShortName { get; set; }
        public string Packing { get; set; }
        public double ? PurchaseRate { get; set; }
        public double MRP { get; set; }
        public double ? SaleRate { get; set; }
        public double ? SpecialRate { get; set; }
        public double ? WholeSaleRate { get; set; }
        public double ? SaleExcise { get; set; }
        public double ? SurchargeOnSale { get; set; }
        public double ? TaxOnSale { get; set; }
        public double ? Scheme1 { get; set; }
        public double ? Scheme2 { get; set; }
        public double ? PurchaseExcise { get; set; }
        public string UPC { get; set; }
        public bool IsHalfScheme { get; set; }
        public bool IsQTRScheme { get; set; }
        public double ? SpecialDiscount { get; set; }
        public double ? SpecialDiscountOnQty { get; set; }
        public bool IsFixedDiscount { get; set; }
        public double ? FixedDiscountRate { get; set; }
        public double ? MaximumQty { get; set; }
        public double ? MaximumDiscount { get; set; }
        public double ? SurchargeOnPurchase { get; set; }
        public double ? TaxOnPurchase { get; set; }
        public double ? DiscountRecieved { get; set; }
        public double ? SpecialDiscountRecieved { get; set; }
        public double ? QtyPerCase { get; set; }
        public string Location { get; set; }
        public int ? MinimumStock { get; set; }
        public int ? MaximumStock { get; set; }
        public int SaleTypeId { get; set; }
        public bool Status { get; set; }
        public int Quantity { get; set; }
    }
}
