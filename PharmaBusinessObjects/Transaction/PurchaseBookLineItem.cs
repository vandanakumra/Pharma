using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction
{
    public class PurchaseBookLineItem
    {
        public int SrNo { get; set; }
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int FreeQty { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public int Scheme1 { get; set; }
        public int Scheme2 { get; set; }
        public double MRP { get; set; }
        public bool IsHalfScheme { get; set; }
        public int Quantity { get; set; }
        public string BatchNumber { get; set; }
        public double? Discount { get; set; }
        public double? SpecialDiscount { get; set; }
        public double? VolumeDiscount { get; set; }
        public double? Excise { get; set; }
        public DateTime Expiry { get; set; }
        public double? TaxOnPurchase { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsNewRate { get; set; }
        public double SaleRate { get; set; }
        public double WholeSaleRate { get; set; }
        public double SpecialRate { get; set; }
        public string PurchaseTaxType { get; set; }

        public PurchaseBookLineItem()
        {
            BatchNumber = ItemName = ItemCode = PurchaseTaxType = string.Empty;
            Quantity = ID = SrNo = InvoiceID = FreeQty = Scheme2 = Scheme1 = 0;
            Rate = SpecialRate = WholeSaleRate = SaleRate = Amount = MRP = 0L;
            VolumeDiscount = SpecialDiscount = Discount = TaxOnPurchase = Excise = 0L;
            Expiry = PurchaseDate = DateTime.MinValue;
        }
    }
}
