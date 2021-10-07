using System.Threading.Tasks;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Customers.Application.Interfaces;

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

        protected override async Task<NoResult> HandleBody(UpdateCustomerCommand command)
        {
            var customer = await customerRepository.GetById(command.CustomerId);

            customer.CustomerChanged+=RegisterDomianEvent;

            customer.Update(
                command.Name,
                command.EmailAddress,
                command.PhoneNumber);

            return NoResult;
        }
    }
}
