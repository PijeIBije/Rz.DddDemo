using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Rz.DddDemo.Base.Presentation.WebApi.Swashbuckle
{
    public class SortSchemasDocumentFilter:IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var schemas = swaggerDoc.Components.Schemas;

            var enumSchemas = schemas.Where(x => x.Key.StartsWith(CustomSchemaIdGenerator.EnumSchemaPrefix))
                .OrderBy(x => x.Key).ToList();

            var errorSchemas = schemas.Where(x => x.Key.StartsWith(CustomSchemaIdGenerator.ErrorTypeSuffix))
                .OrderBy(x => x.Key).ToList();

            var remainingSchemas = schemas.Except(errorSchemas).OrderBy(x => x.Key).ToList();

            schemas = remainingSchemas.Union(enumSchemas).Union(errorSchemas).ToDictionary(x => x.Key, x => x.Value);

            swaggerDoc.Components.Schemas = schemas;
        }
    }
}
