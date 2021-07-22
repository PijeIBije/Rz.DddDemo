using System.Linq;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound
{
    public class CustomerCreatedIntegrationEventHandler:IntegrationEventHandlerBase<CustomerCreatedIntegrationEvent>
    {
        private readonly ICustomerRepository customerRepository;

        protected override bool HandleBody(CustomerCreatedIntegrationEvent customerUpdated)
        {
            var customer = new CustomerAggregate(
                customerUpdated.CustomerId,
                customerUpdated.FirstName,
                customerUpdated.LastName,
                customerUpdated.Addresses.ToList());

            customerRepository.Save(customer);

            return true;
        }

        public CustomerCreatedIntegrationEventHandler(
            ICustomerRepository customerRepository,
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
            this.customerRepository = customerRepository;
        }
    }
}
