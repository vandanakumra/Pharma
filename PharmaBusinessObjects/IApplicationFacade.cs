using PharmaBusinessObjects.Master;
using PharmaBusinessObjects.Transaction;
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
        List<ItemMaster> GetAllItemsBySearch(string searchString, string searchBy);
        List<CustomerCopanyDiscount> GetAllCompanyItemDiscountByCompanyIDForCustomer(int CompanyID);
        List<SupplierCompanyDiscount> GetAllCompanyItemDiscountByCompanyIDForSupplier(int CompanyID);
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
        List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerByLedgerTypeIdAndSearch(int LedgerTypeID, string searchString = null);
        int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p);
        int UpdateAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p);
        List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerBySystemName(string systemName);
        #endregion

        #region Common

        PharmaBusinessObjects.Common.AccountLedgerType GetAccountLedgerTypeByName(string name);
        List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypesWithAll();
        List<PharmaBusinessObjects.Common.AccountType> GetAccountTypes();
        List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypes();
        List<PharmaBusinessObjects.Common.CustomerType> GetCustomerTypes();
        List<PharmaBusinessObjects.Common.RateType> GetInterestTypes();
        List<PharmaBusinessObjects.Common.PersonLedgerType> GetPersonLedgerTypes();
        List<PharmaBusinessObjects.Common.RecordType> GetRecordTypes();
        List<PharmaBusinessObjects.Common.RecordType> GetRecordTypesWithAll();

        #endregion

        #region Personal Ledger Master

        List<PharmaBusinessObjects.Master.PersonalLedgerMaster> GetPersonalLedgers(string searchString);
        int AddPersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p);
        int UpdatePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p);
        int DeletePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p);

        #endregion

        #region Supplier Ledger Master

        List<PharmaBusinessObjects.Master.SupplierLedgerMaster> GetSupplierLedgers(string searchText);
        SupplierLedgerMaster GetSupplierLedgerById(int supplierId);
        int AddSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p);
        int UpdateSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p);
        List<PharmaBusinessObjects.Master.SupplierCompanyDiscount> GetCompleteCompanyDiscountListBySupplierID(int supplierLedgerID);
        SupplierLedgerMaster GetSupplierLedgerByName(string name);
        #endregion

        #region Person Route Master

        List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutes();
        int AddPersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p);

        int UpdatePersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p);

        List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutesByRecordTypeIdAndSearch(int recordTypeID, string searchString = null);

        List<PersonRouteMaster> GetPersonRoutesBySystemName(string systemName);

        #endregion

        #region Customer Ledger Master

        List<PharmaBusinessObjects.Master.CustomerLedgerMaster> GetCustomerLedgers(string searchString = null);
        int AddCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p);
        int UpdateCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p);
        List<PharmaBusinessObjects.Master.CustomerCopanyDiscount> GetCompleteCompanyDiscountListByCustomerID(int customerLedgerID);
        int DeleteCustomerLedger(int customerLedgerID);

        #endregion

        #region User Master

        List<PharmaBusinessObjects.Master.UserMaster> GetUsers(string searchText);
        PharmaBusinessObjects.Master.UserMaster GetUserByUserName(string userName);
        PharmaBusinessObjects.Master.UserMaster GetUserByUserId(int userid);
        int AddUser(PharmaBusinessObjects.Master.UserMaster p);
        int UpdateUser(PharmaBusinessObjects.Master.UserMaster p);
        List<PharmaBusinessObjects.Master.Role> GetRoles(string searchText);
        List<PharmaBusinessObjects.Master.Role> GetActiveRoles();
        PharmaBusinessObjects.Master.Role GetRoleById(int userid);
        bool AddRole(PharmaBusinessObjects.Master.Role p);
        bool UpdateRole(PharmaBusinessObjects.Master.Role p);
        List<PharmaBusinessObjects.Master.Privledge> GetPrivledges(string searchText);
        List<PharmaBusinessObjects.Master.Privledge> GetActivePrivledges();
        PharmaBusinessObjects.Master.Privledge GetPrivledgeById(int userid);
        bool AddPrivledge(PharmaBusinessObjects.Master.Privledge p);
        bool UpdatePrivledge(PharmaBusinessObjects.Master.Privledge p);

        #endregion

        #region Transaction
       
        long InsertUpdateTempPurchaseBookHeader(PurchaseSaleBookHeader header);
        List<PharmaBusinessObjects.Transaction.PurchaseType> GetPurchaseEntryTypes();
        List<PharmaBusinessObjects.Transaction.PurchaseFormType> GetPurchaseFormTypes(int purchaseTypeID);      
        List<PurchaseBookAmount> InsertUpdateTempPurchaseBookLineItem(PurchaseSaleBookLineItem lineItem);
        bool IsTempPurchaseHeaderExists(long purchaseBookHeaderID);
        List<PurchaseBookAmount> DeleteTempPurchaseBookLineItem(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem);
        List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> GetLastNBatchNoForSupplierItem(string supplierCode, string itemCode);
        bool SavePurchaseData(long purchaseBookHeaderID);
        List<PharmaBusinessObjects.Transaction.PurchaseBookAmount> GetFinalAmountWithTaxForPurchase(long purchaseBookHeaderID);

      
        List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> GetAllInitialBillAdjustmentForLedger(TransactionEntity transactionEntity);
        List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> GetAllBillOutstandingForLedger(TransactionEntity transactionEntity);
        long InsertUpdateTempReceiptPayment(PharmaBusinessObjects.Transaction.ReceiptPayment.ReceiptPaymentItem receiptPayment);
        #endregion
    }

}
