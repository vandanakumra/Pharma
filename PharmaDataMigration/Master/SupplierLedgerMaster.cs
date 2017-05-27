using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;

namespace PharmaDataMigration.Master
{
    public class SupplierLedgerMaster
    {
        private DBFConnectionManager dbConnection;

        public SupplierLedgerMaster()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertSupplierLedgerMasterData()
        {
            try
            {
                string query = "select * from ACM where slcd = 'SL'";

                DataTable dtSupplierLedgerMaster = dbConnection.GetData(query);

                List<SupplierLedger> listSupplierLedgerMaster = new List<SupplierLedger>();

                int _result = 0;
                                
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxSupplierLedgerID = context.SupplierLedger.Count();

                    if (dtSupplierLedgerMaster != null && dtSupplierLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtSupplierLedgerMaster.Rows)
                        {
                            maxSupplierLedgerID++;

                            string supplierLedgerCode = "S" + maxSupplierLedgerID.ToString().PadLeft(6, '0');
                            string originalSupplierLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            Common.supplierLedgerCodeMap.Add(new SupplierLedgerCodeMap() { OriginalSupplierLedgerCode = originalSupplierLedgerCode, MappedSupplierLedgerCode = supplierLedgerCode });

                            string areaCode = Common.areaCodeMap.Where(p => p.OriginalAreaCode == Convert.ToString(dr["PAREA"]).TrimEnd()).FirstOrDefault().MappedAreaCode;
                            int areaID = context.PersonRouteMaster.Where(q => q.PersonRouteCode == areaCode).FirstOrDefault().PersonRouteID;
                            string purchaseLedgerCode = Common.accountLedgerCodeMap.Where(q => q.OriginalAccountLedgerCode == Convert.ToString(dr["PCODE"]).TrimEnd()).FirstOrDefault().MappedAccountLedgerCode;
                            int purchaseTypeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == purchaseLedgerCode).FirstOrDefault().AccountLedgerID;

                            SupplierLedger newSupplierLedgerMaster = new SupplierLedger()
                            {
                                SupplierLedgerCode = supplierLedgerCode,
                                SupplierLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                SupplierLedgerShortName = Convert.ToString(dr["Alt_name_1"]).TrimEnd(),
                                SupplierLedgerShortDesc = Convert.ToString(dr["Alt_name_2"]).TrimEnd(),
                                Address = string.Concat(Convert.ToString(dr["ACAD1"]).TrimEnd(), " ", Convert.ToString(dr["ACAD2"]).TrimEnd(), " ", Convert.ToString(dr["ACAD3"]).TrimEnd()),
                                ContactPerson = Convert.ToString(dr["ACAD4"]).TrimEnd(),
                                Mobile = Convert.ToString(dr["Mobile"]).TrimEnd(),
                                //Pager = Convert.ToString(dr["Pager"]).TrimEnd(),
                                //Fax = Convert.ToString(dr["Fax"]).TrimEnd(),
                                OfficePhone = Convert.ToString(dr["Telo"]).TrimEnd(),
                                ResidentPhone = Convert.ToString(dr["Telr"]).TrimEnd(),
                                EmailAddress = Convert.ToString(dr["Email"]).TrimEnd(),
                                AreaId = areaID,
                                CreditDebit = Convert.ToDouble(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                DLNo = Convert.ToString(dr["Stnol"]).TrimEnd(),
                                OpeningBal = Convert.ToDecimal(dr["Abop"]),
                                TaxRetail = Convert.ToString(dr["Vat"]).TrimEnd(),
                                TINNo = Convert.ToString(dr["Drno"]).TrimEnd(),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                PurchaseTypeID = purchaseTypeID,
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now
                            };

                            listSupplierLedgerMaster.Add(newSupplierLedgerMaster);
                        }
                    }

                    context.SupplierLedger.AddRange(listSupplierLedgerMaster);
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
