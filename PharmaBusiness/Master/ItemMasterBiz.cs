﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaBusinessObjects.Master;
using PharmaDAL.Master;

namespace PharmaBusiness.Master
{
    internal class ItemMasterBiz : BaseBiz
    {
        public ItemMasterBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }
        internal List<ItemMaster> GetAllItems()
        {
            return new ItemDaoMaster(this.LoggedInUser).GetAllItems();
        }

        internal List<ItemMaster> GetAllItemsBySearch(string searchString)
        {
            return new ItemDaoMaster(this.LoggedInUser).GetAllItemsBySearch(searchString);
        }
        

        internal bool AddNewItem(ItemMaster newItem)
        {
            return new ItemDaoMaster(this.LoggedInUser).AddNewItem(newItem);
        }

        internal bool UpdateItem(ItemMaster existingItem)
        {
            return new ItemDaoMaster(this.LoggedInUser).UpdateItem(existingItem);
        }

        internal bool DeleteItem(ItemMaster existingItem)
        {
            return new ItemDaoMaster(this.LoggedInUser).DeleteItem(existingItem);
        }

        internal string GetNextItemCode(string companyCode)
        {
            int totalItemsFromSameCompany =  new ItemDaoMaster(this.LoggedInUser).TotalItemsFromSameCompany(companyCode);
            totalItemsFromSameCompany++;
            string getNextItemCode=String.Concat(companyCode, totalItemsFromSameCompany.ToString().PadLeft(6, '0'));
            return getNextItemCode;
        }
    }
}
