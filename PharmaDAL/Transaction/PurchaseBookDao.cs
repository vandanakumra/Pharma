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


        public long InsertUpdateTempPurchaseBookHeader(PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader header)
        {
            try
            {
                long PurchaseSaleBookHeaderID = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    SqlConnection connection = (SqlConnection)context.Database.Connection;

                    SqlCommand cmd = new SqlCommand("InsertUpdateInvetoryHeadersInTempTable", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    List<PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader> list = new List<PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader>();
                    list.Add(header);

                    SqlParameter parameter = new SqlParameter();
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.TableTypePurchaseSaleBookHeader";
                    parameter.ParameterName = "@TableTypePurchaseSaleBookHeader";
                    parameter.Value = CommonDaoMethods.CreateDataTable<PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader>(list);

                    cmd.Parameters.Add(parameter);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        PurchaseSaleBookHeaderID = Convert.ToInt64(dt.Rows[0]["PurchaseSaleBookHeaderID"]);
                    }
                }

                return PurchaseSaleBookHeaderID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public long InsertUpdateTempPurchaseBookLineItem(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        {
            try
            {
                long PurchaseSaleBookLineItemID = 0;

                lineItem.ExpiryDate = DateTime.Now;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    SqlConnection connection = (SqlConnection)context.Database.Connection;

                    SqlCommand cmd = new SqlCommand("InsertUpdateInvetoryLineItemInTempTable", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> list = new List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem>();
                    list.Add(lineItem);

                    SqlParameter parameter = new SqlParameter();
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.TableTypePurchaseSaleBookLineItem";
                    parameter.ParameterName = "@TableTypePurchaseSaleBookLineItem";
                    parameter.Value = CommonDaoMethods.CreateDataTable<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem>(list);

                    cmd.Parameters.Add(parameter);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        PurchaseSaleBookLineItemID = Convert.ToInt64(dt.Rows[0]["PurchaseSaleBookLineItemID"]);
                    }
                }

                return PurchaseSaleBookLineItemID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public long InsertTempPurchaseBookHeader(PharmaBusinessObjects.Transaction.PurchaseBookHeader header)
        //{
        //    using (PharmaDBEntities context = new PharmaDBEntities())
        //    {
        //        TempPurchaseSaleBookHeader h = new TempPurchaseSaleBookHeader();
        //        h.PurchaseBillNo = header.PurchaseBillNo;
        //        h.VoucherDate = header.VoucherDate;
        //        h.LedgerTypeCode = header.LedgerTypeCode;
        //        //h.AccountLedgerCode = header.PurchaseTypeCode;

        //        context.TempPurchaseSaleBookHeader.Add(h);
        //        context.SaveChanges();

        //        return h.PurchaseSaleBookHeaderID;
        //    }
        //}

        //public long UpdateTempPurchaseBookHeader(PharmaBusinessObjects.Transaction.PurchaseBookHeader header)
        //{
        //    using (PharmaDBEntities context = new PharmaDBEntities())
        //    {
        //        TempPurchaseSaleBookHeader h = context.TempPurchaseSaleBookHeader.Where(p => p.PurchaseSaleBookHeaderID == header.PurchaseSaleBookHeaderID).FirstOrDefault();
        //        h.PurchaseBillNo = header.PurchaseBillNo;
        //        h.VoucherDate = header.VoucherDate;
        //        h.LedgerTypeCode = header.LedgerTypeCode;
        //        h.PurchaseEntryFormID = header.PurchaseEntryFormID;
        //        h.OtherAmount = header.OtherAmount;
        //        h.TotalBillAmount = header.TotalBillAmount;






        //        //h = header.Narration1;
        //        //h.Narration2 = header.Narration2;

        //        //h.ExemptedAmount = header.ExemptedAmount;
        //        //h.PurAmount1 = header.PurchaseAmountList == null ? 0L : header.PurchaseAmountList.Count > 0 ? header.PurchaseAmountList.FirstOrDefault().Amount : 0L;
        //        //h.PurAmount2 = header.PurchaseAmountList == null ? 0L : header.PurchaseAmountList.Count > 1 ? header.PurchaseAmountList.Skip(1).Take(1).FirstOrDefault().Amount : 0L;
        //        //h.VAT1 = header.PurchaseAmountList == null ? 0L : header.PurchaseAmountList.Count > 0 ? header.PurchaseAmountList.FirstOrDefault().TaxOnPurchase : 0L;
        //        //h.VAT2 = header.PurchaseAmountList == null ? 0L : header.PurchaseAmountList.Count > 1 ? header.PurchaseAmountList.Skip(1).Take(1).FirstOrDefault().TaxOnPurchase : 0L;

        //        context.SaveChanges();

        //        return h.PurchaseSaleBookHeaderID;
        //    }
        //}

        //public long InsertTempLineItem(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        //{
        //    using (PharmaDBEntities context = new PharmaDBEntities())
        //    {
        //        Entity.TempPurchaseSaleBookLineItem item = new Entity.TempPurchaseSaleBookLineItem();
        //        item.PurchaseSaleBookHeaderID = lineItem.InvoiceID;
        //        item.ItemCode = lineItem.ItemCode;
        //        item.Batch = string.Empty;
        //        item.Quantity = lineItem.Quantity;
        //        item.PurchaseSaleRate = lineItem.Rate;
        //        item.Amount = lineItem.Amount;
        //        item.FreeQuantity = lineItem.FreeQty;
        //        item.Discount = lineItem.Discount;
        //        item.SpecialDiscount = lineItem.SpecialDiscount;
        //        item.MRP = lineItem.MRP;
        //       // item.Excise = lineItem.Excise;

        //        if (lineItem.Expiry == DateTime.MinValue)
        //            item.ExpiryDate = null;
        //        else
        //            item.ExpiryDate = lineItem.Expiry;

        //        item.Scheme1 = lineItem.Scheme1;
        //        item.Scheme2 = lineItem.Scheme2;
        //        item.IsHalfScheme = lineItem.IsHalfScheme;
        //        item.VolumeDiscount = lineItem.VolumeDiscount;
        //        item.SpecialRate = lineItem.SpecialRate;
        //        item.WholeSaleRate = lineItem.WholeSaleRate;
        //        item.SaleRate = lineItem.SaleRate;
        //        item.PurchaseSaleTypeCode = lineItem.PurchaseTaxType;
        //        item.PurchaseSaleTax = (double)lineItem.TaxOnPurchase;
        //        item.CreatedBy = this.LoggedInUser.Username;
        //        item.CreatedOn = DateTime.Now;

        //        context.TempPurchaseSaleBookLineItem.Add(item);
        //        context.SaveChanges();

        //        return item.PurchaseSaleBookLineItemID;
        //    }
        //}

        //public long UpdateTempLineItem(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        //{
        //    using (PharmaDBEntities context = new PharmaDBEntities())
        //    {
        //        Entity.TempPurchaseSaleBookLineItem item = context.TempPurchaseSaleBookLineItem.FirstOrDefault(p => p.PurchaseSaleBookLineItemID == lineItem.ID);

        //        if (item != null)
        //        {
        //            item.PurchaseSaleBookHeaderID = lineItem.InvoiceID;
        //            item.ItemCode = lineItem.ItemCode;
        //            item.Batch = lineItem.BatchNumber;
        //            item.Quantity = lineItem.Quantity;
        //            item.PurchaseSaleRate = lineItem.Rate;
        //            item.Amount = lineItem.Amount;
        //            item.FreeQuantity = lineItem.FreeQty;
        //            item.Discount = lineItem.Discount;
        //            item.VolumeDiscount = lineItem.VolumeDiscount;
        //            item.SpecialDiscount = lineItem.SpecialDiscount;
        //            item.MRP = lineItem.MRP;
        //           // item.e = lineItem.Excise;

        //            if (lineItem.Expiry == DateTime.MinValue)
        //                item.ExpiryDate = null;
        //            else
        //                item.ExpiryDate = lineItem.Expiry;

        //            item.Scheme1 = lineItem.Scheme1;
        //            item.Scheme2 = lineItem.Scheme2;
        //            item.IsHalfScheme = lineItem.IsHalfScheme;
        //            item.SpecialRate = lineItem.SpecialRate;
        //            item.WholeSaleRate = lineItem.WholeSaleRate;
        //            item.SaleRate = lineItem.SaleRate;
        //            item.PurchaseSaleTypeCode = lineItem.PurchaseTaxType;
        //            item.PurchaseSaleTax = (double)lineItem.TaxOnPurchase;
        //            item.ModifiedBy = this.LoggedInUser.Username;
        //            item.ModifiedOn = DateTime.Now;
        //            //IsNewRate and Purchase Rate
        //            //context.TempPurchaseBookLineItem.Add(item);
        //            context.SaveChanges();
        //        }

        //        return item.PurchaseSaleBookLineItemID;
        //    }
        //}

        public List<PharmaBusinessObjects.Transaction.PurchaseType> GetPurchaseEntryTypes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PurchaseSaleEntryType.Select(p => new PharmaBusinessObjects.Transaction.PurchaseType() {
                        ID = p.PurchaseSaleEntryTypeID,
                        PurchaseTypeName = p.PurchaseSaleTypeName
                }).ToList();
            }
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseFormType> GetPurchaseFormTypes(int purchaseTypeID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PurchaseSaleEntryForm.Where(p=>p.Status && p.PurchaseSaleEntryTypeID == purchaseTypeID).Select(p => new PharmaBusinessObjects.Transaction.PurchaseFormType()
                {
                    ID = p.PurchaseSaleEntryFormID,
                    FormTypeName = p.PurchaseSaleFormName
                }).ToList();
            }
        }


        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> GetLastNBatchNoForSupplierItem(string supplierCode, string itemCode)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                //return context.PurchaseSaleBookLineItem.Where(p => p.PurchaseSaleBookHeader.LedgerTypeCode == supplierCode & p.ItemCode == itemCode)
                //    .Select(p => new PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem()
                //    {
                //        ID = p.PurchaseSaleBookLineItemID,
                //        ItemCode = p.ItemCode,
                //        Rate = p.PurchaseSaleRate,
                //        Discount = p.Discount,
                //        SpecialDiscount = p.SpecialDiscount,
                //        VolumeDiscount = p.VolumeDiscount,
                //        TaxOnPurchase = p.SalePurchaseTax,
                //        PurchaseDate = p.PurchaseSaleBookHeader.VoucherDate,
                //        BatchNumber = p.Batch
                //    }).OrderByDescending(p => p.ID).Take(5).ToList();

                return new List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem>();
            }
        }


        public bool SavePurchaseData(long purchaseBookHeaderID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection; ;
                try
                {
                    SqlCommand cmd = new SqlCommand("SavePurchaseData", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", purchaseBookHeaderID));
                    connection.Open();
                    cmd.ExecuteNonQuery();

                }
                finally
                {

                    connection.Close();
                }
                

            }
                return true;
        }

        public PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader GetFinalAmountWithTaxForPurchase(long purchaseBookHeaderID)
        {
            PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader header = new PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader();
            header.PurchaseSaleBookHeaderID = purchaseBookHeaderID;

           // header.PurchaseAmountList = new List<PharmaBusinessObjects.Transaction.PurchaseBookAmount>();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("GetFinalAmountWithTaxForPurchase", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", purchaseBookHeaderID));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                //if(dt != null && dt.Rows.Count > 0)
                //{
                //    foreach (DataRow row in dt.Rows)
                //    {
                //        PharmaBusinessObjects.Transaction.PurchaseBookAmount obj = new PharmaBusinessObjects.Transaction.PurchaseBookAmount();
                    
                //        obj.PurchaseTaxType = Convert.ToString(row["PurchaseTaxType"]);
                //        obj.Amount = Convert.IsDBNull(row["Amount"]) ? 0L :  Convert.ToDouble(row["Amount"]);
                //        obj.TaxOnPurchase = Convert.IsDBNull(row["TaxOnPurchase"]) ? 0L :  Convert.ToDouble(row["TaxOnPurchase"]);

                //        //header.PurchaseAmountList.Add(obj);
                //    }
                //}
            }

            //double totalAmount = header.PurchaseAmountList.Sum(p => p.Amount) + header.PurchaseAmountList.Sum(p => p.TaxOnPurchase);
            //header.InvoiceAmount = totalAmount;

            return header;
        }

    }
}
