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
    
    public partial class TempBillOutStandingsAudjustment
    {
        public long BillOutStandingsAudjustmentID { get; set; }
        public Nullable<long> PurchaseSaleBookHeaderID { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherTypeCode { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public Nullable<long> ReceiptPaymentID { get; set; }
        public long BillOutStandingsID { get; set; }
        public string AdjustmentVoucherNumber { get; set; }
        public string AdjustmentVoucherTypeCode { get; set; }
        public System.DateTime AdjustmentVoucherDate { get; set; }
        public string LedgerType { get; set; }
        public string LedgerTypeCode { get; set; }
        public decimal Amount { get; set; }
        public string ChequeNumber { get; set; }
    
        public virtual BillOutStandings BillOutStandings { get; set; }
        public virtual PurchaseSaleBookHeader PurchaseSaleBookHeader { get; set; }
        public virtual TempReceiptPayment TempReceiptPayment { get; set; }
    }
}
