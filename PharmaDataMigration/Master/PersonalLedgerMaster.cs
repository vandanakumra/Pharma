using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;

namespace PharmaDataMigration.Master
{
    public class PersonalLedgerMaster
    {
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
                    var maxPersonalLedgerID = context.PersonalLedger.Count() > 0 ? context.PersonalLedger.Max(q => q.PersonalLedgerId) : 0;

                    if (dtPersonalLedgerMaster != null && dtPersonalLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtPersonalLedgerMaster.Rows)
                        {
                            maxPersonalLedgerID++;

                            string personalLedgerCode = "P" + maxPersonalLedgerID.ToString().PadLeft(6, '0');
                            string originalPersonalLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            Common.personalLedgerCodeMap.Add(new PersonalLedgerCodeMap() { OriginalPersonalLedgerCode = originalPersonalLedgerCode, MappedPersonalLedgerCode = personalLedgerCode });

                            PharmaDAL.Entity.PersonalLedger newPersonalLedgerMaster = new PharmaDAL.Entity.PersonalLedger()
                            {
                                PersonalLedgerCode = personalLedgerCode,
                                PersonalLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                PersonalLedgerShortName = Convert.ToString(dr["ACNO"]).TrimEnd(),
                                Address = string.Concat(Convert.ToString(dr["ACAD1"]).TrimEnd(), " ", Convert.ToString(dr["ACAD2"]).TrimEnd(), " ", Convert.ToString(dr["ACAD3"]).TrimEnd()),
                                ContactPerson = Convert.ToString(dr["ACAD4"]).TrimEnd(),
                                Mobile = Convert.ToString(dr["Mobile"]).TrimEnd(),
                                Pager = Convert.ToString(dr["Pager"]).TrimEnd(),
                                Fax = Convert.ToString(dr["Fax"]).TrimEnd(),
                                OfficePhone = Convert.ToString(dr["Telo"]).TrimEnd(),
                                ResidentPhone = Convert.ToString(dr["Telr"]).TrimEnd(),
                                EmailAddress = Convert.ToString(dr["Email"]).TrimEnd(),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now
                            };

                            listPersonalLedgerMaster.Add(newPersonalLedgerMaster);
                        }
                    }

                    context.PersonalLedger.AddRange(listPersonalLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
