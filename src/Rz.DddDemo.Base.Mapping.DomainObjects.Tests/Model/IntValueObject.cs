using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Base.Mapping.DomainObjects.Tests.Model
{
    public class IntValueObject:SingleValueObjectBase<int>
    {
        public IntValueObject(int value) : base(value)
        {
        }
    }
}
