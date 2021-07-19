using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Mapping.DefaultMappings
{
    public class ValueTypeMapping:IValueMapping
    {
        public bool TryMap(object source, Type resultType, IMapper mainMapper, out object result)
        {
            if (resultType.IsInstanceOfType(source))
            {
                result = source;
                return true;
            }

            result = default;
            return false;
        }
    }
}
