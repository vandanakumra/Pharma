﻿using PharmaBusinessObjects.Master;
using PharmaBusinessObjects.Transaction;
using PharmaBusinessObjects.Transaction.ReceiptPayment;
using PharmaDAL.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Transaction
{
    internal class ReceiptPaymentBiz : BaseBiz
    {
        public ReceiptPaymentBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> GetAllBillOutstandingForLedger(TransactionEntity transactionEntity)
        {
            return new ReceiptPaymentDao(this.LoggedInUser).GetAllBillOutstandingForLedger(transactionEntity).Where(x=>x.OSAmount > 0).ToList();
        }

        

        internal List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> GetAllTempBillAdjustmentForLedger(TransactionEntity transactionEntity)
        {
            return new ReceiptPaymentDao(this.LoggedInUser).GetAllTempBillAdjustmentForLedger(transactionEntity);
        }

        internal List<BillAdjusted> GetAllInitialBillAdjustmentForLedger(TransactionEntity transactionEntity)
        {
            return new ReceiptPaymentDao(this.LoggedInUser).GetAllInitialBillAdjustmentForLedger(transactionEntity);
        }

        internal long InsertUpdateTempReceiptPayment(PharmaBusinessObjects.Transaction.ReceiptPayment.ReceiptPaymentItem receiptPayment)
        {
            return new ReceiptPaymentDao(this.LoggedInUser).InsertUpdateTempReceiptPayment(receiptPayment);
        }

        internal void InsertTempBillAdjustment(List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> billAdjustmentList)
        {
             new ReceiptPaymentDao(this.LoggedInUser).InsertTempBillAdjustment(billAdjustmentList);
        }

        internal void ClearTempBillAdjustment(TransactionEntity transactionEntity)
        {
            new ReceiptPaymentDao(this.LoggedInUser).ClearTempBillAdjustment(transactionEntity);
        }
        
    }
}
