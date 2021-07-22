using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MongoDB.Bson;

namespace Rz.DddDemo.Base.Infrastructure.MongoDb
{
    public class IncludesToProjectionBsonMapper
    {
        public BsonDocument Map(object includesObject, Dictionary<Type,IEnumerable<string>> defaultProperties = null, Dictionary<Type,Dictionary<string,string>> nameMappings = null)
        {
            var properties = GetIncludes(includesObject, new List<string>(),defaultProperties, nameMappings);

            return new BsonDocument(properties.ToDictionary(x=>x,x=>1));
        }

        private List<string> GetIncludes(object includesObject, List<string> rootPath, Dictionary<Type, IEnumerable<string>> defaultProperties = null, Dictionary<Type, Dictionary<string, string>> nameMappings = null)
        {
            var result = new List<string>();

            if (includesObject == null)
            {
                return result;
            }

            var includesObjectType = includesObject.GetType();

            if (nameMappings == null ||
                !nameMappings.TryGetValue(includesObjectType, out var nameMappingsForThisObject))
                nameMappingsForThisObject = null;

            if (defaultProperties != null &&
                defaultProperties.TryGetValue(includesObjectType, out var defaultPropertiesForThisObject))
            {
                foreach (var defaultProperty in defaultPropertiesForThisObject)
                {
                    var path = rootPath.ToList();
                    path.Add(defaultProperty);

                    var name = GetName(path, nameMappingsForThisObject);

                    result.Add(name);
                }
            }

            var properties = includesObjectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var propertyInfo in properties)
            {
                var value = propertyInfo.GetValue(includesObject);

                var path = rootPath.ToList();
                path.Add(propertyInfo.Name);

                if (propertyInfo.PropertyType == typeof(bool) && (bool)value)
                {
                    var name = GetName(path, nameMappingsForThisObject);

                    result.Add(name);
                }
                else
                {
                    if (propertyInfo.PropertyType.IsClass)
                    {
                        var nestedNames = GetIncludes(value,path, defaultProperties,nameMappings);

                        result.AddRange(nestedNames);
                    }
                }
            }

            return result;
        }

        private string GetName(string name, Dictionary<string, string> nameMappings = null)
        {
            var result = name;

            if (nameMappings != null && nameMappings.TryGetValue(name, out var newName))
                result = newName;

            return result;
        }

        private string GetName(IEnumerable<string> namePath, Dictionary<string, string> nameMappings = null)
        {
            var names = namePath.Select(x => GetName(x, nameMappings));

            return string.Join(".", names);
        }
    }
}
