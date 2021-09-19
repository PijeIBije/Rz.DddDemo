using System;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Orders.Domain.Order
{
    public class OrderId : GuidValueObjectBase
    {
        public OrderId()
        {
            
        }

        public OrderId(Guid value):base(value)
        {
            
        }
    }
}
