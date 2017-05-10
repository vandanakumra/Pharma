using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class PersonRouteMasterDao
    {
        public List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PersonRouteMaster.Select(p => new PharmaBusinessObjects.Master.PersonRouteMaster()
                {
                    PersonRouteID = p.PersonRouteID,
                    PersonRouteCode = p.PersonRouteCode,
                    PersonRouteName = p.PersonRouteName,
                    RecordTypeId = p.RecordTypeId,
                    RecordTypeNme = p.RecordType.RecordType1,                   
                    Status = p.Status,
                    SystemName = p.RecordType.SystemName
                }).ToList();
            }
        }

        public int AddPersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var maxPersonRouteMasterID = context.PersonRouteMaster.Where(q=>q.RecordTypeId == p.RecordTypeId).Count() + 1;

                var systemName = context.RecordType.Where(q => q.RecordTypeId == p.RecordTypeId).FirstOrDefault().SystemName;

                var personRouteCode = systemName + maxPersonRouteMasterID.ToString().PadLeft(3, '0');

                Entity.PersonRouteMaster table = new Entity.PersonRouteMaster()
                {
                    PersonRouteID = p.PersonRouteID,
                    PersonRouteCode = personRouteCode,
                    PersonRouteName = p.PersonRouteName,
                    RecordTypeId = p.RecordTypeId,
                    Status = p.Status
                };

                context.PersonRouteMaster.Add(table);
                return context.SaveChanges();
            }
        }

        public int UpdatePersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var personRouteMaster = context.PersonRouteMaster.Where(q => q.PersonRouteID == p.PersonRouteID).FirstOrDefault();

                    if (personRouteMaster != null)
                    {
                        personRouteMaster.PersonRouteCode = p.PersonRouteCode;
                        personRouteMaster.PersonRouteName = p.PersonRouteName;
                        personRouteMaster.Status = p.Status;
                    }

                    return context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutesByRecordTypeIdAndSearch(int recordTypeID, string searchString = null)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var personRoutes = (from p in context.PersonRouteMaster
                                      where (recordTypeID == 0 || p.RecordTypeId == recordTypeID)
                                      && (string.IsNullOrEmpty(searchString) || p.PersonRouteName.Contains(searchString))
                                      select new PharmaBusinessObjects.Master.PersonRouteMaster()
                                      {
                                          PersonRouteID = p.PersonRouteID,
                                          PersonRouteCode = p.PersonRouteCode,
                                          PersonRouteName = p.PersonRouteName,
                                          RecordTypeId = p.RecordTypeId,
                                          RecordTypeNme = p.RecordType.RecordType1,
                                          Status = p.Status,
                                          SystemName = p.RecordType.SystemName
                                      }).ToList();

                return personRoutes;

            }

        }


    }
}
