using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class CustomerLedgerMasterBiz : BaseBiz
    {
        public CustomerLedgerMasterBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal List<PharmaBusinessObjects.Master.CustomerLedgerMaster> GetCustomerLedgers()
        {
            return new CustomerLedgerMasterDao(this.LoggedInUser).GetCustomerLedgers();
        }

        internal int AddCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {
            return new CustomerLedgerMasterDao(this.LoggedInUser).AddCustomerLedger(p);
        }

        internal int UpdateCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {
            return new CustomerLedgerMasterDao(this.LoggedInUser).UpdateCustomerLedger(p);
        }

    }
}
