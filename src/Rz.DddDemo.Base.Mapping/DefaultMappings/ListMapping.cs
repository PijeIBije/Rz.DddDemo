using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Mapping.DefaultMappings
{
    public class ListMapping:IValueMapping
    {
        public bool TryMap(object source, Type resultType, IMapper mainMapper, out object result)
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

            var genericListType = typeof(List<>).MakeGenericType(sourceItemType);

            if(resultType.IsAssignableFrom(genericListType))
            {
                result = default;
                return false;
            }

            var resultAsList = (IList)Activator.CreateInstance(genericListType);

            if(resultAsList == null) throw new Exception("This can't happen. Coding Error.");

            foreach (var item in (IEnumerable)source)
            {
                if (!mainMapper.TryMap(item, resultItemType, out var mappedValue))
                {
                    result = default;
                    return false;
                }

                resultAsList.Add(mappedValue);
            }

            result = resultAsList;
            return true;
        }
    }
}
