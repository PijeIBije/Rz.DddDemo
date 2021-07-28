using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Orders.Infrastructure.OrderRepository.EntityFrameworkWithDapper
{
    public class OrderDto
    {
        public bool IsShipped { get; set; }

        public bool IsPaid { get;  set; }

        public bool IsCancelled { get; set; }

        public List<OrderLineDto> OrderLines { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

