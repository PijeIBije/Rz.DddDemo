using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound.Interfaces;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Outbound;

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

        protected override bool HandleBody(CustomerUpdatedIntegrationEvent customerUpdated)
        {
            var customerToUpdate = customerRepository.TryGetById(customerUpdated.CustomerId);

            if (customerToUpdate != null)
            {
                customerToUpdate.Update(customerUpdated.FirstName,customerUpdated.LastName);

                foreach (var address in customerUpdated.Addresses)
                {
                    customerToUpdate.AddOrUpdateAddress(address);
                }

                foreach (var addressName in customerUpdated.AddressesRemoved)
                {
                    customerToUpdate.RemoveAddress(addressName);
                }

                customerRepository.Save(customerToUpdate);
            }
            else
            {
                RegisterIntegrationEvent(new CustomerDataRequestedIntegrationEvent(customerUpdated.CustomerId));
            }

            return true;
        }
    }
}
