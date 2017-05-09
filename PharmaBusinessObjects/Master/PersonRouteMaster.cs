using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class PersonRouteMaster
    {
        public int PersonRouteID { get; set; }
        public string PersonRouteCode { get; set; }
        public int? RecordTypeId { get; set; }
        public string RecordTypeNme { get; set; }
        public string PersonRouteName { get; set; }
        public bool Status { get; set; }
    }
}
