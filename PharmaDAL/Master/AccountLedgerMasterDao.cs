
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
                AccountLedgerMaster table = new AccountLedgerMaster() {
                    
                    AccountLedgerName = p.AccountLedgerName,
                    AccountLedgerCode = p.AccountLedgerCode,
                    AccountLedgerTypeId = p.AccountLedgerTypeId,                   
                    AccountTypeId = p.AccountTypeId,                   
                    CreditControlCodeID = p.CreditControlCodeID,
                    DebitControlCodeID = p.DebitControlCodeID,
                    OpeningBalance = p.OpeningBalance,
                    CreditDebit = p.CreditDebit
                };

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





    }
}
