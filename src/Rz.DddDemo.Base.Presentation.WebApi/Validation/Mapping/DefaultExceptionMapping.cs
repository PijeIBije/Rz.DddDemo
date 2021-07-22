using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Errors;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping.Interfaces;

namespace Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping
{
    public class DefaultExceptionMapping:IExceptionMapping
    {
        public static readonly IEnumerable<string> IgnoredProperties =
            typeof(Exception).GetProperties(BindingFlags.Instance|BindingFlags.Public)
                .Select(x => x.Name)
                .Union(new[] {nameof(ArgumentException.ParamName)});

        public bool TryMapToRequestErrors(Exception exception, out IEnumerable<ValidationError> result)
        {
            var errorName = RemoveArgumentPrefix(
                ReplaceExceptionSuffix(
                    RemoveGenericInfo(exception.GetType().Name)));

            var errorData = GetValidationErrorData(exception);

            var validationError = new ValidationError(errorName, errorData);

            result = new[] {validationError};

            return true;
        }

        private string RemoveGenericInfo(string name)
        {
            var genericInfoIndex = name.IndexOf('`');
            var isGeneric = genericInfoIndex > 0;
            return isGeneric ? name.Remove(genericInfoIndex) : name;
        }

        protected string ReplaceExceptionSuffix(string name)
        {
            return name.Substring(0, name.Length - nameof(Exception).Length) + "Error";
        }

        protected string RemoveArgumentPrefix(string name)
        {
            const string prefix = "Argument";

            if (name.StartsWith(prefix)) name = name.Substring(prefix.Length);

            return name;
        }

        protected object GetValidationErrorData(object obj)
        {
            var data = new Dictionary<string,object>();

            var exceptionType = obj.GetType();

            var propertyInfosAll = exceptionType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            var propertyInfos = propertyInfosAll.Where(x => !IgnoredProperties.Contains(x.Name));

            foreach (var propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(obj);

                if (value == null) continue;

                if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
                {
                    value = GetValidationErrorData(value);

                    data.Add(propertyInfo.Name,value);
                }
            }

            return data;
        }
    }
}
