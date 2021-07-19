using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rz.DddDemo.Base.Presentation.WebApi.RabbitMqHostedService.Interfaces
{
    public interface IMessageHandler
    {
        public string ExchangeName { get; }

        public string RoutingKey { get; }

        public Dictionary<string, object> Arguments { get; }

        public Task<bool> Handle(byte[] message);
    }
}
