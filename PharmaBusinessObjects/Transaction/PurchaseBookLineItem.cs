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


        public PurchaseBookLineItem()
        {
            Quantity = 0;
            ID = 0;
            SrNo = 0;
            InvoiceID = 0;
            FreeQty = 0;
            BatchNumber = string.Empty;
            ItemCode = string.Empty;
            ItemName = string.Empty;
            MRP = 0L;
            Scheme1 = 0;
            Scheme2 = 0;
            Amount = 0L;
            Rate = 0L;
        }
    }
}
