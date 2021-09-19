using System;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.Product;

namespace Rz.DddDemo.Orders.Domain.Order
{
    public class OrderLineEntity:DomainEntityBase<OrderLineId>
    {
        public OrderLineEntity(
            ProductId productId, 
            decimal productPrice,
            Quantity quantity):base(new OrderLineId(productId))
        {
            ProductId = productId;
            ProductPrice = productPrice;
            Quantity = quantity;
        }

        public ProductId ProductId { get;  }

        public decimal ProductPrice { get; }
        
        public Quantity Quantity { get; private set; }

        public void AddQuantity(Quantity quantity)
        {
            var newQuantity = quantity + Quantity;

            if (newQuantity > Quantity.Max) throw new Exception($"New quantity would excceed max of {Quantity.Max}");

            Quantity = newQuantity;
        }

        public decimal TotalPrice => ProductPrice * Quantity;
    }
}
