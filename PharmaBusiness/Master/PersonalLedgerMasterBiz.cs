using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class PersonalLedgerMasterBiz
    {
        internal List<PharmaBusinessObjects.Master.PersonalLedgerMaster> GetPersonalLedgers()
        {
            return new PersonalLedgerMasterDao().GetPersonalLedgers();
        }

        internal int AddPersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            return new PersonalLedgerMasterDao().AddPersonalLedger(p);
        }

        internal int UpdatePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            return new PersonalLedgerMasterDao().UpdatePersonalLedger(p);
        }
    }
}
