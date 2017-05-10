using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Master;
using PharmaBusiness.Master;
using PharmaBusiness.Common;

namespace PharmaBusiness
{
    public class ApplicationFacade : IApplicationFacade
    {
        #region Item Master

        /// <summary>
        /// Fetch all the active items
        /// </summary>
        /// <returns>List of items</returns>
        public List<ItemMaster> GetAllItems()
        {
            try
            {
                return new ItemMasterBiz().GetAllItems();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Add new item to ItemMaster
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns>true if added successfully</returns>
        public bool AddNewItem(ItemMaster newItem)
        {
            try
            {
                return new ItemMasterBiz().AddNewItem(newItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update an existing item from ItemMaster
        /// </summary>
        /// <param name="existingItem"></param>
        /// <returns>True if updated is succesfull</returns>
        public bool UpdateItem(ItemMaster existingItem)
        {
            try
            {
                return new ItemMasterBiz().UpdateItem(existingItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete an existing item from ItemMaster
        /// </summary>
        /// <param name="existingItem"></param>
        /// <returns>True if deletion is successfull</returns>
        public bool DeleteItem(ItemMaster existingItem)
        {
            try
            {
                return new ItemMasterBiz().DeleteItem(existingItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get next item code based on the company code
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns>next item code</returns>
        public string GetNextItemCode(string companyCode)
        {
            try
            {
                return new ItemMasterBiz().GetNextItemCode(companyCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

             /// <summary>
             /// Fetch all the active items by Search
             /// </summary>
             /// <returns>List of items</returns>
        public List<ItemMaster> GetAllItemsBySearch(string searchString)
        {
            try
            {
                return new ItemMasterBiz().GetAllItemsBySearch(searchString);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Company Master

        /// <summary>
        /// Add new company to CompanyMaster
        /// </summary>
        /// <returns>List of companies</returns>
        public List<CompanyMaster> GetCompanies(string searchText)
        {
            try
            {
                return new CompanyMasterBiz().GetCompanies(searchText);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PharmaBusinessObjects.Master.CompanyMaster GetCompanyById(int companyID)
        {
            try
            {
                return new CompanyMasterBiz().GetCompanyById(companyID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddCompany(PharmaBusinessObjects.Master.CompanyMaster company)
        {

            try
            {
                return new CompanyMasterBiz().AddCompany(company);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public int UpdateCompany(PharmaBusinessObjects.Master.CompanyMaster company)
        {
            try
            {
                return new CompanyMasterBiz().UpdateCompany(company);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int DeleteCompany(int companyId)
        {
            try
            {
                return new CompanyMasterBiz().DeleteCompany(companyId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Account Ledger Master

        public List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgers()
        {
            try
            {
                return new AccountLedgerMasterBiz().GetAccountLedgers();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerById(int accountLedgerID)
        {
            try
            {
                return new AccountLedgerMasterBiz().GetAccountLedgerById(accountLedgerID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerByLedgerTypeIdAndSearch(int ledgerTypeID, string searchString = null)
        {
            try
            {
                return new AccountLedgerMasterBiz().GetAccountLedgerByLedgerTypeIdAndSearch(ledgerTypeID, searchString);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {

            try
            {
                return new AccountLedgerMasterBiz().AddAccountLedger(p);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public int UpdateAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            try
            {
                return new AccountLedgerMasterBiz().UpdateAccountLedger(p);
            }            
            catch (Exception)
            {
                throw;
            }
        }

       public  List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerBySystemName(string systemName)
        {
            try
            {
                return new AccountLedgerMasterBiz().GetAccountLedgerBySystemName(systemName);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region Common

        public List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypesWithAll()
        {
            return new CommonBiz().GetAccountLedgerTypesWithAll();
        }

        public List<PharmaBusinessObjects.Common.AccountType> GetAccountTypes()
        {
            return new CommonBiz().GetAccountTypes();
        }

        public List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypes()
        {
            return new CommonBiz().GetAccountLedgerTypes();
        }

        public List<PharmaBusinessObjects.Common.CustomerType> GetCustomerTypes()
        {
            return new CommonBiz().GetCustomerTypes();
        }

        public List<PharmaBusinessObjects.Common.InterestType> GetInterestTypes()
        {
            return new CommonBiz().GetInterestTypes();
        }

        public List<PharmaBusinessObjects.Common.PersonLedgerType> GetPersonLedgerTypes()
        {
            return new CommonBiz().GetPersonLedgerTypes();
        }

        public List<PharmaBusinessObjects.Common.RecordType> GetRecordTypes()
        {
            return new CommonBiz().GetRecordTypes();
        }







        #endregion

        #region Personal Ledger Master

        public List<PharmaBusinessObjects.Master.PersonalLedgerMaster> GetPersonalLedgers()
        {
            try
            {
                return new PersonalLedgerMasterBiz().GetPersonalLedgers();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int AddPersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            try
            {
                return new PersonalLedgerMasterBiz().AddPersonalLedger(p);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int UpdatePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            try
            {
                return new PersonalLedgerMasterBiz().UpdatePersonalLedger(p);
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region  Supplier Ledger Master

        public List<SupplierLedgerMaster> GetSupplierLedgers(string searchText)
        {
            try
            {
                return new SupplierLedgerMasterBiz().GetSupplierLedgers(searchText);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddSupplierLedger(SupplierLedgerMaster p)
        {
            try
            {
                return new SupplierLedgerMasterBiz().AddSupplierLedger(p);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateSupplierLedger(SupplierLedgerMaster p)
        {
            try
            {
                return new SupplierLedgerMasterBiz().UpdateSupplierLedger(p);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Person Route Master

        public List<PersonRouteMaster> GetPersonRoutes()
        {
            try
            {
                return new PersonRouteMasterBiz().GetPersonRoutes();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddPersonRoute(PersonRouteMaster p)
        {
            try
            {
                return new PersonRouteMasterBiz().AddPersonRoute(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdatePersonRoute(PersonRouteMaster p)
        {
            try
            {
                return new PersonRouteMasterBiz().UpdatePersonRoute(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Customer Ledger Master

        public List<CustomerLedgerMaster> GetCustomerLedgers()
        {
            try
            {
                return new CustomerLedgerMasterBiz().GetCustomerLedgers();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddCustomerLedger(CustomerLedgerMaster p)
        {
            try
            {
                return new CustomerLedgerMasterBiz().AddCustomerLedger(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateCustomerLedger(CustomerLedgerMaster p)
        {
            try
            {
                return new CustomerLedgerMasterBiz().UpdateCustomerLedger(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion




    }
}
