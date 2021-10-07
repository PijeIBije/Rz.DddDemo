using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Presentation.WebApi.IncludesMapping;
using Rz.DddDemo.Base.Presentation.WebApi.Validation;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping.Interfaces;

namespace Rz.DddDemo.Reservations.Presentation.Di
{
    public static class WebApiExtensionsRegistrations
    {
        public static IServiceCollection AddWebApiExtensions(this IServiceCollection services)
        {
            services.AddSingleton<IncludesMapper>();
            services.AddSingleton<IExceptionMapper, ExceptionMapper>();
            services.AddSingleton<IExceptionMapping, DefaultExceptionMapping>();
            services.AddSingleton<ValidationErrorsDictionary>();

            return services;
        }
    }
}
