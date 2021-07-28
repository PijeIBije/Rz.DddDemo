using System;

namespace Rz.DddDemo.Orders.Infrastructure.IntegrationEventPublishers.RabbitMq.Dto
{
    public class OrderLineDto
    {
        public Guid ProductId { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal ProductPrice { get; set; }
        
        public decimal TotalPrice { get; set; }
    }
}
