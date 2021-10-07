using Rz.DddDemo.Base.Domain.ValueObject;
using Rz.DddDemo.Reservations.Domain.Customer;

namespace Rz.DddDemo.Reservations.Domain.Performance
{
    public class Price : RangedValueObjectBase<decimal>
    {
        protected Price(decimal value) : base(value, 0, decimal.MaxValue, false, true)
        {
        }

        public static implicit operator Price(decimal value) => new Price(value);

        public Price ApplyDiscount(Discount discount)
        {
            return this * (1-discount);
        }
    }
}
