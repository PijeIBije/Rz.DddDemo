using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Reservations.Domain.Performance
{
    public class PriceName:StringValueObjectBase
    {
        public PriceName(string value) : base(value, 0, 200)
        {

        }

        public static implicit operator PriceName(string value) => new PriceName(value);
    }
}
