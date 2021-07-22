using System;

namespace Rz.DddDemo.Base.Mapping.Interface
{
    public interface IMapper
    {
        TResult Map<TSource, TResult>(TSource source, bool requireAllProperties = true);

        bool TryMap<TSource, TResult>(TSource source, out TResult result, bool requireAllProperties = true);

        bool TryMap(object source, Type resultType, out object result, bool requireAllProperties = true);

        bool Map(object source, Type resultType, out object result, bool requireAllProperties = true);
    }
}
