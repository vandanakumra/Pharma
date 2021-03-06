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
    
    public partial class SupplierLedger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplierLedger()
        {
            this.SupplierCompanyDiscountRef = new HashSet<SupplierCompanyDiscountRef>();
        }
    
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
        public Nullable<decimal> OpeningBal { get; set; }
        public string CreditDebit { get; set; }
        public string TaxRetail { get; set; }
        public bool Status { get; set; }
        public int AreaId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string SupplierLedgerShortDesc { get; set; }
        public int PurchaseTypeID { get; set; }
        public string DLNo { get; set; }
        public string GSTNo { get; set; }
        public string CINNo { get; set; }
        public string LINNo { get; set; }
        public string ServiceTaxNo { get; set; }
        public string PANNo { get; set; }
    
        public virtual AccountLedgerMaster AccountLedgerMaster { get; set; }
        public virtual PersonRouteMaster PersonRouteMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierCompanyDiscountRef> SupplierCompanyDiscountRef { get; set; }
    }
}
