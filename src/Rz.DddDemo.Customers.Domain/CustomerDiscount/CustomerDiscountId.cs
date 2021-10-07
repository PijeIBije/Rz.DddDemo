using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.CustomerDiscount
{
    public class CustomerDiscountId : GuidValueObjectBase
    {
        public CustomerDiscountId()
        {

        }

        public CustomerDiscountId(Guid guid) : base(guid)
        {

        }

        public static implicit operator CustomerDiscountId(Guid guid) => new CustomerDiscountId(guid);
    }
}
