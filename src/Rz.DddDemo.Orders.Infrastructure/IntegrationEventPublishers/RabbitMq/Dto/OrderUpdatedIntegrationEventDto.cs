using System.Collections.Generic;

namespace Rz.DddDemo.Orders.Infrastructure.IntegrationEventPublishers.RabbitMq.Dto
{
    public class OrderUpdatedIntegrationEventDto
    {
        public bool IsShipped { get; set; }

        public bool IsPaid { get; set; }

        public bool IsCancelled { get; set; }

        public List<OrderLineDto> OrderLines { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
