﻿using PharmaBusinessObjects.Transaction;
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

        public List<PurchaseBookAmount> InsertUpdateTempPurchaseBookLineItem(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        {
            try
            {
                List<PurchaseBookAmount> purchaseBookAmounts = new List<PurchaseBookAmount>();

              // lineItem.ExpiryDate = DateTime.Now;

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
                        foreach (DataRow row in dt.Rows)
                        {
                            PurchaseBookAmount obj = new PurchaseBookAmount()
                            {
                                PurchaseSaleBookLineItemID = row["PurchaseSaleBookLineItemID"] == null ? 0 : Convert.ToInt64(row["PurchaseSaleBookLineItemID"]) ,
                                PurchaseBookHeaderID = Convert.ToInt64(row["PurchaseSaleBookHeaderID"]),
                                BillAmount = Convert.ToInt64(row["BillAmount"]),
                                TaxAmount = Convert.ToInt64(row["TaxAmount"]),
                                CostAmount = Convert.ToInt64(row["CostAmount"]),
                                GrossAmount = Convert.ToInt64(row["GrossAmount"]),
                                SchemeAmount = Convert.ToInt64(row["SchemeAmount"]),
                                DiscountAmount = Convert.ToInt64(row["DiscountAmount"]),
                                SpecialDiscountAmount = Convert.ToInt64(row["SpecialDiscountAmount"]),
                                VolumeDiscountAmount = Convert.ToInt64(row["VolumeDiscountAmount"]),
                                TotalDiscountAmount = Convert.ToInt64(row["TotalDiscountAmount"])
                            };

                            purchaseBookAmounts.Add(obj);
                        }
                       
                    }
                }

                return purchaseBookAmounts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
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
                return context.PurchaseSaleBookLineItem.Where(p => p.PurchaseSaleBookHeader.LedgerTypeCode == supplierCode & p.ItemCode == itemCode)
                    .Select(p => new PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem()
                    {
                        PurchaseSaleBookLineItemID = p.PurchaseSaleBookLineItemID,
                        ItemCode = p.ItemCode,
                        PurchaseSaleRate = p.PurchaseSaleRate,
                        OldPurchaseSaleRate = p.PurchaseSaleRate,
                        Discount = p.Discount,
                        SpecialDiscount = p.SpecialDiscount,
                        VolumeDiscount = p.VolumeDiscount,
                        PurchaseSaleTax = p.SalePurchaseTax,
                        PurchaseBillDate = p.PurchaseSaleBookHeader.VoucherDate,
                        Batch = p.Batch,
                        ExpiryDate = p.ExpiryDate
                    }).OrderByDescending(p => p.PurchaseSaleBookLineItemID).Take(5).ToList();
                
            }
        }


        public bool SavePurchaseData(long purchaseBookHeaderID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection; ;
                try
                {
                    SqlCommand cmd = new SqlCommand("SavePurchaseEntryData", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PurchaseSaleBookHeaderID", purchaseBookHeaderID));
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

        public List<PharmaBusinessObjects.Transaction.PurchaseBookAmount> GetFinalAmountWithTaxForPurchase(long purchaseBookHeaderID)
        { 

            List<PharmaBusinessObjects.Transaction.PurchaseBookAmount> PurchaseAmountList = new List<PharmaBusinessObjects.Transaction.PurchaseBookAmount>();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("GetFinalAmountWithTaxForPurchase", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PurchaseSaleBookHeaderID", purchaseBookHeaderID));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);
  

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PharmaBusinessObjects.Transaction.PurchaseBookAmount obj = new PharmaBusinessObjects.Transaction.PurchaseBookAmount()
                        {
                            PurchaseBookHeaderID = Convert.ToInt64(row["PurchaseSaleBookHeaderID"]),
                            PurchaseSaleTypeCode = Convert.ToString(row["PurchaseSaleTypeCode"]),
                            PurchaseSaleTypeName = Convert.ToString(row["PurchaseSaleTypeName"]),
                            Amount = Convert.IsDBNull(row["Amount"]) ? 0L : Convert.ToDouble(row["Amount"]),
                            IGST = Convert.IsDBNull(row["IGST"]) ? 0L : Convert.ToDouble(row["IGST"]),
                            SGST = Convert.IsDBNull(row["SGST"]) ? 0L : Convert.ToDouble(row["SGST"]),
                            CGST = Convert.IsDBNull(row["CGST"]) ? 0L : Convert.ToDouble(row["CGST"]),
                            TaxApplicable = Convert.IsDBNull(row["TaxApplicable"]) ? 0L : Convert.ToDouble(row["TaxApplicable"])
                        };

                        PurchaseAmountList.Add(obj);
                    }
                }
            }

            //double totalAmount = header.PurchaseAmountList.Sum(p => p.Amount) + header.PurchaseAmountList.Sum(p => p.TaxOnPurchase);
            //header.InvoiceAmount = totalAmount;

            return PurchaseAmountList;
        }

    }
}
