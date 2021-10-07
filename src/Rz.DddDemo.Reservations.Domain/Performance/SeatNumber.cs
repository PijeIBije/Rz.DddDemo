using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Reservations.Domain.Performance
{
    public class SeatNumber:RangedValueObjectBase<int>
    {
        public SeatNumber(int value) : base(value, 0, int.MaxValue, false, true)
        {

        }

        public static implicit operator SeatNumber(int value) => new SeatNumber(value);
    }
}
