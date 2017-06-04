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
             

        internal long InsertUpdateTempPurchaseBookHeader(PurchaseSaleBookHeader header)
        {
            header.CreatedBy = this.LoggedInUser.Username;
            header.CreatedOn = DateTime.Now;
            header.ModifiedBy = this.LoggedInUser.Username;
            header.ModifiedOn = DateTime.Now;
            return new PurchaseBookDao(this.LoggedInUser).InsertUpdateTempPurchaseBookHeader(header);
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseType> GetPurchaseEntryTypes()
        {
            return new PurchaseBookDao(this.LoggedInUser).GetPurchaseEntryTypes();
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseFormType> GetPurchaseFormTypes(int purchaseTypeID)
        {
            return new PurchaseBookDao(this.LoggedInUser).GetPurchaseFormTypes(purchaseTypeID);
        }
        

        public List<PurchaseBookAmount> InsertUpdateTempPurchaseBookLineItem(PurchaseSaleBookLineItem lineItem)
        {
            lineItem.CreatedBy = this.LoggedInUser.Username;
            lineItem.CreatedOn = DateTime.Now;
            lineItem.ModifiedBy = this.LoggedInUser.Username;
            lineItem.ModifiedOn = DateTime.Now;

            return new PurchaseBookDao(this.LoggedInUser).InsertUpdateTempPurchaseBookLineItem(lineItem);
        }

        public List<PurchaseBookAmount> DeleteTempPurchaseBookLineItem(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        {
            return new PurchaseBookDao(this.LoggedInUser).DeleteTempPurchaseBookLineItem(lineItem);
        }



        internal List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> GetLastNBatchNoForSupplierItem(string supplierCode, string itemCode)
        {
            return new PurchaseBookDao(this.LoggedInUser).GetLastNBatchNoForSupplierItem(supplierCode,itemCode);
        }

        internal bool SavePurchaseData(long purchaseBookHeaderID)
        {
            return new PurchaseBookDao(this.LoggedInUser).SavePurchaseData(purchaseBookHeaderID);
        }

        internal List<PharmaBusinessObjects.Transaction.PurchaseBookAmount> GetFinalAmountWithTaxForPurchase(long purchaseBookHeaderID)
        {
            return new PurchaseBookDao(this.LoggedInUser).GetFinalAmountWithTaxForPurchase(purchaseBookHeaderID);
        }

        internal bool IsTempPurchaseHeaderExists(long purchaseBookHeaderID)
        {
            return new PurchaseBookDao(this.LoggedInUser).IsTempPurchaseHeaderExists(purchaseBookHeaderID);
        }
    }
}
