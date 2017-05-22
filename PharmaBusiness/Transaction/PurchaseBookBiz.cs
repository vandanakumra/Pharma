using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaBusinessObjects.Transaction;
using PharmaDAL.Transaction;

namespace PharmaBusiness.Transaction
{
    internal class PurchaseBookBiz : BaseBiz
    {
        public PurchaseBookBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal int InsertTempPurchaseHeader(PurchaseBookHeader header)
        {
            return new PurchaseBookDao(this.LoggedInUser).InsertTempPurchaseBookHeader(header);
        }

        internal int UpdateTempPurchaseHeader(PurchaseBookHeader header)
        {
            return new PurchaseBookDao(this.LoggedInUser).UpdateTempPurchaseBookHeader(header);
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseType> GetPurchaseEntryTypes()
        {
            return new PurchaseBookDao(this.LoggedInUser).GetPurchaseEntryTypes();
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseFormType> GetPurchaseFormTypes(int purchaseTypeID)
        {
            return new PurchaseBookDao(this.LoggedInUser).GetPurchaseFormTypes(purchaseTypeID);
        }

        public int InsertTempLineItem(PurchaseBookLineItem lineItem)
        {
            return new PurchaseBookDao(this.LoggedInUser).InsertTempLineItem(lineItem);
        }

        public int UpdateTempLineItem(PurchaseBookLineItem lineItem)
        {
            return new PurchaseBookDao(this.LoggedInUser).UpdateTempLineItem(lineItem);
        }

    }
}
