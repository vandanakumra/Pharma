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

        List<ItemMaster> GetAllItems();
        bool AddNewItem(ItemMaster newItem);
        bool UpdateItem(ItemMaster existingItem);
        bool DeleteItem(ItemMaster existingItem);
        string GetNextItemCode(string companyCode);
        List<ItemMaster> GetAllItemsBySearch(string searchString);
        #endregion

        #region Company Master
        List<CompanyMaster> GetCompanies(string searchText);
        PharmaBusinessObjects.Master.CompanyMaster GetCompanyById(int companyId);
        int AddCompany(PharmaBusinessObjects.Master.CompanyMaster company);
        int UpdateCompany(PharmaBusinessObjects.Master.CompanyMaster company);
        int DeleteCompany(int companyId);        
        #endregion

        #region  Account Ledger Master

        List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgers();
        PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerById(int accountLedgerID);
        List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerByLedgerTypeIdAndSearch(int LedgerTypeID,string searchString = null);
        int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p);
        int UpdateAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p);
        List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerBySystemName(string systemName);
        #endregion

        #region Common

        List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypesWithAll();
        List<PharmaBusinessObjects.Common.AccountType> GetAccountTypes();
        List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypes();
        List<PharmaBusinessObjects.Common.CustomerType> GetCustomerTypes();
        List<PharmaBusinessObjects.Common.InterestType> GetInterestTypes();
        List<PharmaBusinessObjects.Common.PersonLedgerType> GetPersonLedgerTypes();
        List<PharmaBusinessObjects.Common.RecordType> GetRecordTypes();
        List<PharmaBusinessObjects.Common.RecordType> GetRecordTypesWithAll();

        #endregion

        #region Personal Ledger Master

        List<PharmaBusinessObjects.Master.PersonalLedgerMaster> GetPersonalLedgers();
        int AddPersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p);
        int UpdatePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p);
        #endregion

        #region Supplier Ledger Master

        List<PharmaBusinessObjects.Master.SupplierLedgerMaster> GetSupplierLedgers(string searchText);
        SupplierLedgerMaster GetSupplierLedgerById(int supplierId);
        int AddSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p);
        int UpdateSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p);

        #endregion

        #region Person Route Master

        List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutes();
        int AddPersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p);

        int UpdatePersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p);

        List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutesByRecordTypeIdAndSearch(int recordTypeID, string searchString = null);

        List<PersonRouteMaster> GetPersonRoutesBySystemName(string systemName);

        #endregion

        #region Customer Ledger Master

        List<PharmaBusinessObjects.Master.CustomerLedgerMaster> GetCustomerLedgers();
        int AddCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p);
        int UpdateCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p);

        #endregion

        #region User Master

        List<PharmaBusinessObjects.Master.UserMaster> GetUsers();
        PharmaBusinessObjects.Master.UserMaster GetUserByUserName(string userName);
        PharmaBusinessObjects.Master.UserMaster GetUserByUserId(int userid);
        int AddUser(PharmaBusinessObjects.Master.UserMaster p);
        int UpdateUser(PharmaBusinessObjects.Master.UserMaster p);

        #endregion

    }

}
