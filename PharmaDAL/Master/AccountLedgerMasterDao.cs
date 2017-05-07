﻿
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class AccountLedgerMasterDao
    {
        public List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgers()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.AccountLedgerMaster.Where(p => p.Status).Select(p => new PharmaBusinessObjects.Master.AccountLedgerMaster()
                {
                    AccountLedgerID = p.AccountLedgerID,
                    AccountLedgerName = p.AccountLedgerName,
                    AccountLedgerCode = p.AccountLedgerCode,
                    AccountLedgerTypeId = p.AccountLedgerTypeId,
                    AccountLedgerType = p.AccountLedgerType.AccountLedgerTypeName,
                    AccountLedgerTypeSystemName = p.AccountLedgerType.SystemName,
                    AccountTypeId = p.AccountTypeId,
                    AccountType = p.AccountType.AccountTypeName,
                    CreditControlCodeID = p.CreditControlCodeID,
                    DebitControlCodeID = p.DebitControlCodeID,
                    OpeningBalance = p.OpeningBalance,
                    CreditDebit = p.CreditDebit                    
                }).ToList();
            }

        }

        public PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerById(int accountLedgerID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.AccountLedgerMaster.Where(p =>p.AccountLedgerID == accountLedgerID && p.Status).Select(p => new PharmaBusinessObjects.Master.AccountLedgerMaster()
                {
                    AccountLedgerID = p.AccountLedgerID,
                    AccountLedgerName = p.AccountLedgerName,
                    AccountLedgerCode = p.AccountLedgerCode,
                    AccountLedgerTypeId = p.AccountLedgerTypeId,
                    AccountLedgerType = p.AccountLedgerType.AccountLedgerTypeName,
                    AccountLedgerTypeSystemName = p.AccountLedgerType.SystemName,
                    AccountTypeId = p.AccountTypeId,
                    AccountType = p.AccountType.AccountTypeName,
                    CreditControlCodeID = p.CreditControlCodeID,
                    DebitControlCodeID = p.DebitControlCodeID,
                    OpeningBalance = p.OpeningBalance,
                    CreditDebit = p.CreditDebit
                }).FirstOrDefault();
            }

        }

        public int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var maxAccountLedgerID = context.AccountLedgerMaster.Count() > 0 ? context.AccountLedgerMaster.Max(q=>q.AccountLedgerID) : 1;

                var accountLedgerCode = "L" + maxAccountLedgerID.ToString().PadLeft(6, '0');

                AccountLedgerMaster table = new AccountLedgerMaster() {
                    
                    AccountLedgerName = p.AccountLedgerName,
                    AccountLedgerCode = accountLedgerCode,
                    AccountLedgerTypeId = p.AccountLedgerTypeId,                   
                    AccountTypeId = p.AccountTypeId,                      
                    OpeningBalance = p.OpeningBalance,
                    CreditDebit = p.CreditDebit
                };

                var accountLedger=  new Common.CommonDao().GetAccountLedgerTypes().Where(q => q.AccountLedgerTypeID == p.AccountLedgerTypeId).FirstOrDefault();

                if (accountLedger.AccountLedgerTypeSystemName != "ControlCodes")
                {
                    table.CreditControlCodeID = p.CreditControlCodeID;
                    table.DebitControlCodeID = p.DebitControlCodeID;
                }

                context.AccountLedgerMaster.Add(table);
                return context.SaveChanges();
            }
        }

        public int UpdateAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var accountLedgerMaster = context.AccountLedgerMaster.Where(q => q.AccountLedgerID == p.AccountLedgerID).FirstOrDefault();

                if (accountLedgerMaster != null)
                {
                    accountLedgerMaster.AccountLedgerName = p.AccountLedgerName;
                    accountLedgerMaster.AccountLedgerCode = p.AccountLedgerCode;
                    accountLedgerMaster.AccountLedgerTypeId = p.AccountLedgerTypeId;
                    accountLedgerMaster.AccountTypeId = p.AccountTypeId;
                    accountLedgerMaster.CreditControlCodeID = p.CreditControlCodeID;
                    accountLedgerMaster.DebitControlCodeID = p.DebitControlCodeID;
                    accountLedgerMaster.OpeningBalance = p.OpeningBalance;
                    accountLedgerMaster.CreditDebit = p.CreditDebit;
                }
                
                return context.SaveChanges();
            }

        }


        public List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerByLedgerTypeIdAndSearch(int ledgerTypeID, string searchString = null)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var accountLedgers = (from p in context.AccountLedgerMaster
                                      where ledgerTypeID == 0 || p.AccountLedgerTypeId == ledgerTypeID
                                      && searchString == null || p.AccountLedgerName.Contains(searchString)
                                      select new PharmaBusinessObjects.Master.AccountLedgerMaster()
                                      {
                                          AccountLedgerID = p.AccountLedgerID,
                                          AccountLedgerName = p.AccountLedgerName,
                                          AccountLedgerCode = p.AccountLedgerCode,
                                          AccountLedgerTypeId = p.AccountLedgerTypeId,
                                          AccountLedgerType = p.AccountLedgerType.AccountLedgerTypeName,
                                          AccountLedgerTypeSystemName = p.AccountLedgerType.SystemName,
                                          AccountTypeId = p.AccountTypeId,
                                          AccountType = p.AccountType.AccountTypeName,
                                          CreditControlCodeID = p.CreditControlCodeID,
                                          DebitControlCodeID = p.DebitControlCodeID,
                                          OpeningBalance = p.OpeningBalance,
                                          CreditDebit = p.CreditDebit

                                      }).ToList();

                return accountLedgers;
                
            }

        }





    }
}
