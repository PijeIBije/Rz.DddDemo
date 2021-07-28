using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Orders.Domain.AutoCancellationParameters.ValueObjects
{
    public class TimeUntilAutoCancellationInHours:RangedValueObjectBase<int>
    {
        public const int Min = 12;

        public const int Max = 24 * 365;

        protected TimeUntilAutoCancellationInHours(int value) : base(value, Min, Max, true, true)
        {
        }
    }
}
