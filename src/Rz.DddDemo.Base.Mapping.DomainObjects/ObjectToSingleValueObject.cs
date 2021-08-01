using System;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Base.Domain.ValueObject.Interfaces;

namespace Rz.DddDemo.Base.Mapping.DomainObjects
{
    public class ObjectToSingleValueObject:ValueMappingBase<object,ISingleValueObject>
    {
        public override bool TryMap(object source, Type resultType, IMapper mainMapper, out ISingleValueObject result,
            bool allowPartialMapping)
        {
            var valueObject = (ISingleValueObject)Activator.CreateInstance(resultType, source);

            result = valueObject;

            return true;
        }
    }
}
