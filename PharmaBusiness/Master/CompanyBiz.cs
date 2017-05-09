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
        internal List<Company> GetCompanies(string searchText)
        {
            return new CompanyDao().GetCompanies(searchText);
        }

        internal PharmaBusinessObjects.Master.Company GetCompanyById(int companyId)
        {
            PharmaBusinessObjects.Master.Company company = new CompanyDao().GetCompanyById(companyId);
            return company;
        }

        internal int AddCompany(PharmaBusinessObjects.Master.Company company)
        {
            return new CompanyDao().AddCompany(company);
        }

        internal int UpdateCompany(PharmaBusinessObjects.Master.Company company)
        {
            return new CompanyDao().UpdateCompany(company);
        }

        internal int DeleteCompany(int companyId)
        {
            return new CompanyDao().DeleteCompany(companyId);
        }
    }
}
