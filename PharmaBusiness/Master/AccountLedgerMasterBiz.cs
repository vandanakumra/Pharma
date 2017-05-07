using PharmaDAL.Common;
using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class AccountLedgerMasterBiz
    {
        internal List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgers()
        {

            CommonDao commonDao = new CommonDao();

            var accountLedgerMasterList = new AccountLedgerMasterDao().GetAccountLedgers();

            var accountLedgerTypeList = commonDao.GetAccountLedgerTypes() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            var AccountTypeList = commonDao.GetAccountTypes() ?? new List<PharmaBusinessObjects.Common.AccountType>();
            var creditControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeID == 1).ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            var debitControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeID == 2).ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();

            foreach (var accountLedger in accountLedgerMasterList)
            {
                accountLedger.AccountLedgerTypeList = accountLedgerTypeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
                accountLedger.AccountTypeList = AccountTypeList ?? new List<PharmaBusinessObjects.Common.AccountType>();
                accountLedger.CreditControlCodeList = creditControlCodeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
                accountLedger.DebitControlCodeList = debitControlCodeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            }

            return accountLedgerMasterList;
        }

        internal PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerById(int accountLedgerID)
        {
            CommonDao commonDao = new CommonDao();

            PharmaBusinessObjects.Master.AccountLedgerMaster accountLedger =  new AccountLedgerMasterDao().GetAccountLedgerById(accountLedgerID);
            accountLedger.AccountLedgerTypeList = commonDao.GetAccountLedgerTypes() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            accountLedger.AccountTypeList = commonDao.GetAccountTypes() ?? new List<PharmaBusinessObjects.Common.AccountType>();
            accountLedger.CreditControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeID == 1).ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            accountLedger.DebitControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeID == 2).ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();


            return accountLedger;
        }

        internal int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            return new AccountLedgerMasterDao().AddAccountLedger(p);
        }

        internal int UpdateAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            return new AccountLedgerMasterDao().UpdateAccountLedger(p);
        }

        internal List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerByLedgerTypeIdAndSearch(int ledgerTypeID, string searchString = null)
        {
            CommonDao commonDao = new CommonDao();

            var accountLedgerMasterList = new AccountLedgerMasterDao().GetAccountLedgerByLedgerTypeIdAndSearch(ledgerTypeID,searchString);

            var accountLedgerTypeList = commonDao.GetAccountLedgerTypes() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            var AccountTypeList = commonDao.GetAccountTypes() ?? new List<PharmaBusinessObjects.Common.AccountType>();
            var creditControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeID == 1).ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            var debitControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeID == 2).ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();

            foreach (var accountLedger in accountLedgerMasterList)
            {
                accountLedger.AccountLedgerTypeList = accountLedgerTypeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
                accountLedger.AccountTypeList = AccountTypeList ?? new List<PharmaBusinessObjects.Common.AccountType>();
                accountLedger.CreditControlCodeList = creditControlCodeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
                accountLedger.DebitControlCodeList = debitControlCodeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            }

            return accountLedgerMasterList; 
        }

        internal List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerBySystemName(string systemName)
        {

            CommonDao commonDao = new CommonDao();

            var accountLedgerMasterList = new AccountLedgerMasterDao().GetAccountLedgers().Where(p=>p.AccountLedgerTypeSystemName == systemName).ToList();          
            return accountLedgerMasterList;
        }
    }
}
