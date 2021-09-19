using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Configs
{
    public class MongoDbConfig
    {
        public const string AppSettingsKey = "MongoDb";
        public string ConnectionString { get; set; }
    }
}
