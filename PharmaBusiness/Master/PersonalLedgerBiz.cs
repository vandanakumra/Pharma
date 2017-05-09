using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class PersonalLedgerBiz
    {
        internal List<PharmaBusinessObjects.Master.PersonalLedger> GetPersonalLedgers()
        {
            return new PersonalLedgerMasterDao().GetPersonalLedgers();
        }

        internal int AddPersonalLedger(PharmaBusinessObjects.Master.PersonalLedger p)
        {
            return new PersonalLedgerMasterDao().AddPersonalLedger(p);
        }

        internal int UpdatePersonalLedger(PharmaBusinessObjects.Master.PersonalLedger p)
        {
            return new PersonalLedgerMasterDao().UpdatePersonalLedger(p);
        }
    }
}
