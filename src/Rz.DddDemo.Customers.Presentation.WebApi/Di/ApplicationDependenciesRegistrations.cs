using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;
using Rz.DddDemo.Customers.Application.DomainEvents.Customer;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Di
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
