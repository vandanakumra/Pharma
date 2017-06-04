using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction
{
    public class TransactionEntity : BaseBusinessObjects
    {
        public string EntityType { get; set; }
        public string EntityCode { get; set; }
        public string EntityName { get; set; }
    }
}
