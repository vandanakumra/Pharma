﻿using System;
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
        public decimal Quantity { get; set; }
        public Nullable<decimal> FreeQuantity { get; set; }
        public decimal PurchaseSaleRate { get; set; }
        public decimal OldPurchaseSaleRate { get; set; }
        public Nullable<decimal> EffecivePurchaseSaleRate { get; set; }
        public string PurchaseSaleTypeCode { get; set; }
        public Nullable<decimal> SurCharge { get; set; }
        public Nullable<decimal> PurchaseSaleTax { get; set; }
        public string LocalCentral { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> IGST { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public decimal Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> SpecialDiscount { get; set; }
        public Nullable<decimal> DiscountQuantity { get; set; }
        public Nullable<decimal> VolumeDiscount { get; set; }
        public Nullable<decimal> Scheme1 { get; set; }
        public Nullable<decimal> Scheme2 { get; set; }
        public bool IsHalfScheme { get; set; }
        public Nullable<decimal> HalfSchemeRate { get; set; }       
        public Nullable<decimal> ConversionRate { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> WholeSaleRate { get; set; }
        public Nullable<decimal> SpecialRate { get; set; }
        public Nullable<decimal> CostAmount { get; set; }
        public Nullable<decimal> GrossAmount { get; set; }
        public Nullable<decimal> SchemeAmount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> SurchargeAmount { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> SpecialDiscountAmount { get; set; }
        public Nullable<decimal> VolumeDiscountAmount { get; set; }
        public Nullable<decimal> TotalDiscountAmount { get; set; }
        public Nullable<decimal> UsedQuantity { get; set; }
        public Nullable<decimal> BalanceQuantity { get; set; }
        public Nullable<long> OldPurchaseSaleBookLineItemID { get; set; }
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
            PurchaseSaleRate = OldPurchaseSaleRate = 0;
            SpecialRate = WholeSaleRate = SaleRate = Amount = 0;
            MRP = 0L;
            VolumeDiscount = SpecialDiscount = Discount = 0;
            PurchaseSaleTax = 0;
            IGST = SGST = CGST = 0;
            CostAmount = DiscountAmount = SpecialDiscountAmount = VolumeDiscountAmount = GrossAmount = TaxAmount = 0;
            SchemeAmount = SurchargeAmount = TotalDiscountAmount = 0;           
        }
    }
}
