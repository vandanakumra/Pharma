using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;

namespace PharmaDataMigration.Master
{
    public class CustomerLedgerMaster
    {
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
                        foreach (DataRow dr in dtCustomerLedgerMaster.Rows)
                        {
                            maxCustomerLedgerID++;

                            string customerLedgerCode = "C" + maxCustomerLedgerID.ToString().PadLeft(6, '0');
                            string originalCustomerLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            Common.customerLedgerCodeMap.Add(new CustomerLedgerCodeMap() { OriginalCustomerLedgerCode = originalCustomerLedgerCode, MappedCustomerLedgerCode = customerLedgerCode });

                            string areaCode = Common.areaCodeMap.Where(p => p.OriginalAreaCode == Convert.ToString(dr["Parea"]).TrimEnd()).FirstOrDefault().MappedAreaCode;
                            int areaID = context.PersonRouteMaster.Where(q => q.PersonRouteCode == areaCode).FirstOrDefault().PersonRouteID;

                            string salesmanCode = Common.salesmanCodeMap.Where(p => p.OriginalSalesManCode == Convert.ToString(dr["Sman"]).TrimEnd()).FirstOrDefault().MappedSalesManCode;
                            int salesmanID = context.PersonRouteMaster.Where(q => q.PersonRouteCode == salesmanCode).FirstOrDefault().PersonRouteID;

                            string routeCode = Common.routeCodeMap.Where(p => p.OriginalRouteCode == Convert.ToString(dr["Route"]).TrimEnd()).FirstOrDefault().MappedRouteCode;
                            int routeID = context.PersonRouteMaster.Where(q => q.PersonRouteCode == routeCode).FirstOrDefault().PersonRouteID;

                            string asmCode = Common.asmCodeMap.Where(p => p.OriginalASMCode == Convert.ToString(dr["Asm"]).TrimEnd()).FirstOrDefault().MappedASMCode;
                            int asmID = context.PersonRouteMaster.Where(q => q.PersonRouteCode == asmCode).FirstOrDefault().PersonRouteID;

                            string rsmCode = Common.rsmCodeMap.Where(p => p.OriginalRSMCode == Convert.ToString(dr["Rsm"]).TrimEnd()).FirstOrDefault().MappedRSMCode;
                            int rsmID = context.PersonRouteMaster.Where(q => q.PersonRouteCode == rsmCode).FirstOrDefault().PersonRouteID;

                            string zsmCode = Common.zsmCodeMap.Where(p => p.OriginalZSMCode == Convert.ToString(dr["Zsm"]).TrimEnd()).FirstOrDefault().MappedZSMCode;
                            int zsmID = context.PersonRouteMaster.Where(q => q.PersonRouteCode == zsmCode).FirstOrDefault().PersonRouteID;

                            string customerType = Convert.ToString(dr["Wr"]).TrimEnd();
                            int customerTypeID = context.CustomerType.Where(p => p.CustomerTypeShortName == customerType).FirstOrDefault().CustomerTypeId;

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
                                CreditDebit = Convert.ToDouble(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                DLNo = Convert.ToString(dr["DRNO"]).TrimEnd(), //confirm
                                GSTNo = Convert.ToString(dr["Stnoc"]).TrimEnd(), //confirm
                                CINNo = Convert.ToString(dr["Stnoc"]).TrimEnd(), //confirm
                                LINNo = Convert.ToString(dr["Stnol"]).TrimEnd(), //confirm
                                ServiceTaxNo = Convert.ToString(dr["Stnol"]).TrimEnd(), //confirm
                                PANNo = Convert.ToString(dr["Stnol"]).TrimEnd(), //confirm
                                OpeningBal = Convert.ToDecimal(dr["Abop"]),
                                TaxRetail = Convert.ToString(dr["Vat"]).TrimEnd(),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                ASMId = asmID,
                                CreditLimit = Convert.ToInt32(dr["Cr_limit"]),
                                CustomerTypeID = customerTypeID,
                                InterestTypeID = 1, //Convert.ToString(dr["ACNO"]).TrimEnd(), confirm
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
                                CentralLocal = "Local",//Convert.ToString(dr["ACNO"]).TrimEnd(),
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now
                            };

                            listCustomerLedgerMaster.Add(newCustomerLedgerMaster);
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
                string query = "select * from DIS";

                DataTable dtCustomerCompanyRef = dbConnection.GetData(query);

                List<CustomerCompanyDiscountRef> listCustomerCompanyRef = new List<CustomerCompanyDiscountRef>();

                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtCustomerCompanyRef != null && dtCustomerCompanyRef.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtCustomerCompanyRef.Rows)
                        {
                            string customerLedgerCode = Common.customerLedgerCodeMap.Where(p => p.OriginalCustomerLedgerCode == Convert.ToString(dr["PCode"]).TrimEnd()).FirstOrDefault().MappedCustomerLedgerCode;
                            int customerLedgerID = context.CustomerLedger.Where(p => p.CustomerLedgerCode == customerLedgerCode).FirstOrDefault().CustomerLedgerId;

                            string companyCode = Common.companyCodeMap.Where(p => p.OriginalCompanyCode == Convert.ToString(dr["Ccode"]).TrimEnd()).FirstOrDefault().MappedCompanyCode;
                            int companyID = context.CompanyMaster.Where(p => p.CompanyCode == companyCode).FirstOrDefault().CompanyId;

                            string itemCode = Common.itemCodeMap.Where(p => p.OriginalItemCode == Convert.ToString(dr["ICode"]).TrimEnd()).FirstOrDefault().MappedItemCode;
                            int itemID = context.ItemMaster.Where(p => p.ItemCode == itemCode).FirstOrDefault().ItemID;

                            CustomerCompanyDiscountRef newCustomerCompanyRef = new CustomerCompanyDiscountRef()
                            {
                                CustomerLedgerID = customerLedgerID,
                                CompanyID = companyID,
                                ItemID = itemID,
                                Normal = Convert.ToDouble(dr["Disamt"]),
                                Breakage = Convert.ToDouble(dr["Disamtbe"]),
                                Expired = Convert.ToDouble(dr["Disamtex"]),
                                IsLessEcise = Convert.ToChar(dr["Less_ex"]) == 'Y' ? true : false
                            };

                            listCustomerCompanyRef.Add(newCustomerCompanyRef);
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
