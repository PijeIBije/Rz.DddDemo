using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Reservations.Domain.Customer
{
    public class Discount:RangedValueObjectBase<decimal>
    {
        protected Discount(decimal value) : base(value, 0, decimal.MaxValue, true, true)
        {
        }

        public static implicit operator Discount(decimal value) => new Discount(value);
    }
}
