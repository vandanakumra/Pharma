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
    
    public partial class PersonalLedger
    {
        public int PersonalLedgerId { get; set; }
        public string PersonalLedgerCode { get; set; }
        public string PersonalLedgerName { get; set; }
        public string PersonalLedgerShortName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string Pager { get; set; }
        public string Fax { get; set; }
        public string OfficePhone { get; set; }
        public string ResidentPhone { get; set; }
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string PersonalLedgerShortDesc { get; set; }
    }
}
