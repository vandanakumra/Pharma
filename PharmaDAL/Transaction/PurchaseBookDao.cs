﻿using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction;
using PharmaBusinessObjects.Transaction.ReceiptPayment;
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




        public List<PurchaseBookAmount> DeleteTempPurchaseBookLineItem(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        {
            try
            {
                List<PurchaseBookAmount> purchaseBookAmounts = new List<PurchaseBookAmount>();              

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    SqlConnection connection = (SqlConnection)context.Database.Connection;

                    SqlCommand cmd = new SqlCommand("DeleteInvetoryLineItemInTempTable", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;                  
                
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PurchaseSaleBookHeaderID", Value = lineItem.PurchaseSaleBookHeaderID});
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PurchaseSaleBookLineItemID", Value = lineItem.PurchaseSaleBookLineItemID});

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            PurchaseBookAmount obj = new PurchaseBookAmount()
                            {
                                PurchaseSaleBookLineItemID = row["PurchaseSaleBookLineItemID"] == null ? 0 : Convert.ToInt64(row["PurchaseSaleBookLineItemID"]),
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

        public bool IsTempPurchaseHeaderExists(long purchaseBookHeaderID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.TempPurchaseSaleBookHeader.Any(p => p.PurchaseSaleBookHeaderID == purchaseBookHeaderID);
            }
        }

        public List<BillOutstanding> GetAllPurchaseInvoiceForSuppier(string supplierCode)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.BillOutStandings.Where(q => q.LedgerTypeCode == supplierCode)
                .Select(p => new PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding()
                {
                    BillOutStandingsID = p.BillOutStandingsID,
                    PurchaseSaleBookHeaderID = p.PurchaseSaleBookHeaderID,
                    VoucherNumber = p.VoucherNumber,
                    VoucherTypeCode = p.VoucherTypeCode,
                    VoucherDate = p.VoucherDate,
                    InvoiceNumber = p.PurchaseSaleBookHeader.PurchaseBillNo,
                    InvoiceDate = p.PurchaseSaleBookHeader.VoucherDate,
                    LedgerType = p.LedgerType,
                    LedgerTypeCode = p.LedgerTypeCode,
                    BillAmount = p.BillAmount,
                    OSAmount = p.OSAmount,
                    IsHold = p.IsHold,
                    HOLDRemarks = p.HOLDRemarks
                }).ToList();
            }
        }


        public PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader GetPurchaseSaleBookHeaderForModify(long purchaseSaleBookHeaderID)
        {
            PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader header = new PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("GetPurchaseSaleBookHeaderForModify", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PurchaseSaleBookHeaderID", Value = purchaseSaleBookHeaderID });             

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    header.PurchaseSaleBookHeaderID = Convert.ToInt64(dt.Rows[0]["PurchaseSaleBookHeaderID"]);
                    header.VoucherTypeCode = Convert.ToString(dt.Rows[0]["VoucherTypeCode"]);
                    header.VoucherDate = Convert.ToDateTime(dt.Rows[0]["VoucherDate"]);
                    header.PurchaseBillNo = Convert.ToString(dt.Rows[0]["PurchaseBillNo"]);
                    header.LedgerType = Convert.ToString(dt.Rows[0]["LedgerType"]);
                    header.LedgerTypeCode = Convert.ToString(dt.Rows[0]["LedgerTypeCode"]);
                    header.LocalCentral = Convert.ToString(dt.Rows[0]["LocalCentral"]);
                    header.OldPurchaseSaleBookHeaderID = Convert.ToInt64(dt.Rows[0]["OldPurchaseSaleBookHeaderID"]);
                    
                }
            }
            return header;
        }


        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> GetPurchaseSaleBookLineItemForModify(long purchaseSaleBookHeaderID)
        {
            List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> lineitems = new List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem>();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("GetPurchaseSaleBookLineItemsForModify", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PurchaseSaleBookHeaderID", Value = purchaseSaleBookHeaderID });


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem obj = new PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem()
                        {
                            PurchaseSaleBookHeaderID = Convert.ToInt64(row["PurchaseSaleBookHeaderID"]),
                            PurchaseSaleBookLineItemID = Convert.ToInt64(row["PurchaseSaleBookHeaderID"]),
                            FifoID = Convert.ToInt64(row["FifoID"] == DBNull.Value ? 0 : row["Quantity"]),
                            ItemCode = Convert.ToString(row["ItemCode"]),
                            Batch = Convert.ToString(row["Batch"]),
                            Quantity = Convert.ToDouble(row["Quantity"] == DBNull.Value ? 0 : row["Quantity"]),
                            FreeQuantity = Convert.ToDouble(row["FreeQuantity"] == DBNull.Value ? 0 : row["FreeQuantity"]),
                            PurchaseSaleRate = Convert.ToDouble(row["PurchaseSaleRate"] == DBNull.Value ? 0 : row["PurchaseSaleRate"]),
                            EffecivePurchaseSaleRate = Convert.ToDouble(row["EffecivePurchaseSaleRate"] == DBNull.Value ? 0 : row["EffecivePurchaseSaleRate"]),
                            PurchaseSaleTypeCode = Convert.ToString(row["PurchaseSaleTypeCode"]),
                            SurCharge = Convert.ToDouble(row["SurCharge"] == DBNull.Value ? 0 : row["SurCharge"]),
                            LocalCentral = Convert.ToString(row["LocalCentral"]),
                            SGST = Convert.ToDouble(row["SGST"]== DBNull.Value ? 0 : row["SGST"]),
                            IGST = Convert.ToDouble(row["IGST"]== DBNull.Value ? 0 : row["IGST"]),
                            CGST = Convert.ToDouble(row["CGST"]== DBNull.Value ? 0 : row["CGST"]),
                            Amount = Convert.ToDouble(row["Amount"]== DBNull.Value ? 0 : row["Amount"]),
                            Discount = Convert.ToDouble(row["Discount"]== DBNull.Value ? 0 : row["Discount"]),
                            SpecialDiscount = Convert.ToDouble(row["SpecialDiscount"]== DBNull.Value ? 0 : row["SpecialDiscount"]),
                            DiscountQuantity = Convert.ToDouble(row["DiscountQuantity"]== DBNull.Value ? 0 : row["DiscountQuantity"]),
                            VolumeDiscount = Convert.ToDouble(row["VolumeDiscount"]== DBNull.Value ? 0 : row["VolumeDiscount"]),
                            Scheme1 = Convert.ToDouble(row["Scheme1"]== DBNull.Value ? 0 : row["Scheme1"]),
                            Scheme2 = Convert.ToDouble(row["Scheme2"]== DBNull.Value ? 0 : row["Scheme2"]),
                            IsHalfScheme = Convert.ToBoolean(row["IsHalfScheme"] == DBNull.Value ? false : row["IsHalfScheme"]),
                            HalfSchemeRate = Convert.ToDouble(row["HalfSchemeRate"]== DBNull.Value ? 0 : row["HalfSchemeRate"]),
                            CostAmount = Convert.ToDouble(row["CostAmount"]== DBNull.Value ? 0 : row["CostAmount"]),
                            GrossAmount = Convert.ToDouble(row["GrossAmount"]== DBNull.Value ? 0 : row["GrossAmount"]),
                            SchemeAmount = Convert.ToDouble(row["SchemeAmount"]== DBNull.Value ? 0 : row["SchemeAmount"]),
                            DiscountAmount = Convert.ToDouble(row["DiscountAmount"]== DBNull.Value ? 0 : row["DiscountAmount"]),
                            SurchargeAmount = Convert.ToDouble(row["SurchargeAmount"]== DBNull.Value ? 0 : row["SurchargeAmount"]),
                            ConversionRate = Convert.ToDouble(row["ConversionRate"]== DBNull.Value ? 0 : row["ConversionRate"]),
                            MRP = Convert.ToDouble(row["MRP"]== DBNull.Value ? 0 : row["MRP"]),
                            ExpiryDate = Convert.ToDateTime(row["ExpiryDate"]),
                            SaleRate = Convert.ToDouble(row["SaleRate"]== DBNull.Value ? 0 : row["SaleRate"]),
                            WholeSaleRate = Convert.ToDouble(row["WholeSaleRate"]== DBNull.Value ? 0 : row["WholeSaleRate"]),
                            SpecialRate = Convert.ToDouble(row["SpecialRate"]== DBNull.Value ? 0 : row["SpecialRate"]),
                            TaxAmount = Convert.ToDouble(row["TaxAmount"]== DBNull.Value ? 0 : row["TaxAmount"]),
                            SpecialDiscountAmount = Convert.ToDouble(row["SpecialDiscountAmount"]== DBNull.Value ? 0 : row["SpecialDiscountAmount"]),
                            VolumeDiscountAmount = Convert.ToDouble(row["VolumeDiscountAmount"]== DBNull.Value ? 0 : row["VolumeDiscountAmount"]),
                            TotalDiscountAmount = Convert.ToDouble(row["TotalDiscountAmount"]== DBNull.Value ? 0 : row["TotalDiscountAmount"]),
                            OldPurchaseSaleBookLineItemID = Convert.ToInt64(row["OldPurchaseSaleBookLineItemID"]== DBNull.Value ? 0 : row["OldPurchaseSaleBookLineItemID"]),
                            BalanceQuantity = Convert.ToDouble(row["BalanceQuantity"]== DBNull.Value ? 0 : row["BalanceQuantity"]),
                            UsedQuantity = Convert.ToDouble(row["UsedQuantity"]== DBNull.Value ? 0 : row["UsedQuantity"])
                       };

                        lineitems.Add(obj);
                    }


                }
            }
            return lineitems;
        }



    }
}
