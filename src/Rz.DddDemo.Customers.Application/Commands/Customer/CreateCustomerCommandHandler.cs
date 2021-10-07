using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Customers.Application.Interfaces;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.CustomerDiscount;

namespace Rz.DddDemo.Customers.Application.Commands.Customer
{
    public class CreateCustomerCommandHandler : CommandHandlerBase<CreateCustomerCommand, CustomerId>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IPurchaseRepository purchaseRepository;
        private readonly ICustomerDiscountRepository customerDiscountRepository;
        private readonly IPurchaseHistoryProvider getLegacyPurchasesCommand;

        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IPurchaseRepository purchaseRepository,
            ICustomerDiscountRepository customerDiscountRepository,
            IPurchaseHistoryProvider getLegacyPurchasesCommand,
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction) : base(
            domainEventsHandler,
            integrationEventsPublisher,
            transaction)
        {
            this.customerRepository = customerRepository;
            this.purchaseRepository = purchaseRepository;
            this.customerDiscountRepository = customerDiscountRepository;
            this.getLegacyPurchasesCommand = getLegacyPurchasesCommand;
        }

        protected override async Task<CustomerId> HandleBody(CreateCustomerCommand command)
        {
            var customer = new CustomerAggregate(command.Name, command.EmailAddress, command.PhoneNumber,command.LegacyCustomerId);

            if (customer.LegacyCustomerId != null)
            {
                var purchaseHistory = (await getLegacyPurchasesCommand.GetPurchases(command.CustomerId, customer.LegacyCustomerId)).ToList();

                await purchaseRepository.Save(purchaseHistory);

                var customerDiscount = new CustomerDiscountAggregate(customer.Id, purchaseHistory.Sum(x=>x.TotalPrice));

                await customerDiscountRepository.Save(customerDiscount);
            }

            await customerRepository.Save(customer);

            var customerUpdatedIntegrationEvent = new CustomerUpdatedIntegrationEvent(customer);

            RegisterIntegrationEvent(customerUpdatedIntegrationEvent);

            return customer.Id;
        }
    }
}
