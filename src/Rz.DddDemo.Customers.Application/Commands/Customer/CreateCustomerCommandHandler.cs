using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Customers.Application.Commands.Interfaces;
using Rz.DddDemo.Customers.Application.IntegrationEvents;
using Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.ValueObjects;

namespace Rz.DddDemo.Customers.Application.Commands.Customer
{
    public class CreateCustomerCommandHandler : CommandHandlerBase<CreateCustomerCommand, CustomerId>
    {
        private readonly ICustomerRepository customerRepository;

        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction) : base(
            domainEventsHandler,
            integrationEventsPublisher,
            transaction)
        {
            this.customerRepository = customerRepository;
        }

        protected override async Task<CustomerId> HandleBody(CreateCustomerCommand command)
        {
            var addreses = command.Addresses.Select(x => new Address(
                x.Name,
                x.AddressLine1,
                x.AddressLine2,
                x.City,
                x.PhoneNumber,
                x.EmailAddress,
                x.Country));

            var customer = new Domain.CustomerAggregate.Customer(command.FirstName, command.LastName, command.DateOfBirth,
                addreses.ToList());

            await customerRepository.Save(customer);

            var customerCreated = new CustomerCreated(customer);

            RegisterIntegrationEvent(customerCreated);

            return customer.Id;
        }
    }
}
