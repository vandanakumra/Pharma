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

        //internal List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> GetAllBillOutstandingForLedger(string ledgerType, string ledgerTypeCode)
        //{
        //    return new ReceiptPaymentDao(this.LoggedInUser).GetAllBillOutstandingForLedger(purchaseTypeID);
        //}
    }
}
