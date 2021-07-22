using System;
using System.Collections;
using System.Collections.Generic;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Mapping.DefaultMappings
{
    public class DictionaryMapping:IValueMapping
    {
        public bool TryMap(object source, Type resultType, IMapper mainMapper, out object result)
        {
            var sourceType = source.GetType();

            if (!typeof(IDictionary).IsAssignableFrom(sourceType) || !sourceType.IsGenericType)
            {
                result = default;
                return false;
            }

            var genericArguments = sourceType.GetGenericArguments();

            if (genericArguments.Length != 2)
            {
                result = default;
                return false;
            }

            var sourceKeyType = genericArguments[0];
            var sourceValueType = genericArguments[1];

            if (!typeof(IDictionary).IsAssignableFrom(resultType) || !resultType.IsGenericType)
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

            var resultKeyType = genericArguments[0];
            var resultValueType = genericArguments[1];

            var genericDictionaryType = typeof(Dictionary<,>).MakeGenericType(resultKeyType,resultValueType);

            if (resultType.IsAssignableFrom(genericDictionaryType))
            {
                result = default;
                return false;
            }

            var resultAsDictionary = (IDictionary)Activator.CreateInstance(genericDictionaryType);

            if (resultAsDictionary == null) throw new Exception("This can't happen. Coding Error.");

            var sourceAsDictionary = (IDictionary) source;

            foreach (var key in sourceAsDictionary.Keys)
            {
                var value = sourceAsDictionary[key];

                if (!mainMapper.TryMap(key, resultKeyType, out var mappedKey) || !mainMapper.TryMap(value, resultValueType, out var mappedValue))
                {
                    result = default;
                    return false;
                }

                resultAsDictionary[mappedKey]=mappedValue;
            }

            result = resultAsDictionary;
            return true;
        }
    }
}
