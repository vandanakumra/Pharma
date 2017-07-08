 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;
using log4net;
using System.Reflection;
using System.Windows.Forms;
using System.Data.Entity.Validation;
using PharmaBusinessObjects.Common;

namespace PharmaDataMigration.Master
{
    public class BillOutstanding
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;        

        public BillOutstanding()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);           
        }      

        public int InsertBillOutstandingData()
        {
            try
            {
                string query = "select * from BILLOS";
                DataTable dtBillOutstanding = dbConnection.GetData(query);

                List<PharmaDAL.Entity.BillOutStandings> listBillOutstandings = new List<PharmaDAL.Entity.BillOutStandings>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtBillOutstanding != null && dtBillOutstanding.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtBillOutstanding.Rows)
                        {
                            try
                            {
                                string ledgerType = string.Empty;
                                string ledgerTypeCode = string.Empty;

                                if(string.IsNullOrWhiteSpace(Convert.ToString(dr["vno"]).TrimEnd()))
                                {
                                    throw new Exception();
                                }
                                else if(Convert.ToString(dr["vno"]).TrimEnd().Length > 8)
                                {
                                    log.Error("BillOS : VNO Length is greater than 8 -->" + Convert.ToString(dr["vno"]).TrimEnd());
                                    throw new Exception();
                                }

                                string originalVoucherTypeCode = Convert.ToString(dr["vtyp"]).TrimEnd();
                                string mappedVoucherTypeCode = Common.voucherTypeMap.Where(x => x.OriginalVoucherType == originalVoucherTypeCode).Select(x => x.MappedVoucherType).FirstOrDefault();

                                if (Convert.ToString(dr["slcd"]).TrimEnd() == "SL")
                                {
                                    ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "SL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                    ledgerTypeCode= Common.supplierLedgerCodeMap.Where(p => p.OriginalSupplierLedgerCode == Convert.ToString(dr["ACNO"]).TrimEnd()).Select(x=>x.MappedSupplierLedgerCode).FirstOrDefault();                                  
                                }
                                else if (Convert.ToString(dr["slcd"]).TrimEnd() == "CL")
                                {
                                    ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "CL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                    ledgerTypeCode = Common.customerLedgerCodeMap.Where(p => p.OriginalCustomerLedgerCode == Convert.ToString(dr["ACNO"]).TrimEnd()).Select(x=>x.MappedCustomerLedgerCode).FirstOrDefault();
                                }

                                string oldVNo = Convert.ToString(dr["vno"]).TrimEnd();
                                var header = Common.voucherNumberMap.Where(p => p.OriginalVoucherNumber == oldVNo).FirstOrDefault();

                                PharmaDAL.Entity.BillOutStandings newBillOS = new PharmaDAL.Entity.BillOutStandings()
                                {
                                    //PurchaseSaleBookHeaderID= header.MappedPurchaseHeaderID,
                                    VoucherNumber = Convert.ToString(dr["vno"]).TrimEnd(),//header.MappedVoucherNumber,
                                    VoucherTypeCode= mappedVoucherTypeCode,
                                    VoucherDate= Convert.ToDateTime(dr["vdt"]),
                                    DueDate= Convert.ToDateTime(dr["duedt"]),
                                    LedgerType = ledgerType,
                                    LedgerTypeCode= ledgerTypeCode,
                                    BillAmount= Convert.ToDecimal(dr["osamt"]),
                                    OSAmount= Convert.ToDecimal(dr["osamt"]),
                                    IsHold= Convert.ToString(dr["vno"]).TrimEnd()=="Y" ? true :false,
                                    HOLDRemarks=null
                                };

                                listBillOutstandings.Add(newBillOS);
                            }
                            catch (Exception)
                            {
                                log.Info(string.Format("BILL OUTSTANDING: Error in Voucher Number {0}", Convert.ToString(dr["vno"]).TrimEnd()));
                            }
                        }
                    }

                    context.BillOutStandings.AddRange(listBillOutstandings);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
