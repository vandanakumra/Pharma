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
                                PharmaDAL.Entity.FIFO newFIFO = new PharmaDAL.Entity.FIFO()
                                {

                                };

                                listFIFO.Add(newFIFO);
                            }
                            catch (Exception)
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

