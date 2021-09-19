using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Customers.Application.DomainEvents.Customer;
using Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Customers.Domain.DomainEvents;
using Rz.DddDemo.Customers.Infrastructure.IntegrationEventPublishers.RabbitMq;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Di
{
    public static class SecondaryAdaptersRegistrations
    {
        public static IServiceCollection AddSecondaryAdapters(this IServiceCollection services)
        {
            //repositories
            services
                .AddSingleton<Application.Commands.Interfaces.ICustomerRepository,
                    Infrastructure.CustomerRepository.MongoDb.CustomerRepository>();

            services
                .AddSingleton<Application.Queries.Interfaces.ICustomerRepository,
                    Infrastructure.CustomerRepository.MongoDb.CustomerRepository>();

            //outbound integraiton events
            services
                .AddSingleton<IIntegrationEventPublisher<CustomerUpdatedIntegrationEvent>,
                    CustomerUpdatedIntegrationEventPublisher>();

            return services;
        }
    }
}
