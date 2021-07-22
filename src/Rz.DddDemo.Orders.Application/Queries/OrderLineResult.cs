using System;

namespace Rz.DddDemo.Orders.Application.Queries
{
    public class OrderLineResult
    {
        public Guid ProductId { get; }

        public decimal OrderPrice { get; }

        public int Quantity { get; set; }
    }
}
