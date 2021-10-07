using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Customers.Application.DomainEvents.Customer;
using Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Customers.Application.Interfaces;
using Rz.DddDemo.Customers.Infrastructure.IntegrationEventPublishers.RabbitMq;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderB;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderC;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Di
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
