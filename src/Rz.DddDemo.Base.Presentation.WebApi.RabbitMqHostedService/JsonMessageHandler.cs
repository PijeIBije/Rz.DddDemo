using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Presentation.WebApi.RabbitMqHostedService.Interfaces;

namespace Rz.DddDemo.Base.Presentation.WebApi.RabbitMqHostedService
{
    public abstract class MessageHandlerBase<TMessageDto,TIntegrationEvent>:IMessageHandler 
        where TMessageDto:new()
        where TIntegrationEvent:IIntegrationEvent
    {
        private readonly Func<Type, IIntegrationEventHandler> integrationEventHandlerLocator;

        protected MessageHandlerBase(
            string exchangeName, 
            string routingKey, 
            Dictionary<string,object> arguments, 
            Func<Type, IIntegrationEventHandler> integrationEventHandlerLocator)
        {
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
            Arguments = arguments;
            this.integrationEventHandlerLocator = integrationEventHandlerLocator;
        }

        public string ExchangeName { get; }
        public string RoutingKey { get; }
        public Dictionary<string, object> Arguments { get; }

        public async Task<bool> Handle(byte[] message)
        {
            var messageDto = JsonSerializer.Deserialize<TMessageDto>(message);

            var integrationEvent = ToIntegrationEvent(messageDto);

            var integrationEventHandler = integrationEventHandlerLocator(typeof(TIntegrationEvent));

            var result = await integrationEventHandler.Handle(integrationEvent);

            return result;
        }

        public abstract TIntegrationEvent ToIntegrationEvent(TMessageDto messageDto);
    }
}
