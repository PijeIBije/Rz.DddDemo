using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.Order.ValueObjects;
using Rz.DddDemo.Orders.Domain.Product.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Order
{
    public class OrderAggregate:DomainEntityBase<OrderId>
    {
        public bool IsShipped { get; private set; }

        public bool IsPaid { get; private set; }

        public bool IsCancelled { get; private set; }

        public ShippingAddress ShippingAddress { get; private set; }

        private readonly List<OrderLineEntity> orderLines;

        public IReadOnlyList<OrderLineEntity> OrderLines => orderLines;

        public OrderAggregate(OrderId orderId, ShippingAddress shippingAddress, bool isShipped, IEnumerable<OrderLineEntity> orderLines, bool isCancelled):base(orderId)
        {
            ShippingAddress = shippingAddress;
            IsShipped = isShipped;
            this.orderLines = orderLines.ToList();
            IsCancelled = isCancelled;
        }

        public OrderAggregate(ShippingAddress shippingAddress,IEnumerable<OrderLineEntity> orderLines):this(
            new OrderId(),
            shippingAddress,
            false,orderLines,false)
        {

        }

        public void AddOrderLine(ProductAggregate.ProductAggregate product, Quantity quantity)
        {
            var existingOrderLine = orderLines.SingleOrDefault(x => x.ProductId == product.Id);

            if (existingOrderLine != null)
            {
                existingOrderLine.AddQuantity(quantity);
            }
            else
            {
                var newOrderLine = new OrderLineEntity(product.Id,product.Price,quantity);
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

        public void Cancel()
        {
            IsCancelled = true;
        }

        public void SetPaid()
        {
            if(IsCancelled || IsShipped) throw new InvalidOperationException("Cannot set order as paid after it was shipped or cancelled.");

            IsPaid = true;
        }
    }
}
