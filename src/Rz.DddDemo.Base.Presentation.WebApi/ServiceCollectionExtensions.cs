using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rz.DddDemo.Base.Presentation.WebApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureWithoutIOptions<TOptions>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TOptions : class, new()
        {
            var options = configuration.Get<TOptions>();

            services.AddSingleton(options);

            return services;
        }
    }
}
