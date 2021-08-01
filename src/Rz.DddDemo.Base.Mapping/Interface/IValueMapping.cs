using System;

namespace Rz.DddDemo.Base.Mapping.Interface
{
    public interface IValueMapping
    {
        bool TryMap(object source, Type resultType, out object result, bool allowPartialMapping, IMapper mainMapper);
    }
}
