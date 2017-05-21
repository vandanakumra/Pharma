using PharmaBusinessObjects.Master;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class SupplierLedgerMasterDao : BaseDao
    {
        public SupplierLedgerMasterDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<PharmaBusinessObjects.Master.SupplierLedgerMaster> GetSupplierLedgers(string searchText)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.SupplierLedger.Where(p=>p.SupplierLedgerName.Contains(searchText)).Select(p => new PharmaBusinessObjects.Master.SupplierLedgerMaster()
                {
                    SupplierLedgerId = p.SupplierLedgerId,
                    SupplierLedgerCode = p.SupplierLedgerCode,
                    SupplierLedgerName = p.SupplierLedgerName,
                    SupplierLedgerShortName = p.SupplierLedgerShortName,
                    Address = p.Address,
                    ContactPerson = p.ContactPerson,
                    Mobile = p.Mobile,
                    Pager = p.Pager,
                    Fax = p.Fax,
                    OfficePhone = p.OfficePhone,
                    ResidentPhone = p.ResidentPhone,
                    EmailAddress = p.EmailAddress,                   
                    AreaId = p.AreaId,
                    AreaName = p.PersonRouteMaster.PersonRouteName,
                    CreditDebit = p.CreditDebit,
                    DLNo = p.DLNo,
                    OpeningBal = p.OpeningBal,
                    TaxRetail = p.TaxRetail,
                    TINNo = p.TINNo,
                    Status = p.Status
                }).ToList();
            }

        }

        public SupplierLedgerMaster GetSupplierLedgerById(int supplierId)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.SupplierLedger.Where(p => p.SupplierLedgerId == supplierId).Select(p => new PharmaBusinessObjects.Master.SupplierLedgerMaster()
                {
                    SupplierLedgerId = p.SupplierLedgerId,
                    SupplierLedgerCode = p.SupplierLedgerCode,
                    SupplierLedgerName = p.SupplierLedgerName,
                    SupplierLedgerShortName = p.SupplierLedgerShortName,
                    Address = p.Address,
                    ContactPerson = p.ContactPerson,
                    Mobile = p.Mobile,
                    Pager = p.Pager,
                    Fax = p.Fax,
                    OfficePhone = p.OfficePhone,
                    ResidentPhone = p.ResidentPhone,
                    EmailAddress = p.EmailAddress,
                    AreaId = p.AreaId,
                    AreaName = p.PersonRouteMaster.PersonRouteName,
                    CreditDebit = p.CreditDebit,
                    DLNo = p.DLNo,
                    OpeningBal = p.OpeningBal,
                    TaxRetail = p.TaxRetail,
                    TINNo = p.TINNo,
                    Status = p.Status
                }).FirstOrDefault();

            }
        }

        public int AddSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {


                    var maxSupplierLedgerID = context.SupplierLedger.Count() + 1;

                    var supplierLedgerCode = "S" + maxSupplierLedgerID.ToString().PadLeft(6, '0');

                    Entity.SupplierLedger table = new Entity.SupplierLedger()
                    {
                        SupplierLedgerCode = supplierLedgerCode,
                        SupplierLedgerName = p.SupplierLedgerName,
                        SupplierLedgerShortName = p.SupplierLedgerShortName,
                        Address = p.Address,
                        ContactPerson = p.ContactPerson,
                        Mobile = p.Mobile,
                        Pager = p.Pager,
                        Fax = p.Fax,
                        OfficePhone = p.OfficePhone,
                        ResidentPhone = p.ResidentPhone,
                        EmailAddress = p.EmailAddress,
                        AreaId = p.AreaId,
                        CreditDebit = p.CreditDebit,
                        DLNo = p.DLNo,
                        OpeningBal = p.OpeningBal,
                        TaxRetail = p.TaxRetail,
                        PurchaseTypeID = p.PurchaseTypeId,
                        TINNo = p.TINNo,
                        Status = p.Status,
                        CreatedBy = this.LoggedInUser.Username,
                        CreatedOn = System.DateTime.Now
                    };

                    context.SupplierLedger.Add(table);
                    return context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
            }
        }

        public int UpdateSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var supplierLedgerMaster = context.SupplierLedger.Where(q => q.SupplierLedgerId == p.SupplierLedgerId).FirstOrDefault();

                    if (supplierLedgerMaster != null)
                    {                      
                        supplierLedgerMaster.SupplierLedgerName = p.SupplierLedgerName;
                        supplierLedgerMaster.SupplierLedgerShortName = p.SupplierLedgerShortName;
                        supplierLedgerMaster.Address = p.Address;
                        supplierLedgerMaster.ContactPerson = p.ContactPerson;
                        supplierLedgerMaster.Mobile = p.Mobile;
                        supplierLedgerMaster.Pager = p.Pager;
                        supplierLedgerMaster.Fax = p.Fax;
                        supplierLedgerMaster.OfficePhone = p.OfficePhone;
                        supplierLedgerMaster.ResidentPhone = p.ResidentPhone;
                        supplierLedgerMaster.EmailAddress = p.EmailAddress;
                        supplierLedgerMaster.AreaId = p.AreaId;
                        supplierLedgerMaster.CreditDebit = p.CreditDebit;
                        supplierLedgerMaster.DLNo = p.DLNo;
                        supplierLedgerMaster.OpeningBal = p.OpeningBal;
                        supplierLedgerMaster.TaxRetail = p.TaxRetail;
                        supplierLedgerMaster.TINNo = p.TINNo;
                        supplierLedgerMaster.Status = p.Status;
                        supplierLedgerMaster.ModifiedBy = this.LoggedInUser.Username;
                        supplierLedgerMaster.ModifiedOn = System.DateTime.Now;
                    }

                    return context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

    }
}
