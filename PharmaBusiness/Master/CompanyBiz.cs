using PharmaBusinessObjects.Master;
using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class CompanyBiz
    {
        internal List<Company> GetCompanies()
        {
            return new CompanyDao().GetCompanies();
        }
    }
}
