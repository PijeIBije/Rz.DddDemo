using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.Purchase
{
    public class Quantity: RangedValueObjectBase<int>
    {
        protected Quantity(int value) : base(value, 1, int.MaxValue, true, true)
        {
        }

        public static implicit operator Quantity(int value) => new Quantity(value);
    }
}
