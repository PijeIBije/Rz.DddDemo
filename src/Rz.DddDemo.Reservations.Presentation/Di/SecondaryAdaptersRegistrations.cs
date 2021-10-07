using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;

namespace Rz.DddDemo.Reservations.Presentation.Di
{
    public static class SecondaryAdaptersRegistrations
    {
        public static IServiceCollection AddSecondaryAdapters(this IServiceCollection services)
        {
            //repositories
            services
                .AddSingleton<ICustomerRepository,
                    Infrastructure.CustomerRepository.MongoDb.CustomerRepository>();

            //outbound integraiton events
            services
                .AddSingleton<IIntegrationEventPublisher<CustomerUpdatedIntegrationEvent>,
                    CustomerUpdatedIntegrationEventPublisher>();

            services
                .AddSingleton<IPurchaseHistoryProviderA, Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA
                    .Mock.PurchaseHistoryProviderA>();

            services
                .AddSingleton<IPurchaseHistoryProviderB, Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderB
                    .Mock.PurchaseHistoryProviderB>();

            services
                .AddSingleton<IPurchaseHistoryProviderC, Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderC
                    .Mock.PurchaseHistoryProviderC>();

            services
                .AddSingleton<IPurchaseHistoryProvider, Infrastructure.PurchaseHistoryProvider.
                    AggregatePurchaseHistoryProvider.PurchaseHistoryProvider>();

            return services;
        }
    }
}
