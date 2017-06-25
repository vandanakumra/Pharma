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

        private const string ORIGINAL_SLCD_CL = "CL";
        private const string ORIGINAL_SLCD_SL = "SL";

        private const string MAPPED_SLCD_CL = "CUSTOMERLEDGER";
        private const string MAPPED_SLCD_SL = "SUPPLIERLEDGER";

        public BillOutstanding()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
            FillVoucherTypeMap();
        }

        public void FillVoucherTypeMap()
        {
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "CN", MappedVoucherType = Constants.VoucherTypeCode.CREDITNOTE });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "DN", MappedVoucherType = Constants.VoucherTypeCode.DEBITNOTE });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "PB", MappedVoucherType = Constants.VoucherTypeCode.PURCHASEENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "PR", MappedVoucherType = Constants.VoucherTypeCode.PURCHASERETURN });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "SB", MappedVoucherType = Constants.VoucherTypeCode.SALEENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "S1", MappedVoucherType = Constants.VoucherTypeCode.SALEENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "SR", MappedVoucherType = Constants.VoucherTypeCode.SALERETURN });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "R1", MappedVoucherType = Constants.VoucherTypeCode.SALERETURN });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "ST", MappedVoucherType = Constants.VoucherTypeCode.STOCKADUSTMENT });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "S8", MappedVoucherType = Constants.VoucherTypeCode.SALEONCHALLAN });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "RV", MappedVoucherType = Constants.VoucherTypeCode.VOUCHERENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "PV", MappedVoucherType = Constants.VoucherTypeCode.VOUCHERENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "JV", MappedVoucherType = Constants.VoucherTypeCode.VOUCHERENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "R9", MappedVoucherType = Constants.VoucherTypeCode.SALERETURNBREAKAGEEXPIRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "RT", MappedVoucherType = Constants.VoucherTypeCode.RECEIPTFROMCUSTOMER });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "PT", MappedVoucherType = Constants.VoucherTypeCode.PAYMENTTOSUPPLIER });           
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

                                if (Convert.ToString(dr["slcd"]).TrimEnd() == ORIGINAL_SLCD_SL)
                                {
                                    ledgerType = MAPPED_SLCD_SL;
                                    ledgerTypeCode= Common.supplierLedgerCodeMap.Where(p => p.OriginalSupplierLedgerCode == Convert.ToString(dr["ACNO"]).TrimEnd()).Select(x=>x.MappedSupplierLedgerCode).FirstOrDefault();                                  
                                }
                                else
                                {
                                    ledgerType = MAPPED_SLCD_CL;
                                    ledgerTypeCode= Common.customerLedgerCodeMap.Where(p => p.OriginalCustomerLedgerCode == Convert.ToString(dr["ACNO"]).TrimEnd()).Select(x=>x.MappedCustomerLedgerCode).FirstOrDefault();
                                }

                                PharmaDAL.Entity.BillOutStandings newBillOS = new PharmaDAL.Entity.BillOutStandings()
                                {
                                    PurchaseSaleBookHeaderID= null,
                                    VoucherNumber = (Convert.ToString(dr["vno"]).TrimEnd()).PadLeft(8,'0'),
                                    VoucherTypeCode= mappedVoucherTypeCode,
                                    VoucherDate= Convert.ToDateTime(dr["vdt"]),
                                    DueDate= Convert.ToDateTime(dr["duedt"]),
                                    LedgerType = ledgerType,
                                    LedgerTypeCode= ledgerTypeCode,
                                    BillAmount=0,
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
