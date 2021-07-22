using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using Rz.DddDemo.Base.Infrastructure.RabbitMq;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Address;
using Rz.DddDemo.Customers.Domain.Address.ValueObjects;

namespace Rz.DddDemo.Customers.Infrastructure.IntegrationEventsPublishers.RabbitMq
{
    public class CustomerUpdatedPublisher : RabbitMqIntegrationEventPublisherBase<CustomerUpdatedIntegrationEvent, CustomerUpdatedIntegraionEventDto>
    {
        private readonly IMapper mapper;

        private static readonly RabbitMqIntegrationEventPublisherConfig Config =
            new RabbitMqIntegrationEventPublisherConfig
            {
                Arguments = null,
                ExchangeName = Schemas.MessageQueue.RabbitMq.Names.CustomerExchangeName,
                Mandatory = false,
                RoutingKey = Schemas.MessageQueue.RabbitMq.Names.Topics.CustomerCreated
            };

        public CustomerUpdatedPublisher(
            ConnectionFactory connectionFactory,
            IMapper mapper) : base(connectionFactory, Config)
        {
            this.mapper = mapper;
        }

        public override CustomerUpdatedIntegraionEventDto ToIntegrationEventDto(CustomerUpdatedIntegrationEvent integrationEvent)
        {
            var dto = mapper.Map<CustomerAggregate, CustomerUpdatedIntegraionEventDto>(integrationEvent.DomainEvent.Source);

            return dto;
        }
    }
}
