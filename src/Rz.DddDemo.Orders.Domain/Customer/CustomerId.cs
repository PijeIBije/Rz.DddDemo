using System;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Orders.Domain.Customer
{
    public class CustomerId:GuidValueObjectBase
    {
        public CustomerId()
        {
            
        }

        public CustomerId(Guid guid):base(guid)
        {
            
        }

        public static implicit operator CustomerId(Guid guid) => new CustomerId(guid);
    }
}
