using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Base.Mapping.DomainObjects.Tests.Model
{
    public class StringValueObject:StringValueObjectBase
    {
        public StringValueObject(string value) : base(value)
        {
        }

        public static implicit operator StringValueObject(string value) =>
            value != null ? new StringValueObject(value) : null;
    }
}
