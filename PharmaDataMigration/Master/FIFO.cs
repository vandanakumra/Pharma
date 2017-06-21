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
                                    ExpiryDate= ! String.IsNullOrWhiteSpace(Convert.ToString(dr["expdt"]).TrimEnd()) ? Convert.ToDateTime(dr["expdt"]) : (DateTime?)null,
                                    Quantity = !String.IsNullOrWhiteSpace(Convert.ToString(dr["qty"]).TrimEnd()) ? Convert.ToDecimal(dr["qty"]) : default(decimal),
                                    BalanceQuanity = !String.IsNullOrWhiteSpace(Convert.ToString(dr["bqty"]).TrimEnd()) ? Convert.ToDecimal(dr["bqty"]) : default(decimal),
                                    PurchaseTypeId=null,
                                    PurchaseRate= !String.IsNullOrWhiteSpace(Convert.ToString(dr["prate"]).TrimEnd()) ? Convert.ToDecimal(dr["prate"]) : default(decimal),
                                    EffectivePurchaseRate = !String.IsNullOrWhiteSpace(Convert.ToString(dr["eprate"]).TrimEnd()) ? Convert.ToDecimal(dr["eprate"]) : default(decimal),
                                    SaleRate = !String.IsNullOrWhiteSpace(Convert.ToString(dr["srate"]).TrimEnd()) ? Convert.ToDecimal(dr["srate"]) : default(decimal),
                                    WholeSaleRate = !String.IsNullOrWhiteSpace(Convert.ToString(dr["wsrate"]).TrimEnd()) ? Convert.ToDecimal(dr["wsrate"]) : default(decimal),
                                    SpecialRate = !String.IsNullOrWhiteSpace(Convert.ToString(dr["splrate"]).TrimEnd()) ? Convert.ToDecimal(dr["splrate"]) : default(decimal),
                                    MRP = Convert.ToDecimal(dr["mrp"]),
                                    Scheme1 = !String.IsNullOrWhiteSpace(Convert.ToString(dr["scheme1"]).TrimEnd()) ? Convert.ToDecimal(dr["scheme1"]) : default(decimal),
                                    Scheme2 = !String.IsNullOrWhiteSpace(Convert.ToString(dr["scheme2"]).TrimEnd()) ? Convert.ToDecimal(dr["scheme2"]) : default(decimal),
                                    IsOnHold= Convert.ToString(dr["hold"]).TrimEnd() == "Y" ? true : false,
                                    OnHoldRemarks=null,
                                    MfgDate= !String.IsNullOrWhiteSpace(Convert.ToString(dr["mfgdt"]).TrimEnd()) ? Convert.ToDateTime(dr["mfgdt"]) : (DateTime?)null,
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
                throw new Exception(string.Join(",", ex.EntityValidationErrors.Select(p => p.ValidationErrors.Select(q => q.ErrorMessage))));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

