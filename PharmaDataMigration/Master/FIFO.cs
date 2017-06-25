using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;
using log4net;
using System.Reflection;
using System.Windows.Forms;
using System.Data.Entity.Validation;
using PharmaBusinessObjects.Common;

namespace PharmaDataMigration.Master
{
    public class FIFO
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public FIFO()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertFIFOData()
        {
            try
            {
                string query = "select * from FIFO";
                DataTable dtFIFO = dbConnection.GetData(query);

                List<PharmaDAL.Entity.FIFO> listFIFO = new List<PharmaDAL.Entity.FIFO>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtFIFO != null && dtFIFO.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtFIFO.Rows)
                        {
                            try
                            {
                                string originalItemCode = Convert.ToString(dr["itemc"]).TrimEnd();
                                string mappedItemCode = Common.itemCodeMap.Where(x => x.OriginalItemCode == originalItemCode).Select(x => x.MappedItemCode).FirstOrDefault();

                                if(mappedItemCode == null)
                                {
                                    log.Error(string.Format("FIFO: Item Code Not found in Item Master {0}", originalItemCode));
                                    throw new Exception();
                                }

                                PharmaDAL.Entity.FIFO newFIFO = new PharmaDAL.Entity.FIFO();

                                newFIFO.PurchaseSaleBookHeaderID = null;
                                newFIFO.VoucherNumber = (Convert.ToString(dr["vno"]).TrimEnd()).PadLeft(8, '0');
                                newFIFO.VoucherDate = Convert.ToDateTime(dr["vdt"]);
                                newFIFO.SRLNO = Convert.ToInt32(dr["srlno"]);
                                newFIFO.ItemCode = mappedItemCode;
                                newFIFO.PurchaseBillNo = Convert.ToString(dr["pbillno"]).TrimEnd();
                                newFIFO.Batch = Convert.ToString(dr["batch"]).TrimEnd();
                                newFIFO.ExpiryDate = CommonMethods.SafeConversionDatetime(Convert.ToString(dr["expdt"]).TrimEnd());
                                newFIFO.Quantity = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["qty"]).TrimEnd()) ?? default(decimal);
                                newFIFO.BalanceQuanity = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["bqty"]).TrimEnd()) ?? default(decimal);
                                newFIFO.PurchaseTypeId = null;
                                newFIFO.PurchaseRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["prate"]).TrimEnd()) ?? default(decimal);
                                newFIFO.EffectivePurchaseRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["eprate"]).TrimEnd());
                                newFIFO.SaleRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["srate"]).TrimEnd()) ?? default(decimal);
                                newFIFO.WholeSaleRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["wsrate"]).TrimEnd());
                                newFIFO.SpecialRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["splrate"]).TrimEnd());
                                newFIFO.MRP = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["mrp"]).TrimEnd()) ?? default(decimal);
                                newFIFO.Scheme1 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["scheme1"]).TrimEnd());
                                newFIFO.Scheme2 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["scheme2"]).TrimEnd());
                                newFIFO.IsOnHold = Convert.ToString(dr["hold"]).TrimEnd() == "Y" ? true : false;
                                newFIFO.OnHoldRemarks = null;
                                newFIFO.MfgDate = CommonMethods.SafeConversionDatetime(Convert.ToString(dr["mfgdt"]).TrimEnd());
                                newFIFO.UPC = Convert.ToString(dr["barcode"]).TrimEnd();


                                listFIFO.Add(newFIFO);
                            }
                            catch (Exception ex)
                            {
                                log.Info(string.Format("FIFO: Error in Voucher Number {0}", Convert.ToString(dr["vno"]).TrimEnd()));
                            }
                        }
                    }

                    context.FIFO.AddRange(listFIFO);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (DbEntityValidationException ex)
            {
                log.Info(string.Format("FIFO: Error {0}", ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
               
                log.Info(string.Format("FIFO: Error {0}", ex.Message));
                throw ex;
            }
        }

    }
}

