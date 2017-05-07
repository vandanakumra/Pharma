using PharmaDAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Common
{
    class CommonBiz
    {
        public List<PharmaBusinessObjects.Common.AccountType> GetAccountTypes()
        {
            return new CommonDao().GetAccountTypes();
        }

        public List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypes()
        {
            return new CommonDao().GetAccountLedgerTypes();
        }


        public List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypesWithAll()
        {
            var accountLedgerTypes = new CommonDao().GetAccountLedgerTypes() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>(); ;

            accountLedgerTypes.Insert(0, new PharmaBusinessObjects.Common.AccountLedgerType() { AccountLedgerTypeID = 0, AccountLedgerTypeName = "All" });

            return accountLedgerTypes;
        }

        public List<PharmaBusinessObjects.Common.CustomerType> GetCustomerTypes()
        {
            return new CommonDao().GetCustomerTypes();
        }

        public List<PharmaBusinessObjects.Common.InterestType> GetInterestTypes()
        {
            return new CommonDao().GetInterestTypes();
        }

        public List<PharmaBusinessObjects.Common.PersonLedgerType> GetPersonLedgerTypes()
        {
            return new CommonDao().GetPersonLedgerTypes();
        }


        public List<PharmaBusinessObjects.Common.RecordType> GetRecordTypes()
        {
            return new CommonDao().GetRecordTypes();
        }


    }
}
