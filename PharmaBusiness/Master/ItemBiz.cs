using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaBusinessObjects.Master;
using PharmaDAL.Master;

namespace PharmaBusiness.Master
{
    internal class ItemBiz
    {
        internal List<Item> GetAllItems()
        {
            return new ItemDao().GetAllItems();
        }

        internal bool AddNewItem(Item newItem)
        {
            return new ItemDao().AddNewItem(newItem);
        }

        internal bool UpdateItem(Item existingItem)
        {
            return new ItemDao().UpdateItem(existingItem);
        }

        internal bool DeleteItem(Item existingItem)
        {
            return new ItemDao().DeleteItem(existingItem);
        }

        internal string GetNextItemCode(string companyCode)
        {
            int totalItemsFromSameCompany =  new ItemDao().TotalItemsFromSameCompany(companyCode);
            totalItemsFromSameCompany++;
            string getNextItemCode=String.Concat(companyCode, totalItemsFromSameCompany.ToString().PadLeft(6, '0'));
            return getNextItemCode;
        }
    }
}
