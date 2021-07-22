
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Rz.DddDemo.Base.Presentation.WebApi.Swashbuckle
{
    public class IncludesOperationFilter<TIncludesObject,TController>:IOperationFilter
    where TIncludesObject:class
    where TController:ControllerBase
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.DeclaringType == typeof(TController))
            {
                var includesParamter = operation.Parameters.SingleOrDefault(x=>x.Name== ControllerBase.IncludesQueryParameterName);

                if (includesParamter != null)
                {
                    var includes = GetIncludes(typeof(TIncludesObject), string.Empty);

                    includesParamter.Schema.Enum.Clear();

                    foreach (var include in includes)
                    {
                        includesParamter.Schema.Enum.Add(new OpenApiString(include));
                    }
                }
            }
        }

        private IEnumerable<string> GetIncludes(Type includesObjectType, string rootPath)
        {
            var result = new List<string>();

            var includesProperties = includesObjectType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.Name);

            if (!string.IsNullOrWhiteSpace(rootPath))
            {
                includesProperties = includesProperties
                    .Select(x => $"{rootPath}{ControllerBase.IncludesPropertyPathSeparator}{x}").ToList();
            }

            result.AddRange(includesProperties);

            var nestedIncludesProperties = includesObjectType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType.IsClass);

            foreach (var nestedIncludesProperty in nestedIncludesProperties)
            {
                var nestedPath = nestedIncludesProperty.Name;

                if (!string.IsNullOrWhiteSpace(rootPath))
                {
                    nestedPath = $"{rootPath}{ControllerBase.IncludesPropertyPathSeparator}{nestedPath}";
                }

                result.AddRange(GetIncludes(nestedIncludesProperty.PropertyType,nestedPath));
            }

            return result;
        }
    }
}
