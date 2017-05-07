using PharmaBusinessObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects
{
    public interface IApplicationFacade
    {

        #region Item Master

        List<Item> GetAllItems();
        bool AddNewItem(Item newItem);
        bool UpdateItem(Item existingItem);
        bool DeleteItem(Item existingItem);

        #endregion

        #region Company Master

        List<Company> GetCompanies();
        #endregion

        #region  Account Ledger Master

        List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgers();
        PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerById(int accountLedgerID);
        List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerByLedgerTypeIdAndSearch(int LedgerTypeID,string searchString = null);
        int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p);
        int UpdateAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p);
        List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetDebitCreditControlCodes();
        #endregion

        #region Common

        List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypesWithAll();
        List<PharmaBusinessObjects.Common.AccountType> GetAccountTypes();
        List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypes();
        List<PharmaBusinessObjects.Common.CustomerType> GetCustomerTypes();
        List<PharmaBusinessObjects.Common.InterestType> GetInterestTypes();
        List<PharmaBusinessObjects.Common.PersonLedgerType> GetPersonLedgerTypes();
        List<PharmaBusinessObjects.Common.RecordType> GetRecordTypes();

        #endregion
    }
        
}
