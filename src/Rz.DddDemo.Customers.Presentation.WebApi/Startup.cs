using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Presentation.WebApi.Controllers;
using Rz.DddDemo.Base.Presentation.WebApi.ModelBinding;
using Rz.DddDemo.Base.Presentation.WebApi.Swashbuckle;
using Rz.DddDemo.Base.Presentation.WebApi.Validation;

namespace Rz.DddDemo.Customers.Presentation.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(swaggerGenOptions =>
                {
                    swaggerGenOptions.SwaggerDoc("v1",
                        new OpenApiInfo {Title = "Rz.DddDemo.Customers", Version = "v1"});
                    swaggerGenOptions.OperationFilter<IncludesOperationFilter<CustomerIncludes, CustomerController>>();
                    swaggerGenOptions.CustomSchemaIds(CustomSchemaIdGenerator.Generate);
                    swaggerGenOptions.DocumentFilter<SortSchemasDocumentFilter>();
                    swaggerGenOptions.UseInlineDefinitionsForEnums();
                    swaggerGenOptions.DescribeAllParametersInCamelCase();
                })
                .AddControllers(
                    config => { config.ModelBinderProviders.Insert(0, new StringEnumerableModelBinderProvider()); })
                .AddCustomInvalidModelStateRespone()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(swaggerOptions =>
                    app.UseSwaggerUI(swaggerUiOptions => swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Rz.DddDemo.Customers.Presentation.WebApi v1")));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
