﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Common
{
    public static class Constants
    {
        public static class Messages
        {
            public const string RequiredField = "Field is Required";
            public const string DeletePrompt = "Do you want to delete ?";
            public const string Confirmation = "Confirmation";
            public const string InValidEmail = "Please enter valid EmailId";
            public const string ErrorOccured = "Something went wrong";
            public const string PersonRouteCreate = "{0} does not exist. Do you want to add new {0} ?";
        }

        public static class RecordType
        {
            public const string ASM = "ASM";
            public const string RSM = "RSM";
            public const string ZSM = "ZSM";
            public const string SALESMAN = "SALESMAN";
            public const string AREA = "AREA";
            public const string ROUTE = "ROUTE";
            public const string NONE = "NONE";

            public const string ASMDISPLAYNAME = "A.S.M";
            public const string RSMDISPLAYNAME = "R.S.M";
            public const string ZSMDISPLAYNAME = "Z.S.M";
            public const string SALESMANDISPLAYNAME = "Sales Man";
            public const string AREADISPLAYNAME = "Area";
            public const string ROUTEDISPLAYNAME = "Route";
            public const string NONEDISPLAYNAME = "NONE";
        }

        public static class AccountLedgerType
        {
            public const string IncomeLedger = "IncomeLedger";
            public const string ExpenditureLedger = "ExpenditureLedger";
            public const string TransactionBooks = "TransactionBooks";
            public const string GeneralLedger = "GeneralLedger";
            public const string PurchaseLedger = "PurchaseLedger";
            public const string SaleLedger = "SaleLedger";
            public const string ControlCodes = "ControlCodes";
        }
        }
}
