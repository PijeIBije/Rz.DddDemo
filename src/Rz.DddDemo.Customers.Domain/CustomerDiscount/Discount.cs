using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Domain.CustomerDiscount
{
    public class Discount:RangedValueObjectBase<float>
    {
        public const float DiscountRatio = 0.001f;
        public const float DiscountMax = 0.05f;

        protected Discount(float value) : base(value, 0, DiscountMax, true, true)
        {
        }

        public static implicit operator Discount(float value) => new Discount(value);

        public static Discount Calculate(Price totalPurchaseValue)
        {
            var discount = Math.Min(DiscountMax, (float)totalPurchaseValue.Value * DiscountRatio);

            return discount;
        }
    }
}
