using System;

namespace Rz.DddDemo.Base.Mapping.Interface
{
    public interface IMapper
    {
        TResult Map<TSource, TResult>(TSource source, bool allowPartialMapping = true);

        bool TryMap<TSource, TResult>(TSource source, out TResult result, bool allowPartialMapping = true);

        object Map(object source, Type resultType, bool allowPartialMapping = true);

        bool TryMap(object source, out object result, Type resultType, bool allowPartialMapping = true);
    }
}
