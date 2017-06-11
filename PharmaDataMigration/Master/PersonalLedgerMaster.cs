using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;
using log4net;
using System.Reflection;

namespace PharmaDataMigration.Master
{
    public class PersonalLedgerMaster
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public PersonalLedgerMaster()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertPersonalLedgerMasterData()
        {
            try
            {
                string query = "select * from ACM where slcd = 'PD'";

                DataTable dtPersonalLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PersonalLedger> listPersonalLedgerMaster = new List<PharmaDAL.Entity.PersonalLedger>();

                int _result = 0;
                
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxPersonalLedgerID = context.PersonalLedger.Count();

                    if (dtPersonalLedgerMaster != null && dtPersonalLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtPersonalLedgerMaster.Rows)
                        {
                            try
                            {
                                maxPersonalLedgerID++;

                                string personalLedgerCode = "P" + maxPersonalLedgerID.ToString().PadLeft(6, '0');
                                string originalPersonalLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                                Common.personalLedgerCodeMap.Add(new PersonalLedgerCodeMap() { OriginalPersonalLedgerCode = originalPersonalLedgerCode, MappedPersonalLedgerCode = personalLedgerCode });

                                PharmaDAL.Entity.PersonalLedger newPersonalLedgerMaster = new PharmaDAL.Entity.PersonalLedger()
                                {
                                    PersonalLedgerCode = personalLedgerCode,
                                    PersonalLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                    PersonalLedgerShortName = Convert.ToString(dr["Alt_name_1"]).TrimEnd(),
                                    Address = string.Concat(Convert.ToString(dr["ACAD1"]).TrimEnd(), " ", Convert.ToString(dr["ACAD2"]).TrimEnd(), " ", Convert.ToString(dr["ACAD3"]).TrimEnd()),
                                    ContactPerson = Convert.ToString(dr["ACAD4"]).TrimEnd(),
                                    Mobile = Convert.ToString(dr["Mobile"]).TrimEnd(),
                                    //Pager = Convert.ToString(dr["Pager"]).TrimEnd(),
                                    //Fax = Convert.ToString(dr["Fax"]).TrimEnd(),
                                    OfficePhone = Convert.ToString(dr["Telo"]).TrimEnd(),
                                    ResidentPhone = Convert.ToString(dr["Telr"]).TrimEnd(),
                                    EmailAddress = Convert.ToString(dr["Email"]).TrimEnd(),
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now,
                                    PersonalLedgerShortDesc = Convert.ToString(dr["Alt_name_2"]).TrimEnd()
                                };

                                listPersonalLedgerMaster.Add(newPersonalLedgerMaster);
                            }
                            catch(Exception)
                            {
                                log.Info("PERSONAL LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).TrimEnd());
                            }
                        }
                    }

                    context.PersonalLedger.AddRange(listPersonalLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
