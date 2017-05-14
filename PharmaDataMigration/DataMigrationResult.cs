using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDataMigration
{
    public class DataMigrationResult
    {
        public string TableName { get; set; }
        public string Status { get; set; }
        public int NumberOfRecords { get; set; }
    }
}
