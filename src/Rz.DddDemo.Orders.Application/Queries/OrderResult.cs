using System.Collections.Generic;
using Rz.DddDemo.Orders.Domain.Order;

namespace Rz.DddDemo.Orders.Application.Queries
{
    public class OrderResult
    {
        public List<OrderLineResult> Lines { get; set; }

        public bool IsShipped { get; private set; }

        public bool IsCancelled { get; private set; }

        public ShippingAddressValueObject ShippingAddress { get; private set; }
    }
}
