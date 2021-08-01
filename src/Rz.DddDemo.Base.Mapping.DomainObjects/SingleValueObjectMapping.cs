using System;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Base.Domain.ValueObject.Interfaces;

namespace Rz.DddDemo.Base.Mapping.DomainObjects
{
    public class SingleValueToObjectMapping:ValueMappingBase<ISingleValueObject,object>
    {
        public override bool TryMap(ISingleValueObject source, Type resultType, IMapper mainMapper, out object result,
            bool allowPartialMapping)
        {
            result = source.Value;
            return true;
        }
    }
}
