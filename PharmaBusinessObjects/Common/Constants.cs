using System;
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
        }

        public static class RecordType
        {
            public const string ASM = "ASM";
            public const string RSM = "RSM";
            public const string ZSM = "ZSM";
            public const string SALESMAN = "SALESMAN";
            public const string AREA = "AREA";
            public const string ROUTE = "ROUTE";
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
