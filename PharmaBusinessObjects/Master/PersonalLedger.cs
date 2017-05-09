﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class PersonalLedger
    {
        public int PersonalLedgerId { get; set; }
        public string PersonalLedgerCode { get; set; }
        public string PersonalLedgerName { get; set; }
        public string PersonalLedgerShortName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public int? Mobile { get; set; }
        public int? Pager { get; set; }
        public int? Fax { get; set; }
        public string OfficePhone { get; set; }
        public string ResidentPhone { get; set; }
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
    }
}
