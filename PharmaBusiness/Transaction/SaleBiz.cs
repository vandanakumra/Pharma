﻿using PharmaBusinessObjects.Common;
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
        internal SaleBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal List<SaleChangeType> GetTypeOfChanges()
        {
            return new List<SaleChangeType>() {
                new SaleChangeType(){TypeID = Convert.ToInt32(Enums.SaleEntryChangeType.TemporaryChange), TypeName = Enums.SaleEntryChangeType.TemporaryChange.ToString() },
                new SaleChangeType(){TypeID = Convert.ToInt32(Enums.SaleEntryChangeType.CompanyWiseChange), TypeName = Enums.SaleEntryChangeType.CompanyWiseChange.ToString() },
                new SaleChangeType(){ TypeID = Convert.ToInt32(Enums.SaleEntryChangeType.ItemWiseChange), TypeName = Enums.SaleEntryChangeType.ItemWiseChange.ToString()}
            };
        }

        internal PurchaseSaleBookLineItem GetNewSaleLineItem(string itemCode, string customerCode)
        {
            return new SaleEntryDao(this.LoggedInUser).GetNewSaleLineItem(itemCode, customerCode);
        }

        internal SaleLineItemInfo GetSaleLineItemInfo(string code, long fifoID)
        {
            return new SaleEntryDao(this.LoggedInUser).GetSaleLineItemInfo(code, fifoID);
        }

        internal List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> InsertUpdateTempPurchaseBookLineItemForSale(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        {
            return new SaleEntryDao(this.LoggedInUser).InsertUpdateTempPurchaseBookLineItemForSale(lineItem);
        }

        internal void UpdateSaleDiscount(PharmaBusinessObjects.Common.Enums.SaleEntryChangeType changeType, decimal discount, decimal specialDiscount, string itemCode, string customerCode)
        {
            new SaleEntryDao(this.LoggedInUser).UpdateSaleDiscount(changeType, discount, specialDiscount, itemCode, customerCode);
        }
    }
}