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
    
    public partial class CustomerCompanyDiscountRef
    {
        public int CustCompDiscountRefID { get; set; }
        public int CustomerLedgerID { get; set; }
        public int CompanyID { get; set; }
        public Nullable<double> Normal { get; set; }
        public Nullable<double> Breakage { get; set; }
        public Nullable<double> Expired { get; set; }
        public bool IsLessEcise { get; set; }
    }
}
