using System;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.ValueObjects
{
    public class DateOfBirth:RangedValueObjectBase<DateTime>
    {
        public static readonly DateTime Min = new DateTime(1950,0,0);

        public static readonly DateTime Max = DateTime.Now.AddYears(-18);
        protected DateOfBirth(DateTime value) : base(value,Min,Max)
        {
        }

        public static implicit operator DateOfBirth(DateTime value) => new DateOfBirth(value);
    }
}
