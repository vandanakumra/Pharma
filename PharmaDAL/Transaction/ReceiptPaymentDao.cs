﻿using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
                        receiptPaymentDB.VoucherNumber = receiptPayment.VoucherNumber;
                        receiptPaymentDB.VoucherTypeCode = receiptPayment.VoucherTypeCode;
                        receiptPaymentDB.VoucherDate = receiptPayment.VoucherDate;
                        receiptPaymentDB.LedgerType = receiptPayment.LedgerType;
                        receiptPaymentDB.LedgerTypeCode = receiptPayment.LedgerTypeCode;
                        receiptPaymentDB.PaymentMode = receiptPayment.PaymentMode;
                        receiptPaymentDB.Ammount = receiptPayment.Amount;
                        receiptPaymentDB.BankAccountLedgerTypeCode = receiptPayment.BankAccountLedgerTypeCode;
                        receiptPaymentDB.ChequeDate = receiptPayment.ChequeDate;
                        receiptPaymentDB.ChequeClearDate = receiptPayment.ChequeClearDate;
                        receiptPaymentDB.IsChequeCleared = receiptPayment.IsChequeCleared;
                        receiptPaymentDB.POST = receiptPayment.POST;
                        receiptPaymentDB.PISNumber = receiptPayment.PISNumber;
                        receiptPaymentDB.ChequeNumber = receiptPayment.ChequeNumber;
                        context.SaveChanges();
                        receiptPaymentID = receiptPaymentDB.ReceiptPaymentID;
                    }
                    else
                    {
                        Entity.TempReceiptPayment receiptPaymentDBEntry = new Entity.TempReceiptPayment()
                        {
                            VoucherNumber=(context.ReceiptPayment.Where(q=>q.VoucherTypeCode == receiptPayment.VoucherTypeCode).Count()+1).ToString("D8"),
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
            catch (Exception ex)
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
                                OSAmount = p.OSAmount- context.TempBillOutStandingsAudjustment.Where(x=>x.BillOutStandingsID == p.BillOutStandingsID).Select(x=>x.Amount).FirstOrDefault(),
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
                        OSAmount = p.BillOutStandings.OSAmount,
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
                        OSAmount = p.OSAmount

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
                    long receiptPaymentID = billAdjustmentList.FirstOrDefault().ReceiptPaymentID ?? default(long);
                    var receiptPaymentEntity = context.TempReceiptPayment.Where(q => q.ReceiptPaymentID == receiptPaymentID).Select(q => q).ToList().FirstOrDefault();
                    var previousAdjustments = context.TempBillOutStandingsAudjustment.Where(x => x.ReceiptPaymentID == receiptPaymentID && x.LedgerTypeCode == receiptPaymentEntity.LedgerTypeCode).ToList();
                    context.TempBillOutStandingsAudjustment.RemoveRange(previousAdjustments);
                   
                    foreach (var billAdjust in billAdjustmentList)
                    {
                        Entity.TempBillOutStandingsAudjustment billAdjustmentDBEntry = new Entity.TempBillOutStandingsAudjustment()
                        {
                            PurchaseSaleBookHeaderID=billAdjust.PurchaseSaleBookHeaderID,
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
                        context.SaveChanges();
                    }                
                  }
            }
            catch (DbEntityValidationException ex)
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

                    context.TempBillOutStandingsAudjustment.RemoveRange(tempBillAdjustmentForEntity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
