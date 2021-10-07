using Microsoft.Extensions.DependencyInjection;

namespace Rz.DddDemo.Reservations.Presentation.Di
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
