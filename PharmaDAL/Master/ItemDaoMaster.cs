using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data;

namespace PharmaDAL.Master
{
    public class ItemDaoMaster : BaseDao
    {
        public ItemDaoMaster(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<PharmaBusinessObjects.Master.ItemMaster> GetAllItems()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.ItemMaster.Select(p => new PharmaBusinessObjects.Master.ItemMaster()
                {
                    ItemID = p.ItemID,
                    ItemCode = p.ItemCode,
                    ItemName = p.ItemName,
                    CompanyID=p.CompanyID,
                    CompanyName = p.CompanyMaster.CompanyName,
                    ConversionRate = p.ConversionRate,
                    ShortName = p.ShortName,
                    Packing = p.Packing,
                    PurchaseRate = p.PurchaseRate,
                    MRP = p.MRP,
                    SaleRate = p.SaleRate,
                    SpecialRate = p.SpecialRate,
                    WholeSaleRate = p.WholeSaleRate,
                    SaleExcise = p.SaleExcise,
                    SurchargeOnSale = p.SurchargeOnSale,
                    TaxOnSale = p.TaxOnSale,
                    Scheme1 = p.Scheme1,
                    Scheme2 = p.Scheme2,
                    PurchaseExcise = p.PurchaseExcise,
                    UPC = p.UPC,
                    IsHalfScheme = p.IsHalfScheme,
                    IsQTRScheme = p.IsQTRScheme,
                    SpecialDiscount = p.SpecialDiscount,
                    SpecialDiscountOnQty = p.SpecialDiscountOnQty,
                    IsFixedDiscount = p.IsFixedDiscount,
                    FixedDiscountRate = p.FixedDiscountRate,
                    //MaximumQty = p.MaximumQty,
                    //MaximumDiscount = p.MaximumDiscount,
                    SurchargeOnPurchase = p.SurchargeOnPurchase,
                    TaxOnPurchase = p.TaxOnPurchase,
                    DiscountRecieved = p.DiscountRecieved,
                    SpecialDiscountRecieved = p.SpecialDiscountRecieved,
                    QtyPerCase = p.QtyPerCase,
                    Location = p.Location,
                    //MinimumStock = p.MinimumStock,
                    //MaximumStock = p.MaximumStock,
                    SaleTypeId = p.SaleTypeId,
                    PurchaseTypeId=p.PurchaseTypeId,
                    PurchaseTypeCode = p.AccountLedgerMaster1.AccountLedgerCode,
                    PurchaseTypeName=  p.AccountLedgerMaster1.AccountLedgerName,
                    PurchaseTypeRate= p.AccountLedgerMaster1.SalePurchaseTaxType,
                    Status = p.Status,
                    

                }).ToList();
            }
        }

        public bool AddNewItem(PharmaBusinessObjects.Master.ItemMaster newItem)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    int _result = 0;
                    int totalItemsFromSameCompany = TotalItemsFromSameCompany(newItem.CompanyCode);
                    totalItemsFromSameCompany++;

                    Entity.ItemMaster newItemMasterDB = new Entity.ItemMaster()
                    {
                        ItemCode = string.Concat(newItem.CompanyCode, totalItemsFromSameCompany.ToString().PadLeft(6, '0')),
                        ItemName = newItem.ItemName,
                        CompanyID=newItem.CompanyID,
                        ConversionRate = newItem.ConversionRate,
                        ShortName = newItem.ShortName,
                        Packing = newItem.Packing,
                        PurchaseRate = newItem.PurchaseRate,
                        MRP = newItem.MRP,
                        SaleRate = newItem.SaleRate,
                        SpecialRate = newItem.SpecialRate,
                        WholeSaleRate = newItem.WholeSaleRate,
                        SaleExcise = newItem.SaleExcise,
                        SurchargeOnSale = newItem.SurchargeOnSale,
                        TaxOnSale = newItem.TaxOnSale,
                        Scheme1 = newItem.Scheme1,
                        Scheme2 = newItem.Scheme2,
                        PurchaseExcise = newItem.PurchaseExcise,
                        UPC = newItem.UPC,
                        IsHalfScheme = newItem.IsHalfScheme,
                        IsQTRScheme = newItem.IsQTRScheme,
                        SpecialDiscount = newItem.SpecialDiscount,
                        SpecialDiscountOnQty = newItem.SpecialDiscountOnQty,
                        IsFixedDiscount = newItem.IsFixedDiscount,
                        FixedDiscountRate = newItem.FixedDiscountRate,
                        //MaximumQty = newItem.MaximumQty,
                        //MaximumDiscount = newItem.MaximumDiscount,
                        SurchargeOnPurchase = newItem.SurchargeOnPurchase,
                        TaxOnPurchase = newItem.TaxOnPurchase,
                        DiscountRecieved = newItem.DiscountRecieved,
                        SpecialDiscountRecieved = newItem.SpecialDiscountRecieved,
                        QtyPerCase = newItem.QtyPerCase,
                        Location = newItem.Location,
                        //MinimumStock = newItem.MinimumStock,
                        //MaximumStock = newItem.MaximumStock,
                        SaleTypeId = newItem.SaleTypeId,
                        PurchaseTypeId=newItem.PurchaseTypeId,
                        Status = newItem.Status,
                        CreatedBy = this.LoggedInUser.Username,
                        CreatedOn = System.DateTime.Now
                    };

