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
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public int Scheme1 { get; set; }
        public int Scheme2 { get; set; }
        public decimal MRP { get; set; }
        public bool IsHalfScheme { get; set; }
        public int Quantity { get; set; }
        public string BatchNumber { get; set; }

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
            MRP = 0M;
            Scheme1 = 0;
            Scheme2 = 0;
            Amount = 0M;
            Rate = 0M;
        }
    }
}
