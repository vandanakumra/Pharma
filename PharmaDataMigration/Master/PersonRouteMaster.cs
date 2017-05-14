using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;

namespace PharmaDataMigration.Master
{
    public class PersonRouteMaster
    {
        private DBFConnectionManager dbConnection;

        public PersonRouteMaster()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertASMData()
        {
            try
            {
                string query = "select * from MASTERS where slcd = 'AS'";

                DataTable dtASMMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PersonRouteMaster> listASMMaster = new List<PharmaDAL.Entity.PersonRouteMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var systemName = PharmaBusinessObjects.Common.Constants.RecordType.ASM;
                    int recordTypeID = context.RecordType.Where(q => q.SystemName == systemName).FirstOrDefault().RecordTypeId;
                    var maxASMID = context.PersonRouteMaster.Where(q => q.RecordTypeId == recordTypeID).Count();

                    if (dtASMMaster != null && dtASMMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtASMMaster.Rows)
                        {
                            maxASMID++;

                            PharmaDAL.Entity.PersonRouteMaster newASMMaster = new PharmaDAL.Entity.PersonRouteMaster()
                            {
                                PersonRouteCode = systemName + maxASMID.ToString().PadLeft(3, '0'), //Convert.ToString(dr["ACNO"]),
                                PersonRouteName = Convert.ToString(dr["ACName"]),
                                RecordTypeId = recordTypeID,
                                CreatedBy = "admin",
                                CreatedOn = System.DateTime.Now,
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true
                            };

                            listASMMaster.Add(newASMMaster);
                        }
                    }

                    context.PersonRouteMaster.AddRange(listASMMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertRSMData()
        {
            try
            {
                string query = "select * from MASTERS where slcd = 'RS'";

                DataTable dtRSMMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PersonRouteMaster> listRSMMaster = new List<PharmaDAL.Entity.PersonRouteMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var systemName = PharmaBusinessObjects.Common.Constants.RecordType.RSM;
                    int recordTypeID = context.RecordType.Where(q => q.SystemName == systemName).FirstOrDefault().RecordTypeId;
                    var maxRSMID = context.PersonRouteMaster.Where(q => q.RecordTypeId == recordTypeID).Count();

                    if (dtRSMMaster != null && dtRSMMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtRSMMaster.Rows)
                        {
                            maxRSMID++;

                            PharmaDAL.Entity.PersonRouteMaster newRSMMaster = new PharmaDAL.Entity.PersonRouteMaster()
                            {
                                PersonRouteCode = systemName + maxRSMID.ToString().PadLeft(3, '0'), //Convert.ToString(dr["ACNO"]),
                                PersonRouteName = Convert.ToString(dr["ACName"]),
                                RecordTypeId = recordTypeID,
                                CreatedBy = "admin",
                                CreatedOn = System.DateTime.Now,
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true
                            };

                            listRSMMaster.Add(newRSMMaster);
                        }
                    }

                    context.PersonRouteMaster.AddRange(listRSMMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertZSMData()
        {
            try
            {
                string query = "select * from MASTERS where slcd = 'ZS'";

                DataTable dtZSMMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PersonRouteMaster> listZSMMaster = new List<PharmaDAL.Entity.PersonRouteMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var systemName = PharmaBusinessObjects.Common.Constants.RecordType.ZSM;
                    int recordTypeID = context.RecordType.Where(q => q.SystemName == systemName).FirstOrDefault().RecordTypeId;
                    var maxZSMID = context.PersonRouteMaster.Where(q => q.RecordTypeId == recordTypeID).Count();

                    if (dtZSMMaster != null && dtZSMMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtZSMMaster.Rows)
                        {
                            maxZSMID++;

                            PharmaDAL.Entity.PersonRouteMaster newZSMMaster = new PharmaDAL.Entity.PersonRouteMaster()
                            {
                                PersonRouteCode = systemName + maxZSMID.ToString().PadLeft(3, '0'), //Convert.ToString(dr["ACNO"]),
                                PersonRouteName = Convert.ToString(dr["ACName"]),
                                RecordTypeId = recordTypeID,
                                CreatedBy = "admin",
                                CreatedOn = System.DateTime.Now,
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true
                            };

                            listZSMMaster.Add(newZSMMaster);
                        }
                    }

                    context.PersonRouteMaster.AddRange(listZSMMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertAreaData()
        {
            try
            {
                string query = "select * from MASTERS where slcd = 'AR'";

                DataTable dtAreaMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PersonRouteMaster> listAreaMaster = new List<PharmaDAL.Entity.PersonRouteMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var systemName = PharmaBusinessObjects.Common.Constants.RecordType.AREA;
                    int recordTypeID = context.RecordType.Where(q => q.SystemName == systemName).FirstOrDefault().RecordTypeId;
                    var maxAreaID = context.PersonRouteMaster.Where(q => q.RecordTypeId == recordTypeID).Count();

                    if (dtAreaMaster != null && dtAreaMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtAreaMaster.Rows)
                        {
                            maxAreaID++;

                            PharmaDAL.Entity.PersonRouteMaster newAreaMaster = new PharmaDAL.Entity.PersonRouteMaster()
                            {
                                PersonRouteCode = systemName + maxAreaID.ToString().PadLeft(3, '0'), //Convert.ToString(dr["ACNO"]),
                                PersonRouteName = Convert.ToString(dr["ACName"]),
                                RecordTypeId = recordTypeID,
                                CreatedBy = "admin",
                                CreatedOn = System.DateTime.Now,
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true
                            };

                            listAreaMaster.Add(newAreaMaster);
                        }
                    }

                    context.PersonRouteMaster.AddRange(listAreaMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertRouteData()
        {
            try
            {
                string query = "select * from MASTERS where slcd = 'RT'";

                DataTable dtRouteMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PersonRouteMaster> listRouteMaster = new List<PharmaDAL.Entity.PersonRouteMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var systemName = PharmaBusinessObjects.Common.Constants.RecordType.ROUTE;
                    int recordTypeID = context.RecordType.Where(q => q.SystemName == systemName).FirstOrDefault().RecordTypeId;
                    var maxRouteID = context.PersonRouteMaster.Where(q => q.RecordTypeId == recordTypeID).Count();

                    if (dtRouteMaster != null && dtRouteMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtRouteMaster.Rows)
                        {
                            maxRouteID++;

                            PharmaDAL.Entity.PersonRouteMaster newRouteMaster = new PharmaDAL.Entity.PersonRouteMaster()
                            {
                                PersonRouteCode = systemName + maxRouteID.ToString().PadLeft(3, '0'), //Convert.ToString(dr["ACNO"]),
                                PersonRouteName = Convert.ToString(dr["ACName"]),
                                RecordTypeId = recordTypeID,
                                CreatedBy = "admin",
                                CreatedOn = System.DateTime.Now,
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true
                            };

                            listRouteMaster.Add(newRouteMaster);
                        }
                    }

                    context.PersonRouteMaster.AddRange(listRouteMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertSalesManData()
        {
            try
            {
                string query = "select * from MASTERS where slcd = 'SM'";

                DataTable dtSalesManMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PersonRouteMaster> listSalesManMaster = new List<PharmaDAL.Entity.PersonRouteMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var systemName = PharmaBusinessObjects.Common.Constants.RecordType.SALESMAN;
                    int recordTypeID = context.RecordType.Where(q => q.SystemName == systemName).FirstOrDefault().RecordTypeId;
                    var maxSalesManID = context.PersonRouteMaster.Where(q => q.RecordTypeId == recordTypeID).Count();

                    if (dtSalesManMaster != null && dtSalesManMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtSalesManMaster.Rows)
                        {
                            maxSalesManID++;

                            PharmaDAL.Entity.PersonRouteMaster newSalesManMaster = new PharmaDAL.Entity.PersonRouteMaster()
                            {
                                PersonRouteCode = systemName + maxSalesManID.ToString().PadLeft(3, '0'), //Convert.ToString(dr["ACNO"]),
                                PersonRouteName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                RecordTypeId = recordTypeID,
                                CreatedBy = "admin",
                                CreatedOn = System.DateTime.Now,
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true
                            };

                            listSalesManMaster.Add(newSalesManMaster);
                        }
                    }

                    context.PersonRouteMaster.AddRange(listSalesManMaster);
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
