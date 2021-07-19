using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Presentation.WebApi.IncludesMapping.Interfaces;

namespace Rz.DddDemo.Base.Presentation.WebApi.IncludesMapping
{
    public class IncludesMapper : IIncludesMapper
    {
        public const string IncludesPropertyPathSeparator = ".";

        public T Map<T>(IEnumerable<string> includes) where T : class
        {
            if (includes == null) return null;

            var includesSplit = includes.Select(x=>x.Split(IncludesPropertyPathSeparator).ToList()).ToList();

            return (T) Map(typeof(T), includesSplit);
        }

        protected virtual object Map(Type includesType, List<List<string>> includes)
        {
            if (includes == null) return null;

            var includesObject = Activator.CreateInstance(includesType);

            var includesForNestedObjects = includes.Where(x => x.Count > 1).GroupBy(x => x.First());

            foreach (var includesForNestedObject in includesForNestedObjects)
            {
                var nestedIncludeName = includesForNestedObject.Key;

                var nestedIncludeProperty = includesType.GetProperty(nestedIncludeName);

                if(nestedIncludeProperty == null) throw new MissingMemberException(nestedIncludeName);

                var nestedIncludeType = nestedIncludeProperty.PropertyType;

                var includesForNestedObjectWithoutRoot =
                    includesForNestedObject.Select(x => x.Skip(1).ToList()).ToList();

                var nestedIncludesObject = Map(nestedIncludeType, includesForNestedObjectWithoutRoot);

                nestedIncludeProperty.SetValue(includesObject,nestedIncludesObject);
            }

            var includesForThisObject = includes.Where(x => x.Count == 1).Select(x => x.Single());

            foreach (var includeForThisObject in includesForThisObject)
            {
                var propertyInfo = includesType.GetProperty(includeForThisObject);

                if(propertyInfo == null) throw new MissingMemberException(includeForThisObject);

                if (propertyInfo.PropertyType == typeof(bool))
                {
                    propertyInfo.SetValue(includesObject,true);
                }
                else
                {
                    throw new Exception("Either nested includes object or bool flag is allowed.");
                }
            }

            return includesObject;
        }
    }
}
