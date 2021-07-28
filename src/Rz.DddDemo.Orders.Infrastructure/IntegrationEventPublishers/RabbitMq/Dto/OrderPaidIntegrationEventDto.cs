using System;

namespace Rz.DddDemo.Orders.Infrastructure.IntegrationEventPublishers.RabbitMq.Dto
{
    public class OrderPaidIntegrationEventDto
    {
        public Guid OrderId { get; set; }
    }
}
