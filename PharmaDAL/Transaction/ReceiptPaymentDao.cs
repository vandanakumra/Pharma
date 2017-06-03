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
        ReceiptPaymentDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public long InsertUpdateTempReceiptPayment(PharmaBusinessObjects.Transaction.ReceiptPayment.ReceiptPayment receiptPayment)
        {
            try
            {
                long receiptPaymentID = 0;
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                   
                    if (receiptPayment.ReceiptPaymentID > 0)
                    {

                    }
                    else
                    {
                        Entity.TempReceiptPayment newReceiptPaymentEntry = new Entity.TempReceiptPayment()
                        {
                            VoucherNumber = receiptPayment.VoucherNumber,
                            VoucherTypeCode = receiptPayment.VoucherTypeCode,
                            VoucherDate = receiptPayment.VoucherDate,
                            LedgerType = receiptPayment.LedgerType,
                            LedgerTypeCode = receiptPayment.LedgerTypeCode,
                            PaymentMode = receiptPayment.PaymentMode,
                            Ammount = receiptPayment.Amount,
                            BankAccountLedgerTypeCode = receiptPayment.BankAccountLedgerTypeCode,
                            ChequeDate = receiptPayment.ChequeDate,
                            ChequeClearDate = receiptPayment.ChequeClearDate,
                            IsChequeCleared = receiptPayment.IsChequeCleared,
                            POST = receiptPayment.POST,
                            PISNumber = receiptPayment.PISNumber,
                            ChequeNumber = receiptPayment.ChequeNumber
                        };
                    }

                }

                return receiptPaymentID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
