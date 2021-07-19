using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Orders.Domain.ProductAggregate.ValueObjects;

namespace Rz.DddDemo.Orders.Application.Queries
{
    public class OrderLineResult
    {
        public Guid ProductId { get; }

        public decimal OrderPrice { get; }

        public int Quantity { get; set; }
    }
}
