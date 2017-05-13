using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using PharmaDAL.Entity;
using PharmaDAL.Master;
using PharmaBusinessObjects;

namespace PharmaDataMigration.Master
{
    public class ItemMaster
    {
        private ItemDaoMaster itemMasterDao; 
        private DBFConnectionManager dbConnection;
        private List<CompanyCodeCounts> companyCodeCounts;

        public ItemMaster()
        {
            itemMasterDao = new ItemDaoMaster(Common.LoggedInUser);
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
            companyCodeCounts = new List<CompanyCodeCounts>();
        }        

        public bool InsertItemMasterData()
        {
            try
            {
                string query = "select * from MASTERS where slcd = 'IT'";

                DataTable dtItemMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.ItemMaster> listItemMaster = new List<PharmaDAL.Entity.ItemMaster>();
                int _result = 0;
                companyCodeCounts = TotalItemsByCompany();

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtItemMaster != null && dtItemMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtItemMaster.Rows)
                        {
                            
                            int totalItemsFromSameCompany = companyCodeCounts.Where(p => p.CompanyCode == Convert.ToString(dr["CompCD"])).Select(p => p.CompanyCodeCount).FirstOrDefault();
                            totalItemsFromSameCompany++;

                            if (totalItemsFromSameCompany > 1)
                            {
                                foreach (var item in companyCodeCounts.Where(p => p.CompanyCode == Convert.ToString(dr["CompCD"])))
                                {
                                    item.CompanyCodeCount = totalItemsFromSameCompany;
                                }
                            }
                            else
                            {
                                companyCodeCounts.Add(new CompanyCodeCounts() { CompanyCode = Convert.ToString(dr["CompCD"]), CompanyCodeCount = totalItemsFromSameCompany });
                            }
                            
                            PharmaDAL.Entity.ItemMaster newItemMaster = new PharmaDAL.Entity.ItemMaster()
                            {
                                ItemCode = string.Concat(Convert.ToString(dr["CompCD"]), totalItemsFromSameCompany.ToString().PadLeft(6, '0')),
                                ItemName = Convert.ToString(dr["ACName"]),
                                CompanyCode = Convert.ToString(dr["CompCD"]),
                                ConversionRate = Convert.ToDouble(dr["ConvRate"]),
                                ShortName = Convert.ToString(dr["ALT_Name"]),
                                Packing = Convert.ToString(dr["Size"]),
                                PurchaseRate = Convert.ToDouble(dr["PRate"]),
                                MRP = Convert.ToDouble(dr["MRP"]),
                                SaleRate = Convert.ToDouble(dr["SRate"]),
                                SpecialRate = Convert.ToDouble(dr["SPLRate"]),
                                WholeSaleRate = Convert.ToDouble(dr["WSRATE"]),
                                SaleExcise = Convert.ToDouble(dr["EXCISES"]),
                                SurchargeOnSale = Convert.ToDouble(dr["SC"]),
                                TaxOnSale = Convert.ToDouble(dr["STax"]),
                                Scheme1 = Convert.ToDouble(dr["Scheme1"]),
                                Scheme2 = Convert.ToDouble(dr["Scheme2"]),
                                PurchaseExcise = Convert.ToDouble(dr["ExciseP"]),
                                UPC = Convert.ToString(dr["UPC"]),
                                IsHalfScheme = Convert.ToChar(dr["half"]) == 'Y' ? true : false,
                                IsQTRScheme = Convert.ToChar(dr["qtr"]) == 'Y' ? true : false,
                                SpecialDiscount = Convert.ToDouble(dr["SPLDIS"]),
                                SpecialDiscountOnQty = Convert.ToDouble(dr["DISQTY"]),
                                IsFixedDiscount = Convert.ToChar(dr["check_dis"]) == 'Y' ? true : false,
                                FixedDiscountRate = Convert.ToDouble(dr["drate1"]),
                                MaximumQty = Convert.ToDouble(dr["MAX_QTY"]),
                                MaximumDiscount = Convert.ToDouble(dr["max_dis"]),
                                SurchargeOnPurchase = Convert.ToDouble(dr["PSC"]),
                                TaxOnPurchase = Convert.ToDouble(dr["PTax"]),
                                DiscountRecieved = Convert.ToDouble(dr["PDIS"]),
                                SpecialDiscountRecieved = Convert.ToDouble(dr["PSPLDIS"]),
                                QtyPerCase = Convert.ToDouble(dr["Case_Qty"]),
                                Location = Convert.ToString(dr["location"]),
                                MinimumStock = Convert.ToInt32(dr["min"]),
                                MaximumStock = Convert.ToInt32(dr["max"]),
                                SaleTypeId = 1, //Convert.ToInt32(dr["SType"]),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true
                            };

                            listItemMaster.Add(newItemMaster);
                        }
                    }

                    context.ItemMaster.AddRange(listItemMaster);
                    _result = context.SaveChanges();

                    if (_result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CompanyCodeCounts> TotalItemsByCompany()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var companyCodeCounts = itemMasterDao.GetAllItems().GroupBy(p => p.CompanyCode)
                                                                    .Select(q => new CompanyCodeCounts()
                                                                                    {
                                                                                        CompanyCode = q.Key,
                                                                                        CompanyCodeCount = q.Count()
                                                                                    }
                                                                    ).ToList();

                return companyCodeCounts;
            }
        }
    }

    public class CompanyCodeCounts
    {
        public string CompanyCode { get; set; }
        public int CompanyCodeCount { get; set; }
    }
}
