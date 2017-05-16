using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Status { get; set; }
    }

    public class Privledge
    {
        public int PrivledgeId { get; set; }
        public string PrivledgeName { get; set; }
        public bool Status { get; set; }
    }
}
