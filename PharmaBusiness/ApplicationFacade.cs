using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Master;
using PharmaBusiness.Master;

namespace PharmaBusiness
{
    public class ApplicationFacade : IApplicationFacade
    {
        #region Item Master

        /// <summary>
        /// Fetch all the active items
        /// </summary>
        /// <returns>List of items</returns>
        public List<Item> GetAllItems()
        {
            try
            {
                return new ItemBiz().GetAllItems();
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
        public bool AddNewItem(Item newItem)
        {
            try
            {
                return new ItemBiz().AddNewItem(newItem);
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
        public bool UpdateItem(Item existingItem)
        {
            try
            {
                return new ItemBiz().UpdateItem(existingItem);
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
        public bool DeleteItem(Item existingItem)
        {
            try
            {
                return new ItemBiz().DeleteItem(existingItem);
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
        public List<Company> GetCompanies()
        {
            try
            {
                return new CompanyBiz().GetCompanies();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Account Ledger

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
        public int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {

            try
            {
                return new AccountLedgerMasterBiz().AddAccountLedger(p);
            }
            catch (Exception)
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


        #endregion

    }
}
