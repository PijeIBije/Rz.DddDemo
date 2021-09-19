using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.Product;

namespace Rz.DddDemo.Orders.Domain.Order
{
    public class OrderAggregate:DomainEntityBase<OrderId>
    {
        public event DomainEventHanlder<OrderUpdatedDomainEvent> OrderUpdated;
        public bool IsShipped { get; private set; }

        public bool IsPaid { get; private set; }

        public bool IsCancelled { get; private set; }

        public ShippingAddressValueObject ShippingAddress { get; private set; }

        private readonly List<OrderLineEntity> orderLines;

        public IReadOnlyList<OrderLineEntity> OrderLines => orderLines;

        public OrderAggregate(OrderId orderId, ShippingAddressValueObject shippingAddress, bool isShipped, IEnumerable<OrderLineEntity> orderLines, bool isCancelled):base(orderId)
        {
            ShippingAddress = shippingAddress;
            IsShipped = isShipped;
            this.orderLines = orderLines.ToList();
            IsCancelled = isCancelled;
        }

        public OrderAggregate(ShippingAddressValueObject shippingAddress,IEnumerable<OrderLineEntity> orderLines):this(
            new OrderId(),
            shippingAddress,
            false,orderLines,false)
        {

        }

        public void AddOrderLine(ProductAggregate product, Quantity quantity)
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

        public void UpdateShippingAddress(ShippingAddressValueObject newShippingAddress)
        {
            Guard.AgainstNullValue(newShippingAddress,nameof(newShippingAddress));

            if(IsShipped) throw new InvalidOperationException("Cannot update Shipping Address of already shipped order");

            var orderUpdated = newShippingAddress != ShippingAddress;

            ShippingAddress = newShippingAddress;

            if(orderUpdated) OrderUpdated?.Invoke(new OrderUpdatedDomainEvent(this));
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

        public decimal TotalPrice => OrderLines.Sum(x => x.TotalPrice);
    }
}