                    context.ItemMaster.Add(newItemMasterDB);
                    _result = context.SaveChanges();

                    if (_result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }

        }

        public bool UpdateItem(PharmaBusinessObjects.Master.ItemMaster existingItem)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                int _result = 0;

                Entity.ItemMaster existingItemDB = context.ItemMaster.Where(p => p.ItemCode == existingItem.ItemCode && p.Status).FirstOrDefault();

                if (existingItemDB != null)
                {
                    existingItemDB.ItemName = existingItem.ItemName;
                    existingItemDB.CompanyID = existingItem.CompanyID;
                    existingItemDB.ConversionRate = existingItem.ConversionRate;
                    existingItemDB.ShortName = existingItem.ShortName;
                    existingItemDB.Packing = existingItem.Packing;
                    existingItemDB.PurchaseRate = existingItem.PurchaseRate;
                    existingItemDB.MRP = existingItem.MRP;
                    existingItemDB.SaleRate = existingItem.SaleRate;
                    existingItemDB.SpecialRate = existingItem.SpecialRate;
                    existingItemDB.WholeSaleRate = existingItem.WholeSaleRate;
                    existingItemDB.SaleExcise = existingItem.SaleExcise;
                    existingItemDB.SurchargeOnSale = existingItem.SurchargeOnSale;
                    existingItemDB.TaxOnSale = existingItem.TaxOnSale;
                    existingItemDB.Scheme1 = existingItem.Scheme1;
                    existingItemDB.Scheme2 = existingItem.Scheme2;
                    existingItemDB.PurchaseExcise = existingItem.PurchaseExcise;
                    existingItemDB.UPC = existingItem.UPC;
                    existingItemDB.IsHalfScheme = existingItem.IsHalfScheme;
                    existingItemDB.IsQTRScheme = existingItem.IsQTRScheme;
                    existingItemDB.SpecialDiscount = existingItem.SpecialDiscount;
                    existingItemDB.SpecialDiscountOnQty = existingItem.SpecialDiscountOnQty;
                    existingItemDB.IsFixedDiscount = existingItem.IsFixedDiscount;
                    existingItemDB.FixedDiscountRate = existingItem.FixedDiscountRate;
                    //existingItemDB.MaximumQty = existingItem.MaximumQty;
                    //existingItemDB.MaximumDiscount = existingItem.MaximumDiscount;
                    existingItemDB.SurchargeOnPurchase = existingItem.SurchargeOnPurchase;
                    existingItemDB.TaxOnPurchase = existingItem.TaxOnPurchase;
                    existingItemDB.DiscountRecieved = existingItem.DiscountRecieved;
                    existingItemDB.SpecialDiscountRecieved = existingItem.SpecialDiscountRecieved;
                    existingItemDB.QtyPerCase = existingItem.QtyPerCase;
                    existingItemDB.Location = existingItem.Location;
                    //existingItemDB.MinimumStock = existingItem.MinimumStock;
                    //existingItemDB.MaximumStock = existingItem.MaximumStock;
                    existingItemDB.SaleTypeId = existingItem.SaleTypeId;
                    existingItemDB.PurchaseTypeId = existingItem.PurchaseTypeId;
                    existingItemDB.Status = existingItem.Status;
                    existingItemDB.ModifiedBy = this.LoggedInUser.Username;
                    existingItemDB.ModifiedOn = System.DateTime.Now;
                }
                _result = context.SaveChanges();
                _result = 1;

                if (_result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool DeleteItem(PharmaBusinessObjects.Master.ItemMaster existingItem)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                int _result = 0;

                Entity.ItemMaster existingItemDB = context.ItemMaster.Where(p => p.ItemCode == existingItem.ItemCode && p.Status).FirstOrDefault();

                if (existingItemDB != null)
                {
                    existingItemDB.Status = false;
                    existingItemDB.Status = existingItem.Status;
                    existingItemDB.ModifiedBy = this.LoggedInUser.Username;
                    existingItemDB.ModifiedOn = System.DateTime.Now;
                    //context.ItemMaster.Remove((Entity.ItemMaster)existingItemDB);
                }
                _result = context.SaveChanges();

                if (_result > 0)
                    return true;
                else
                    return false;
            }
        }

        public int TotalItemsFromSameCompany(string companyCode)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                int totalItemsFromSameCompany = GetAllItems().Where(x => x.CompanyCode == companyCode).Count();
                return totalItemsFromSameCompany;
            }
        }


        public List<PharmaBusinessObjects.Master.ItemMaster> GetAllItemsBySearch(string searchString = null, string searchBy = "Name")
        {

            //using (PharmaDBEntities context = new PharmaDBEntities())
            //{
            //    List<PharmaBusinessObjects.Master.ItemMaster> itemList = new List<PharmaBusinessObjects.Master.ItemMaster>();

            //    SqlConnection connection = (SqlConnection)context.Database.Connection;

            //    SqlCommand cmd = new SqlCommand("Select * from ItemMaster", connection);
            //    cmd.CommandType = System.Data.CommandType.Text;               

            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();

            //    sda.Fill(dt);


            //    if(dt != null && dt.Rows.Count > 0)
            //    {
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            PharmaBusinessObjects.Master.ItemMaster item = new PharmaBusinessObjects.Master.ItemMaster()
            //            {

            //                ItemID = Convert.ToInt32(row["ItemID"]),
            //                ItemCode = Convert.ToString(row["ItemCode"]),
            //                ItemName = Convert.ToString(row["ItemName"]),
            //                CompanyID = Convert.ToInt32(row["CompanyID"]),
            //                ConversionRate = Convert.ToDecimal(row["ConversionRate"]),
            //               // CompanyName = Convert.ToString(row["CompanyMaster.CompanyName"]),
            //                ShortName = Convert.ToString(row["ShortName"]),
            //                Packing = Convert.ToString(row["Packing"]),
            //                PurchaseRate = Convert.ToDecimal(row["PurchaseRate"]),
            //                MRP = Convert.ToDecimal(row["MRP"]),
            //                SaleRate = Convert.ToDecimal(row["SaleRate"]),
            //                SpecialRate = Convert.ToDecimal(row["SpecialRate"]),
            //                WholeSaleRate = Convert.ToDecimal(row["WholeSaleRate"]),
            //                SaleExcise = Convert.ToDecimal(row["SaleExcise"]),
            //                SurchargeOnSale = Convert.ToDecimal(row["SurchargeOnSale"]),
            //                TaxOnSale = Convert.ToDecimal(row["TaxOnSale"]),
            //                Scheme1 = Convert.ToDecimal(row["Scheme1"]),
            //                Scheme2 = Convert.ToDecimal(row["Scheme2"]),
            //                PurchaseExcise = Convert.ToDecimal(row["PurchaseExcise"]),
            //                UPC = Convert.ToString(row["UPC"]),
            //                IsHalfScheme = Convert.ToBoolean(row["IsHalfScheme"]),
            //                IsQTRScheme = Convert.ToBoolean(row["IsQTRScheme"]),
            //                SpecialDiscount = Convert.ToDecimal(row["SpecialDiscount"]),
            //                SpecialDiscountOnQty = Convert.ToDecimal(row["SpecialDiscountOnQty"]),
            //                IsFixedDiscount = Convert.ToBoolean(row["IsFixedDiscount"]),
            //                FixedDiscountRate = Convert.ToDecimal(row["FixedDiscountRate"]),
            //                SurchargeOnPurchase = Convert.ToDecimal(row["SurchargeOnPurchase"]),
            //                TaxOnPurchase = Convert.ToDecimal(row["TaxOnPurchase"]),
            //                DiscountRecieved = Convert.ToDecimal(row["DiscountRecieved"]),
            //                SpecialDiscountRecieved = Convert.ToDecimal(row["SpecialDiscountRecieved"]),
            //                QtyPerCase = Convert.ToDecimal(row["QtyPerCase"]),
            //                Location = Convert.ToString(row["Location"]),
            //                SaleTypeId = Convert.ToInt32(row["SaleTypeId"]),
            //                PurchaseTypeId = Convert.ToInt32(row["PurchaseTypeId"]),
            //                //PurchaseTypeCode = Convert.ToDecimal(row["AccountLedgerMaster1.AccountLedgerCode,
            //                //PurchaseTypeName = Convert.ToDecimal(row["AccountLedgerMaster1.AccountLedgerName,
            //                //PurchaseTypeRate = Convert.ToDecimal(row["AccountLedgerMaster1.SalePurchaseTaxType,
            //                Status = Convert.ToBoolean(row["Status"])
            //            };

            //            itemList.Add(item);

            //        }
            //    }
            //    return itemList;              
            //}



            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.ItemMaster.Where(p => p.Status
                                                && (string.IsNullOrEmpty(searchString) || p.ItemName.Contains(searchString))
                                                ).Select(p => new PharmaBusinessObjects.Master.ItemMaster()
                                                {
                                                    ItemID = p.ItemID,
                                                    ItemCode = p.ItemCode,
                                                    ItemName = p.ItemName,
                                                    CompanyID = p.CompanyID,
                                                    ConversionRate = p.ConversionRate,
                                                    CompanyName = p.CompanyMaster.CompanyName,
                                                    ShortName = p.ShortName,
                                                    Packing = p.Packing,
                                                    PurchaseRate = p.PurchaseRate,
                                                    MRP = p.MRP,
                                                    SaleRate = p.SaleRate,
                                                    SpecialRate = p.SpecialRate,
                                                    WholeSaleRate = p.WholeSaleRate,
                                                    SaleExcise = p.SaleExcise,
                                                    SurchargeOnSale = p.SurchargeOnSale,
                                                    TaxOnSale = p.TaxOnSale,
                                                    Scheme1 = p.Scheme1,
                                                    Scheme2 = p.Scheme2,
                                                    PurchaseExcise = p.PurchaseExcise,
                                                    UPC = p.UPC,
                                                    IsHalfScheme = p.IsHalfScheme,
                                                    IsQTRScheme = p.IsQTRScheme,
                                                    SpecialDiscount = p.SpecialDiscount,
                                                    SpecialDiscountOnQty = p.SpecialDiscountOnQty,
                                                    IsFixedDiscount = p.IsFixedDiscount,
                                                    FixedDiscountRate = p.FixedDiscountRate,
                                                    SurchargeOnPurchase = p.SurchargeOnPurchase,
                                                    TaxOnPurchase = p.TaxOnPurchase,
                                                    DiscountRecieved = p.DiscountRecieved,
                                                    SpecialDiscountRecieved = p.SpecialDiscountRecieved,
                                                    QtyPerCase = p.QtyPerCase,
                                                    Location = p.Location,
                                                    SaleTypeId = p.SaleTypeId,
                                                    PurchaseTypeId = p.PurchaseTypeId,
                                                    PurchaseTypeCode = p.AccountLedgerMaster1.AccountLedgerCode,
                                                    PurchaseTypeName = p.AccountLedgerMaster1.AccountLedgerName,
                                                    PurchaseTypeRate = p.AccountLedgerMaster1.SalePurchaseTaxType,
                                                    Status = p.Status

                                                }).ToList();
            }
        }

        public List<PharmaBusinessObjects.Master.ItemMaster> GetAllItemByCompanyID(int CompanyID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                List<PharmaBusinessObjects.Master.ItemMaster> allItemByCompanyID = new List<PharmaBusinessObjects.Master.ItemMaster>();

                allItemByCompanyID = context.ItemMaster.Where(item => item.CompanyID == CompanyID && item.Status)
                                                                 .Select(item => new PharmaBusinessObjects.Master.ItemMaster()
                                                                 {
                                                                     CompanyID=CompanyID,
                                                                     CompanyName=item.CompanyMaster.CompanyName,
                                                                     ItemID=item.ItemID,
                                                                     ItemName=item.ItemName

                                                                 }).ToList();

                return allItemByCompanyID;
            }
        }
    }
}
