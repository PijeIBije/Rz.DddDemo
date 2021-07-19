using System;
using System.Collections.Generic;
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

namespace Rz.DddDemo.Customers.Application.Commands.Customer
{
    public class UpdateCustomerCommandHandler:CommandHandlerBase<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public UpdateCustomerCommandHandler(
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

        protected override async Task HandleBody(UpdateCustomerCommand command)
        {
            var customer = await customerRepository.GetById(command.CustomerId);

            customer.Update(command.FirstName,command.LastName,command.DateOfBirth);

            foreach (var addressData in command.AddressesToAddOrUpdate)
            {
                customer.AddOrUpdateAddress(
                    addressData.Name,
                    addressData.AddressLine1,
                    addressData.AddressLine2,
                    addressData.City,
                    addressData.PhoneNumber,
                    addressData.EmailAddress,
                    addressData.Country);
            }

            foreach (var addressName in command.AddresesToRemove)
            {
                customer.RemoveAddress(addressName);
            }

            await customerRepository.Save(customer);

            var customerUpdated = new CustomerUpdated(customer,command.AddresesToRemove);

            RegisterIntegrationEvent(customerUpdated);
        }
    }
}
