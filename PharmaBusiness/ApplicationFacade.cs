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


        #endregion

        #region Company Master

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
