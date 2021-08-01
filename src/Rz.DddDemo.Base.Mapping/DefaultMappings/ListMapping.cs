using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Mapping.DefaultMappings
{
    public class ListMapping:IValueMapping
    {
        public bool TryMap(object source, Type resultType, out object result, bool allowPartialMapping,
            IMapper mainMapper)
        {
            var sourceType = source.GetType();

            if (typeof(string).IsAssignableFrom(sourceType) || !typeof(IEnumerable).IsAssignableFrom(sourceType) || !sourceType.IsGenericType)
            {
                result = default;
                return false;
            }

            var genericArguments = sourceType.GetGenericArguments();

            if (genericArguments.Length != 1)
            {
                result = default;
                return false;
            }

            var sourceItemType = genericArguments.Single();

            if (typeof(string).IsAssignableFrom(resultType) || !typeof(IEnumerable).IsAssignableFrom(resultType) || !resultType.IsGenericType)
            {
                result = default;
                return false;
            }

            genericArguments = resultType.GetGenericArguments();

            if (genericArguments.Length != 1)
            {
                result = default;
                return false;
            }

            var resultItemType = genericArguments.Single();

            var genericListType = typeof(List<>).MakeGenericType(resultItemType);

            if(!resultType.IsAssignableFrom(genericListType))
            {
                result = default;
                return false;
            }

            var resultAsList = (IList)Activator.CreateInstance(genericListType);

            if(resultAsList == null) throw new Exception("This can't happen. Coding Error.");

            foreach (var item in (IEnumerable)source)
            {
                if (!mainMapper.TryMap(item, out var mappedValue,resultItemType,allowPartialMapping))
                {
                    result = default;
                    if(allowPartialMapping) continue;
                    return false;
                }

                resultAsList.Add(mappedValue);
            }

            result = resultAsList;
            return true;
        }
    }
}
