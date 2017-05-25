using PharmaBusinessObjects.Transaction;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                item.Amount = lineItem.Amount;
                item.FreeQuantity = lineItem.FreeQty;
                item.Discount = lineItem.Discount;
                item.SpecialDiscount = lineItem.SpecialDiscount;
                item.MRP = lineItem.MRP;
                item.Excise = lineItem.Excise;
                if (lineItem.Expiry == DateTime.MinValue)
                    item.Expiry = null;
                else
                    item.Expiry = lineItem.Expiry;
                item.Scheme1 = lineItem.Scheme1;
                item.Scheme2 = lineItem.Scheme2;
                item.IsHalfScheme = lineItem.IsHalfScheme;
                item.VolumeDiscount = lineItem.VolumeDiscount;
                item.SpecialRate = lineItem.SpecialRate;
                item.WholeSaleRate = lineItem.WholeSaleRate;
                item.SaleRate = lineItem.SaleRate;
                item.PurchaseTaxType = lineItem.PurchaseTaxType;
                item.CreatedBy = this.LoggedInUser.Username;
                item.CreatedOn = DateTime.Now;

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
                    item.BatchNo = lineItem.BatchNumber;
                    item.Quantity = lineItem.Quantity;
                    item.Rate = lineItem.Rate;
                    item.Amount = lineItem.Amount;
                    item.FreeQuantity = lineItem.FreeQty;
                    item.Discount = lineItem.Discount;
                    item.VolumeDiscount = lineItem.VolumeDiscount;
                    item.SpecialDiscount = lineItem.SpecialDiscount;
                    item.MRP = lineItem.MRP;
                    item.Excise = lineItem.Excise;
                    if (lineItem.Expiry == DateTime.MinValue)
                        item.Expiry = null;
                    else
                        item.Expiry = lineItem.Expiry;
                    item.Scheme1 = lineItem.Scheme1;
                    item.Scheme2 = lineItem.Scheme2;
                    item.IsHalfScheme = lineItem.IsHalfScheme;
                    item.SpecialRate = lineItem.SpecialRate;
                    item.WholeSaleRate = lineItem.WholeSaleRate;
                    item.SaleRate = lineItem.SaleRate;
                    item.PurchaseTaxType = "L000012";//lineItem.PurchaseTaxType;
                    item.ModifiedBy = this.LoggedInUser.Username;
                    item.ModifiedOn = DateTime.Now;
                    //IsNewRate and Purchase Rate
                    //context.TempPurchaseBookLineItem.Add(item);
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


        public List<PharmaBusinessObjects.Transaction.PurchaseBookLineItem> GetLastNBatchNoForSupplierItem(string supplierCode, string itemCode)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PurchaseBookLineItem.Where(p => p.PurchaseBookHeader.SupplierCode == supplierCode & p.ItemCode == itemCode)
                    .Select(p => new PharmaBusinessObjects.Transaction.PurchaseBookLineItem()
                    {
                        ID = p.ID,
                        ItemCode = p.ItemCode,
                        Rate = p.Rate,
                        Discount = p.Discount,
                        SpecialDiscount = p.SpecialDiscount,
                        VolumeDiscount = p.VolumeDiscount,
                        TaxOnPurchase = p.TaxOnPurchase,
                        PurchaseDate = p.PurchaseBookHeader.PurchaseDate,
                        BatchNumber = p.BatchNo
                    }).OrderByDescending(p => p.ID).Take(5).ToList();
            }
        }


        public bool SavePurchaseData(int purchaseBookHeaderID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("SavePurchaseData", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID",purchaseBookHeaderID));

                cmd.ExecuteNonQuery();


            }
                return true;
        }

        public PharmaBusinessObjects.Transaction.PurchaseBookHeader GetFinalAmountWithTaxForPurchase(int purchaseBookHeaderID)
        {
            PharmaBusinessObjects.Transaction.PurchaseBookHeader header = new PharmaBusinessObjects.Transaction.PurchaseBookHeader();
            header.InvoiceID = purchaseBookHeaderID;

            header.PurchaseAmountList = new List<PharmaBusinessObjects.Transaction.PurchaseBookAmount>();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("GetFinalAmountWithTaxForPurchase", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", purchaseBookHeaderID));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PharmaBusinessObjects.Transaction.PurchaseBookAmount obj = new PharmaBusinessObjects.Transaction.PurchaseBookAmount();
                    
                        obj.PurchaseTaxType = Convert.ToString(row["PurchaseTaxType"]);
                        obj.Amount = Convert.IsDBNull(row["Amount"]) ? 0L :  Convert.ToDouble(row["Amount"]);
                        obj.TaxOnPurchase = Convert.IsDBNull(row["TaxOnPurchase"]) ? 0L :  Convert.ToDouble(row["TaxOnPurchase"]);

                        header.PurchaseAmountList.Add(obj);
                    }
                }
            }

            double totalAmount = header.PurchaseAmountList.Sum(p => p.Amount) + header.PurchaseAmountList.Sum(p => p.TaxOnPurchase);
            header.InvoiceAmount = totalAmount;

            return header;
        }

    }
}
