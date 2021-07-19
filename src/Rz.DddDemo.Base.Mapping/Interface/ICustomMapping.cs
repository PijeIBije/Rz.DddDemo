using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Base.Mapping.Interface
{
    public interface IValueMapping
    {
        bool TryMap(object source, Type resultType, IMapper mainMapper, out object result);
    }
}
