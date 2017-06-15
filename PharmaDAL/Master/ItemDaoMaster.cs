using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PharmaDAL.Master
{
    public class ItemDaoMaster : BaseDao
    {
        string ConnString = "";

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
                    CompanyID = p.CompanyID,
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
                    HSNCode = p.HSNCode,
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
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            int _result = 0;
                            int totalItemsFromSameCompany = TotalItemsFromSameCompany(newItem.CompanyCode);
                            totalItemsFromSameCompany++;

                            //Add HSN if does not exist
                            if (!context.HSNCode.Where(x => x.HSNCode1 == newItem.HSNCode).Any())
                            {
                                Entity.HSNCode HSNCodeDBEntry = new HSNCode()
                                {
                                    HSNCode1 = newItem.HSNCode,
                                    HSNDescription = newItem.HSNCode + "- Default Description",
                                    CreatedBy = this.LoggedInUser.Username,
                                    CreatedOn = System.DateTime.Now
                                };

                                context.HSNCode.Add(HSNCodeDBEntry);
                            }


                            Entity.ItemMaster newItemMasterDB = new Entity.ItemMaster()
                            {
                                ItemCode = string.Concat(newItem.CompanyCode, totalItemsFromSameCompany.ToString().PadLeft(6, '0')),
                                ItemName = newItem.ItemName,
                                CompanyID = newItem.CompanyID,
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
                                SurchargeOnPurchase = newItem.SurchargeOnPurchase,
                                TaxOnPurchase = newItem.TaxOnPurchase,
                                DiscountRecieved = newItem.DiscountRecieved,
                                SpecialDiscountRecieved = newItem.SpecialDiscountRecieved,
                                QtyPerCase = newItem.QtyPerCase,
                                Location = newItem.Location,
                                SaleTypeId = newItem.SaleTypeId,
                                PurchaseTypeId = newItem.PurchaseTypeId,

                                HSNCode = newItem.HSNCode,

                                Status = newItem.Status,
                                CreatedBy = this.LoggedInUser.Username,
                                CreatedOn = System.DateTime.Now,

                            };

                            context.ItemMaster.Add(newItemMasterDB);
                            _result = context.SaveChanges();

                            if (_result > 0)
                                return true;
                            else
                                return false;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool UpdateItem(PharmaBusinessObjects.Master.ItemMaster existingItem)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int _result = 0;

                        Entity.ItemMaster existingItemDB = context.ItemMaster.Where(p => p.ItemCode == existingItem.ItemCode && p.Status).FirstOrDefault();

                        //Add HSN if does not exist
                        if (!context.HSNCode.Where(x => x.HSNCode1 == existingItem.HSNCode).Any())
                        {
                            Entity.HSNCode HSNCodeDBEntry = new HSNCode()
                            {
                                HSNCode1 = existingItem.HSNCode,
                                HSNDescription = existingItem.HSNCode + "- Default Description",
                                CreatedBy = this.LoggedInUser.Username,
                                CreatedOn = System.DateTime.Now
                            };
                            context.HSNCode.Add(HSNCodeDBEntry);
                        }

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
                            existingItemDB.SurchargeOnPurchase = existingItem.SurchargeOnPurchase;
                            existingItemDB.TaxOnPurchase = existingItem.TaxOnPurchase;
                            existingItemDB.DiscountRecieved = existingItem.DiscountRecieved;
                            existingItemDB.SpecialDiscountRecieved = existingItem.SpecialDiscountRecieved;
                            existingItemDB.QtyPerCase = existingItem.QtyPerCase;
                            existingItemDB.Location = existingItem.Location;
                            existingItemDB.SaleTypeId = existingItem.SaleTypeId;
                            existingItemDB.PurchaseTypeId = existingItem.PurchaseTypeId;
                            existingItemDB.HSNCode = existingItem.HSNCode;
                            existingItemDB.Status = existingItem.Status;
                            existingItemDB.ModifiedBy = this.LoggedInUser.Username;
                            existingItemDB.ModifiedOn = System.DateTime.Now;
                        }

                        _result = context.SaveChanges();
                        transaction.Commit();

                        _result = 1;

                        if (_result > 0)
                            return true;
                        else
                            return false;

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
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



        public DataTable GetAllItemsBySearch()
        {
            ConnString = ConfigurationManager.ConnectionStrings["PharmaDBConn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnString))
            {

                List<PharmaBusinessObjects.Master.ItemMaster> itemList = new List<PharmaBusinessObjects.Master.ItemMaster>();

                SqlCommand cmd = new SqlCommand("SELECT * FROM CompanyItemMapping", connection);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null)
                {
                    return dt;
                }
                else
                    return new DataTable();


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
                                                    HSNCode = p.HSNCode,
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
                                                                     CompanyID = CompanyID,
                                                                     CompanyName = item.CompanyMaster.CompanyName,
                                                                     ItemID = item.ItemID,
                                                                     ItemName = item.ItemName

                                                                 }).ToList();

                return allItemByCompanyID;
            }
        }

        public List<PharmaBusinessObjects.Master.HSNCodes> GetAllHSNCodes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                List<PharmaBusinessObjects.Master.HSNCodes> allHSNCode = new List<PharmaBusinessObjects.Master.HSNCodes>();

                allHSNCode = context.HSNCode.Select(hsn => new PharmaBusinessObjects.Master.HSNCodes()
                {
                    HSNID = hsn.HSNID,
                    HSNCode = hsn.HSNCode1,
                    HSNDescription = hsn.HSNDescription

                }).ToList();
                return allHSNCode;
            }
        }


        public PharmaBusinessObjects.Master.ItemMaster GetItemByCodeAndCustomer(int itemCode, string customerCode)
        {
            PharmaBusinessObjects.Master.ItemMaster master = new PharmaBusinessObjects.Master.ItemMaster();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("GetSaleLineItemByCode", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ItemCode", itemCode));
                cmd.Parameters.Add(new SqlParameter("@CustomerCode", customerCode));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    master.ItemID = Convert.IsDBNull(dt.Rows[0]["ItemId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ItemId"]);
                    master.ItemCode = Convert.ToString(dt.Rows[0]["ItemCode"]);
                    master.ItemName = Convert.ToString(dt.Rows[0]["ItemName"]);
                    master.CompanyID = Convert.IsDBNull(dt.Rows[0]["CompanyID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["CompanyID"]);
                    master.SaleRate = Convert.IsDBNull(dt.Rows[0]["SaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SaleRate"]);
                    master.SpecialRate = Convert.IsDBNull(dt.Rows[0]["SpecialRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialRate"]);
                    master.WholeSaleRate = Convert.IsDBNull(dt.Rows[0]["WholeSaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["WholeSaleRate"]);
                    master.SaleExcise = Convert.IsDBNull(dt.Rows[0]["SaleExcise"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SaleExcise"]);
                    master.SurchargeOnSale = Convert.IsDBNull(dt.Rows[0]["SurchargeOnSale"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SurchargeOnSale"]);
                    master.TaxOnSale = Convert.IsDBNull(dt.Rows[0]["TaxOnSale"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["TaxOnSale"]);
                    master.Scheme1 = Convert.IsDBNull(dt.Rows[0]["Scheme1"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme1"]);
                    master.Scheme2 = Convert.IsDBNull(dt.Rows[0]["Scheme2"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme2"]);
                    master.IsHalfScheme = Convert.IsDBNull(dt.Rows[0]["IsHalfScheme"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsHalfScheme"]);
                    master.IsQTRScheme = Convert.IsDBNull(dt.Rows[0]["IsQTRScheme"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsQTRScheme"]);
                    master.SpecialDiscount = Convert.IsDBNull(dt.Rows[0]["SpecialDiscount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialDiscount"]);
                    master.SpecialDiscountOnQty = Convert.IsDBNull(dt.Rows[0]["SpecialDiscountOnQty"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialDiscountOnQty"]);
                    master.IsFixedDiscount = Convert.IsDBNull(dt.Rows[0]["IsFixedDiscount"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsFixedDiscount"]);
                    master.FixedDiscountRate = Convert.IsDBNull(dt.Rows[0]["FixedDiscountRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["FixedDiscountRate"]);
                    master.QtyPerCase = Convert.IsDBNull(dt.Rows[0]["QtyPerCase"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["QtyPerCase"]);
                    master.Location = Convert.ToString(dt.Rows[0]["Location"]);
                    master.SaleTypeId = Convert.IsDBNull(dt.Rows[0]["SaleTypeId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["SaleTypeId"]);
                    //master.Discount = Convert.IsDBNull(dt.Rows[0]["Discount"]) ? 0 : Convert.ToDouble(dt.Rows[0]["Discount"]);
                    //  master.Batch = Convert.ToString(dt.Rows[0]["Batch"]);
                    master.Packing = Convert.ToString(dt.Rows[0]["Packing"]);
                    master.PurchaseRate = Convert.IsDBNull(dt.Rows[0]["PurchaseRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["PurchaseRate"]);
                    // master.FifoID = Convert.IsDBNull(dt.Rows[0]["FifoID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["FifoID"]);
                }
            }

            return master;
        }
    }
}