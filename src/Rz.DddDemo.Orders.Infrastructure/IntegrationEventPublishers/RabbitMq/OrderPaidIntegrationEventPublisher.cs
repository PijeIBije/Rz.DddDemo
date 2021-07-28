using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using Rz.DddDemo.Base.Infrastructure.RabbitMq;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Orders.Domain.Customer;
using Rz.DddDemo.Orders.Domain.Order;
using Rz.DddDemo.Orders.Infrastructure.IntegrationEventPublishers.RabbitMq.Dto;

namespace Rz.DddDemo.Orders.Infrastructure.IntegrationEventPublishers.RabbitMq
{
    public class OrderPaidIntegrationEventPublisher : RabbitMqIntegrationEventPublisherBase<OrderPaidIntegrationEvent, OrderPaidIntegrationEventDto>
    {
        private readonly IMapper mapper;

        private static readonly RabbitMqIntegrationEventPublisherConfig Config =
            new RabbitMqIntegrationEventPublisherConfig
            {
                Arguments = null,
                ExchangeName = Schemas.MessageQueue.RabbitMq.Names.Orders.ExchangeName,
                Mandatory = false,
                RoutingKey = Schemas.MessageQueue.RabbitMq.Names.Orders.Topics.OrderPaid
            };

        public OrderPaidIntegrationEventPublisher(
            ConnectionFactory connectionFactory,
            IMapper mapper) : base(connectionFactory, Config)
        {
            this.mapper = mapper;
        }

        public override OrderPaidIntegrationEventDto ToIntegrationEventDto(OrderPaidIntegrationEvent integrationEvent)
        {
            var dto = mapper.Map<OrderPaidIntegrationEvent, OrderPaidIntegrationEventDto>(integrationEvent);

            return dto;
        }
    }
}
