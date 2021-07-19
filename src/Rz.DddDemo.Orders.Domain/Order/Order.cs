using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.Order.ValueObjects;
using Rz.DddDemo.Orders.Domain.ProductAggregate;
using Rz.DddDemo.Orders.Domain.ProductAggregate.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Order
{
    public class Order:DomainEntityBase<OrderId>
    {
        public bool IsShipped { get; private set; }

        public bool IsCancelled { get; private set; }

        public ShippingAddress ShippingAddress { get; private set; }

        private readonly List<OrderLine> orderLines = new List<OrderLine>();

        public IReadOnlyList<OrderLine> OrderLines => orderLines;

        public Order(OrderId orderId, ShippingAddress shippingAddress, bool isShipped, IEnumerable<OrderLine> orderLines, bool isCancelled):base(orderId)
        {
            ShippingAddress = shippingAddress;
            IsShipped = isShipped;
            this.orderLines = orderLines.ToList();
            IsCancelled = isCancelled;
        }

        public Order(ShippingAddress shippingAddress):this(
            new OrderId(),
            shippingAddress,
            false, 
            Enumerable.Empty<OrderLine>(),false)
        {

        }

        public void AddOrderLine(Product product, Quantity quantity)
        {
            var existingOrderLine = orderLines.SingleOrDefault(x => x.ProductId == product.Id);

            if (existingOrderLine != null)
            {
                existingOrderLine.AddQuantity(quantity);
            }
            else
            {
                var newOrderLine = new OrderLine(product.Id,product.Price,quantity);
                orderLines.Add(newOrderLine);
            }
        }

        public void RemoveOrderLine(ProductId productId)
        {
            var orderLine = orderLines.SingleOrDefault(x => x.ProductId == productId);

            if(orderLine == null) throw new InvalidOperationException($"No order line with product id {productId}");

            orderLines.Remove(orderLine);
        }

        public void UpdateShippingAddress(ShippingAddress shippingAddress)
        {
            Guard.AgainstNullValue(shippingAddress,nameof(shippingAddress));

            if(IsShipped) throw new InvalidOperationException("Cannot update Shipping Address of already shipped order");

            ShippingAddress = shippingAddress;
        }

        public void CancelOrder()
        {
            IsCancelled = true;
        }
    }
}
