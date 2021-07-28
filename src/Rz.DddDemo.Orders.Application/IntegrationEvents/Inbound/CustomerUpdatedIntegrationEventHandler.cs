using System.Linq;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Orders.Application.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound
{
    public class CustomerUpdatedIntegrationEventHandler:IntegrationEventHandlerBase<CustomerUpdatedIntegrationEvent>
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerUpdatedIntegrationEventHandler(
            ICustomerRepository customerRepository,
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher, Transaction transaction) : base(domainEventsHandler,
            integrationEventsPublisher, transaction)
        {
            this.customerRepository = customerRepository;
        }

        protected override async Task<bool> HandleBody(CustomerUpdatedIntegrationEvent customerUpdatedIntegrationEvent)
        {
            var customerToUpdate = await customerRepository.TryGetById(customerUpdatedIntegrationEvent.CustomerId);

            if (customerToUpdate != null)
            {
                customerToUpdate.Update(
                    customerUpdatedIntegrationEvent.FirstName,
                    customerUpdatedIntegrationEvent.LastName,
                    customerUpdatedIntegrationEvent.Addresses);

                await customerRepository.Save(customerToUpdate);
            }
            else
            {
                var customer = new CustomerAggregate(
                    customerUpdatedIntegrationEvent.CustomerId,
                    customerUpdatedIntegrationEvent.FirstName,
                    customerUpdatedIntegrationEvent.LastName,
                    customerUpdatedIntegrationEvent.Addresses.ToList());

                await customerRepository.Save(customer);
            }

            return true;
        }
    }
}
