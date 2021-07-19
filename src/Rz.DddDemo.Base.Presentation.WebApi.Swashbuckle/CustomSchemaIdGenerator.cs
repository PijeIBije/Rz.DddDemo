using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rz.DddDemo.Base.Presentation.WebApi.Swashbuckle
{
    public static class CustomSchemaIdGenerator
    {
        public const string EnumSchemaPrefix = "Enum";

        public const string ErrorSchemaPrefix = "Errors";

        public const string ErrorTypeSuffix = "Error";
        public static string Generate(Type type)
        {
            var fullName = type.FullName;
            
            if (fullName == null) return type.Name;

            var fullNameSplit = fullName.Split('.');

            var name = fullNameSplit.Last();

            var nameSplit = name.Split('+');

            name = nameSplit.Last();

            if (name.EndsWith(ErrorTypeSuffix)) return $"{ErrorSchemaPrefix}.{name}";

            if(type.IsEnum) return $"{EnumSchemaPrefix}.{name}";

            return name;
        }
    }
}
