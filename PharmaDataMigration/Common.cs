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
        public static List<ASMCodeMap> asmCodeMap;
        public static List<RSMCodeMap> rsmCodeMap;
        public static List<ZSMCodeMap> zsmCodeMap;
        public static List<SalesManCodeMap> salesmanCodeMap;
        public static List<AreaCodeMap> areaCodeMap;
        public static List<RouteCodeMap> routeCodeMap;
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

    public class ASMCodeMap
    {
        public string OriginalASMCode { get; set; }
        public string MappedASMCode { get; set; }
    }

    public class RSMCodeMap
    {
        public string OriginalRSMCode { get; set; }
        public string MappedRSMCode { get; set; }
    }

    public class ZSMCodeMap
    {
        public string OriginalZSMCode { get; set; }
        public string MappedZSMCode { get; set; }
    }

    public class SalesManCodeMap
    {
        public string OriginalSalesManCode { get; set; }
        public string MappedSalesManCode { get; set; }
    }

    public class AreaCodeMap
    {
        public string OriginalAreaCode { get; set; }
        public string MappedAreaCode { get; set; }
    }

    public class RouteCodeMap
    {
        public string OriginalRouteCode { get; set; }
        public string MappedRouteCode { get; set; }
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
