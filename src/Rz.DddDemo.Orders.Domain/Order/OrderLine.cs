using System;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.Order.ValueObjects;
using Rz.DddDemo.Orders.Domain.ProductAggregate.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Order
{
    public class OrderLine:DomainEntityBase<ProductId>
    {
        public OrderLine(
            ProductId productId, 
            decimal orderPrice,
            Quantity quantity):base(productId)
        {
            ProductId = productId;
            OrderPrice = orderPrice;
            Quantity = quantity;
        }

        public ProductId ProductId { get;  }

        public decimal OrderPrice { get; }
        
        public Quantity Quantity { get; private set; }

        public void AddQuantity(Quantity quantity)
        {
            var newQuantity = quantity + Quantity;

            if (newQuantity > Quantity.Max) throw new Exception($"New quantity would excceed max of {Quantity.Max}");

            Quantity = newQuantity;
        }

        public decimal TotalPrice => OrderPrice * Quantity;
    }
}
