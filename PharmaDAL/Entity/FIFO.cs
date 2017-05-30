//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PharmaDAL.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class FIFO
    {
        public long FifoID { get; set; }
        public long PurchaseSaleBookHeaderID { get; set; }
        public string VoucherNumber { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public int SRLNO { get; set; }
        public string ItemCode { get; set; }
        public string PurchaseBillNo { get; set; }
        public string Batch { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public double Quantity { get; set; }
        public double BalanceQuanity { get; set; }
        public Nullable<int> PurchaseTypeId { get; set; }
        public double PurchaseRate { get; set; }
        public Nullable<double> EffectivePurchaseRate { get; set; }
        public double SaleRate { get; set; }
        public Nullable<double> WholeSaleRate { get; set; }
        public Nullable<double> SpecialRate { get; set; }
        public double MRP { get; set; }
        public Nullable<double> Scheme1 { get; set; }
        public Nullable<double> Scheme2 { get; set; }
        public Nullable<bool> IsOnHold { get; set; }
        public string OnHoldRemarks { get; set; }
        public Nullable<System.DateTime> MfgDate { get; set; }
        public string UPC { get; set; }
    
        public virtual PurchaseSaleBookHeader PurchaseSaleBookHeader { get; set; }
    }
}
