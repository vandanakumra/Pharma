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
            return new CompanyBiz().GetCompanies();
        }

        #endregion

    }
}
