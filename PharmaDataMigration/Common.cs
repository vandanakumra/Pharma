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
}
