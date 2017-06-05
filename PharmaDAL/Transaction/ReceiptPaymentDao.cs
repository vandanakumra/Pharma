using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
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
                    if (receiptPayment.ReceiptPaymentID > 0)
                    {
                        var receiptPaymentDB=context.TempReceiptPayment.Where(x => x.ReceiptPaymentID == receiptPayment.ReceiptPaymentID).FirstOrDefault();

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
                            VoucherTypeCode = receiptPayment.VoucherTypeCode,
                            VoucherDate = receiptPayment.VoucherDate,
                            LedgerType = receiptPayment.LedgerType,
                            LedgerTypeCode = receiptPayment.LedgerTypeCode,
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
                                OSAmount = p.OSAmount,
                                IsHold = p.IsHold,
                                HOLDRemarks = p.HOLDRemarks
                }).ToList();
            }
        }

        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> ReceiptPaymentEntryForLedger(PharmaBusinessObjects.Transaction.TransactionEntity entity)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.BillOutStandings.Where(q => q.LedgerType == entity.EntityType
                                                            && q.LedgerTypeCode == entity.EntityCode
                                                            && q.OSAmount > 0)
                .Select(p => new PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding()
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
                    BillAmount = p.BillAmount,
                    OSAmount = p.OSAmount,
                    IsHold = p.IsHold,
                    HOLDRemarks = p.HOLDRemarks
                }).ToList();
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
                        OSAmount = p.OSAmount
                    }).ToList();
                }
            }
            catch(Exception ex)
            {
                throw;
            }         
        }
    }
}
