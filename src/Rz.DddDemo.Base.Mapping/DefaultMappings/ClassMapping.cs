using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Mapping.DefaultMappings
{
    public class ClassMapping:IValueMapping
    {
        public bool TryMap(object source, Type resultType, out object result, bool allowPartialMapping,
            IMapper mainMapper)
        {
            var sourceType = source.GetType();

            if (!sourceType.IsClass || !resultType.IsClass)
            {
                result = default;
                return false;
            }

            ParameterInfo[] selectedConstructorParamterInfos = Array.Empty<ParameterInfo>();

            ConstructorInfo selectedConstructorInfo = null;

            foreach (var constructorInfo in resultType.GetConstructors(BindingFlags.Instance | BindingFlags.Public))
            {
                var constructorParamterInfos = constructorInfo.GetParameters();

                if (constructorParamterInfos.Length >= selectedConstructorParamterInfos.Length)
                {
                    selectedConstructorParamterInfos = constructorParamterInfos;
                    selectedConstructorInfo = constructorInfo;
                }
            }

            if (selectedConstructorInfo == null)
            {
                result = default;
                return false;
            }

            var sourceProperties = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(x => x.CanRead).ToList();

            if (selectedConstructorParamterInfos.Length > 0)
            {
                var arguments = new List<object>();

                foreach (var selectedConstructorParamterInfo in selectedConstructorParamterInfos)
                {
                    var parameterName = selectedConstructorParamterInfo.Name;

                    var sourcePropertyInfo = sourceProperties.SingleOrDefault(x =>
                        x.Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

                    if (sourcePropertyInfo == null)
                    {
                        result = default;
                        return false;
                    }

                    var sourceValue = sourcePropertyInfo.GetValue(source);

                    if (!mainMapper.TryMap(sourceValue, out var mappedValue, selectedConstructorParamterInfo.ParameterType, allowPartialMapping))
                    {
                        result = default;
                        if(allowPartialMapping) continue;
                        return false;
                    }

                    arguments.Add(mappedValue);
                }

                result = Activator.CreateInstance(resultType, arguments.ToArray());

                return true;
            }

            result = Activator.CreateInstance(resultType);

            var resultPropertyInfos = resultType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(x => x.CanWrite);

            foreach (var resultPropertyInfo in resultPropertyInfos)
            {
                var sourcePropertyInfo = sourceProperties.SingleOrDefault(x =>
                    x.Name.Equals(resultPropertyInfo.Name, StringComparison.OrdinalIgnoreCase));

                if (sourcePropertyInfo == null) continue;
                var value = sourcePropertyInfo.GetValue(source);

                if (mainMapper.TryMap(value, out var mappedValue, resultPropertyInfo.PropertyType, allowPartialMapping))
                {
                    resultPropertyInfo.SetValue(result, mappedValue);
                }
                else
                {
                    if(allowPartialMapping)continue;
                    return false;
                }
            }

            return true;
        }
    }
}
