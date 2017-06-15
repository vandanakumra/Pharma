using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;
using log4net;
using System.Reflection;
using System.Windows.Forms;
using System.Data.Entity.Validation;

namespace PharmaDataMigration.Master
{
    public class CompanyMaster
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public CompanyMaster()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertCompanyMasterData()
        {
            try
            {
                string query = "select * from MASTERS where slcd = 'CO'";

                DataTable dtCompanyMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.CompanyMaster> listCompanyMaster = new List<PharmaDAL.Entity.CompanyMaster>();
                
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    List<string> companyCodeList = context.CompanyMaster.Select(p => p.CompanyCode).ToList();
                    int maxCompanyCode = companyCodeList.Count > 0 ? companyCodeList.Max(p => Convert.ToInt32(p)) : 0;
                    
                    if (dtCompanyMaster != null && dtCompanyMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtCompanyMaster.Rows)
                        {
                            try
                            {
                                maxCompanyCode++;

                                string companyCode = maxCompanyCode.ToString().PadLeft(6, '0');
                                string originalCompanyCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                                Common.companyCodeMap.Add(new CompanyCodeMap() { OriginalCompanyCode = originalCompanyCode, MappedCompanyCode = companyCode });

                                PharmaDAL.Entity.CompanyMaster newCompanyMaster = new PharmaDAL.Entity.CompanyMaster()
                                {
                                    CompanyCode = companyCode,
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    StockSummaryRequired = Convert.ToChar(dr["SSR"]) == 'Y' ? true : false,
                                    //IsDirect = Convert.ToChar(dr["HALF"]) == 'D' ? true : false,
                                    OrderPreferenceRating = Convert.ToInt32(dr["CONVRATE"]),
                                    BillingPreferenceRating = Convert.ToInt32(dr["DISQTY"]),
                                    CompanyName = Convert.ToString(dr["ACNAME"]).TrimEnd(),
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now
                                };

                                listCompanyMaster.Add(newCompanyMaster);
                            }
                            catch (Exception)
                            {
                                log.Info("COMPANY MASTER : Error in ACName --> " + Convert.ToString(dr["ACName"]).TrimEnd());
                            }
                        }
                    }

                    context.CompanyMaster.AddRange(listCompanyMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch(DbEntityValidationException ex)
            {
                throw new  Exception( string.Join(",", ex.EntityValidationErrors.Select(p => p.ValidationErrors.Select(q => q.ErrorMessage))));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
