using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.Purchase
{
    public class Price:RangedValueObjectBase<decimal>
    {
        protected Price(decimal value) : base(value, 0, decimal.MaxValue, false, true)
        {
        }

        public static implicit operator Price(decimal value) => new Price(value);
    }
}
