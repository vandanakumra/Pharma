using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDataMigration
{
    public class Common
    {
        public static PharmaBusinessObjects.Master.UserMaster LoggedInUser;
        public static string DataDirectory;// = @"F:\PHARMA\DATA\";
        public static List<CompanyCodeMap> companyCodeMap;
        public static List<ItemCodeMap> itemCodeMap;
        public static List<PersonalLedgerCodeMap> personalLedgerCodeMap;
        public static List<ControlCodeMap> controlCodeMap;
        public static List<AccountLedgerCodeMap> accountLedgerCodeMap;
    }

    public class CompanyCodeMap
    {
        public string OriginalCompanyCode { get; set; }
        public string MappedCompanyCode { get; set; }
    }

    public class ItemCodeMap
    {
        public string OriginalItemCode { get; set; }
        public string MappedItemCode { get; set; }
    }

    public class PersonalLedgerCodeMap
    {
        public string OriginalPersonalLedgerCode { get; set; }
        public string MappedPersonalLedgerCode { get; set; }
    }

    public class ControlCodeMap
    {
        public string OriginalControlCode { get; set; }
        public string MappedControlCode { get; set; }
    }

    public class AccountLedgerCodeMap
    {
        public string OriginalAccountLedgerCode { get; set; }
        public string MappedAccountLedgerCode { get; set; }
        public int AccountLedgerTypeID { get; set; }
    }
}
