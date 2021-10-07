using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.QueryHandling.Intefaces;
using Rz.DddDemo.Customers.Application.Commands.Customer;
using Rz.DddDemo.Customers.Application.DomainEvents.Customer;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Di
{
    public static class PrimaryAdaptersRegistrations
    {
        public static IServiceCollection AddPrimaryAdapters(this IServiceCollection services)
        {
            /*
            //commands
            services.AddSingleton<ICommandHandler<CreateCustomerCommand, CustomerId>, CreateCustomerCommandHandler>();
            services.AddSingleton<ICommandHandler<UpdateCustomerCommand>, UpdateCustomerCommandHandler>();

            //queries
            services.AddSingleton <IQueryHandler<CustomerQuery,IEnumerable<CustomerResult>>, CustomerQueryHandler>();

            //domain events
            services
                .AddSingleton<IDomainEventHandler<CustomerChangedDomainEvent>, CustomerChangedDomainEventHandler>();

            //inbound integration events*/

            return services;
        }
    }
}
