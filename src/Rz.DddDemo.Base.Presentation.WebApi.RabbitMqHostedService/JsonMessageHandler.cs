using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Presentation.WebApi.RabbitMqHostedService.Interfaces;

namespace Rz.DddDemo.Base.Presentation.WebApi.RabbitMqHostedService
{
    public abstract class MessageHandlerBase<TMessageDto,TIntegrationEvent>:IMessageHandler 
        where TMessageDto:new()
        where TIntegrationEvent:IIntegrationEvent
    {
        private readonly IMediator mediator;

        protected MessageHandlerBase(
            string exchangeName, 
            string routingKey, 
            Dictionary<string,object> arguments,
            IMediator mediator)
        {
            this.mediator = mediator;
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
            Arguments = arguments;
            this.mediator = mediator;
        }

        public string ExchangeName { get; }
        public string RoutingKey { get; }
        public Dictionary<string, object> Arguments { get; }

        public async Task<bool> Handle(byte[] message)
        {
            var messageDto = JsonSerializer.Deserialize<TMessageDto>(message);

            var integrationEvent = ToIntegrationEvent(messageDto);

            await mediator.Send(integrationEvent);

            return true;
        }

        public abstract TIntegrationEvent ToIntegrationEvent(TMessageDto messageDto);
    }
}
