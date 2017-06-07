using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction.SaleEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Transaction
{
    public class SaleBiz
    {
        public List<SaleChangeType> GetTypeOfChanges()
        {
            return new List<SaleChangeType>() {
                new SaleChangeType(){TypeID = Convert.ToInt32(Enums.SaleEntryChangeType.TemporaryChange), TypeName = Enums.SaleEntryChangeType.TemporaryChange.ToString() },
                new SaleChangeType(){TypeID = Convert.ToInt32(Enums.SaleEntryChangeType.CompanyWiseChange), TypeName = Enums.SaleEntryChangeType.CompanyWiseChange.ToString() },
                new SaleChangeType(){ TypeID = Convert.ToInt32(Enums.SaleEntryChangeType.ItemWiseChange), TypeName = Enums.SaleEntryChangeType.ItemWiseChange.ToString()}
            };
        }
    }
}
