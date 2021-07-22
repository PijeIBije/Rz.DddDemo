using System.Collections.Generic;

namespace Rz.DddDemo.Base.Infrastructure.RabbitMq
{
    public class RabbitMqIntegrationEventPublisherConfig
    {
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
        public  Dictionary<string,object> Arguments { get; set; }
        public bool Mandatory { get; set; }
    }
}
