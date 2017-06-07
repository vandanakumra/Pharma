using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction
{
    public class PurchaseSaleBookHeader : BaseBusinessObjects
    {

        public long PurchaseSaleBookHeaderID { get; set; }
        public string VoucherTypeCode { get; set; }
        public DateTime VoucherDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string PurchaseBillNo { get; set; }
        public string LedgerType { get; set; }
        public string LedgerTypeCode { get; set; }
        public double? Amount01 { get; set; }
        public double? Amount02 { get; set; }
        public double? Amount03 { get; set; }
        public double? Amount04 { get; set; }
        public double? Amount05 { get; set; }
        public double? Amount06 { get; set; }
        public double? Amount07 { get; set; }
        public double? SGST01 { get; set; }
        public double? SGST02 { get; set; }
        public double? SGST03 { get; set; }
        public double? SGST04 { get; set; }
        public double? SGST05 { get; set; }
        public double? SGST06 { get; set; }
        public double? SGST07 { get; set; }
        public double? IGST01 { get; set; }
        public double? IGST02 { get; set; }
        public double? IGST03 { get; set; }
        public double? IGST04 { get; set; }
        public double? IGST05 { get; set; }
        public double? IGST06 { get; set; }
        public double? IGST07 { get; set; }
        public double? CGST01 { get; set; }
        public double? CGST02 { get; set; }
        public double? CGST03 { get; set; }
        public double? CGST04 { get; set; }
        public double? CGST05 { get; set; }
        public double? CGST06 { get; set; }
        public double? CGST07 { get; set; }
        public double TotalTaxAmount { get; set; }
        public double? SurchargeAmount { get; set; }
        public double? TotalBillAmount { get; set; }
        public double? TotalCostAmount { get; set; }
        public double? TotalGrossAmount { get; set; }
        public double? TotalSchemeAmount { get; set; }
        public double? TotalDiscountAmount { get; set; }
        public double? OtherAmount { get; set; }
        public string FreshBreakageExcess { get; set; }
        public string ReturnBillNo { get; set; }
        public Nullable<System.DateTime> ReturBillDate { get; set; }
        public Nullable<int> CustomerTypeId { get; set; }
        public string LocalCentral { get; set; }
        public string OrderNumber { get; set; }
        public string ChallanNumber { get; set; }
        public string Message { get; set; }
        public string Deliveryddress { get; set; }
        public string DeliveredBy { get; set; }
        public string CourierName { get; set; }
        public Nullable<System.DateTime> CourierDate { get; set; }
        public double? CourierWeight { get; set; }
        public Nullable<int> PurchaseEntryFormID { get; set; }
        public double? LastBalance { get; set; }

        public Nullable<int> ZSMId { get; set; }
        public Nullable<int> ASMId { get; set; }
        public Nullable<int> RSMId { get; set; }
        public Nullable<int> AreaId { get; set; }
        public Nullable<int> SalesManId { get; set; }
        public Nullable<int> RouteId { get; set; }

        public Nullable<long> OldPurchaseSaleBookHeaderID { get; set; }

    }

    public class PurchaseBookAmount : BaseBusinessObjects
    {
        public long PurchaseBookHeaderID { get; set; }
        public string PurchaseSaleTypeCode { get; set; }
        public string PurchaseSaleTypeName { get; set; }
        public double Amount { get; set; }
        public double IGST { get; set; }
        public double SGST { get; set; }
        public double CGST { get; set; }
        public double TaxApplicable { get; set; }
        public long PurchaseSaleBookLineItemID { get; set; }
        public double BillAmount { get; set; }
        public double TaxAmount { get; set; }
        public double CostAmount { get; set; }
        public double GrossAmount { get; set; }
        public double SchemeAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double SpecialDiscountAmount { get; set; }
        public double VolumeDiscountAmount { get; set; }
        public double TotalDiscountAmount { get; set; }       
    }



}
