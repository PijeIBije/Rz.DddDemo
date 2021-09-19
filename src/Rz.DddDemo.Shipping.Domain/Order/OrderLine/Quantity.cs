using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Shipping.Domain.Order.OrderLine
{
    public class Quantity:RangedValueObjectBase<int>
    {
        public const int Min = 1;

        public const int Max = 1000;

        protected Quantity(int value) : base(value, Min, Max, true, true)
        {
        }

        public static implicit operator Quantity(int value) => new Quantity(value);
    }
}
