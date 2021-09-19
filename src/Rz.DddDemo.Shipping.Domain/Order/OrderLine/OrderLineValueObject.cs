using Rz.DddDemo.Base.Domain;

namespace Rz.DddDemo.Shipping.Domain.Order.OrderLine
{
    public class OrderLineValueObject
    {
        public ProductId ProductId { get; }
        public Quantity Quantity { get; }

        public OrderLineValueObject(
            ProductId productId,
            Quantity quantity)
        {
            Guard.AgainstNullValue(productId,nameof(productId));
            Guard.AgainstNullValue(quantity,nameof(quantity));

            ProductId = productId;
            Quantity = quantity;
        }
    }
}
