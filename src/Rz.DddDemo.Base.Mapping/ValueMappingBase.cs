using System;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Mapping
{
    public abstract class ValueMappingBase<TSource,TResult>:IValueMapping
    {
        public bool TryMap(object source, Type resultType, out object result, bool allowPartialMapping,
            IMapper mainMapper)
        {
            if (source is TSource sourceAsTSource && typeof(TResult).IsAssignableFrom(resultType))
            {
                if (TryMap(sourceAsTSource, resultType, mainMapper, out var resultObject, allowPartialMapping))
                {
                    result = resultObject;
                    return true;
                }
            }

            result = default;
            return false;
        }

        public abstract bool TryMap(TSource source, Type resultType, IMapper mainMapper, out TResult result, bool allowPartialMapping);
    }
}
