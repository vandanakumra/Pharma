using System;
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
            return new ItemDaoMaster().GetAllItems();
        }

        internal List<ItemMaster> GetAllItemsBySearch(string searchString)
        {
            return new ItemDaoMaster().GetAllItemsBySearch(searchString);
        }
        

        internal bool AddNewItem(ItemMaster newItem)
        {
            return new ItemDaoMaster().AddNewItem(newItem);
        }

        internal bool UpdateItem(ItemMaster existingItem)
        {
            return new ItemDaoMaster().UpdateItem(existingItem);
        }

        internal bool DeleteItem(ItemMaster existingItem)
        {
            return new ItemDaoMaster().DeleteItem(existingItem);
        }

        internal string GetNextItemCode(string companyCode)
        {
            int totalItemsFromSameCompany =  new ItemDaoMaster().TotalItemsFromSameCompany(companyCode);
            totalItemsFromSameCompany++;
            string getNextItemCode=String.Concat(companyCode, totalItemsFromSameCompany.ToString().PadLeft(6, '0'));
            return getNextItemCode;
        }
    }
}
