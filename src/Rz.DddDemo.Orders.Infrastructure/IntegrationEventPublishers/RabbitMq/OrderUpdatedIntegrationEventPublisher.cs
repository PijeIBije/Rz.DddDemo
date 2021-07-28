using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using Rz.DddDemo.Base.Infrastructure.RabbitMq;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Orders.Domain.Order;
using Rz.DddDemo.Orders.Infrastructure.IntegrationEventPublishers.RabbitMq.Dto;

namespace Rz.DddDemo.Orders.Infrastructure.IntegrationEventPublishers.RabbitMq
{
    public class OrderUpdatedIntegrationEventPublisher : RabbitMqIntegrationEventPublisherBase<OrderUpdatedIntegrationEvent, OrderUpdatedIntegrationEventDto>
    {
        private readonly IMapper mapper;

        private static readonly RabbitMqIntegrationEventPublisherConfig Config =
            new RabbitMqIntegrationEventPublisherConfig
            {
                Arguments = null,
                ExchangeName = Schemas.MessageQueue.RabbitMq.Names.Orders.ExchangeName,
                Mandatory = false,
                RoutingKey = Schemas.MessageQueue.RabbitMq.Names.Orders.Topics.OrderUpdated
            };

        public OrderUpdatedIntegrationEventPublisher(
            ConnectionFactory connectionFactory,
            IMapper mapper) : base(connectionFactory, Config)
        {
            this.mapper = mapper;
        }

        public override OrderUpdatedIntegrationEventDto ToIntegrationEventDto(OrderUpdatedIntegrationEvent integrationEvent)
        {
            var dto = mapper.Map<OrderAggregate, OrderUpdatedIntegrationEventDto>(integrationEvent.Order);

            return dto;
        }
    }
}
