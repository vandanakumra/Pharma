using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class SupplierLedgerMaster
    {
        public int SupplierLedgerId { get; set; }
        public string SupplierLedgerCode { get; set; }
        public string SupplierLedgerName { get; set; }
        public string SupplierLedgerShortName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string Pager { get; set; }
        public string Fax { get; set; }
        public string OfficePhone { get; set; }
        public string ResidentPhone { get; set; }
        public string EmailAddress { get; set; }
        public decimal? OpeningBal { get; set; }
        public string CreditDebit { get; set; }
        public string TaxRetail { get; set; }
        public bool Status { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string DLNo { get; set; }
        public string TINNo { get; set; }
    }
}
