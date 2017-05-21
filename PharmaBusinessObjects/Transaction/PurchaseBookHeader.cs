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
    }
}
