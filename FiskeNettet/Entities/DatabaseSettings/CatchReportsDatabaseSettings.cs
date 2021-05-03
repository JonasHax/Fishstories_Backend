using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Entities.DatabaseSettings
{
    public class CatchReportsDatabaseSettings : ICatchReportsDatabaseSettings
    {
        public string CatchReportsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICatchReportsDatabaseSettings
    {
        string CatchReportsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}