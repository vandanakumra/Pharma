using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class CustomerCopanyDiscount : BaseBusinessObjects
    {
        public int CustCompDiscountRefID { get; set; }
        public int CustomerLedgerID { get; set; }
        public string CompanyName { get; set; }
        public int CompanyID { get; set; }
        public string ItemName { get; set; }
        public int ItemID { get; set; }
        public double? Normal { get; set; }
        public double? Breakage { get; set; }
        public double? Expired { get; set; }
        public bool IsLessEcise { get; set; }
    }
}
