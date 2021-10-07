using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Reservations.Domain.Performance
{
    public class RowNumber : RangedValueObjectBase<int>
    {
        public RowNumber(int value) : base(value, 0, int.MaxValue, false, true)
        {

        }

        public static implicit operator RowNumber(int value) => new RowNumber(value);
    }
}
