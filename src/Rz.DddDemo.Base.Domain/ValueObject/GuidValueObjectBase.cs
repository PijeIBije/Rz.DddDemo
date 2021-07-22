using System;

namespace Rz.DddDemo.Base.Domain.ValueObject
{
    public abstract class GuidValueObjectBase:SingleValueObjectBase<Guid>
    {
        protected GuidValueObjectBase(Guid value) : base(value)
        {
        }

        protected GuidValueObjectBase():this(Guid.NewGuid())
        {

        }
    }
}
