using System;

namespace Rz.DddDemo.Base.Domain.ValueObject
{
    public class RangedValueObjectBase<TValue>:SingleValueObjectBase<TValue> where TValue:IComparable
    {
        protected RangedValueObjectBase(TValue value,TValue minValue, TValue maxValue, bool includeMin = true, bool includeMax = true) : base(value)
        {
            Guard.AgainstValueNotInRange(nameof(value),value,minValue,maxValue,includeMin,includeMax);
        }
    }
}
