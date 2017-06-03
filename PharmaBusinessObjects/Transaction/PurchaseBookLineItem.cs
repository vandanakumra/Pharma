using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction
{
    public class PurchaseSaleBookLineItem
    {
        public long PurchaseSaleBookLineItemID { get; set; }
        public long PurchaseSaleBookHeaderID { get; set; }
        public Nullable<long> FifoID { get; set; }
        public Nullable<System.DateTime> PurchaseBillDate { get; set; }
        public string PurchaseVoucherNumber { get; set; }
        public Nullable<int> PurchaseSrlNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Batch { get; set; }
        public string BatchNew { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> FreeQuantity { get; set; }
        public double PurchaseSaleRate { get; set; }
        public Nullable<double> EffecivePurchaseSaleRate { get; set; }
        public string PurchaseSaleTypeCode { get; set; }
        public Nullable<double> SurCharge { get; set; }
        public Nullable<double> PurchaseSaleTax { get; set; }
        public string LocalCentral { get; set; }
        public Nullable<double> SGST { get; set; }
        public Nullable<double> IGST { get; set; }
        public Nullable<double> CGST { get; set; }
        public double Amount { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<double> SpecialDiscount { get; set; }
        public Nullable<double> DiscountQuantity { get; set; }
        public Nullable<double> VolumeDiscount { get; set; }
        public Nullable<double> Scheme1 { get; set; }
        public Nullable<double> Scheme2 { get; set; }
        public bool IsHalfScheme { get; set; }
        public Nullable<double> HalfSchemeRate { get; set; }       
        public Nullable<double> ConversionRate { get; set; }
        public Nullable<double> MRP { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<double> SaleRate { get; set; }
        public Nullable<double> WholeSaleRate { get; set; }
        public Nullable<double> SpecialRate { get; set; }


        public Nullable<double> CostAmount { get; set; }
        public Nullable<double> GrossAmount { get; set; }
        public Nullable<double> SchemeAmount { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public Nullable<double> SurchargeAmount { get; set; }
        public Nullable<double> TaxAmount { get; set; }
        public Nullable<double> SpecialDiscountAmount { get; set; }
        public Nullable<double> VolumeDiscountAmount { get; set; }
        public Nullable<double> TotalDiscountAmount { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public PurchaseSaleBookLineItem()
        {
            Batch = BatchNew = ItemCode = PurchaseSaleTypeCode = string.Empty;
            Quantity = 0;
            FreeQuantity = 0;
            Scheme1 = Scheme1 = 0;
            IsHalfScheme = false;
            Amount = 0;
            PurchaseSaleBookLineItemID = 0;
            PurchaseSaleRate = 0;
            SpecialRate = WholeSaleRate = SaleRate = Amount = 0;
            MRP = 0L;
            VolumeDiscount = SpecialDiscount = Discount = 0;
            PurchaseSaleTax = 0;
            IGST = SGST = CGST = 0;
            CostAmount = DiscountAmount = SpecialDiscountAmount = VolumeDiscountAmount = GrossAmount = TaxAmount = 0.0;
            SchemeAmount = SurchargeAmount = TotalDiscountAmount = 0.0;
           // ExpiryDate = DateTime.MinValue;
        }
    }
}
