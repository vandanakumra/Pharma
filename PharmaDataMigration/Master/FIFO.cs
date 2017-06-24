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

                                PharmaDAL.Entity.FIFO newFIFO = new PharmaDAL.Entity.FIFO()
                                {
                                    PurchaseSaleBookHeaderID=null,
                                    VoucherNumber= (Convert.ToString(dr["vno"]).TrimEnd()).PadLeft(8, '0'),
                                    VoucherDate = Convert.ToDateTime(dr["vdt"]),
                                    SRLNO=Convert.ToInt32(dr["srlno"]),
                                    ItemCode=mappedItemCode,
                                    PurchaseBillNo= Convert.ToString(dr["pbillno"]).TrimEnd(),
                                    Batch = Convert.ToString(dr["batch"]).TrimEnd(),
                                    ExpiryDate= CommonMethods.SafeConversionDatetime(Convert.ToString(dr["expdt"]).TrimEnd()),
                                    Quantity = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["qty"]).TrimEnd()) ?? default(decimal),
                                    BalanceQuanity = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["bqty"]).TrimEnd()) ?? default(decimal),
                                    PurchaseTypeId=null,
                                    PurchaseRate= CommonMethods.SafeConversionDecimal(Convert.ToString(dr["prate"]).TrimEnd()) ?? default(decimal),
                                    EffectivePurchaseRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["eprate"]).TrimEnd()),                                
                                    SaleRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["srate"]).TrimEnd()) ?? default(decimal),
                                    WholeSaleRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["wsrate"]).TrimEnd()),
                                    SpecialRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["splrate"]).TrimEnd()),
                                    MRP = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["mrp"]).TrimEnd()) ?? default(decimal),
                                    Scheme1 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["scheme1"]).TrimEnd()),
                                    Scheme2 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["scheme2"]).TrimEnd()),
                                    IsOnHold= Convert.ToString(dr["hold"]).TrimEnd() == "Y" ? true : false,
                                    OnHoldRemarks=null,
                                    MfgDate= CommonMethods.SafeConversionDatetime(Convert.ToString(dr["mfgdt"]).TrimEnd()),
                                    UPC = Convert.ToString(dr["barcode"]).TrimEnd()
                                };

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
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

