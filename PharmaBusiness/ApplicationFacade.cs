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
        PharmaBusinessObjects.Master.UserMaster LoggedInUser { get; set; }
        public ApplicationFacade(PharmaBusinessObjects.Master.UserMaster loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
        }


        #region Item Master

        /// <summary>
        /// Fetch all the active items
        /// </summary>
        /// <returns>List of items</returns>
        public List<ItemMaster> GetAllItems()
        {
            try
            {
                return new ItemMasterBiz(this.LoggedInUser).GetAllItems();
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
                return new ItemMasterBiz(this.LoggedInUser).AddNewItem(newItem);
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
                return new ItemMasterBiz(this.LoggedInUser).UpdateItem(existingItem);
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
                return new ItemMasterBiz(this.LoggedInUser).DeleteItem(existingItem);
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
                return new ItemMasterBiz(this.LoggedInUser).GetNextItemCode(companyCode);
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
                return new ItemMasterBiz(this.LoggedInUser).GetAllItemsBySearch(searchString);
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
                return new CompanyMasterBiz(this.LoggedInUser).GetCompanies(searchText);
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
                return new CompanyMasterBiz(this.LoggedInUser).GetCompanyById(companyID);
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
                return new CompanyMasterBiz(this.LoggedInUser).AddCompany(company);
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
                return new CompanyMasterBiz(this.LoggedInUser).UpdateCompany(company);
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
                return new CompanyMasterBiz(this.LoggedInUser).DeleteCompany(companyId);
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
                return new AccountLedgerMasterBiz(this.LoggedInUser).GetAccountLedgers();
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
                return new AccountLedgerMasterBiz(this.LoggedInUser).GetAccountLedgerById(accountLedgerID);
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
                return new AccountLedgerMasterBiz(this.LoggedInUser).GetAccountLedgerByLedgerTypeIdAndSearch(ledgerTypeID, searchString);
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
                return new AccountLedgerMasterBiz(this.LoggedInUser).AddAccountLedger(p);
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
                return new AccountLedgerMasterBiz(this.LoggedInUser).UpdateAccountLedger(p);
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
                return new AccountLedgerMasterBiz(this.LoggedInUser).GetAccountLedgerBySystemName(systemName);
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

        public List<PharmaBusinessObjects.Common.RecordType> GetRecordTypesWithAll()
        {
            return new CommonBiz().GetRecordTypesWithAll();
        }





        #endregion

        #region Personal Ledger Master

        public List<PharmaBusinessObjects.Master.PersonalLedgerMaster> GetPersonalLedgers(string searchString)
        {
            try
            {
                return new PersonalLedgerMasterBiz(this.LoggedInUser).GetPersonalLedgers(searchString);
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
                return new PersonalLedgerMasterBiz(this.LoggedInUser).AddPersonalLedger(p);
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
                return new PersonalLedgerMasterBiz(this.LoggedInUser).UpdatePersonalLedger(p);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int DeletePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            try
            {
                return new PersonalLedgerMasterBiz(this.LoggedInUser).DeletePersonalLedger(p);
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
                return new SupplierLedgerMasterBiz(this.LoggedInUser).GetSupplierLedgers(searchText);
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
                return new SupplierLedgerMasterBiz(this.LoggedInUser).AddSupplierLedger(p);
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
                return new SupplierLedgerMasterBiz(this.LoggedInUser).UpdateSupplierLedger(p);
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
                return new PersonRouteMasterBiz(this.LoggedInUser).GetPersonRoutes();

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
                return new PersonRouteMasterBiz(this.LoggedInUser).AddPersonRoute(p);
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
                return new PersonRouteMasterBiz(this.LoggedInUser).UpdatePersonRoute(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutesByRecordTypeIdAndSearch(int recordTypeID, string searchString = null)
        {
            try
            {
                return new PersonRouteMasterBiz(this.LoggedInUser).GetPersonRoutesByRecordTypeIdAndSearch(recordTypeID,searchString);
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
                return new CustomerLedgerMasterBiz(this.LoggedInUser).GetCustomerLedgers();
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
                return new CustomerLedgerMasterBiz(this.LoggedInUser).AddCustomerLedger(p);
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
                return new CustomerLedgerMasterBiz(this.LoggedInUser).UpdateCustomerLedger(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region User Master

        public List<PharmaBusinessObjects.Master.UserMaster> GetUsers()
        {
            return new UserBiz(this.LoggedInUser).GetUsers();
        }
        public PharmaBusinessObjects.Master.UserMaster GetUserByUserName(string userName)
        {
            return new UserBiz(this.LoggedInUser).GetUserByUserName(userName);
        }
        public PharmaBusinessObjects.Master.UserMaster GetUserByUserId(int userid)
        {
            return new UserBiz(this.LoggedInUser).GetUserByUserId(userid);
        }
        public int AddUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            return new UserBiz(this.LoggedInUser).AddUser(p);
        }
        public int UpdateUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            return new UserBiz(this.LoggedInUser).UpdateUser(p);
        }

        #endregion



    }
}
