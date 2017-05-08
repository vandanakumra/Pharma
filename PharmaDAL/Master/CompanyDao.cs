using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;
using PharmaBusinessObjects.Master;
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaDAL.Master
{
    public class CompanyDao
    {
        public List<Company> GetCompanies(string searchText)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                List<Company> companyList = context.CompanyMaster.Where(p => p.Status && (string.IsNullOrEmpty(searchText) || p.CompanyName.Contains(searchText))).Select(p => new Company()
                                            {
                                                CompanyId = p.CompanyId,
                                                CompanyName = p.CompanyName,
                                                OrderPreferenceRating = p.OrderPreferenceRating,
                                                BillingPreferenceRating = p.BillingPreferenceRating,
                                                CompanyCode = p.CompanyCode,
                                                Status = p.Status,
                                                IsDirect = p.IsDirect,
                                                StockSummaryRequired = p.StockSummaryRequired
                    
                                            }).ToList();
                companyList.ForEach(p => {
                    p.DirectIndirect = p.IsDirect ? Enum.GetName(typeof(DI), 1) : Enum.GetName(typeof(DI), 0);
                    p.StockSummaryRequirement = p.StockSummaryRequired ? Enum.GetName(typeof(Choice), 1) : Enum.GetName(typeof(Choice), 0);
                });

                return companyList;
            }
        }

        public Company GetCompanyById(int companyId)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.CompanyMaster.Where(p => p.CompanyId == companyId).Select(p => new Company()
                {
                    CompanyId = p.CompanyId,
                    CompanyName = p.CompanyName,
                    OrderPreferenceRating = p.OrderPreferenceRating,
                    BillingPreferenceRating = p.BillingPreferenceRating,
                    CompanyCode = p.CompanyCode,
                    Status = p.Status,
                    IsDirect = p.IsDirect,
                    StockSummaryRequired = p.StockSummaryRequired
                }).FirstOrDefault();
            }
        }

        public int AddCompany(PharmaBusinessObjects.Master.Company company)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                List<string> companyCodeList = context.CompanyMaster.Select(p => p.CompanyCode).ToList();
                    
                int maxCompanyCode = companyCodeList.Count > 0 ? companyCodeList.Max(p=>Convert.ToInt32(p)) + 1 : 1;

                var companyCode = maxCompanyCode.ToString().PadLeft(3, '0');

                CompanyMaster table = new CompanyMaster()
                {
                    CompanyCode = companyCode,
                    Status = company.Status,
                    StockSummaryRequired = company.StockSummaryRequired,
                    IsDirect = company.IsDirect,
                    OrderPreferenceRating = company.OrderPreferenceRating,
                    BillingPreferenceRating = company.BillingPreferenceRating,
                    CompanyName = company.CompanyName
                };

                context.CompanyMaster.Add(table);
                return context.SaveChanges();
            }
        }

        public int UpdateCompany(PharmaBusinessObjects.Master.Company company)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var companyMaster = context.CompanyMaster.FirstOrDefault(p=>p.CompanyId == company.CompanyId);

                if (companyMaster != null)
                {
                    companyMaster.Status = company.Status;
                    companyMaster.StockSummaryRequired = company.StockSummaryRequired;
                    companyMaster.IsDirect = company.IsDirect;
                    companyMaster.OrderPreferenceRating = company.OrderPreferenceRating;
                    companyMaster.BillingPreferenceRating = company.BillingPreferenceRating;
                    companyMaster.CompanyName = company.CompanyName;
                }

                return context.SaveChanges();
            }
        }

        public int DeleteCompany(int companyId)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var companyMaster = context.CompanyMaster.FirstOrDefault(p => p.CompanyId == companyId);

                if (companyMaster != null)
                {
                    companyMaster.Status = false;
                }

                return context.SaveChanges();
            }
        }
    }


}
