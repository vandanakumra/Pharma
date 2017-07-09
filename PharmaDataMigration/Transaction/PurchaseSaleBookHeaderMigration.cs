using log4net;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PharmaDataMigration.Transaction
{
    public class PurchaseSaleBookHeaderMigration
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public PurchaseSaleBookHeaderMigration()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertPurchaseSaleBookHeaderData()
        {
            try
            {
                int result = 0;
                string query = "select * from SalePur1";
                DataTable dtSalePur = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PurchaseSaleBookHeader> listPurchaseSaleBookHeader = new List<PharmaDAL.Entity.PurchaseSaleBookHeader>();
                
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtSalePur != null && dtSalePur.Rows.Count > 0)
                    {
                        var personRouteList = context.PersonRouteMaster.Select(r => r).ToList();
                        var areaList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.AREA).Select(r => r).ToList();
                        var salesmanList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.SALESMAN).Select(r => r).ToList();
                        var routeList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.ROUTE).Select(r => r).ToList();
                        var asmList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.ASM).Select(r => r).ToList();
                        var rsmList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.RSM).Select(r => r).ToList();
                        var zsmList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.ZSM).Select(r => r).ToList();

                        var customerTypeList = context.CustomerType.Select(p => p);


                        foreach (var item in Common.voucherTypeMap)
                        {
                            log.Info(string.Format("Voucher Type Map {0} --> {1}",item.OriginalVoucherType,item.MappedVoucherType));
                        }

                        foreach (DataRow dr in dtSalePur.Rows)
                        {
                            try
                            {                                
                                PharmaDAL.Entity.PurchaseSaleBookHeader newPurchaseSaleBookHeader = new PharmaDAL.Entity.PurchaseSaleBookHeader();

                                string oldVNo = Convert.ToString(dr["vno"]).TrimEnd();
                                string newVNo = (Convert.ToString(dr["vno"]).TrimEnd()).PadLeft(8, '0');

                                Common.voucherNumberMap.Add(new VoucherNumberMap() {OriginalVoucherNumber = oldVNo , MappedVoucherNumber = newVNo });

                                

                                string ledgerType = string.Empty;
                                string ledgerTypeCode = string.Empty;

                               

                                string originalVoucherTypeCode = Convert.ToString(dr["vtyp"]).TrimEnd();
                                string mappedVoucherTypeCode = Common.voucherTypeMap.Where(x => x.OriginalVoucherType == originalVoucherTypeCode).Select(x => x.MappedVoucherType).FirstOrDefault();

                                log.Info(string.Format("Under loop orginal Voucher Type Code is {0} --> {1} ",originalVoucherTypeCode,mappedVoucherTypeCode));


                                if (Convert.ToString(dr["slcd"]).TrimEnd() == "SL")
                                {
                                    ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "SL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                    ledgerTypeCode = Common.supplierLedgerCodeMap.Where(p => p.OriginalSupplierLedgerCode == Convert.ToString(dr["ACNO"]).TrimEnd()).Select(x => x.MappedSupplierLedgerCode).FirstOrDefault();
                                }
                                else if (Convert.ToString(dr["slcd"]).TrimEnd() == "CL")
                                {
                                    ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "CL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                    ledgerTypeCode = Common.customerLedgerCodeMap.Where(p => p.OriginalCustomerLedgerCode == Convert.ToString(dr["ACNO"]).TrimEnd()).Select(x => x.MappedCustomerLedgerCode).FirstOrDefault();
                                }

                                newPurchaseSaleBookHeader.VoucherTypeCode = mappedVoucherTypeCode;
                                newPurchaseSaleBookHeader.VoucherNumber = newVNo;
                                newPurchaseSaleBookHeader.VoucherDate = Convert.ToDateTime(dr["vdt"]);
                                newPurchaseSaleBookHeader.DueDate = Convert.ToDateTime(dr["DUEDT"]);
                                newPurchaseSaleBookHeader.PurchaseBillNo = Convert.ToString(dr["PBILLNO"]).TrimEnd();
                                newPurchaseSaleBookHeader.LedgerType = ledgerType;
                                newPurchaseSaleBookHeader.LedgerTypeCode = ledgerTypeCode;

                                newPurchaseSaleBookHeader.Amount01 = default(decimal);
                                newPurchaseSaleBookHeader.Amount02 = default(decimal);
                                newPurchaseSaleBookHeader.Amount03 = default(decimal);
                                newPurchaseSaleBookHeader.Amount04 = default(decimal);
                                newPurchaseSaleBookHeader.Amount05 = default(decimal);
                                newPurchaseSaleBookHeader.Amount06 = default(decimal);
                                newPurchaseSaleBookHeader.Amount07 = default(decimal);
                                newPurchaseSaleBookHeader.SGST01 = default(decimal);
                                newPurchaseSaleBookHeader.SGST02 = default(decimal);
                                newPurchaseSaleBookHeader.SGST03 = default(decimal);
                                newPurchaseSaleBookHeader.SGST04 = default(decimal);
                                newPurchaseSaleBookHeader.SGST05 = default(decimal);
                                newPurchaseSaleBookHeader.SGST06 = default(decimal);
                                newPurchaseSaleBookHeader.SGST07 = default(decimal);
                                newPurchaseSaleBookHeader.IGST01 = default(decimal);
                                newPurchaseSaleBookHeader.IGST02 = default(decimal);
                                newPurchaseSaleBookHeader.IGST03 = default(decimal);
                                newPurchaseSaleBookHeader.IGST04 = default(decimal);
                                newPurchaseSaleBookHeader.IGST05 = default(decimal);
                                newPurchaseSaleBookHeader.IGST06 = default(decimal);
                                newPurchaseSaleBookHeader.IGST07 = default(decimal);
                                newPurchaseSaleBookHeader.CGST01 = default(decimal);
                                newPurchaseSaleBookHeader.CGST02 = default(decimal);
                                newPurchaseSaleBookHeader.CGST03 = default(decimal);
                                newPurchaseSaleBookHeader.CGST04 = default(decimal);
                                newPurchaseSaleBookHeader.CGST05 = default(decimal);
                                newPurchaseSaleBookHeader.CGST06 = default(decimal);
                                newPurchaseSaleBookHeader.CGST07 = default(decimal);
                                newPurchaseSaleBookHeader.TotalTaxAmount = default(decimal);
                                newPurchaseSaleBookHeader.SurchargeAmount = default(decimal);
                                newPurchaseSaleBookHeader.TotalBillAmount = default(decimal);
                                newPurchaseSaleBookHeader.TotalCostAmount = default(decimal);
                                newPurchaseSaleBookHeader.TotalGrossAmount = default(decimal);
                                newPurchaseSaleBookHeader.TotalSchemeAmount = default(decimal);
                                newPurchaseSaleBookHeader.TotalDiscountAmount = default(decimal);
                                newPurchaseSaleBookHeader.OtherAmount = default(decimal);

                                try
                                {
                                    string areaCode = string.IsNullOrEmpty(Convert.ToString(dr["Parea"]).TrimEnd()) ? null : Common.areaCodeMap.Where(p => p.OriginalAreaCode == Convert.ToString(dr["Parea"]).TrimEnd()).FirstOrDefault().MappedAreaCode;
                                    int? areaID = areaCode == null ? (int?)null : areaList.Where(q => q.PersonRouteCode == areaCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.AreaId = areaID;
                                }
                                catch { }

                                try
                                {
                                    string salesmanCode = string.IsNullOrEmpty(Convert.ToString(dr["Sman"]).TrimEnd())
                                                        ? null : Common.salesmanCodeMap.Where(p => p.OriginalSalesManCode == Convert.ToString(dr["Sman"]).TrimEnd()).FirstOrDefault().MappedSalesManCode;
                                    int? salesmanID = salesmanCode == null ? (int?)null : salesmanList.Where(q => q.PersonRouteCode == salesmanCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.SalesManId = salesmanID;
                                }
                                catch { }

                                try
                                {
                                    string routeCode = string.IsNullOrEmpty(Convert.ToString(dr["Route"]).TrimEnd()) ? null : Common.routeCodeMap.Where(p => p.OriginalRouteCode == Convert.ToString(dr["Route"]).TrimEnd()).FirstOrDefault().MappedRouteCode;
                                    int? routeID = routeCode == null ? (int?)null : routeList.Where(q => q.PersonRouteCode == routeCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.RouteId = routeID;
                                }
                                catch { }

                                try
                                {
                                    string asmCode = string.IsNullOrEmpty(Convert.ToString(dr["Asm"]).TrimEnd()) ? null : Common.asmCodeMap.Where(p => p.OriginalASMCode == Convert.ToString(dr["Asm"]).TrimEnd()).FirstOrDefault().MappedASMCode;
                                    int? asmID = asmCode == null ? (int?)null : asmList.Where(q => q.PersonRouteCode == asmCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.ASMId = asmID;
                                }
                                catch { }

                                try
                                {
                                    string rsmCode = string.IsNullOrEmpty(Convert.ToString(dr["Rsm"]).TrimEnd()) ? null : Common.rsmCodeMap.Where(p => p.OriginalRSMCode == Convert.ToString(dr["Rsm"]).TrimEnd()).FirstOrDefault().MappedRSMCode;
                                    int? rsmID = rsmCode == null ? (int?)null : rsmList.Where(q => q.PersonRouteCode == rsmCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.RSMId = rsmID;
                                }
                                catch { }

                                try
                                {
                                    string zsmCode = string.IsNullOrEmpty(Convert.ToString(dr["Zsm"]).TrimEnd()) ? null : Common.zsmCodeMap.Where(p => p.OriginalZSMCode == Convert.ToString(dr["Zsm"]).TrimEnd()).FirstOrDefault().MappedZSMCode;
                                    int? zsmID = zsmCode == null ? (int?)null : zsmList.Where(q => q.PersonRouteCode == zsmCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.ZSMId = zsmID;
                                }
                                catch { }

                                try
                                {
                                    string customerType = Convert.ToString(dr["Wr"]).TrimEnd();
                                    int customerTypeID = customerTypeList.Where(p => p.CustomerTypeShortName == customerType).FirstOrDefault().CustomerTypeId;
                                    newPurchaseSaleBookHeader.CustomerTypeId = customerTypeID;
                                }
                                catch { }

                                try
                                {
                                    newPurchaseSaleBookHeader.RateTypeId = (int?)null;
                                }
                                catch { }


                                newPurchaseSaleBookHeader.FreshBreakageExcess = Convert.ToString(dr["FRBR"]);
                                newPurchaseSaleBookHeader.ReturnBillNo = Convert.ToString(dr["RINVNO"]);

                                if (dr["RINVDT"] != null)
                                {
                                    newPurchaseSaleBookHeader.ReturBillDate = Convert.ToDateTime(dr["RINVDT"]);
                                }

                                if (dr["SALE_LORC"] == null || string.IsNullOrEmpty(Convert.ToString(dr["SALE_LORC"])))
                                {
                                    newPurchaseSaleBookHeader.LocalCentral = "L";
                                }
                                else
                                {
                                    newPurchaseSaleBookHeader.LocalCentral = Convert.ToString(dr["SALE_LORC"]);
                                }

                                newPurchaseSaleBookHeader.OrderNumber = Convert.ToString(dr["ORDNO1"]);
                                newPurchaseSaleBookHeader.ChallanNumber = Convert.ToString(dr["CHNO1"]);
                                newPurchaseSaleBookHeader.Message = Convert.ToString(dr["MESS1"]);
                                newPurchaseSaleBookHeader.Deliveryddress = Convert.ToString(dr["DLFROM"]);
                                newPurchaseSaleBookHeader.DeliveredBy = Convert.ToString(dr["DLBY"]);
                                newPurchaseSaleBookHeader.CourierName = Convert.ToString(dr["AIRBLNO"]);

                                if (dr["AIRBLDT"] != null)
                                {
                                    newPurchaseSaleBookHeader.CourierDate = Convert.ToDateTime(dr["AIRBLDT"]);
                                }

                                newPurchaseSaleBookHeader.CourierWeight = dr["WEIGHT"] == null ? default(decimal) : Convert.ToDecimal(dr["WEIGHT"]);
                                newPurchaseSaleBookHeader.LastBalance = dr["LBAL"] == null ? default(decimal) : Convert.ToDecimal(dr["LBAL"]);

                                //newPurchaseSaleBookHeader.PurchaseSaleEntryFormID = (Convert.ToString(dr["vno"]).TrimEnd()).PadLeft(8, '0');
                              
                                newPurchaseSaleBookHeader.CreatedBy = "admin";
                                newPurchaseSaleBookHeader.CreatedOn = DateTime.Now;
                               


                                listPurchaseSaleBookHeader.Add(newPurchaseSaleBookHeader);
                            }
                            catch (Exception ex)
                            {
                                log.Info(string.Format("PurchaseSaleBookHeader: Error in Voucher Number {0}", Convert.ToString(dr["vno"]).TrimEnd()));
                            }
                        }
                    }

                    context.PurchaseSaleBookHeader.AddRange(listPurchaseSaleBookHeader);
                    result = context.SaveChanges();

                    
                }

                if(result > 0)
                {
                    FillVoucherNumberMapping();
                }

                return result;
            }
            catch (DbEntityValidationException ex)
            {
                log.Info(string.Format("PurchaseSaleBookHeader: Error {0}", ex.Message));

                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                log.Info(exceptionMessage);

                throw ex;
            }
            catch (Exception ex)
            {

                log.Info(string.Format("PurchaseSaleBookHeader: Error {0}", ex.Message));
                throw ex;
            }
        }

        private void FillVoucherNumberMapping()
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var list = context.PurchaseSaleBookHeader.Select(p => new PurchaseSaleBookHeader()
                    {
                        PurchaseSaleBookHeaderID = p.PurchaseSaleBookHeaderID,
                        VoucherNumber = p.VoucherNumber
                    }).ToList();

                    Common.voucherNumberMap.ForEach(p => p.MappedPurchaseHeaderID = list.Where(q => q.VoucherNumber == p.MappedVoucherNumber).FirstOrDefault().PurchaseSaleBookHeaderID);


                }
            }
            catch {}
        }
    }
}
