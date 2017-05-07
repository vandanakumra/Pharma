using PharmaBusinessObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects
{
    public interface IApplicationFacade
    {

        #region Item Master

        List<Item> GetAllItems();
        bool AddNewItem(Item newItem);
        bool UpdateItem(Item existingItem);
        bool DeleteItem(Item existingItem);

        #endregion

        #region Company Master

        List<Company> GetCompanies();
        #endregion

    }
}
