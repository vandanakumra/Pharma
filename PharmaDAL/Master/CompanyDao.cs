using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;
using PharmaBusinessObjects.Master;

namespace PharmaDAL.Master
{
    public class CompanyDao
    {
        public List<Company> GetCompanies()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.CompanyMaster.Where(p => p.Status).Select(p => new Company() {
                        CompanyId = p.CompanyId,
                        CompanyName = p.CompanyName,
                        OrderPreferenceRating = p.OrderPreferenceRating,
                        BillingPreferenceRating = p.BillingPreferenceRating,
                        CompanyCode = p.CompanyCode,
                        Status = p.Status,
                        IsDirect = p.IsDirect,
                        StockSummaryRequired = p.StockSummaryRequired
                }).ToList();
            }

        }

    }
}
