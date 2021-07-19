using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rz.DddDemo.Base.Infrastructure.Dapper
{
    public class IncludesToSqlMapper
    {
        public string GetSelectClauseColumns(object includesObject, string tableName, string schemaName,
            Dictionary<Type, IEnumerable<string>> defaultColumns,
            Dictionary<Type, Dictionary<string, string>> nameMappings = null)
        {
            var columnNames = GetColumnNames(includesObject, tableName, schemaName, defaultColumns, nameMappings);

            return string.Join(",",columnNames);
        }

        private IEnumerable<string> GetColumnNames(object includesObject, string parentObjectName, string schemaName,
            Dictionary<Type, IEnumerable<string>> defaultColumns,
            Dictionary<Type, Dictionary<string, string>> nameMappings = null)
        {
            var result = new List<string>();

            if (includesObject == null)
            {
                result.Add($"{GetName(new [] {schemaName,parentObjectName})}.{SqlKeywords.AllColumns}");
                return result;
            }

            var includesObjectType = includesObject.GetType();


            if (nameMappings == null || !nameMappings.TryGetValue(includesObjectType, out var nameMappingsForThisObject))
                nameMappingsForThisObject = null;

            if (defaultColumns.TryGetValue(includesObjectType, out var defaultColumnsForThisObject))
            {

                var defaultColumnNames = defaultColumnsForThisObject.Select(x =>
                    GetName(new[] {schemaName, parentObjectName, x}, nameMappingsForThisObject));

                result.AddRange(defaultColumnNames);
            }

            var properties = includesObjectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var propertyInfo in properties)
            {
                var value = propertyInfo.GetValue(includesObject);

                if (propertyInfo.PropertyType == typeof(bool) && (bool) value)
                {
                    result.Add(GetName(new []{schemaName,parentObjectName,propertyInfo.Name},nameMappingsForThisObject));
                }
                else
                {
                    if (propertyInfo.PropertyType.IsClass)
                    {
                        var columnsFromNestedInclude = GetColumnNames(value, propertyInfo.Name, schemaName,
                            defaultColumns, nameMappings);

                        result.AddRange(columnsFromNestedInclude);
                    }
                }
            }

            return result;
        }

        private string GetName(string[] pathNamess, Dictionary<string, string> nameMappings = null)
        {
            var result = string.Join("." ,pathNamess.Select(x=> GetName(x,nameMappings)));
            return result;
        }

        private string GetName(string name, Dictionary<string, string> nameMappings = null)
        {
            var result = name;

            if (nameMappings != null && nameMappings.TryGetValue(result, out var newName))
            {
                result = newName;
            }

            result = $"[{result}]";

            return result;
        }
    }
}
