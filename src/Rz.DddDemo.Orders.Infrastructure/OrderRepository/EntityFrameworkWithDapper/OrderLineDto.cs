using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Orders.Infrastructure.OrderRepository.EntityFrameworkWithDapper
{
    public class OrderLineDto
    {
        public int OrderLineId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public Guid OrderId { get; set; }

        public OrderDto Order { get; set; }
    }
}
