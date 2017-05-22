using PharmaBusinessObjects.Transaction;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Transaction
{
    public class PurchaseBookDao :BaseDao
    {
        public PurchaseBookDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public int InsertTempPurchaseBookHeader(PharmaBusinessObjects.Transaction.PurchaseBookHeader header)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                TempPurchaseBookHeader h = new TempPurchaseBookHeader();
                h.InvoiceNumber = header.InvoiceNumber;
                h.PurchaseDate = header.PurchaseDate;
                h.SupplierCode = header.SupplierCode;
                //h.AccountLedgerCode = header.PurchaseTypeCode;

                context.TempPurchaseBookHeader.Add(h);
                context.SaveChanges();

                return h.ID;
            }
        }

        public int UpdateTempPurchaseBookHeader(PharmaBusinessObjects.Transaction.PurchaseBookHeader header)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                TempPurchaseBookHeader h = context.TempPurchaseBookHeader.Where(p => p.ID == header.InvoiceID).FirstOrDefault();
                h.InvoiceNumber = header.InvoiceNumber;
                h.PurchaseDate = header.PurchaseDate;
                h.SupplierCode = header.SupplierCode;
                h.PurchaseEntryFormID = header.PurchaseFormTypeID == 0 ? (int?)null : header.PurchaseFormTypeID;
                context.SaveChanges();

                return h.ID;
            }
        }

        public int InsertTempLineItem(PharmaBusinessObjects.Transaction.PurchaseBookLineItem lineItem)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                Entity.TempPurchaseBookLineItem item = new Entity.TempPurchaseBookLineItem();
                item.PurchaseBookHeaderID = lineItem.InvoiceID;
                item.ItemCode = lineItem.ItemCode;
                item.BatchNo = string.Empty;
                item.Quantity = lineItem.Quantity;
                item.Rate = lineItem.Rate;

                context.TempPurchaseBookLineItem.Add(item);
                context.SaveChanges();

                return item.ID;
            }
        }

        public int UpdateTempLineItem(PharmaBusinessObjects.Transaction.PurchaseBookLineItem lineItem)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                Entity.TempPurchaseBookLineItem item = context.TempPurchaseBookLineItem.FirstOrDefault(p => p.ID == lineItem.ID);

                if (item != null)
                {
                    item.PurchaseBookHeaderID = lineItem.InvoiceID;
                    item.ItemCode = lineItem.ItemCode;
                    item.BatchNo = string.Empty;
                    item.Quantity = lineItem.Quantity;
                    item.Rate = lineItem.Rate;

                    context.TempPurchaseBookLineItem.Add(item);
                    context.SaveChanges();
                }

                return item.ID;
            }
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseType> GetPurchaseEntryTypes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PurchaseEntryType.Select(p => new PharmaBusinessObjects.Transaction.PurchaseType() {
                        ID = p.ID,
                        PurchaseTypeName = p.PurchaseTypeName
                }).ToList();
            }
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseFormType> GetPurchaseFormTypes(int purchaseTypeID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PurchaseEntryForm.Where(p=>p.Status && p.PurchaseTypeID == purchaseTypeID).Select(p => new PharmaBusinessObjects.Transaction.PurchaseFormType()
                {
                    ID = p.ID,
                    FormTypeName = p.PurchaseFormName
                }).ToList();
            }
        }
    }
}
