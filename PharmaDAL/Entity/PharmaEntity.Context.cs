﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PharmaDBEntities : DbContext
    {
        public PharmaDBEntities()
            : base("name=PharmaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountLedgerMaster> AccountLedgerMaster { get; set; }
        public virtual DbSet<AccountLedgerType> AccountLedgerType { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<AuditHistory> AuditHistory { get; set; }
        public virtual DbSet<CompanyMaster> CompanyMaster { get; set; }
        public virtual DbSet<CustomerCompanyDiscountRef> CustomerCompanyDiscountRef { get; set; }
        public virtual DbSet<CustomerLedger> CustomerLedger { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<InterestType> InterestType { get; set; }
        public virtual DbSet<ItemMaster> ItemMaster { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<PersonalLedger> PersonalLedger { get; set; }
        public virtual DbSet<PersonLedgerType> PersonLedgerType { get; set; }
        public virtual DbSet<PersonRouteMaster> PersonRouteMaster { get; set; }
        public virtual DbSet<Privledges> Privledges { get; set; }
        public virtual DbSet<PurchaseBookHeader> PurchaseBookHeader { get; set; }
        public virtual DbSet<PurchaseBookLineItem> PurchaseBookLineItem { get; set; }
        public virtual DbSet<PurchaseEntryForm> PurchaseEntryForm { get; set; }
        public virtual DbSet<PurchaseEntryType> PurchaseEntryType { get; set; }
        public virtual DbSet<RecordType> RecordType { get; set; }
        public virtual DbSet<RolePrivledges> RolePrivledges { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SupplierLedger> SupplierLedger { get; set; }
        public virtual DbSet<TempPurchaseBookHeader> TempPurchaseBookHeader { get; set; }
        public virtual DbSet<TempPurchaseBookLineItem> TempPurchaseBookLineItem { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
