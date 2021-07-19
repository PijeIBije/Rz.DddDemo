using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Orders.Domain.ProductAggregate.ValueObjects
{
    public class ProductId:GuidValueObjectBase
    {
        public ProductId(Guid value):base(value)
        {
            
        }
    }
}
