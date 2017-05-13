﻿using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class CustomerLedgerMasterDao : BaseDao
    {
        public CustomerLedgerMasterDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }
        public List<PharmaBusinessObjects.Master.CustomerLedgerMaster> GetCustomerLedgers()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.CustomerLedger.Select(p => new PharmaBusinessObjects.Master.CustomerLedgerMaster()
                {
                    CustomerLedgerId = p.CustomerLedgerId,
                    CustomerLedgerCode = p.CustomerLedgerCode,
                    CustomerLedgerName = p.CustomerLedgerName,
                    CustomerLedgerShortName = p.CustomerLedgerShortName,
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
                    Status = p.Status,
                    ASMId = p.ASMId,
                    ASMName =  "",
                    BankArea = p.BankArea,
                    BankName= p.BankName,
                    CloseDay = p.CloseDay,
                    CreditLimit = p.CreditLimit,
                    CSTNo = p.CSTNo,
                    CustomerTypeID = p.CustomerTypeID,
                    CustomerTypeName = "",
                    Day = p.Day,
                    InterestTypeID =p.InterestTypeID,
                    InterestTypeName = "",
                    IsLessExcise = p.IsLessExcise,
                    RateTypeID = p.RateTypeID,
                    RateTypeName = "",
                    RouteId = p.RouteId,
                    RouteName = "",
                    RSMId = p.RSMId,
                    RSMName = "",
                    SalesManId = p.SalesManId,
                    SalesmanName = "",
                    ZSMId = p.ZSMId,
                    ZSMName = "",
                    IsFixedTax = p.IsFixedTax,
                    Tax = p.Tax,
                    IsFixedSC = p.IsFixedSC,
                    SC = p.SC,
                    IsChangeSCWhileBill = p.IsChangeSCWhileBill,
                    SaleBillFormat = p.SaleBillFormat,
                    MaxOSAmount = p.MaxOSAmount,
                    MaxNumOfOSBill = p.MaxNumOfOSBill,
                    MaxBillAmount = p.MaxBillAmount,
                    MaxGracePeriod = p.MaxGracePeriod,
                    IsFollowConditionStrictly = p.IsFollowConditionStrictly,
                    Discount = p.Discount,
                    CentralLocal = p.CentralLocal,
                }).ToList();
            }

        }

        public int AddCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {

            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxCustmerLedgerID = context.CustomerLedger.Count() + 1;

                    var customerLedgerCode = "C" + maxCustmerLedgerID.ToString().PadLeft(6, '0');

                    Entity.CustomerLedger table = new Entity.CustomerLedger()
                    {
                        CustomerLedgerCode = customerLedgerCode,
                        CustomerLedgerName = p.CustomerLedgerName,
                        CustomerLedgerShortName = p.CustomerLedgerShortName,
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
                        TINNo = p.TINNo,
                        Status = p.Status,
                        ASMId = p.ASMId,
                        BankArea = p.BankArea,
                        BankName = p.BankName,
                        CloseDay = p.CloseDay,
                        CreditLimit = p.CreditLimit,
                        CSTNo = p.CSTNo,
                        CustomerTypeID = p.CustomerTypeID,
                        Day = p.Day,
                        InterestTypeID = p.InterestTypeID,
                        IsLessExcise = p.IsLessExcise,
                        RateTypeID = p.RateTypeID,
                        RouteId = p.RouteId,
                        RSMId = p.RSMId,
                        SalesManId = p.SalesManId,
                        ZSMId = p.ZSMId,
                        IsFixedTax = p.IsFixedTax,
                        Tax = p.Tax,
                        IsFixedSC = p.IsFixedSC,
                        SC = p.SC,
                        IsChangeSCWhileBill = p.IsChangeSCWhileBill,
                        SaleBillFormat = p.SaleBillFormat,
                        MaxOSAmount = p.MaxOSAmount,
                        MaxNumOfOSBill = p.MaxNumOfOSBill,
                        MaxBillAmount = p.MaxBillAmount,
                        MaxGracePeriod = p.MaxGracePeriod,
                        IsFollowConditionStrictly = p.IsFollowConditionStrictly,
                        Discount = p.Discount,
                        CentralLocal = p.CentralLocal,
                        CreatedBy = this.LoggedInUser.Username,
                        CreatedOn = System.DateTime.Now

                    };

                    context.CustomerLedger.Add(table);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;

            }          
        }

        public int UpdateCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var customerLedgerMaster = context.CustomerLedger.Where(q => q.CustomerLedgerId == p.CustomerLedgerId).FirstOrDefault();

                    if (customerLedgerMaster != null)
                    {
                        customerLedgerMaster.CustomerLedgerName = p.CustomerLedgerName;
                        customerLedgerMaster.CustomerLedgerShortName = p.CustomerLedgerShortName;
                        customerLedgerMaster.Address = p.Address;
                        customerLedgerMaster.ContactPerson = p.ContactPerson;
                        customerLedgerMaster.Mobile = p.Mobile;
                        customerLedgerMaster.Pager = p.Pager;
                        customerLedgerMaster.Fax = p.Fax;
                        customerLedgerMaster.OfficePhone = p.OfficePhone;
                        customerLedgerMaster.ResidentPhone = p.ResidentPhone;
                        customerLedgerMaster.EmailAddress = p.EmailAddress;
                        customerLedgerMaster.AreaId = p.AreaId;
                        customerLedgerMaster.CreditDebit = p.CreditDebit;
                        customerLedgerMaster.DLNo = p.DLNo;
                        customerLedgerMaster.OpeningBal = p.OpeningBal;
                        customerLedgerMaster.TaxRetail = p.TaxRetail;
                        customerLedgerMaster.TINNo = p.TINNo;
                        customerLedgerMaster.Status = p.Status;
                        customerLedgerMaster.ASMId = p.ASMId;
                        customerLedgerMaster.BankArea = p.BankArea;
                        customerLedgerMaster.BankName = p.BankName;
                        customerLedgerMaster.CloseDay = p.CloseDay;
                        customerLedgerMaster.CreditLimit = p.CreditLimit;
                        customerLedgerMaster.CSTNo = p.CSTNo;
                        customerLedgerMaster.CustomerTypeID = p.CustomerTypeID;
                        customerLedgerMaster.Day = p.Day;
                        customerLedgerMaster.InterestTypeID = p.InterestTypeID;
                        customerLedgerMaster.IsLessExcise = p.IsLessExcise;
                        customerLedgerMaster.RateTypeID = p.RateTypeID;
                        customerLedgerMaster.RouteId = p.RouteId;
                        customerLedgerMaster.RSMId = p.RSMId;
                        customerLedgerMaster.SalesManId = p.SalesManId;
                        customerLedgerMaster.ZSMId = p.ZSMId;
                        customerLedgerMaster.IsFixedTax = p.IsFixedTax;
                        customerLedgerMaster.Tax = p.Tax;
                        customerLedgerMaster.IsFixedSC = p.IsFixedSC;
                        customerLedgerMaster.SC = p.SC;
                        customerLedgerMaster.IsChangeSCWhileBill = p.IsChangeSCWhileBill;
                        customerLedgerMaster.SaleBillFormat = p.SaleBillFormat;
                        customerLedgerMaster.MaxOSAmount = p.MaxOSAmount;
                        customerLedgerMaster.MaxNumOfOSBill = p.MaxNumOfOSBill;
                        customerLedgerMaster.MaxBillAmount = p.MaxBillAmount;
                        customerLedgerMaster.MaxGracePeriod = p.MaxGracePeriod;
                        customerLedgerMaster.IsFollowConditionStrictly = p.IsFollowConditionStrictly;
                        customerLedgerMaster.Discount = p.Discount;
                        customerLedgerMaster.CentralLocal = p.CentralLocal;
                        customerLedgerMaster.ModifiedBy = this.LoggedInUser.Username;
                        customerLedgerMaster.ModifiedOn = System.DateTime.Now;
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
