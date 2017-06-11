using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Transaction
{
    public class ReceiptPaymentDao : BaseDao
    {
        public ReceiptPaymentDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public long InsertUpdateTempReceiptPayment(PharmaBusinessObjects.Transaction.ReceiptPayment.ReceiptPaymentItem receiptPayment)
        {
            try
            {
                long receiptPaymentID = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var receiptPaymentDB = context.TempReceiptPayment.Where(x => x.ReceiptPaymentID == receiptPayment.ReceiptPaymentID).FirstOrDefault();

                    if (receiptPaymentDB != null)
                    {                       
                        receiptPaymentDB.PaymentMode = receiptPayment.PaymentMode;
                        receiptPaymentDB.Ammount = receiptPayment.Amount;
                        receiptPaymentDB.BankAccountLedgerTypeCode = receiptPayment.BankAccountLedgerTypeCode;
                        receiptPaymentDB.ChequeNumber = receiptPayment.ChequeNumber;
                        receiptPaymentDB.ChequeDate = receiptPayment.ChequeDate;
                        receiptPaymentDB.UnadjustedAmount = receiptPayment.UnadjustedAmount;
                        context.SaveChanges();
                        receiptPaymentID = receiptPaymentDB.ReceiptPaymentID;
                    }
                    else
                    {
                        Entity.TempReceiptPayment receiptPaymentDBEntry = new Entity.TempReceiptPayment()
                        {
                            VoucherNumber="TPVOCHER",
                            VoucherTypeCode = receiptPayment.VoucherTypeCode,
                            VoucherDate = receiptPayment.VoucherDate,
                            LedgerType = receiptPayment.LedgerType,
                            LedgerTypeCode = receiptPayment.LedgerTypeCode,
                            PaymentMode=receiptPayment.PaymentMode,
                            BankAccountLedgerTypeCode = receiptPayment.BankAccountLedgerTypeCode
                        };

                        context.TempReceiptPayment.Add(receiptPaymentDBEntry);
                        context.SaveChanges();
                        receiptPaymentID = receiptPaymentDBEntry.ReceiptPaymentID;
                    }
                }
                return receiptPaymentID;
            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }
        }

        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> GetAllBillOutstandingForLedger(PharmaBusinessObjects.Transaction.TransactionEntity entity)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.BillOutStandings.Where(q=>q.LedgerType== entity.EntityType 
                                                            && q.LedgerTypeCode == entity.EntityCode
                                                            && q.OSAmount > 0)
                .Select(p => new PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding()
                {
                                BillOutStandingsID = p.BillOutStandingsID,
                                PurchaseSaleBookHeaderID = p.PurchaseSaleBookHeaderID,
                                VoucherNumber = p.VoucherNumber,
                                VoucherTypeCode = p.VoucherTypeCode,
                                VoucherDate = p.VoucherDate,
                                InvoiceNumber=p.PurchaseSaleBookHeader.PurchaseBillNo,
                                InvoiceDate=p.PurchaseSaleBookHeader.VoucherDate,
                                LedgerType = p.LedgerType,
                                LedgerTypeCode = p.LedgerTypeCode,
                                BillAmount = p.BillAmount,
                                OSAmount = p.OSAmount,
                                IsHold = p.IsHold,
                                HOLDRemarks = p.HOLDRemarks
                }).ToList();
            }
        }

        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> GetAllTempBillAdjustmentForLedger(PharmaBusinessObjects.Transaction.TransactionEntity entity)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    return context.TempBillOutStandingsAudjustment.Where(q => q.LedgerType == entity.EntityType
                                                                && q.LedgerTypeCode == entity.EntityCode)
                    .Select(p => new PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted()
                    {
                        BillOutStandingsAudjustmentID = p.BillOutStandingsAudjustmentID,
                        InvoiceNumber = p.PurchaseSaleBookHeader.PurchaseBillNo,
                        InvoiceDate = p.PurchaseSaleBookHeader.VoucherDate,
                        LedgerType = p.LedgerType,
                        LedgerTypeCode = p.LedgerTypeCode,
                        OSAmount = p.BillOutStandings.OSAmount + context.TempBillOutStandingsAudjustment.Where(x => x.BillOutStandingsID == p.BillOutStandingsID).Select(x => x.Amount).FirstOrDefault(),
                        Amount = p.Amount
                    }).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }
        }

        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> GetAllInitialBillAdjustmentForLedger(PharmaBusinessObjects.Transaction.TransactionEntity entity)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    
                    return context.BillOutStandings.Where(q => q.LedgerType == entity.EntityType
                                                                && q.LedgerTypeCode == entity.EntityCode
                                                                && q.OSAmount > 0)
                    .Select(p => new PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted()
                    {
                        BillOutStandingsID = p.BillOutStandingsID,
                        PurchaseSaleBookHeaderID = p.PurchaseSaleBookHeaderID,
                        VoucherNumber = p.VoucherNumber,
                        VoucherTypeCode = p.VoucherTypeCode,
                        VoucherDate = p.VoucherDate,
                        InvoiceNumber = p.PurchaseSaleBookHeader.PurchaseBillNo,
                        InvoiceDate = p.PurchaseSaleBookHeader.VoucherDate,
                        LedgerType = p.LedgerType,
                        LedgerTypeCode = p.LedgerTypeCode,
                        Amount= context.TempBillOutStandingsAudjustment.Where(x => x.BillOutStandingsID == p.BillOutStandingsID).Select(x => x.Amount).FirstOrDefault(),
                        OSAmount = p.OSAmount + context.TempBillOutStandingsAudjustment.Where(x => x.BillOutStandingsID == p.BillOutStandingsID).Select(x => x.Amount).FirstOrDefault(),

                    }).ToList();
                }
            }
            catch(Exception ex)
            {
                throw;
            }         
        }

        public void InsertTempBillAdjustment(List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> billAdjustmentList)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            if (billAdjustmentList.Count == 0)
                            {
                                transaction.Dispose();
                                return;
                            }
                              

                            long receiptPaymentID = billAdjustmentList.FirstOrDefault().ReceiptPaymentID ?? default(long);
                            var receiptPaymentEntity = context.TempReceiptPayment.Where(q => q.ReceiptPaymentID == receiptPaymentID).Select(q => q).ToList().FirstOrDefault();
                            var previousAdjustments = context.TempBillOutStandingsAudjustment.Where(x => x.ReceiptPaymentID == receiptPaymentID && x.LedgerTypeCode == receiptPaymentEntity.LedgerTypeCode).ToList();
                            //Recover bill outstanding before removing adjustments
                            previousAdjustments.ForEach(x => x.BillOutStandings.OSAmount = x.BillOutStandings.OSAmount + x.Amount);
                            context.TempBillOutStandingsAudjustment.RemoveRange(previousAdjustments);

                            foreach (var billAdjust in billAdjustmentList)
                            {
                                Entity.TempBillOutStandingsAudjustment billAdjustmentDBEntry = new Entity.TempBillOutStandingsAudjustment()
                                {
                                    PurchaseSaleBookHeaderID = billAdjust.PurchaseSaleBookHeaderID,
                                    VoucherNumber = receiptPaymentEntity.VoucherNumber,
                                    VoucherTypeCode = receiptPaymentEntity.VoucherTypeCode,
                                    VoucherDate = receiptPaymentEntity.VoucherDate,
                                    ReceiptPaymentID = receiptPaymentEntity.ReceiptPaymentID,
                                    BillOutStandingsID = billAdjust.BillOutStandingsID,
                                    AdjustmentVoucherNumber = billAdjust.AdjustmentVoucherNumber,
                                    AdjustmentVoucherTypeCode = billAdjust.AdjustmentVoucherTypeCode,
                                    AdjustmentVoucherDate = billAdjust.AdjustmentVoucherDate,
                                    LedgerType = billAdjust.LedgerType,
                                    LedgerTypeCode = billAdjust.LedgerTypeCode,
                                    Amount = billAdjust.Amount,
                                    ChequeNumber = receiptPaymentEntity.ChequeNumber
                                };
                                context.TempBillOutStandingsAudjustment.Add(billAdjustmentDBEntry);

                                var billOSDB = context.BillOutStandings.Where(x => x.BillOutStandingsID == billAdjustmentDBEntry.BillOutStandingsID).FirstOrDefault();
                                    billOSDB.OSAmount -= billAdjustmentDBEntry.Amount;
                            }
                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (DbEntityValidationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearTempBillAdjustment(PharmaBusinessObjects.Transaction.TransactionEntity entity)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                  var tempBillAdjustmentForEntity =  context.TempBillOutStandingsAudjustment.Where(q => q.ReceiptPaymentID == entity.ReceiptPaymentID
                                                                && q.LedgerTypeCode == entity.EntityCode)
                                                                .Select(q => q).ToList();

                    ///Rollback all amount deducted amount from OS amount from Bill outstanding
                    ///
                    foreach (var tempAdj in tempBillAdjustmentForEntity)
                    {
                        tempAdj.BillOutStandings.OSAmount += tempAdj.Amount;
                    }

                    context.TempBillOutStandingsAudjustment.RemoveRange(tempBillAdjustmentForEntity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearTempTransaction(PharmaBusinessObjects.Transaction.TransactionEntity entity)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var tempAdjustments = context.TempBillOutStandingsAudjustment.Where(x => x.ReceiptPaymentID == entity.ReceiptPaymentID).ToList();
                            ///Rollback all amount deducted amount from OS amount from Bill outstanding
                            ///
                            foreach (var tempAdj in tempAdjustments)
                            {
                                tempAdj.BillOutStandings.OSAmount += tempAdj.Amount;
                            }

                            context.TempBillOutStandingsAudjustment.RemoveRange(tempAdjustments);

                            var tempReceipt = context.TempReceiptPayment.Where(x => x.ReceiptPaymentID == entity.ReceiptPaymentID).ToList();
                            context.TempReceiptPayment.RemoveRange(tempReceipt);

                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }                      
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveAllTempTransaction(List<long> tempReceiptPaymentIds)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    SqlConnection connection = (SqlConnection)context.Database.Connection;

                    SqlCommand cmd = new SqlCommand("SaveReceiptPaymentData", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    List<PharmaBusinessObjects.Transaction.ReceiptPayment.TempReceiptPayment> list = new List<PharmaBusinessObjects.Transaction.ReceiptPayment.TempReceiptPayment>();
                    foreach (long id in tempReceiptPaymentIds)
                    {
                        list.Add(new PharmaBusinessObjects.Transaction.ReceiptPayment.TempReceiptPayment() { ReceiptPaymentID = id });
                    }

                    SqlParameter parameter = new SqlParameter();
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.TableTypeIds";
                    parameter.ParameterName = "@ReceiptPaymentIDs";
                    parameter.Value = CommonDaoMethods.CreateDataTable<PharmaBusinessObjects.Transaction.ReceiptPayment.TempReceiptPayment>(list);

                    cmd.Parameters.Add(parameter);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
