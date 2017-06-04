using PharmaBusinessObjects.Master;
using PharmaBusinessObjects.Transaction;
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
            return new ReceiptPaymentDao(this.LoggedInUser).GetAllBillOutstandingForLedger(transactionEntity);
        }
    }
}
