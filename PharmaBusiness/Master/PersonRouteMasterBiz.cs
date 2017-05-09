using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class PersonRouteMasterBiz
    {
        internal List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutes()
        {
            return new PersonRouteMasterDao().GetPersonRoutes();
        }

        internal int AddPersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p)
        {
            return new PersonRouteMasterDao().AddPersonRoute(p);
        }


        internal int UpdatePersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p)
        {
            return new PersonRouteMasterDao().UpdatePersonRoute(p);
        }

    }
}
