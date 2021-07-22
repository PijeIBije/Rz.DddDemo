using System;

namespace Rz.DddDemo.Base.Mapping.Interface
{
    public interface IValueMapping
    {
        bool TryMap(object source, Type resultType, IMapper mainMapper, out object result, bool requireAllProperties);
    }
}
