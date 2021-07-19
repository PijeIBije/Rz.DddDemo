using System;

namespace Rz.DddDemo.Base.Domain.ValueObject
{
    public class EnumValueObjectBase<TValue>:StringValueObjectBase where TValue:Enum
    {
        protected EnumValueObjectBase(TValue value) : this(value.ToString())
        {
        }

        protected EnumValueObjectBase(string value) : base(value)
        {

        }
    }
}
