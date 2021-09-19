using RabbitMQ.Client;
using Rz.DddDemo.Base.Infrastructure.RabbitMq;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Customers.Domain;

namespace Rz.DddDemo.Customers.Infrastructure.IntegrationEventPublishers.RabbitMq
{
    public class CustomerUpdatedIntegrationEventPublisher : RabbitMqIntegrationEventPublisherBase<CustomerUpdatedIntegrationEvent, CustomerUpdatedIntegraionEventDto>
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

        public CustomerUpdatedIntegrationEventPublisher(
            ConnectionFactory connectionFactory,
            IMapper mapper) : base(connectionFactory, Config)
        {
            this.mapper = mapper;
        }

        public override CustomerUpdatedIntegraionEventDto ToIntegrationEventDto(CustomerUpdatedIntegrationEvent integrationEvent)
        {
            var dto = mapper.Map<CustomerAggregate, CustomerUpdatedIntegraionEventDto>(integrationEvent.Customer);

            return dto;
        }
    }
}
