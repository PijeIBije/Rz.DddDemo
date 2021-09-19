using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Configs
{
    public class RabbitMqConfig
    {
        public const string AppSettingsKey = "RabbitMq";

        public string HostName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
