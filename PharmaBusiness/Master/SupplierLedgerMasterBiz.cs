using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class SupplierLedgerMasterBiz
    {
        internal List<PharmaBusinessObjects.Master.SupplierLedgerMaster> GetSupplierLedgers(string searchText)
        {
            return new SupplierLedgerMasterDao().GetSupplierLedgers(searchText);
        }

        internal int AddSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p)
        {
            return new SupplierLedgerMasterDao().AddSupplierLedger(p);
        }

        internal int UpdateSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p)
        {
            return new SupplierLedgerMasterDao().UpdateSupplierLedger(p);
        }

    }
}
