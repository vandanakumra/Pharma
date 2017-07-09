using log4net;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PharmaDataMigration.Transaction
{
    public class PurchaseSaleBookLineItemMigration
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public PurchaseSaleBookLineItemMigration()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertPurchaseSaleBookLineItemData()
        {
            try
            {
                string query = "select * from SalePur2";
                DataTable dtSalePur = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PurchaseSaleBookLineItem> listPurchaseSaleBookLineItem = new List<PharmaDAL.Entity.PurchaseSaleBookLineItem>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtSalePur != null && dtSalePur.Rows.Count > 0)
                    {    
                        foreach (DataRow dr in dtSalePur.Rows)
                        {
                            try
                            {
                                PharmaDAL.Entity.PurchaseSaleBookLineItem newPurchaseSaleBookLineItem = new PharmaDAL.Entity.PurchaseSaleBookLineItem();

                                string oldVNo = Convert.ToString(dr["vno"]).TrimEnd();
                                string oldPVNo = Convert.ToString(dr["PURVNO"]).TrimEnd();                               

                                var header = Common.voucherNumberMap.Where(p => p.OriginalVoucherNumber == oldVNo).FirstOrDefault();
                                var pHeader = Common.voucherNumberMap.Where(p => p.OriginalVoucherNumber == oldPVNo).FirstOrDefault();

                                string oldItemCode = Convert.ToString(dr["ITEMC"]);
                                string newItemCode = Common.itemCodeMap.Where(p => p.OriginalItemCode == oldItemCode).Select(p => p.MappedItemCode).FirstOrDefault();

                                string oldPSType  = Convert.ToString(dr["PSTYPE"]);
                                string newPSType = Common.accountLedgerCodeMap.Where(p => p.OriginalAccountLedgerCode == oldPSType).Select(p => p.MappedAccountLedgerCode).FirstOrDefault();

                                newPurchaseSaleBookLineItem.PurchaseSaleBookHeaderID = header.MappedPurchaseHeaderID;
                                newPurchaseSaleBookLineItem.FifoID = 0;
                                newPurchaseSaleBookLineItem.PurchaseBillDate = Convert.ToDateTime(dr["PURVDT"]);
                                newPurchaseSaleBookLineItem.PurchaseVoucherNumber = pHeader.MappedVoucherNumber;
                                newPurchaseSaleBookLineItem.PurchaseSrlNo = Convert.ToInt32(dr["PURSRLNO"]);
                                newPurchaseSaleBookLineItem.ItemCode = newItemCode;
                                newPurchaseSaleBookLineItem.Batch = Convert.ToString(dr["BATCH"]);
                                newPurchaseSaleBookLineItem.BatchNew = Convert.ToString(dr["BATCH1"]);
                                newPurchaseSaleBookLineItem.Quantity = Convert.ToInt32(dr["QTY"]);
                                newPurchaseSaleBookLineItem.FreeQuantity = Convert.ToInt32(dr["FQTY"]);
                                newPurchaseSaleBookLineItem.PurchaseSaleRate = Convert.ToDecimal(dr["PSRATE"]);
                                newPurchaseSaleBookLineItem.EffecivePurchaseSaleRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["EPSRATE"])) + CommonMethods.SafeConversionDecimal(Convert.ToString(dr["EPCOST"]));
                                newPurchaseSaleBookLineItem.PurchaseSaleTypeCode = newPSType;
                                newPurchaseSaleBookLineItem.SurCharge = Convert.ToDecimal(dr["SC"]);
                                newPurchaseSaleBookLineItem.SalePurchaseTax = Convert.ToDecimal(dr["TAX"]);
                                newPurchaseSaleBookLineItem.TaxAmount = dr["TAXAMT"] == null ? default(decimal) : Convert.ToDecimal(dr["TAXAMT"]);

                                if (dr["SALE_LORC"] == null || string.IsNullOrEmpty(Convert.ToString(dr["SALE_LORC"])))
                                {
                                    newPurchaseSaleBookLineItem.LocalCentral = "L";
                                }
                                else
                                {
                                    newPurchaseSaleBookLineItem.LocalCentral = Convert.ToString(dr["SALE_LORC"]);
                                }

                                if(newPurchaseSaleBookLineItem.LocalCentral == "L")
                                {
                                    newPurchaseSaleBookLineItem.SGST = newPurchaseSaleBookLineItem.TaxAmount * (decimal)0.5 ;                                   
                                    newPurchaseSaleBookLineItem.CGST = newPurchaseSaleBookLineItem.TaxAmount * (decimal)0.5;
                                }
                                else
                                {
                                    newPurchaseSaleBookLineItem.IGST = newPurchaseSaleBookLineItem.TaxAmount;
                                }                             
                              
                                
                                newPurchaseSaleBookLineItem.Amount = Convert.ToDecimal(dr["SALEAMT"]); //  PSSRATE * QYTY = GROSS = SALEAMT

                                newPurchaseSaleBookLineItem.Discount = Convert.ToDecimal(dr["DIS"]);
                                newPurchaseSaleBookLineItem.SpecialDiscount = Convert.ToDecimal(dr["SPLDIS"]);
                                newPurchaseSaleBookLineItem.DiscountQuantity = Convert.ToDecimal(dr["DISQTY"]);
                                newPurchaseSaleBookLineItem.VolumeDiscount = Convert.ToDecimal(dr["VDIS"]);
                                newPurchaseSaleBookLineItem.Scheme1 = Convert.ToDecimal(dr["SCHEME1"]);
                                newPurchaseSaleBookLineItem.Scheme2 = Convert.ToDecimal(dr["SCHEME2"]);
                                newPurchaseSaleBookLineItem.IsHalfScheme = Convert.ToString(dr["HALF"]) == "Y" ? true : false;//  Convert.ToBoolean(dr["HALF"]); // ???
                                newPurchaseSaleBookLineItem.HalfSchemeRate =    Convert.ToDecimal(dr["HALFP"]);


                                newPurchaseSaleBookLineItem.CostAmount = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["EPSRATE"])) + CommonMethods.SafeConversionDecimal(Convert.ToString(dr["EPCOST"]));//??
                                newPurchaseSaleBookLineItem.GrossAmount = Convert.ToDecimal(dr["SALEAMT"]); 
                                newPurchaseSaleBookLineItem.SchemeAmount = Convert.ToDecimal(dr["SCAMT"]);
                                newPurchaseSaleBookLineItem.DiscountAmount = Convert.ToDecimal(dr["DISAMT"]);
                                newPurchaseSaleBookLineItem.SurchargeAmount = Convert.ToDecimal(dr["SCAMT"]);
                                newPurchaseSaleBookLineItem.ConversionRate = Convert.ToDecimal(dr["CONVRATE"]);
                                newPurchaseSaleBookLineItem.MRP = Convert.ToDecimal(dr["MRP"]);

                               // newPurchaseSaleBookLineItem.MfgDate = Convert.ToDateTime(dr["MRP"]);
                                newPurchaseSaleBookLineItem.ExpiryDate = CommonMethods.SafeConversionDatetime(Convert.ToString(dr["EXPDT"]));
                                newPurchaseSaleBookLineItem.SaleRate = 0;//Convert.ToDecimal(dr["MRP"]); //??
                                newPurchaseSaleBookLineItem.WholeSaleRate = Convert.ToDecimal(dr["WSRATE"]);
                                newPurchaseSaleBookLineItem.SpecialRate = Convert.ToDecimal(dr["SPLRATE"]);

                               
                                newPurchaseSaleBookLineItem.SpecialDiscountAmount = 0;// Convert.ToDecimal(dr["SPLRATE"]);
                                newPurchaseSaleBookLineItem.VolumeDiscountAmount = 0;// Convert.ToDecimal(dr["SPLRATE"]);
                                newPurchaseSaleBookLineItem.TotalDiscountAmount = Convert.ToDecimal(dr["DISAMT"]);


                                newPurchaseSaleBookLineItem.CreatedBy = "admin";
                                newPurchaseSaleBookLineItem.CreatedOn = DateTime.Now;
                                newPurchaseSaleBookLineItem.ModifiedBy = "admin";
                                newPurchaseSaleBookLineItem.ModifiedOn = DateTime.Now;

                                listPurchaseSaleBookLineItem.Add(newPurchaseSaleBookLineItem);
                            }
                            catch (Exception ex)
                            {
                                log.Info(string.Format("PurchaseSaleBookLineItem: Error in Voucher Number {0}", Convert.ToString(dr["vno"]).TrimEnd()));
                            }
                        }
                    }

                    context.PurchaseSaleBookLineItem.AddRange(listPurchaseSaleBookLineItem);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (DbEntityValidationException ex)
            {
                log.Info(string.Format("PurchaseSaleBookHeader: Error {0}", ex.Message));
                log.Info(string.Format("{0}{1}Validation errors:{1}{2}", ex, Environment.NewLine, ex.EntityValidationErrors.Select(e => string.Join(Environment.NewLine, e.ValidationErrors.Select(v => string.Format("{0} - {1}", v.PropertyName, v.ErrorMessage))))));

                throw ex;
            }
            catch (Exception ex)
            {

                log.Info(string.Format("PurchaseSaleBookLineItem: Error {0}", ex.Message));
                throw ex;
            }
        }


    }
}
