using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Base.Mapping.DomainObjects.Tests.Model
{
    public class EnumValueObject:EnumValueObjectBase<EnumValueObject.Values>
    {
        public enum Values
        {
            A,
            B
        }

        public EnumValueObject(Values value) : base(value)
        {
        }

        public EnumValueObject(string value) : base(value)
        {
        }
    }
}
