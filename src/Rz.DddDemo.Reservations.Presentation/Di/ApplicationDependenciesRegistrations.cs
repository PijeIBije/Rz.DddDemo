using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;

namespace Rz.DddDemo.Reservations.Presentation.Di
{
    public static class ApplicationDependenciesRegistrations
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Base.Application.NoResult));

            services.AddSingleton<Transaction>();
            services.AddSingleton<ITransactionEvents>(x => x.GetService<Transaction>());

            return services;
        }
    }
}
