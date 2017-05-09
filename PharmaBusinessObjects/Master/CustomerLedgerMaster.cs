﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class CustomerLedgerMaster
    {
        public int CustomerLedgerId { get; set; }
        public string CustomerLedgerCode { get; set; }
        public string CustomerLedgerName { get; set; }
        public string CustomerLedgerShortName { get; set; }
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
        public int ZSMId { get; set; }
        public string ZSMName { get; set; }
        public int ASMId { get; set; }
        public string ASMName { get; set; }
        public int RSMId { get; set; }
        public string RSMName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int SalesManId { get; set; }
        public string SalesmanName { get; set; }
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string DLNo { get; set; }
        public string TINNo { get; set; }
        public string CSTNo { get; set; }
        public string Day { get; set; }
        public int CreditLimit { get; set; }
        public string BankName { get; set; }
        public string BankArea { get; set; }
        public string CloseDay { get; set; }
        public int? RateTypeID { get; set; }
        public string RateTypeName { get; set; }
        public bool IsLessExcise { get; set; }
        public int CustomerTypeID { get; set; }
        public string CustomerTypeName { get; set; }
        public int InterestTypeID { get; set; }
        public string InterestTypeName { get; set; }
    }
}