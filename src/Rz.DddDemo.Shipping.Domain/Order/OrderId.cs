using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Shipping.Domain.Order
{
    public class OrderId:GuidValueObjectBase
    {
        public OrderId()
        {
            
        }

        public OrderId(Guid value):base(value)
        {
            
        }

        public static implicit operator OrderId(Guid value) => new OrderId(value);
    }
}
