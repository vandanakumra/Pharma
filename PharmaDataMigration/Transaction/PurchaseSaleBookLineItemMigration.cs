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


        public int InsertData(DataTable dtSalePur)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                int _result = 0;

                List<PharmaDAL.Entity.PurchaseSaleBookLineItem> listPurchaseSaleBookLineItem = new List<PharmaDAL.Entity.PurchaseSaleBookLineItem>();

                if (dtSalePur != null && dtSalePur.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSalePur.Rows)
                    {
                        try
                        {
                            PharmaDAL.Entity.PurchaseSaleBookLineItem newPurchaseSaleBookLineItem = new PharmaDAL.Entity.PurchaseSaleBookLineItem();

                            string oldVNo = string.Empty;
                            string oldPVNo = string.Empty;

                            oldVNo = Convert.ToString(dr["vno"]).TrimEnd();
                            oldPVNo = Convert.ToString(dr["PURVNO"]).TrimEnd();

                            var header = Common.voucherNumberMap.Where(p => p.OriginalVoucherNumber == oldVNo).FirstOrDefault();

                            if (header != null)
                            {

                                string oldItemCode = Convert.ToString(dr["ITEMC"]);
                                string newItemCode = Common.itemCodeMap.Where(p => p.OriginalItemCode == oldItemCode).Select(p => p.MappedItemCode).FirstOrDefault();

                                if (string.IsNullOrEmpty(newItemCode))
                                {
                                    throw new Exception(string.Format("FIFO: Item Code Not found in Item Master {0}", oldItemCode));
                                }                              


                                string oldPSType = Convert.ToString(dr["PSTYPE"]);
                                string newPSType = Common.accountLedgerCodeMap.Where(p => p.OriginalAccountLedgerCode == oldPSType).Select(p => p.MappedAccountLedgerCode).FirstOrDefault();

                                if (!string.IsNullOrEmpty(newPSType))
                                {
                                    newPurchaseSaleBookLineItem.PurchaseSaleTypeCode = newPSType;
                                }

                                newPurchaseSaleBookLineItem.PurchaseSaleBookHeaderID = header.MappedPurchaseHeaderID;


                                //newPurchaseSaleBookLineItem.FifoID = 0;

                                if (dr["PURVDT"] != null)
                                {
                                    newPurchaseSaleBookLineItem.PurchaseBillDate = Convert.ToDateTime(dr["PURVDT"]);
                                }

                                if (!string.IsNullOrEmpty(oldPVNo))
                                {
                                    var pHeader = Common.voucherNumberMap.Where(p => p.OriginalVoucherNumber == oldPVNo).FirstOrDefault();
                                    newPurchaseSaleBookLineItem.PurchaseVoucherNumber = pHeader.MappedVoucherNumber;
                                }

                                newPurchaseSaleBookLineItem.PurchaseSrlNo = Convert.ToInt32(dr["PURSRLNO"]);


                                newPurchaseSaleBookLineItem.ItemCode = newItemCode;
                                newPurchaseSaleBookLineItem.Batch = Convert.ToString(dr["BATCH"]);
                                newPurchaseSaleBookLineItem.BatchNew = Convert.ToString(dr["BATCH1"]);
                                newPurchaseSaleBookLineItem.Quantity = Convert.ToInt32(dr["QTY"]);
                                newPurchaseSaleBookLineItem.FreeQuantity = Convert.ToInt32(dr["FQTY"]);
                                newPurchaseSaleBookLineItem.PurchaseSaleRate = Convert.ToDecimal(dr["PSRATE"]);


                                newPurchaseSaleBookLineItem.EffecivePurchaseSaleRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["EPSRATE"])) + CommonMethods.SafeConversionDecimal(Convert.ToString(dr["EPCOST"]));

                                newPurchaseSaleBookLineItem.SurCharge = Convert.ToDecimal(dr["SC"]);
                                newPurchaseSaleBookLineItem.SalePurchaseTax = Convert.ToDecimal(dr["TAX"]);
                                newPurchaseSaleBookLineItem.TaxAmount = dr["TAXAMT"] == null ? default(decimal) : Convert.ToDecimal(dr["TAXAMT"]);


                                newPurchaseSaleBookLineItem.LocalCentral = header.LocalCentral;                               

                                if (header.LocalCentral == "L")
                                {
                                    newPurchaseSaleBookLineItem.SGST = newPurchaseSaleBookLineItem.TaxAmount * (decimal)0.5;
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
                                newPurchaseSaleBookLineItem.HalfSchemeRate = Convert.ToDecimal(dr["HALFP"]);


                                newPurchaseSaleBookLineItem.CostAmount = 
                                    CommonMethods.SafeConversionDecimal(Convert.ToString(dr["EPSRATE"])) 
                                    + CommonMethods.SafeConversionDecimal(Convert.ToString(dr["EPCOST"]));//??

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
                            else
                            {
                                log.Info(string.Format("PurchaseSaleBookHeader: Error in VNo {0}}", Convert.ToString(dr["vno"]).TrimEnd()));
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex.Message);
                            log.Info(string.Format("PurchaseSaleBookLineItem: Error in Voucher Number {0}", Convert.ToString(dr["vno"]).TrimEnd()));
                        }
                    }
                }

                context.PurchaseSaleBookLineItem.AddRange(listPurchaseSaleBookLineItem);
                _result = context.SaveChanges();

                return _result;
            }
        }

        public int InsertPurchaseSaleBookLineItemData()
        {
            try
            {
                int _result = 0;

                foreach (var item in Common.voucherTypeMap)
                {
                    string query = string.Format("select * from SalePur2 WHERE VTYP = '{0}'",item.OriginalVoucherType);
                    DataTable dtSalePur = dbConnection.GetData(query);
                    if (dtSalePur != null && dtSalePur.Rows.Count > 0)
                    {
                        log.Info(string.Format("PurchaseSaleBookLineItem: Record Count For VType {0} is {1}", item.MappedVoucherType , dtSalePur.Rows.Count));

                        _result += InsertData(dtSalePur);
                    }
                }

                return _result;
            }
            catch (DbEntityValidationException ex)
            {
                log.Info(string.Format("PurchaseSaleBookLineItem: Error {0}", ex.Message));

                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                log.Info(exceptionMessage);

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
