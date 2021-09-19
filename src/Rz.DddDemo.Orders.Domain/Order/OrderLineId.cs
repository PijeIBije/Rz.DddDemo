using System;
using Rz.DddDemo.Orders.Domain.Product;

namespace Rz.DddDemo.Orders.Domain.Order
{
    public class OrderLineId:ProductId
    {
        public OrderLineId(Guid value) : base(value)
        {
        }

        public OrderLineId()
        {
            
        }

        public OrderLineId(ProductId productId):base(productId)
        {
            
        }
    }
}
