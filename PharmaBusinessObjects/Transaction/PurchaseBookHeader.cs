using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction
{
    public class PurchaseBookHeader : BaseBusinessObjects
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SupplierCode { get; set; }
        public int PurchaseFormTypeID { get; set; }
        public List<PurchaseBookAmount> PurchaseAmountList { get; set; }
        public double ExemptedAmount { get; set; }
        public double OtherAmount { get; set; }
        public double InvoiceAmount { get; set; }
        public string Narration1 { get; set; }
        public string Narration2 { get; set; }
    }

    public class PurchaseBookAmount : BaseBusinessObjects
    {
        public int PurchaseBookHeaderID { get; set; }
        public string PurchaseTaxType { get; set; }
        public double Amount { get; set; }
        public double TaxOnPurchase { get; set; }
    }
}
