using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Rz.DddDemo.Base.Infrastructure.Dapper
{
    public static class SqlQueryFormatter
    {
        public const char ParameterPrefix = '@';

        public static string GetParameterName(string parameterName)=> $"{ParameterPrefix}{parameterName}";

        public static string GetName(params string[] path) => string.Join(".", path.Select(x => $"[{x}]"));

        public static string GetNames(string[] rootPath, params string[] names)
        {
            var rootPathString = GetName(rootPath);

            var result =string.Join(",", names.Select(x => $"{rootPath}.{GetName(x)}"));

            return result;
        }

        public static string SetInlineParams(string queryString, object inlineParameters)
        {
            foreach (var inlineParamterPropertyInfo in inlineParameters.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance))
            {
                var value = inlineParamterPropertyInfo.GetValue(inlineParameters).ToString();

                var name = GetParameterName(inlineParamterPropertyInfo.Name);

                queryString=queryString.Replace(name, value);
            }

            return queryString;
        }

        public static string GenerateUpsertClause(
            string tableName, 
            string schemaName,
            IEnumerable<string> columnNamesForInsert, 
            IEnumerable<string> columnNamesForUpdate, 
            string idColumnName,
            string idParameterName = null)
        {
            return GenerateUpsertClause(
                tableName,
                schemaName,
                columnNamesForInsert.ToDictionary(x => x, x => x),
                columnNamesForUpdate.ToDictionary(x => x, x => x),
                idColumnName,
                idParameterName);
        }

        public static string GenerateUpsertClause(
            string tableName,
            string schemaName,
            IDictionary<string,string> columnAndParameterNamesForInsert,
            IDictionary<string,string> columnAndParameterNamesForUpdate,
            string idColumnName,
            string idParameterName = null)
        {
            return GenerateUpdateClause(tableName, schemaName, columnAndParameterNamesForUpdate, idColumnName,
                       idParameterName) +
                   " IF @@ROWCOUNT = 0" +
                   "BEING " +
                   GenerateInsertClause(tableName, schemaName, columnAndParameterNamesForInsert) +
                   "END";
        }

        public static string GenerateInsertClause(
            string tableName,
            string schemaName,
            IDictionary<string, string> columnAndParameterNames)
        {
            var columnList =
                $"({string.Join(", ", columnAndParameterNames.Keys.Select(x => GetName(schemaName, tableName, x)))}";

            var valuesClause =
                $"VALUES({string.Join(", ", columnAndParameterNames.Values.Select(GetParameterName))})";

            return $"INSERT INTO {GetName(schemaName, tableName)} {columnList} {valuesClause}";
        }

        public static string GenerateInsertClause(
            string tableName,
            string schemaName,
            IEnumerable<string> columnNamesForInsert)
        {
            return GenerateInsertClause(
                tableName,
                schemaName,
                columnNamesForInsert.ToDictionary(x => x, x => x));
        }

        public static string GenerateUpdateClause(string tableName,
            string schemaName,
            IDictionary<string, string> columnAndParameterNamesForUpdate,
            string idColumnName = null, string idParameterName = null)
        {
            var setValueClasues = new List<string>();

            foreach (var columnName in columnAndParameterNamesForUpdate.Keys)
            {
                var parameterName = columnAndParameterNamesForUpdate[columnName];

                setValueClasues.Add($"{GetName(schemaName,tableName,columnName)} = {GetParameterName(parameterName)}");
            }

            var whereClause = string.IsNullOrWhiteSpace(idColumnName)
                ? string.Empty
                : $"WHERE {GetName(schemaName, tableName, idColumnName)} = {GetParameterName(string.IsNullOrWhiteSpace(idParameterName)?idColumnName:idParameterName)}";

            var result =
                $"UPDATE {GetName(schemaName, tableName)} WITH (UPDLOCK, SERIALIZABLE) SET {string.Join(", ", setValueClasues)} {whereClause}";

            return result;
        }

        public static string GenerateUpdateClause(string tableName,
            string schemaName,
            IEnumerable<string> columnNames,
            string idColumnName = null, string idParameterName = null)
        {
            return GenerateUpdateClause(
                tableName,
                schemaName,
                columnNames.ToDictionary(x => x, x => x),
                idColumnName, idParameterName);
        }

    }
}
