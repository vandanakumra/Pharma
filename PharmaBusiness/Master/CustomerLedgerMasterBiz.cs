using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    class CustomerLedgerMasterBiz
    {
        internal List<PharmaBusinessObjects.Master.CustomerLedgerMaster> GetCustomerLedgers()
        {
            return new CustomerLedgerMasterDao().GetCustomerLedgers();
        }

        internal int AddCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {
            return new CustomerLedgerMasterDao().AddCustomerLedger(p);
        }

        internal int UpdateCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {
            return new CustomerLedgerMasterDao().UpdateCustomerLedger(p);
        }

    }
}
