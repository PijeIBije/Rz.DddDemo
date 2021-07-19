using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound
{
    public class CustomerCreatedIntegrationEventHandler:IntegrationEventHandlerBase<CustomerCreated>
    {
        private readonly ICustomerRepository customerRepository;

        protected override bool HandleBody(CustomerCreated customerUpdated)
        {
            var customer = new Customer(
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
