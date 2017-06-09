using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction;
using PharmaBusinessObjects.Transaction.SaleEntry;
using PharmaDAL.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Transaction
{
    internal class SaleBiz : BaseBiz
    {
        public SaleBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<SaleChangeType> GetTypeOfChanges()
        {
            return new List<SaleChangeType>() {
                new SaleChangeType(){TypeID = Convert.ToInt32(Enums.SaleEntryChangeType.TemporaryChange), TypeName = Enums.SaleEntryChangeType.TemporaryChange.ToString() },
                new SaleChangeType(){TypeID = Convert.ToInt32(Enums.SaleEntryChangeType.CompanyWiseChange), TypeName = Enums.SaleEntryChangeType.CompanyWiseChange.ToString() },
                new SaleChangeType(){ TypeID = Convert.ToInt32(Enums.SaleEntryChangeType.ItemWiseChange), TypeName = Enums.SaleEntryChangeType.ItemWiseChange.ToString()}
            };
        }

        public PurchaseSaleBookLineItem GetNewSaleLineItem(string itemCode, string customerCode)
        {
            return new PurchaseBookDao(this.LoggedInUser).GetNewSaleLineItem(itemCode, customerCode);
        }
    }
}
