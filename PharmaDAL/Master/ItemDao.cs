using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;
using PharmaBusinessObjects.Master;

namespace PharmaDAL.Master
{
    public class ItemDao
    {
        public List<Item> GetAllItems()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.ItemMaster.Where(p => p.Status).Select(p => new Item()
                {
                    ItemID = p.ItemID,
                    ItemCode = p.ItemCode,
                    ItemName = p.ItemName,
                    CompanyCode = p.CompanyCode,
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
                    MaximumQty = p.MaximumQty,
                    MaximumDiscount = p.MaximumDiscount,
                    SurchargeOnPurchase = p.SurchargeOnPurchase,
                    TaxOnPurchase = p.TaxOnPurchase,
                    DiscountRecieved = p.DiscountRecieved,
                    SpecialDiscountRecieved = p.SpecialDiscountRecieved,
                    QtyPerCase = p.QtyPerCase,
                    Location = p.Location,
                    MinimumStock = p.MinimumStock,
                    MaximumStock = p.MaximumStock,
                    SaleTypeId = p.SaleTypeId,
                    Status = p.Status

                }).ToList();
            }
        }

        public bool AddNewItem(Item newItem)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    int _result = 0;
                    int totalItemsFromSameCompany = TotalItemsFromSameCompany(newItem.CompanyCode);
                    totalItemsFromSameCompany++;
                    ItemMaster newItemMasterDB = new ItemMaster()
                    {
                        ItemCode = String.Concat(newItem.CompanyCode, totalItemsFromSameCompany.ToString().PadLeft(6, '0')),
                        ItemName = newItem.ItemName,
                        CompanyCode = newItem.CompanyCode,
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
                        MaximumQty = newItem.MaximumQty,
                        MaximumDiscount = newItem.MaximumDiscount,
                        SurchargeOnPurchase = newItem.SurchargeOnPurchase,
                        TaxOnPurchase = newItem.TaxOnPurchase,
                        DiscountRecieved = newItem.DiscountRecieved,
                        SpecialDiscountRecieved = newItem.SpecialDiscountRecieved,
                        QtyPerCase = newItem.QtyPerCase,
                        Location = newItem.Location,
                        MinimumStock = newItem.MinimumStock,
                        MaximumStock = newItem.MaximumStock,
                        SaleTypeId = newItem.SaleTypeId,
                        Status = newItem.Status
                    };

                    context.ItemMaster.Add(newItemMasterDB);
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

        public bool UpdateItem(Item existingItem)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                int _result = 0;
                ItemMaster existingItemDB = context.ItemMaster.Where(p => p.ItemCode == existingItem.ItemCode && p.Status).FirstOrDefault();
                if (existingItemDB != null)
                {
                    existingItemDB.ItemName = existingItem.ItemName;
                    existingItemDB.CompanyCode = existingItem.CompanyCode;
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
                    existingItemDB.MaximumQty = existingItem.MaximumQty;
                    existingItemDB.MaximumDiscount = existingItem.MaximumDiscount;
                    existingItemDB.SurchargeOnPurchase = existingItem.SurchargeOnPurchase;
                    existingItemDB.TaxOnPurchase = existingItem.TaxOnPurchase;
                    existingItemDB.DiscountRecieved = existingItem.DiscountRecieved;
                    existingItemDB.SpecialDiscountRecieved = existingItem.SpecialDiscountRecieved;
                    existingItemDB.QtyPerCase = existingItem.QtyPerCase;
                    existingItemDB.Location = existingItem.Location;
                    existingItemDB.MinimumStock = existingItem.MinimumStock;
                    existingItemDB.MaximumStock = existingItem.MaximumStock;
                    existingItemDB.SaleTypeId = existingItem.SaleTypeId;
                    existingItemDB.Status = existingItem.Status;
                }
                _result = context.SaveChanges();

                if (_result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool DeleteItem(Item existingItem)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                int _result = 0;
                ItemMaster existingItemDB = context.ItemMaster.Where(p => p.ItemCode == existingItem.ItemCode && p.Status).FirstOrDefault();
                if (existingItemDB != null)
                {
                    context.ItemMaster.Remove(existingItemDB);
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
    }
}
