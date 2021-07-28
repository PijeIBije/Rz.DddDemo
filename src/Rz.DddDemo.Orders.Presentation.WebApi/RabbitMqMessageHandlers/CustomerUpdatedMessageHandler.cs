using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound;
using Rz.DddDemo.Orders.Presentation.WebApi.RabbitMqMessageHandlers.Dto;
using Rz.DddDemo.Base.Presentation.WebApi.RabbitMqHostedService;
using Rz.DddDemo.Orders.Domain.Customer.Address;

namespace Rz.DddDemo.Orders.Presentation.WebApi.RabbitMqMessageHandlers
{
    public class CustomerUpdatedMessageHandler:MessageHandlerBase<CustomerUdpatedDto,CustomerUpdatedIntegrationEvent>
    {
        private readonly IMapper mapper;

        public CustomerUpdatedMessageHandler(
            IMapper mapper,
            string exchangeName, 
            string routingKey, 
            Dictionary<string, object> arguments, Func<Type, IIntegrationEventHandler> integrationEventHandlerLocator) : base(exchangeName, routingKey, arguments, integrationEventHandlerLocator)
        {
            this.mapper = mapper;
        }

        public override CustomerUpdatedIntegrationEvent ToIntegrationEvent(CustomerUdpatedDto messageDto)
        {
            
        }
    }
}
