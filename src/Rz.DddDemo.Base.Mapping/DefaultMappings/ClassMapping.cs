using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Mapping.DefaultMappings
{
    public class ClassMapping:IValueMapping
    {
        public bool TryMap(object source, Type resultType, IMapper mainMapper, out object result)
        {
            var sourceType = source.GetType();

            if (!sourceType.IsClass || resultType.IsClass)
            {
                result = default;
                return false;
            }

            ParameterInfo[] selectedConstructorParamterInfos = Array.Empty<ParameterInfo>();

            ConstructorInfo selectedConstructorInfo = null;

            foreach (var constructorInfo in sourceType.GetConstructors(BindingFlags.Instance | BindingFlags.Public))
            {
                var constructorParamterInfos = constructorInfo.GetParameters();

                if (constructorParamterInfos.Length > selectedConstructorParamterInfos.Length)
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

                    if (!mainMapper.TryMap(sourceValue,selectedConstructorParamterInfo.ParameterType , out var mappedValue))
                    {
                        result = default;
                        return false;
                    }

                    arguments.Add(mappedValue);
                }

                result = Activator.CreateInstance(resultType, arguments.ToList());

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

                if (mainMapper.TryMap(value,resultPropertyInfo.PropertyType, out var mappedValue))
                {
                    resultPropertyInfo.SetValue(result, mappedValue);
                }
            }

            return true;
        }
    }
}
