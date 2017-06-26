using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;
using log4net;
using System.Reflection;

namespace PharmaDataMigration.Master
{
    public class CustomerLedgerMaster
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public CustomerLedgerMaster()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertCustomerLedgerMasterData()
        {
            try
            {
                string query = "select * from ACM where slcd = 'CL'";

                DataTable dtCustomerLedgerMaster = dbConnection.GetData(query);

                List<CustomerLedger> listCustomerLedgerMaster = new List<CustomerLedger>();

                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxCustomerLedgerID = context.CustomerLedger.Count();

                    if (dtCustomerLedgerMaster != null && dtCustomerLedgerMaster.Rows.Count > 0)
                    {
                        var personRouteList = context.PersonRouteMaster.Select(r => r).ToList();
                        var areaList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.AREA).Select(r => r).ToList();
                        var salesmanList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.SALESMAN).Select(r => r).ToList();
                        var routeList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.ROUTE).Select(r => r).ToList();
                        var asmList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.ASM).Select(r => r).ToList();
                        var rsmList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.RSM).Select(r => r).ToList();
                        var zsmList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.ZSM).Select(r => r).ToList();

                        var customerTypeList = context.CustomerType.Select(p => p);

                        foreach (DataRow dr in dtCustomerLedgerMaster.Rows)
                        {
                            try
                            {
                                maxCustomerLedgerID++;

                                string customerLedgerCode = "C" + maxCustomerLedgerID.ToString().PadLeft(6, '0');
                                string originalCustomerLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                                Common.customerLedgerCodeMap.Add(new CustomerLedgerCodeMap() { OriginalCustomerLedgerCode = originalCustomerLedgerCode, MappedCustomerLedgerCode = customerLedgerCode });

                                string areaCode = string.IsNullOrEmpty(Convert.ToString(dr["Parea"]).TrimEnd()) ? null : Common.areaCodeMap.Where(p => p.OriginalAreaCode == Convert.ToString(dr["Parea"]).TrimEnd()).FirstOrDefault().MappedAreaCode;
                                int? areaID = areaCode == null ? (int?)null : areaList.Where(q => q.PersonRouteCode == areaCode).FirstOrDefault().PersonRouteID;

                                string salesmanCode = string.IsNullOrEmpty(Convert.ToString(dr["Sman"]).TrimEnd())
                                                        || Convert.ToString(dr["Sman"]).TrimEnd() == "020" //this value is not present in MASTERS as Salesman Code
                                                        ? null : Common.salesmanCodeMap.Where(p => p.OriginalSalesManCode == Convert.ToString(dr["Sman"]).TrimEnd()).FirstOrDefault().MappedSalesManCode;
                                int? salesmanID = salesmanCode == null ? (int?)null : salesmanList.Where(q => q.PersonRouteCode == salesmanCode).FirstOrDefault().PersonRouteID;

                                string routeCode = string.IsNullOrEmpty(Convert.ToString(dr["Route"]).TrimEnd()) ? null : Common.routeCodeMap.Where(p => p.OriginalRouteCode == Convert.ToString(dr["Route"]).TrimEnd()).FirstOrDefault().MappedRouteCode;
                                int? routeID = routeCode == null ? (int?)null : routeList.Where(q => q.PersonRouteCode == routeCode).FirstOrDefault().PersonRouteID;

                                string asmCode = string.IsNullOrEmpty(Convert.ToString(dr["Asm"]).TrimEnd()) ? null : Common.asmCodeMap.Where(p => p.OriginalASMCode == Convert.ToString(dr["Asm"]).TrimEnd()).FirstOrDefault().MappedASMCode;
                                int? asmID = asmCode == null ? (int?)null : asmList.Where(q => q.PersonRouteCode == asmCode).FirstOrDefault().PersonRouteID;

                                string rsmCode = string.IsNullOrEmpty(Convert.ToString(dr["Rsm"]).TrimEnd()) ? null : Common.rsmCodeMap.Where(p => p.OriginalRSMCode == Convert.ToString(dr["Rsm"]).TrimEnd()).FirstOrDefault().MappedRSMCode;
                                int? rsmID = rsmCode == null ? (int?)null : rsmList.Where(q => q.PersonRouteCode == rsmCode).FirstOrDefault().PersonRouteID;

                                string zsmCode = string.IsNullOrEmpty(Convert.ToString(dr["Zsm"]).TrimEnd()) ? null : Common.zsmCodeMap.Where(p => p.OriginalZSMCode == Convert.ToString(dr["Zsm"]).TrimEnd()).FirstOrDefault().MappedZSMCode;
                                int? zsmID = zsmCode == null ? (int?)null : zsmList.Where(q => q.PersonRouteCode == zsmCode).FirstOrDefault().PersonRouteID;

                                string customerType = Convert.ToString(dr["Wr"]).TrimEnd();
                                int customerTypeID = customerTypeList.Where(p => p.CustomerTypeShortName == customerType).FirstOrDefault().CustomerTypeId;

                                CustomerLedger newCustomerLedgerMaster = new CustomerLedger()
                                {
                                    CustomerLedgerCode = customerLedgerCode,
                                    CustomerLedgerName = Convert.ToString(dr["ACNAME"]).TrimEnd(),
                                    CustomerLedgerShortName = Convert.ToString(dr["Alt_Name_1"]).TrimEnd(),
                                    CustomerLedgerShortDesc = Convert.ToString(dr["Alt_Name_2"]).TrimEnd(),
                                    Address = string.Concat(Convert.ToString(dr["ACAD1"]).TrimEnd(), " ", Convert.ToString(dr["ACAD2"]).TrimEnd(), " ", Convert.ToString(dr["ACAD3"]).TrimEnd()),
                                    ContactPerson = Convert.ToString(dr["ACAD4"]).TrimEnd(),
                                    Mobile = Convert.ToString(dr["Mobile"]).TrimEnd(),
                                    OfficePhone = Convert.ToString(dr["Telo"]).TrimEnd(),
                                    ResidentPhone = Convert.ToString(dr["Telr"]).TrimEnd(),
                                    EmailAddress = Convert.ToString(dr["Email"]).TrimEnd(),
                                    AreaId = areaID,
                                    CreditDebit = Convert.ToDecimal(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                    DLNo = "test", //Convert.ToString(dr["DRNO"]).TrimEnd(), //confirm -> increase size more than 20
                                    GSTNo = "test", //Convert.ToString(dr["Stnoc"]).TrimEnd() -> confirm
                                    CINNo = "test", //Convert.ToString(dr["Stnoc"]).TrimEnd() -> confirm
                                    LINNo = "test", //Convert.ToString(dr["Stnol"]).TrimEnd(), //confirm
                                    ServiceTaxNo = "test",//Convert.ToString(dr["Stnol"]).TrimEnd() -> //confirm
                                    PANNo = "test", //Convert.ToString(dr["Stnol"]).TrimEnd() -> confirm
                                    OpeningBal = Convert.ToDecimal(dr["Abop"]),
                                    TaxRetail = Convert.ToString(dr["Vat"]).TrimEnd(), // Remove
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    ASMId = asmID,
                                    CreditLimit = Convert.ToInt32(dr["Cr_limit"]),
                                    CustomerTypeID = customerTypeID,
                                    InterestTypeID = 1, //Convert.ToString(dr["ACNO"]).TrimEnd(), confirm  SBType
                                    IsLessExcise = Convert.ToChar(dr["Less_ex"]) == 'Y' ? true : false,
                                    RateTypeID = 1, //Convert.ToString(dr["ACNO"]).TrimEnd(), confirm
                                    RouteId = routeID,
                                    RSMId = rsmID,
                                    SalesManId = salesmanID,
                                    ZSMId = zsmID,
                                    SaleBillFormat = Convert.ToString(dr["Sb_format"]).TrimEnd(),
                                    MaxOSAmount = Convert.ToInt32(dr["Max_os_a"]),
                                    MaxNumOfOSBill = Convert.ToInt32(dr["Max_os_n"]),
                                    MaxBillAmount = Convert.ToInt32(dr["Max_bill_a"]),
                                    MaxGracePeriod = Convert.ToInt32(dr["Grace_days"]),
                                    IsFollowConditionStrictly = Convert.ToChar(dr["Validate"]) == 'Y' ? true : false,
                                    Discount = 0,//Convert.ToString(dr["ACNO"]).TrimEnd(),
                                    CentralLocal = "C",//Convert.ToString(dr["ACNO"]).TrimEnd(), //LC
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now
                                };

                                listCustomerLedgerMaster.Add(newCustomerLedgerMaster);

                            }
                            catch (Exception)
                            {
                                log.Info("CUSTOMER LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).TrimEnd());
                            }
                        }
                    }

                    context.CustomerLedger.AddRange(listCustomerLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertCustomerCompanyReferenceData()
        {
            try
            {
                //string query = "select * from DIS where Icode not in (select distinct acno from masters where slcd = 'IT') and Ccode not in (select distinct acno from masters where slcd = 'CO')";
                string query = "select * from DIS WHERE Disamt > 0";

                DataTable dtCustomerCompanyRef = dbConnection.GetData(query);

                List<CustomerCompanyDiscountRef> listCustomerCompanyRef = new List<CustomerCompanyDiscountRef>();

                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtCustomerCompanyRef != null && dtCustomerCompanyRef.Rows.Count > 0)
                    {
                        var companyList = context.CompanyMaster.Select(p => p).ToList();
                        var customerLedgerList = context.CustomerLedger.Select(p => p).ToList();
                        var itemList = context.ItemMaster.Select(p => p).ToList();

                        foreach (DataRow dr in dtCustomerCompanyRef.Rows)
                        {
                            try
                            {
                                if (dr["Disamt"] != null && Convert.ToDecimal(dr["Disamt"]) > 0)
                                {

                                    string customerLedgerCode = Common.customerLedgerCodeMap.Where(p => p.OriginalCustomerLedgerCode == Convert.ToString(dr["PCode"]).TrimEnd()).FirstOrDefault().MappedCustomerLedgerCode;
                                    int customerLedgerID = customerLedgerList.Where(p => p.CustomerLedgerCode == customerLedgerCode).FirstOrDefault().CustomerLedgerId;
                                    string companyCode = string.Empty;

                                    var company = Common.companyCodeMap.Where(p => p.OriginalCompanyCode == Convert.ToString(dr["Ccode"]).TrimEnd()).FirstOrDefault();

                                    if (company == null)
                                    {
                                        continue;
                                    }

                                    companyCode = company.MappedCompanyCode;
                                    int companyID = companyList.Where(p => p.CompanyCode == companyCode).FirstOrDefault().CompanyId;

                                    string itemCode = string.IsNullOrEmpty(Convert.ToString(dr["ICode"]).TrimEnd()) ? null : Common.itemCodeMap.Where(p => p.OriginalItemCode == Convert.ToString(dr["ICode"]).TrimEnd()).FirstOrDefault().MappedItemCode;
                                    int? itemID = itemCode == null ? (int?)null : itemList.Where(p => p.ItemCode == itemCode).FirstOrDefault().ItemID;


                                    CustomerCompanyDiscountRef newCustomerCompanyRef = new CustomerCompanyDiscountRef()
                                    {
                                        CustomerLedgerID = customerLedgerID,
                                        CompanyID = companyID,
                                        ItemID = itemID,
                                        Normal = Convert.ToDecimal(dr["Disamt"]),
                                        Breakage = Convert.ToDecimal(dr["Disamtbe"]),
                                        Expired = Convert.ToDecimal(dr["Disamtex"]),
                                        IsLessEcise = Convert.ToString(dr["Less_ex"]) == "Y" ? true : false
                                    };

                                    listCustomerCompanyRef.Add(newCustomerCompanyRef);
                                }
                            }
                            catch (Exception)
                            {
                                //log.Info("ITEM MASTER : Error in ACName --> " + Convert.ToString(dr["ACName"]).TrimEnd());
                            }
                        }
                    }

                    context.CustomerCompanyDiscountRef.AddRange(listCustomerCompanyRef);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
