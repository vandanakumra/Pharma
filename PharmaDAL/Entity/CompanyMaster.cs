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
    
    public partial class CompanyMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyMaster()
        {
            this.CustomerCompanyDiscountRef = new HashSet<CustomerCompanyDiscountRef>();
            this.ItemMaster = new HashSet<ItemMaster>();
            this.SupplierCompanyDiscountRef = new HashSet<SupplierCompanyDiscountRef>();
        }
    
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public bool Status { get; set; }
        public bool IsDirect { get; set; }
        public int OrderPreferenceRating { get; set; }
        public int BillingPreferenceRating { get; set; }
        public bool StockSummaryRequired { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerCompanyDiscountRef> CustomerCompanyDiscountRef { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMaster> ItemMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierCompanyDiscountRef> SupplierCompanyDiscountRef { get; set; }
    }
}
