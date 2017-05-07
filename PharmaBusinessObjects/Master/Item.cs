using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CompanyCode { get; set; }
        public Nullable<double> ConversionRate { get; set; }
        public string ShortName { get; set; }
        public string Packing { get; set; }
        public Nullable<double> PurchaseRate { get; set; }
        public double MRP { get; set; }
        public Nullable<double> SaleRate { get; set; }
        public Nullable<double> SpecialRate { get; set; }
        public Nullable<double> WholeSaleRate { get; set; }
        public Nullable<double> SaleExcise { get; set; }
        public Nullable<double> SurchargeOnSale { get; set; }
        public Nullable<double> TaxOnSale { get; set; }
        public Nullable<double> Scheme1 { get; set; }
        public Nullable<double> Scheme2 { get; set; }
        public Nullable<double> PurchaseExcise { get; set; }
        public string UPC { get; set; }
        public bool IsHalfScheme { get; set; }
        public bool IsQTRScheme { get; set; }
        public Nullable<double> SpecialDiscount { get; set; }
        public Nullable<double> SpecialDiscountOnQty { get; set; }
        public bool IsFixedDiscount { get; set; }
        public Nullable<double> FixedDiscountRate { get; set; }
        public Nullable<double> MaximumQty { get; set; }
        public Nullable<double> MaximumDiscount { get; set; }
        public Nullable<double> SurchargeOnPurchase { get; set; }
        public Nullable<double> TaxOnPurchase { get; set; }
        public Nullable<double> DiscountRecieved { get; set; }
        public Nullable<double> SpecialDiscountRecieved { get; set; }
        public Nullable<double> QtyPerCase { get; set; }
        public string Location { get; set; }
        public Nullable<int> MinimumStock { get; set; }
        public Nullable<int> MaximumStock { get; set; }
        public int SaleTypeId { get; set; }
        public bool Status { get; set; }
    }
}
