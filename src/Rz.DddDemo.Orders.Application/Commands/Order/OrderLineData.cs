using Rz.DddDemo.Orders.Domain.Order.ValueObjects;
using Rz.DddDemo.Orders.Domain.Product.ValueObjects;

namespace Rz.DddDemo.Orders.Application.Commands.Order
{
    public class OrderLineData
    {
        public ProductId ProductId { get; set; }

        public Quantity Quantity { get; set; }
    }
}
