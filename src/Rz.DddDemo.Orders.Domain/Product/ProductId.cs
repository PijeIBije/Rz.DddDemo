using System;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Orders.Domain.Product
{
    public class ProductId:GuidValueObjectBase
    {
        public ProductId(Guid value):base(value)
        {
            
        }

        public ProductId()
        {
            
        }

        public static implicit operator ProductId(Guid value) => new ProductId(value);
    }
}
